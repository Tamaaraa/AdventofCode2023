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
        Console.WriteLine(steps1);
    }
}
