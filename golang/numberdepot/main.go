package main

import (
	"encoding/json"
	"io/ioutil"
	"log"
	"os"
	"strconv"
)

type coupon struct {
	Tickets []ticket
	Name    string
	Phone   string
}

type ticket struct {
	Picks [5]int
	Power int
}

func main() {
	if len(os.Args) < 8 {
		log.Fatalf("Usage: numberdepot <directory> <n1> <n2> <n3> <n4> <n5> <pb>")
	}

	files, err := ioutil.ReadDir(os.Args[1])

	if err != nil {
		log.Fatal(err)
	}

	os.Chdir(os.Args[1])
	numbers := make([]int, 0)

	for i := 2; i <= 6; i++ {
		if num, err := strconv.Atoi(os.Args[i]); err != nil {
			log.Fatal(err)
		} else {
			numbers = append(numbers, num)
		}
	}

	pb, err := strconv.Atoi(os.Args[7])

	if err != nil {
		log.Fatal(err)
	}

	for _, file := range files {
		err := checkFile(file.Name(), numbers, pb)

		if err != nil {
			log.Println(err)
		}
	}
}

func checkFile(path string, numbers []int, pb int) error {
	jsonFile, err := os.Open(path)

	if err != nil {
		return err
	}

	defer jsonFile.Close()
	contents, err := ioutil.ReadAll(jsonFile)

	if err != nil {
		return err
	}

	var c coupon

	if err := json.Unmarshal(contents, &c); err != nil {
		return err
	}

	println(path, c.Name, c.Phone)

	for i, ticket := range c.Tickets {
		println("  ", i, "---",
			ticket.Picks[0],
			ticket.Picks[1],
			ticket.Picks[2],
			ticket.Picks[3],
			ticket.Picks[4],
			"-",
			ticket.Power)

		for _, pick := range ticket.Picks {
			for _, num := range numbers {
				if num == pick {
					println("    ------>", num)
				}
			}
		}

		if pb == ticket.Power {
			println("    ------>", pb, "PB")
		}
	}

	return nil
}
