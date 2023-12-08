using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace AdventOfCode;

static class Program
{
    static void Main()
    {
        string input = File.ReadAllText("./input");
        Dictionary<string, Dictionary<char, string>> pathDict = new();

        string directions = input.Split("\n\n")[0];
        foreach (string line in input.Split("\n\n")[1].Split("\n"))
        {
            string root = line.Split(" = ")[0];
            string left = line.Split(" = ")[1].Split(" ")[0][1..4];
            string right = line.Split(" = ")[1].Split(" ")[1][..3];

            pathDict[root] = new() { ['L'] = left, ['R'] = right };
        }

        int steps1 = 0;
        int steps2 = 0;
        string pos = "AAA";
        while (pos != "ZZZ")
        {
            foreach (char ch in directions)
            {
                pos = pathDict[pos][ch];
                steps1++;
                if (pos == "ZZZ")
                {
                    break;
                }
            }
        }

        List<string> positions = pathDict.Keys.Where(k => k.EndsWith("A")).ToList();

        List<long> durations = new();
        foreach (string pos2 in positions)
        {
            if (steps2 > 0)
            {
                durations.Add(steps2);
            }
            pos = pos2;
            steps2 = 0;
            while (!pos.EndsWith("Z"))
            {
                foreach (char ch in directions)
                {
                    if (!pos.EndsWith("Z"))
                    {
                        steps2++;
                        pos = pathDict[pos][ch];
                    }
                }
            }
        }
        durations.Add(steps2);

        Console.WriteLine(steps1);
        Console.WriteLine(LCMOfList(durations));
    }

    // find the greatest common divider using the Euclidean Algorithm
    static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // find the lowest common multiple
    static long LCM(long a, long b)
    {
        return a * b / GCD(a, b);
    }

    // Find LCM between 2 numbers until list is fully iterated through.
    static long LCMOfList(List<long> numbers)
    {
        long result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            result = LCM(result, numbers[i]);
        }
        return result;
    }
}
