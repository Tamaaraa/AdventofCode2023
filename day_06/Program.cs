using System.Numerics;

string input = File.ReadAllText("./input");

string[] td = input.Split("\n");

string t = td[0];
string d = td[1];

string[] times = t.Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] dists = d.Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

string longTime = "";
string longDist = "";

foreach (string time in times)
{
    longTime += time;
}
foreach (string dist in dists)
{
    longDist += dist;
}

BigInteger ans1 = 1;

for (int i = 0; i < times.Length; i++)
{
    ans1 *= Solve(BigInteger.Parse(times[i]), BigInteger.Parse(dists[i]));
}

static BigInteger Solve(BigInteger time, BigInteger dist)
{
    BigInteger ans = 0;
    for (int i = 0; i < time + 1; i++)
    {
        BigInteger diff = i * (time - i);
        if (diff >= dist)
        {
            ans++;
        }
    }
    return ans;
}

BigInteger ans2 = Solve(BigInteger.Parse(longTime), BigInteger.Parse(longDist));

Console.WriteLine(ans1);
Console.WriteLine(ans2);
