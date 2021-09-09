package setsgame

import (
	"testing"
)

func TestCardsWithSamePropertiesShouldBeEqual(t *testing.T) {
	var target1 = Card{Color: Green, Shape: Diamond, Fill: Empty, Size: Double}
	var target2 = Card{Color: Green, Shape: Diamond, Fill: Empty, Size: Double}

	if target1 != target2 {
		t.Error()
	}
}

func TestCardsWithDifferentColorsShouldNotBeEqual(t *testing.T) {
	var target1 = Card{Color: Purple, Shape: Diamond, Fill: Empty, Size: Double}
	var target2 = Card{Color: Green, Shape: Diamond, Fill: Empty, Size: Double}

	if target1 == target2 {
		t.Error()
	}
}

func TestCardsWithDifferentShapesShouldNotBeEqual(t *testing.T) {
	var target1 = Card{Color: Green, Shape: Squiggle, Fill: Empty, Size: Double}
	var target2 = Card{Color: Green, Shape: Diamond, Fill: Empty, Size: Double}

	if target1 == target2 {
		t.Error()
	}
}

func TestCardsWithDifferentFillsShouldNotBeEqual(t *testing.T) {
	var target1 = Card{Color: Red, Shape: Diamond, Fill: Lines, Size: Double}
	var target2 = Card{Color: Red, Shape: Diamond, Fill: Solid, Size: Double}

	if target1 == target2 {
		t.Error()
	}
}

func TestCardsWithDifferentSizesShouldNotBeEqual(t *testing.T) {
	var target1 = Card{Color: Purple, Shape: Diamond, Fill: Empty, Size: Double}
	var target2 = Card{Color: Purple, Shape: Diamond, Fill: Empty, Size: Single}

	if target1 == target2 {
		t.Error()
	}
}

func TestMapsShouldNotTakeDuplicateCards(t *testing.T) {
	hash := make(map[Card]bool)
	hash[Card{Green, Squiggle, Solid, Triple}] = true
	hash[Card{Green, Squiggle, Solid, Triple}] = true

	if len(hash) > 1 {
		t.Error()
	}
}

func TestRandomCardShouldRandomizeDecently(t *testing.T) {
	targets := make(map[Card]bool)

	for i := 0; i < 100; i++ {
		targets[RandomCard()] = true
	}

	if len(targets) < 50 {
		t.Error()
	}
}

func TestRandomBoardShouldGetRandomDistinctCards(t *testing.T) {
	target := RandomBoard()
	cards := make(map[Card]bool)

	for _, card := range target.Cards {
		cards[card] = true
	}

	if len(cards) < len(target.Cards) {
		t.Error()
	}
}
