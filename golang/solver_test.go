package setsgame

import (
	"testing"
)

func TestIsSetReturnsTrueForAllDifferentCards(t *testing.T) {
	target := []Card{
		{Purple, Oval, Solid, Single},
		{Green, Squiggle, Empty, Double},
		{Red, Diamond, Lines, Triple},
	}

	if !IsSet(target) {
		t.Error()
	}
}

func TestIsSetReturnsTrueForAllEqualCards(t *testing.T) {
	target := []Card{
		{Red, Diamond, Lines, Triple},
		{Red, Diamond, Lines, Triple},
		{Red, Diamond, Lines, Triple},
	}

	if !IsSet(target) {
		t.Error()
	}
}

func TestIsSetReturnsTrueForCardsDifferentOnlyInColor(t *testing.T) {
	target := []Card{
		{Red, Diamond, Lines, Triple},
		{Green, Diamond, Lines, Triple},
		{Purple, Diamond, Lines, Triple},
	}

	if !IsSet(target) {
		t.Error()
	}
}

func TestIsSetReturnsFalseForCardsInTwoDifferentColors(t *testing.T) {
	target := []Card{
		{Red, Diamond, Lines, Single},
		{Green, Diamond, Lines, Double},
		{Red, Diamond, Lines, Triple},
	}

	if IsSet(target) {
		t.Error()
	}
}

func TestBruteForceSolveShouldFindSixSets(t *testing.T) {
	cards := []Card{
		{Green, Diamond, Empty, Triple},
		{Purple, Squiggle, Empty, Single},
		{Red, Diamond, Lines, Double},
		{Purple, Diamond, Solid, Single},
		{Green, Squiggle, Empty, Triple},
		{Red, Squiggle, Lines, Single},
		{Green, Oval, Lines, Double},
		{Red, Squiggle, Empty, Triple},
		{Green, Squiggle, Solid, Single},
		{Red, Diamond, Solid, Double},
		{Green, Squiggle, Empty, Double},
		{Purple, Squiggle, Solid, Triple},
	}
	board := Board{cards}
	solution := BruteForceSolve(&board)

	if len(solution) != 6 {
		t.Errorf("Expected 6 sets, found %d", len(solution))
	}

	for _, set := range solution {
		if len(set) != 3 {
			t.Errorf("Expected 3 cards per set, found %d", len(set))
		}
	}
}
