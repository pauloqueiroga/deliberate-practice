package main

import (
	"encoding/csv"
	"encoding/xml"
	"errors"
	"io"
	"log"
	"os"
	"sort"
	"strconv"
	"strings"
)

const (
	hSpacing = 80
	vSpacing = 40
)

var (
	maxX = 0
)

func main() {
	if len(os.Args) < 3 {
		log.Fatal("Usage: stagetree <path/to/input-file.csv> <path/to/output-file.drawio")
	}

	events, err := readEvents(os.Args[1])
	if err != nil {
		log.Fatal(err)
	}

	tree, err := makeTree(events)
	if err != nil {
		log.Fatal(err)
	}

	weighTree(tree)

	if err = plotTree(tree, os.Args[2], 10); err != nil {
		log.Fatal(err)
	}
}

func readEvents(filePath string) (map[string]event, error) {
	result := make(map[string]event)
	inputFile, err := os.Open(filePath)
	if err != nil {
		return result, err
	}
	defer inputFile.Close()

	reader := csv.NewReader(inputFile)
	reader.FieldsPerRecord = 9
	// discard the header row
	_, err = reader.Read()
	if err == io.EOF {
		return result, nil
	}
	if err != nil {
		return result, err
	}

	for {
		row, err := reader.Read()

		if err == io.EOF {
			break
		}
		if err != nil {
			return result, err
		}

		e := event{
			source1:  row[3],
			source2:  row[4],
			source3:  row[5],
			outcome:  row[8], // skipping row[7] (duration) for now
			treeNode: newNode(row[0], row[1], row[6]),
		}
		result[row[0]] = e

		if _, ok := result[e.outcome]; !ok && e.outcome != "" {
			result[e.outcome] = event{
				treeNode: newNode(e.outcome, "outcome: "+e.outcome, "outcome"),
			}
		}
	}

	return result, nil
}

func makeTree(events map[string]event) (*node, error) {
	var root *node = nil

	for id, event := range events {
		if id == "0" {
			root = event.treeNode
		}

		if event.source1 != "" {
			if source, ok := events[event.source1]; ok {
				source.treeNode.addChild(event.treeNode)
			} else {
				return root, errors.New("Source not found " + event.source1)
			}
		}

		if event.source2 != "" {
			if source, ok := events[event.source2]; ok {
				source.treeNode.addChild(event.treeNode)
			} else {
				return root, errors.New("Source not found " + event.source2)
			}
		}

		if event.source3 != "" {
			if source, ok := events[event.source3]; ok {
				source.treeNode.addChild(event.treeNode)
			} else {
				return root, errors.New("Source not found " + event.source3)
			}
		}

		if event.outcome != "" {
			if target, ok := events[event.outcome]; ok {
				event.treeNode.addChild(target.treeNode)
			} else {
				return root, errors.New("Outcome not found " + event.outcome)
			}
		}
	}

	return root, nil
}

func newNode(id, company, phase string) *node {
	return &node{
		id:      id,
		company: company,
		phase:   phase,
		nodes:   make([]*node, 0),
		visited: false,
	}
}

func (root *node) addChild(child *node) {
	root.nodes = append(root.nodes, child)
}

func weighTree(root *node) (string, int) {
	if root == nil {
		return "", 0
	}

	weight := 1

	for _, n := range root.nodes {
		o, w := weighTree(n)
		weight += w

		if root.outcome == "" {
			root.outcome = o
		}
	}

	if root.phase == "outcome" {
		root.outcome = root.company
	}

	root.weight = weight
	sort.Slice(root.nodes, func(i, j int) bool {
		if root.nodes[i].outcome < root.nodes[j].outcome {
			return true
		}

		if root.nodes[i].outcome > root.nodes[j].outcome {
			return false
		}

		if root.nodes[i].company < root.nodes[j].company {
			return true
		}

		if root.nodes[i].company > root.nodes[j].company {
			return false
		}

		return root.nodes[i].weight < root.nodes[j].weight
	})

	return root.outcome, weight
}

func plotTree(root *node, filePath string, spacing int) error {
	outputFile, err := os.Create(filePath)
	if err != nil {
		return err
	}
	defer outputFile.Close()

	graph := newGraph()
	addNodes(root, &graph, 10, 10, "")
	rearrangeOutcomes(&graph, maxX+hSpacing)
	encoder := xml.NewEncoder(outputFile)
	encoder.Indent("", "\t")
	encoder.Encode(graph)

	return nil
}

func addNodes(root *node, graph *graphModel, x, y int, parent string) (int, int) {
	if root == nil {
		return x, y
	}

	if root.visited {
		return x, y
	}

	root.visited = true
	value := root.company

	if value == parent {
		value = ""
	}

	if x > maxX {
		maxX = x
	}

	shape := cell{
		ID:       root.id,
		ParentID: "layer1",
		Value:    value,
		Style:    eventNodeStyle(),
		Vertex:   "1",
		Geometry: &geometry{
			X:      strconv.Itoa(x),
			Y:      strconv.Itoa(y),
			Width:  "10",
			Height: "10",
			As:     "geometry",
		}}
	graph.Root.Cells = append(graph.Root.Cells, shape)

	x += hSpacing

	for i, n := range root.nodes {
		if i > 0 {
			y += vSpacing
		}
		_, y = addNodes(n, graph, x, y, root.company)
		addLink(graph, root.id, n.id)
	}

	return x, y
}

func addLink(graph *graphModel, sourceId, targetId string) {
	if sourceId == "" || targetId == "" {
		return
	}

	link := cell{
		ID:       sourceId + "-" + targetId,
		ParentID: "layer1",
		Style:    linkStyle(),
		Edge:     "1",
		SourceID: sourceId,
		TargetID: targetId,
		Geometry: &geometry{
			Relative: "1",
			As:       "geometry",
		},
	}
	graph.Root.Cells = append(graph.Root.Cells, link)
}

func rearrangeOutcomes(graph *graphModel, newX int) {
	for _, n := range graph.Root.Cells {
		if strings.HasPrefix(n.Value, "outcome") {
			n.Geometry.X = strconv.Itoa(newX)
		}
	}
}
