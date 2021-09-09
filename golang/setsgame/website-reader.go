package setsgame

import (
	"path/filepath"
	"strconv"
	"strings"

	"golang.org/x/net/html"
)

var cardMap = make(map[int]Card)

func init() {
	id := 1

	for _, fill := range []Fill{Solid, Lines, Empty} {
		for _, shape := range []Shape{Squiggle, Diamond, Oval} {
			for _, color := range []Color{Red, Purple, Green} {
				for _, size := range []Size{Single, Double, Triple} {
					cardMap[id] = Card{color, shape, fill, size}
					id++
				}
			}
		}
	}
}

func CardById(id int) Card {
	return cardMap[id]
}

func ParseCards(html string) []Card {
	cardImages := getAllByTypeAndName(html, "img", "card")
	cards := make([]Card, 0)

	for _, img := range cardImages {
		for _, a := range img.Attr {
			if a.Key == "src" {
				fileName := filepath.Base(a.Val)
				idStr := fileName[:len(fileName)-len(filepath.Ext(fileName))]
				id, _ := strconv.Atoi(idStr)
				cards = append(cards, CardById(id))
				break
			}
		}
	}

	return cards
}

func getAllByTypeAndName(src string, nodeType string, startsWith string) []html.Node {
	doc, _ := html.Parse(strings.NewReader(src))
	result := make([]html.Node, 0)
	var crawl func(node *html.Node)
	crawl = func(node *html.Node) {
		if node.Type == html.ElementNode && node.Data == nodeType {
			for _, attr := range node.Attr {
				if attr.Key == "name" && strings.HasPrefix(attr.Val, startsWith) {
					result = append(result, *node)
					break
				}
			}
		}

		for child := node.FirstChild; child != nil; child = child.NextSibling {
			crawl(child)
		}
	}

	crawl(doc)
	return result
}
