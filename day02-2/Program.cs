int total = 0;
Span<Range> setRanges = stackalloc Range[20];
Span<Range> pullRanges = stackalloc Range[20];
ReadOnlySpan<char> line;
while (!(line = Console.ReadLine().AsSpan()).IsEmpty)
{ 
    line = line[(line.IndexOf(':') + 1)..];
    int minRed = 0, minGreen = 0, minBlue = 0;
    int setCount = line.Split(setRanges, ';');
    foreach (var setRange in setRanges[..setCount])
    {
        var set = line[setRange];
        int pullCount = set.Split(pullRanges, ',', StringSplitOptions.TrimEntries);
        foreach (var pullRange in pullRanges[..pullCount])
        {
            var pull = set[pullRange];
            var cubeCount = int.Parse(pull[..pull.IndexOf(' ')]);
            switch (pull[pull.IndexOf(' ') + 1])
            {
                case 'r': minRed = Math.Max(minRed, cubeCount); break;
                case 'g': minGreen = Math.Max(minGreen, cubeCount); break;
                case 'b': minBlue = Math.Max(minBlue, cubeCount); break;
            };
        }        
    }    
    total += minRed * minGreen * minBlue;
}
Console.WriteLine(total);
