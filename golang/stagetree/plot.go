package main

import (
	"sort"
	"strconv"
)

const (
	hSpacing = 80
	vSpacing = 40
)

var (
	stageColors  map[string]map[string]string = make(map[string]map[string]string)
	stageOffsets map[string]int               = make(map[string]int)
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

func eventNodeStyle(stage string) style {
	s := style{
		Attributes: map[string]string{
			"ellipse":               "",
			"aspect":                "fixed",
			"html":                  "1",
			"labelPosition":         "center",
			"verticalLabelPosition": "bottom",
			"align":                 "center",
			"verticalAlign":         "top",
			"fontColor":             "#000000",
		},
	}

	if _, ok := stageColors[stage]; !ok {
		stageColors[stage] = getColorStyle(len(stageColors))
	}

	for k, v := range stageColors[stage] {
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

func stageHeaderStyle(stage string) style {
	s := style{
		Attributes: map[string]string{
			"html":       "1",
			"whiteSpace": "wrap",
			"fontColor":  "#ffffff",
		},
	}

	if _, ok := stageColors[stage]; !ok {
		stageColors[stage] = getColorStyle(len(stageColors))
	}

	for k, v := range stageColors[stage] {
		s.Attributes[k] = v
	}

	return s
}

func plotStages(graph *graphModel, stageDepths map[string]int) error {
	keys := make([]string, 0, len(stageDepths))
	for k := range stageDepths {
		keys = append(keys, k)
	}
	sort.Strings(keys)

	offset := 0

	for _, k := range keys {
		stageOffsets[k] = offset + hSpacing/2 - 5
		width := hSpacing * stageDepths[k]
		shape := cell{
			ID:       k,
			Value:    k,
			Style:    stageHeaderStyle(k),
			ParentID: "layer1",
			Vertex:   "1",
			Geometry: &geometry{
				X:      strconv.Itoa(offset),
				Y:      "0",
				Height: strconv.Itoa(vSpacing),
				Width:  strconv.Itoa(width),
				As:     "geometry",
			},
		}
		graph.Root.Cells = append(graph.Root.Cells, shape)

		offset += width
	}
	return nil
}

func plotTree(graph *graphModel, root *node) error {
	addNodes(root, graph, hSpacing/2-5, vSpacing+5, "")
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

	if x < stageOffsets[root.stage] {
		x = stageOffsets[root.stage]
	}

	shape := cell{
		ID:       root.id,
		ParentID: "layer1",
		Value:    value,
		Style:    eventNodeStyle(root.stage),
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
