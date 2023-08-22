// See https://aka.ms/new-console-template for more information

var lines = File.ReadAllLines("data.txt");

var validPasswds = lines.Count(x =>
{
    try
    {
        return ParsePasswordLine(x);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Couldn't parse line \"{x}\": {e}");
        return false;
    }
});

Console.WriteLine($"Valid passwords: {validPasswds}");

bool ParsePasswordLine(string s)
{
    var parts = s.Split();
    var sym = parts[0][0];

    var symRange = parts[1][..^1].Split('-');
    var rangeLeft = int.Parse(symRange[0]);
    var rangeRight = int.Parse(symRange[1]);

    var pass = parts[2];

    var symCount = pass.Count(c => c == sym);
    return rangeLeft <= symCount && symCount <= rangeRight;
}