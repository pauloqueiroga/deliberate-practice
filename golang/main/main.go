package main

import (
	"fmt"
	"pauloqueiroga/setsgame"
)

func main() {
	board := setsgame.RandomBoard()
	fmt.Println(board)
	fmt.Println("===============")
	sets := setsgame.BruteForceSolve(board)
	fmt.Println(sets)
}
