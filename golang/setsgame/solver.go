package setsgame

func IsSet(cards []Card) bool {
	distinctColors := make(map[Color]bool)
	distinctShapes := make(map[Shape]bool)
	distinctFills := make(map[Fill]bool)
	distinctSizes := make(map[Size]bool)

	for _, card := range cards {
		distinctColors[card.Color] = true
		distinctShapes[card.Shape] = true
		distinctFills[card.Fill] = true
		distinctSizes[card.Size] = true
	}

	colorCount := len(distinctColors)
	shapeCount := len(distinctShapes)
	fillCount := len(distinctFills)
	sizeCount := len(distinctSizes)

	return ((colorCount == 3 || colorCount == 1) &&
		(shapeCount == 3 || shapeCount == 1) &&
		(fillCount == 3 || fillCount == 1) &&
		(sizeCount == 3 || sizeCount == 1))
}

func BruteForceSolve(board *Board) [][]Card {
	result := make([][]Card, 0, 6)
	i := 0

	for _, card1 := range board.Cards {
		i++
		j := i

		for _, card2 := range board.Cards[i:] {
			j++

			for _, card3 := range board.Cards[j:] {
				set := []Card{card1, card2, card3}

				if IsSet(set) {
					result = append(result, set)
				}
			}
		}
	}

	return result
}
