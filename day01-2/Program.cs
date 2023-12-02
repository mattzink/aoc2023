(string, int)[] values = [
    ("zero", 0),
    ("one", 1),
    ("two", 2),
    ("three", 3),
    ("four", 4),
    ("five", 5),
    ("six", 6),
    ("seven", 7),
    ("eight", 8),
    ("nine", 9)
];

int total = 0;
ReadOnlySpan<char> line;
while (!(line = Console.ReadLine().AsSpan()).IsEmpty)
{
    int firstDigit = 0;
    int lastDigit = 0; 
    int lowestFirstIndex = int.MaxValue;
    int highestLastIndex = -1;

    foreach ((var word, var digit) in values)
    {
        var index = line.IndexOf(word);
        if (index >= 0 && index < lowestFirstIndex)
        {
            firstDigit = digit;
            lowestFirstIndex = index;
        }
        
        index = line.IndexOf((char)('0' + digit));
        if (index >= 0 && index < lowestFirstIndex)
        {
            firstDigit = digit;
            lowestFirstIndex = index;
        }

        index = line.LastIndexOf(word);
        if (index > highestLastIndex)
        {
            lastDigit = digit;
            highestLastIndex = index;
        }
        
        index = line.LastIndexOf((char)('0' + digit));
        if (index > highestLastIndex)
        {
            lastDigit = digit;
            highestLastIndex = index;
        }
    }
    
    total += (firstDigit * 10) + lastDigit;
}
Console.WriteLine(total);
