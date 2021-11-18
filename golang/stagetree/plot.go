package main

import (
	"encoding/xml"
	"os"
	"strconv"
	"strings"
)

func getColorStyle(index int) map[string]string {
	var styleColors = []map[string]string{
		{"strokeColor": "#2D7600", "fillColor": "#60A917"},
		{"strokeColor": "#001DBC", "fillColor": "#0050ef"},
		{"strokeColor": "#A50040", "fillColor": "#d80073"},
		{"strokeColor": "#3700CC", "fillColor": "#6a00ff"},
		{"strokeColor": "#6F0000", "fillColor": "#a20025"},
		{"strokeColor": "#006EAF", "fillColor": "#1ba1e2"},
		{"strokeColor": "#005700", "fillColor": "#008a00"},
		{"strokeColor": "#BD7000", "fillColor": "#f0a30a"},
		{"strokeColor": "#3A5431", "fillColor": "#6d8764"},
		{"strokeColor": "#36393d", "fillColor": "#ffff88"},
	}
	return styleColors[index%len(styleColors)]
}

var phases map[string]int = make(map[string]int)

func eventNodeStyle(phase string) style {
	s := style{
		Attributes: map[string]string{
			"ellipse":               "",
			"aspect":                "fixed",
			"html":                  "1",
			"labelPosition":         "center",
			"verticalLabelPosition": "bottom",
			"align":                 "center",
			"verticalAlign":         "top",
		},
	}

	if _, ok := phases[phase]; !ok {
		phases[phase] = len(phases)
	}

	for k, v := range getColorStyle(phases[phase]) {
		s.Attributes[k] = v
	}

	return s
}

func linkStyle() style {
	return style{
		Attributes: map[string]string{
			"edgeStyle":      "entityRelationEdgeStyle",
			"orthogonalLoop": "1",
			"jettySize":      "auto",
			"html":           "1",
			"strokeWidth":    "1",
		},
	}
}

func plotTree(root *node, filePath string, spacing int) error {
	outputFile, err := os.Create(filePath)
	if err != nil {
		return err
	}
	defer outputFile.Close()

	graph := newGraph()
	addNodes(root, &graph, 10, 10, "")
	rearrangeOutcomes(&graph, maxX)
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
		Style:    eventNodeStyle(root.phase),
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
