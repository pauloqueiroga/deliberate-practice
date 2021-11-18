package main

import (
	"encoding/csv"
	"encoding/xml"
	"errors"
	"io"
	"log"
	"os"
	"sort"
)

var maxDepth = make(map[string]int)

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

	weighTree(tree, "", 0)

	graph := newGraph()

	if err = plotStages(&graph, maxDepth); err != nil {
		log.Fatal(err)
	}

	if err = plotTree(&graph, tree); err != nil {
		log.Fatal(err)
	}

	outputFile, err := os.Create(os.Args[2])
	if err != nil {
		log.Fatal(err)
	}
	defer outputFile.Close()

	encoder := xml.NewEncoder(outputFile)
	encoder.Indent("", "\t")
	if err := encoder.Encode(graph); err != nil {
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

		if e.outcome != "" {
			oid := row[0] + e.outcome
			o := event{
				source1:  row[0],
				treeNode: newNode(oid, "outcome: "+e.outcome, "outcome"),
			}
			result[oid] = o
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
	}

	return root, nil
}

func newNode(id, company, stage string) *node {
	return &node{
		id:      id,
		company: company,
		stage:   stage,
		nodes:   make([]*node, 0),
		visited: false,
	}
}

func (root *node) addChild(child *node) {
	root.nodes = append(root.nodes, child)
}

func weighTree(root *node, currentStage string, stageDepth int) (string, int) {
	if root == nil {
		return "", 0
	}

	weight := 1

	if currentStage == root.stage {
		stageDepth++
	} else {
		stageDepth = 1
	}

	if maxDepth[root.stage] < stageDepth {
		maxDepth[root.stage] = stageDepth
	}

	for _, n := range root.nodes {
		o, w := weighTree(n, root.stage, stageDepth)
		weight += w

		if root.outcome == "" {
			root.outcome = o
		}
	}

	if root.stage == "outcome" {
		root.outcome = root.company
	}

	root.weight = weight
	sort.Slice(root.nodes, func(i, j int) bool {
		if root.nodes[i].company < root.nodes[j].company {
			return true
		}

		if root.nodes[i].company > root.nodes[j].company {
			return false
		}

		if root.nodes[i].weight > root.nodes[j].weight {
			return true
		}

		if root.nodes[i].weight < root.nodes[j].weight {
			return false
		}

		return root.nodes[i].outcome < root.nodes[j].outcome
	})

	return root.outcome, weight
}
