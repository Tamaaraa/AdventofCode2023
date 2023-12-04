string input = File.ReadAllText("./input");

Dictionary<int, int> cardNumbers = new();

var rows = input.Split('\n');
var totalSum = 0;
var totalCards = 0;

for (var i = 0; i < rows.Length; i++)
{
    cardNumbers[i + 1] = 1;
}

foreach (string row in rows)
{
    string[] numbers = row.Split("|");
    int wins = 0;

    int cardNum = int.Parse(
        numbers[0].Split(":")[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]
    );

    List<int> winningNumbers = numbers[0]
        .Split(":")[1]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();
    List<int> ownedNumbers = numbers[1]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();

    foreach (int num in ownedNumbers)
    {
        if (winningNumbers.Contains(num))
        {
            wins++;
        }
    }

    if (wins > 0)
    {
        for (int i = 1; i < wins + 1; i++)
        {
            if (cardNum + i <= rows.Length)
            {
                cardNumbers[cardNum + i] += 1 * cardNumbers[cardNum];
            }
        }
    }

    totalSum += (int)powerFunc(wins);
}

Console.WriteLine(totalSum);

for (int i = 1; i <= rows.Length; i++)
{
    totalCards += cardNumbers[i];
}

Console.WriteLine(totalCards);

static double powerFunc(int wins)
{
    if (wins < 2)
    {
        return wins;
    }
    else
    {
        return Math.Pow(2, wins - 1);
    }
}
