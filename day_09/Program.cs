namespace AdventOfCode;

class Solution
{
    // Read input
    public string input = File.ReadAllText("./input");

    public static void Main()
    {
        Solution solution = new();
        Console.WriteLine("Part One Result: " + solution.PartOne(solution.input));
        Console.WriteLine("Part Two Result: " + solution.PartTwo(solution.input));
    }

    public object PartOne(string input) => Solve(input, FindNums);

    public object PartTwo(string input) => Solve(input, FindNums2);

    // Split input into lines and call the line splitter and extrapolation function on each, then sum the results.
    int Solve(string input, Func<int[], int> findNums) =>
        input.Split("\n").Select(GetLine).Select(findNums).Sum();

    // Splits lines into numbers
    int[] GetLine(string line) => line.Split(" ").Select(int.Parse).ToArray();

    // Find the differences between the current element value and the next, then add them all into a new array
    static int[] FindDiff(int[] numbers) =>
        numbers.Zip(numbers.Skip(1)).Select(n => n.Second - n.First).ToArray();

    // Find differences between elements until there's no elements. And add the last value of every line to each other
    //  2     4     6     8   (2+8)
    //     2     2     2   (0+2)
    //        0     0    (0)
    int FindNums(int[] nums) => !nums.Any() ? 0 : FindNums(FindDiff(nums)) + nums.Last();

    // Same as FindNums but at the start of each line (the end again after reverse :))
    int FindNums2(int[] nums) => FindNums(nums.Reverse().ToArray());
}
