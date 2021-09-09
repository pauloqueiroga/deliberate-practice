package setsgame

import (
	"math/rand"
	"time"
)

func init() {
	rand.Seed(time.Now().UnixNano())
}

type Board struct {
	Cards []Card
}

func RandomBoard() *Board {
	distinctCards := make(map[Card]bool)

	for len(distinctCards) < 12 {
		distinctCards[RandomCard()] = true
	}

	cards := make([]Card, 0)

	for card := range distinctCards {
		cards = append(cards, card)
	}

	return NewBoard(cards)
}

func NewBoard(c []Card) *Board {
	return &Board{Cards: c}
}

type Card struct {
	Color Color
	Shape Shape
	Fill  Fill
	Size  Size
}

func RandomCard() Card {
	return Card{
		Color: Color(rand.Intn(int(colorCount))),
		Shape: Shape(rand.Intn(int(shapeCount))),
		Fill:  Fill(rand.Intn(int(fillCount))),
		Size:  Size(rand.Intn(int(sizeCount))),
	}
}

// func (c1 Card) Equals(c2 Card) bool {
// 	return c1.Color == c2.Color && c1.Shape == c2.Shape && c1.Fill == c2.Fill && c1.Size == c2.Size
// }
