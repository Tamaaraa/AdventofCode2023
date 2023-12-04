using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

StreamReader sr = new StreamReader("./input");
string line = sr.ReadLine();
int ans1 = 0;
int ans2 = 0;

while (line != null) {
    Dictionary<string, int> colorCounts = new Dictionary<string, int>();

    var matchGameId = Regex.Match(line, @"Game (\d+):");
    int gameId = int.Parse(matchGameId.Groups[1].Value);

    var matches = Regex.Matches(line, @"(\d+) (\w+)");

    foreach (Match match in matches) {
        int count = int.Parse(match.Groups[1].Value);
        string color = match.Groups[2].Value;

        if (colorCounts.ContainsKey(color)) {
            colorCounts[color] = Math.Max(colorCounts[color], count);
        }
        else {
            colorCounts[color] = count;
        }


    }

    if (colorCounts["red"] <= 12) {
        if (colorCounts["blue"] <= 14) { 
            if (colorCounts["green"] <= 13) {
                 ans1 += gameId;
            }
        } 
    } 

    ans2 += colorCounts["red"] * colorCounts["blue"] * colorCounts["green"];

    line = sr.ReadLine();
}

Console.WriteLine(ans1);
Console.WriteLine(ans2);