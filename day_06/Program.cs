using System.Runtime.InteropServices;

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

double ans1 = 1;

for (int i = 0; i < times.Length; i++)
{
    ans1 *= Solve(double.Parse(times[i]), double.Parse(dists[i]));
}

static double Solve(double time, double dist)
{
    double ans = 0;
    for (int i = 0; i < time + 1; i++)
    {
        double diff = i * (time - i);
        if (diff >= dist)
        {
            ans++;
        }
    }
    return ans;
}

double ans2 = Solve(double.Parse(longTime), double.Parse(longDist));

Console.WriteLine(ans1);
Console.WriteLine(ans2);
