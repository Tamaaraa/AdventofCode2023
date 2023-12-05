string input = File.ReadAllText("./input");

string[] parts = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

string seeds = parts[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

string seedToSoil = parts[1].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

string soilToFertilizer = parts[2].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

string fertilizerToWater = parts[3].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

string waterToLight = parts[4].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

string lightToTemperature = parts[5].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

string temperatureToHumidity = parts[6].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

string humidityToLocation = parts[7].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];

Dictionary<double, double> soil = new();
Dictionary<double, double> fertilizer = new();
Dictionary<double, double> water = new();
Dictionary<double, double> light = new();
Dictionary<double, double> temperature = new();
Dictionary<double, double> humidity = new();
Dictionary<double, double> location = new();

loopOverLines(soil, seedToSoil);
loopOverLines(fertilizer, soilToFertilizer);
loopOverLines(water, fertilizerToWater);
loopOverLines(light, waterToLight);
loopOverLines(temperature, lightToTemperature);
loopOverLines(humidity, temperatureToHumidity);
loopOverLines(location, humidityToLocation);

static Dictionary<double, double> loopOverLines(Dictionary<double, double> dict, string input)
{
    foreach (string line in input.Split("\n").Skip(1))
    {
        string[] numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        double destination = double.Parse(numbers[0]);
        double source = double.Parse(numbers[1]);
        double length = double.Parse(numbers[2]);
        dict = fillDict(dict, destination, source, length);
    }
    return dict;
}

static Dictionary<double, double> fillDict(
    Dictionary<double, double> dict,
    double destination,
    double source,
    double length
)
{
    double destinationInitial = destination;
    for (double i = destination; i < destination + length; i++)
    {
        dict[i] = source;
        source++;
    }

    return dict;
}
