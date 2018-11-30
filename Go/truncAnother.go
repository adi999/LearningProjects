package main

import (
	"fmt"
	"strconv"
)

func main()  {
	fmt.Print("Enter your floating point number: ")
	var input string
	_, readErr := fmt.Scan(&input)
	if readErr == nil {
		number, parseErr := strconv.ParseFloat(input, 32)
		if parseErr == nil {
			fmt.Println(strconv.Itoa(int(number)))
		}
	}
}