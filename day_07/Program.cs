using System.Numerics;

string input = File.ReadAllText("./input");
Dictionary<BigInteger, int> winOrder = new();
Dictionary<BigInteger, int> winOrder2 = new();
string cardOrder = "23456789TJQKA";
string part2CardOrder = "J23456789TQKA";

foreach (string line in input.Split("\n"))
{
    string hand = line.Split(" ")[0];
    int bet = int.Parse(line.Split(" ")[1]);

    // get whatever card you have the most of and assign it to a variable.
    var part2Replacement = (
        from c in hand
        where c != 'J'
        group c by c into g
        orderby g.Count() descending
        select g.Key
    ).FirstOrDefault('J');

    winOrder[(PatternValue(hand) << 64) + CardValue(hand, cardOrder)] = bet;
    winOrder2[
        (PatternValue(hand.Replace('J', part2Replacement)) << 64) + CardValue(hand, part2CardOrder)
    ] = bet;
}

List<BigInteger> keys = new();
keys.AddRange(winOrder.Keys);
keys.Sort();
int i = 1;
BigInteger ans1 = 0;

List<BigInteger> keys2 = new();
keys2.AddRange(winOrder2.Keys);
keys2.Sort();
BigInteger ans2 = 0;

foreach (BigInteger key in keys)
{
    ans1 += winOrder[key] * i;
    i++;
}

i = 1;
foreach (BigInteger key in keys2)
{
    ans2 += winOrder2[key] * i;
    i++;
}

Console.WriteLine(ans1);
Console.WriteLine(ans2);

// Convert hand to card values: Eg. A6436 -> 13 6 4 3 6
BigInteger CardValue(string hand, string cardOrder) =>
    new(hand.Select(c => (byte)cardOrder.IndexOf(c)).Reverse().ToArray());

// for every character get the count of occurances
BigInteger PatternValue(string hand) =>
    new(hand.Select(c => (byte)hand.Count(x => x == c)).Order().ToArray());
