package main

import (
	"fmt"
	"io/ioutil"
	"net/http"

	sg "pauloqueiroga/setsgame"
)

func main() {
	fmt.Println("Fetching today's puzzle...")
	resp, err := http.Get("https://www.setgame.com/set/puzzle")

	if err != nil {
		panic(err)
	}

	defer resp.Body.Close()

	if resp.StatusCode == http.StatusOK {
		fmt.Println("Got it. Reading HTML source...")
		bodyBytes, err := ioutil.ReadAll(resp.Body)

		if err != nil {
			panic(err)
		}

		bodyString := string(bodyBytes)
		fmt.Println("Read it. Parsing cards out of it...")
		cards := sg.ParseCards(bodyString)
		fmt.Println("Parsed. Creating board...")
		board := sg.NewBoard(cards)
		fmt.Printf("%+v\n", board)
		fmt.Println("Solving Puzzle...")
		sets := sg.BruteForceSolve(board)
		fmt.Printf("%+v\n", sets)
	}
}
