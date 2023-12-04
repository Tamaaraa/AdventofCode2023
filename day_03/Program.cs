using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

string input = File.ReadAllText(@"./input");

var rows = input.Split('\n');
var totalSum = 0;
bool added = false;

for (int j = 0; j < rows.Length; j++) {
    added = false;
    string curr_row = rows[j];
    var symbols2 = Regex.Matches("nah", @".");
    var symbols3 = Regex.Matches("nah", @".");
    var symbols = Regex.Matches(curr_row, @"[^.0-9]");
    if (j > 0 ) {
        symbols2 = Regex.Matches(rows[j-1], @"[^.0-9]");
    }
    if (j < rows.Length-1) {
        symbols3 = Regex.Matches(rows[j+1], @"[^.0-9]");
    }
    var numbers = Regex.Matches(curr_row, @"\d+");

    foreach (Match numberMatch in numbers){
        int numberStartIndex = numberMatch.Index;
        int numberEndIndex = numberStartIndex + numberMatch.Length-1;
        added = false;

        foreach (Match symbolMatch in symbols){
            int symbolIndex = symbolMatch.Index;

            // Check if the symbol is adjacent to the number
            if (Adjacent(numberStartIndex, numberEndIndex, symbolIndex)){
                // Add the number to the total sum
                totalSum += int.Parse(numberMatch.Value);
                added = true;
            }
        }

        if (added != true && j > 0) {
            foreach (Match symbolMatch in symbols2) {
                int symbolIndex = symbolMatch.Index;

                // Check if the symbol is adjacent to the number
                if (Adjacent(numberStartIndex, numberEndIndex, symbolIndex)){
                    // Add the number to the total sum
                    totalSum += int.Parse(numberMatch.Value);
                    added = true;
                }
            }
        }

        if (added != true && j < rows.Length-1) {
            foreach (Match symbolMatch in symbols3){
                int symbolIndex = symbolMatch.Index;

                // Check if the symbol is adjacent to the number
                if (Adjacent(numberStartIndex, numberEndIndex, symbolIndex)){
                    // Add the number to the total sum
                    totalSum += int.Parse(numberMatch.Value);
                    added = true;
                }
            }
        }
    }
}


static bool Adjacent(int numStart, int numEnd, int symbol) {
    for (int i = numStart-1; i <= numEnd+1; i++) {
        if (symbol == i) {
            return true;
        }
    }
    return false;
}
// Output the result
Console.WriteLine("Total sum of numbers adjacent to symbols: " + totalSum);




var totalSum2 = 0;

for (int j = 0; j < rows.Length; j++) {
    added = false;
    string curr_row = rows[j];
    var symbols = Regex.Matches(curr_row, @"\*");
    var numbers = Regex.Matches(curr_row, @"\d+");
    var numbers2 = Regex.Matches("nah", @".");
    var numbers3 = Regex.Matches("nah", @".");
    if (j > 0 ) {
        numbers2 = Regex.Matches(rows[j-1], @"\d+");
    }
    if (j < rows.Length-1) {
        numbers3 = Regex.Matches(rows[j+1], @"\d+");
    }

    foreach (Match symbolMatch in symbols){
        int symbolIndex = symbolMatch.Index;
        int match1Val = 0;
        int match2Val = 0;

        foreach (Match numberMatch in numbers){

            int numberStartIndex = numberMatch.Index;
            int numberEndIndex = numberStartIndex + numberMatch.Length-1;

            if (Adjacent(numberStartIndex, numberEndIndex, symbolIndex)){
                if (match1Val == 0) {
                    match1Val = int.Parse(numberMatch.Value);
                } else {
                    match2Val = int.Parse(numberMatch.Value);
                }
            }
        }
        foreach (Match numberMatch in numbers2){

            int numberStartIndex = numberMatch.Index;
            int numberEndIndex = numberStartIndex + numberMatch.Length-1;

            if (Adjacent(numberStartIndex, numberEndIndex, symbolIndex)){
                if (match1Val == 0) {
                    match1Val = int.Parse(numberMatch.Value);
                } else {
                    match2Val = int.Parse(numberMatch.Value);
                }
            }
        }
        foreach (Match numberMatch in numbers3){

            int numberStartIndex = numberMatch.Index;
            int numberEndIndex = numberStartIndex + numberMatch.Length-1;

            if (Adjacent(numberStartIndex, numberEndIndex, symbolIndex)){
                if (match1Val == 0) {
                    match1Val = int.Parse(numberMatch.Value);
                } else {
                    match2Val = int.Parse(numberMatch.Value);
                }
            }
        }

        totalSum2 += match1Val * match2Val;
    }
}

Console.WriteLine("Gear multipliers equal: " + totalSum2); 

