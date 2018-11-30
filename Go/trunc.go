package main

import "fmt"

func main() {
   fmt.Printf("Enter number to truncate:")
   var input float64
   fmt.Scanln(&input)
   input = trunc(input)
   fmt.Println(input)
}

func trunc(valueToTruncate float64) float64 {
    
    return float64(int64(valueToTruncate))
}