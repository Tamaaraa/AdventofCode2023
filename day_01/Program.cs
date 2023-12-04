using System.IO;
using System;
using System.Text.RegularExpressions;

string line;
int number;
int firstNum = 0;
int lastNum = 0;
int ans= 0;
int lineCount = 0;

Dictionary<string, int> spelledOutNums = new Dictionary<string, int> {
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9}
};

try {
    StreamReader sr = new StreamReader("./input");
    line = sr.ReadLine();

    while (line != null) {
        MatchCollection matches = Regex.Matches(line, @"(one|two|three|four|five|six|seven|eight|nine|[1-9])", RegexOptions.IgnoreCase);
        if (matches.Count > 0) {
            if (!int.TryParse(matches[0].Value, out firstNum)) {
                if (spelledOutNums.TryGetValue(matches[0].Value, out firstNum)){
                    
                }
            }
        }
        MatchCollection matches2 = Regex.Matches(line, @"(one|two|three|four|five|six|seven|eight|nine|[1-9])", RegexOptions.RightToLeft);
        if (matches2.Count > 0) {
            if (!int.TryParse(matches2[0].Value, out lastNum)) {
                if (spelledOutNums.TryGetValue(matches2[0].Value, out lastNum)){

                }
            }
        }

        lineCount += 1;
        number = firstNum * 10 + lastNum;
        Console.WriteLine("Line: " + lineCount + "\t-\t" + number + ": " + line);
        ans += number;
        line = sr.ReadLine();
    }
    
}   catch(Exception e) {
    Console.WriteLine(e);
} finally {
    Console.WriteLine(ans);
}