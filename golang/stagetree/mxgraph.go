package main

import (
	"encoding/xml"
)

type graphModel struct {
	XMLName xml.Name  `xml:"mxGraphModel"`
	Dx      string    `xml:"dx,attr"`
	Dy      string    `xml:"dy,attr"`
	Arrows  string    `xml:"arrows,attr,omitempty"`
	Root    modelRoot `xml:"root"`
}

type modelRoot struct {
	XMLName xml.Name `xml:"root"`
	Cells   []cell
}

type cell struct {
	XMLName  xml.Name `xml:"mxCell"`
	ID       string   `xml:"id,attr"`
	Value    string   `xml:"value,attr,omitempty"`
	Style    style    `xml:"style,attr,omitempty"`
	ParentID string   `xml:"parent,attr,omitempty"`
	Vertex   string   `xml:"vertex,attr,omitempty"`
	Edge     string   `xml:"edge,attr,omitempty"`
	SourceID string   `xml:"source,attr,omitempty"`
	TargetID string   `xml:"target,attr,omitempty"`
	Geometry *geometry
}

type geometry struct {
	XMLName  xml.Name `xml:"mxGeometry"`
	X        string   `xml:"x,attr,omitempty"`
	Y        string   `xml:"y,attr,omitempty"`
	Width    string   `xml:"width,attr,omitempty"`
	Height   string   `xml:"height,attr,omitempty"`
	Relative string   `xml:"relative,attr,omitempty"`
	As       string   `xml:"as,attr"`
}

type style struct {
	Attributes map[string]string
}

func (a style) MarshalXMLAttr(name xml.Name) (xml.Attr, error) {
	var text string

	for k, v := range a.Attributes {
		text += k

		if v != "" {
			text += "="
			text += v
		}

		text += ";"
	}

	return xml.Attr{Name: xml.Name{Local: "style"}, Value: text}, nil
}

func newGraph() graphModel {
	return graphModel{
		Dx: "640",
		Dy: "480",
		Root: modelRoot{
			Cells: []cell{
				{ID: "root"},
				{
					ID:       "layer1",
					ParentID: "root",
				},
			},
		},
	}
}
