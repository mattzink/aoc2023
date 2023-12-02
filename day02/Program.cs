const int MaxRedCubes = 12, MaxGreenCubes = 13, MaxBlueCubes = 14;

int total = 0;
Span<Range> setRanges = stackalloc Range[20];
Span<Range> pullRanges = stackalloc Range[20];
ReadOnlySpan<char> line;
while (!(line = Console.ReadLine().AsSpan()).IsEmpty)
{
    int gameId = int.Parse(line[5..line.IndexOf(':')]);   
    line = line[(line.IndexOf(':') + 1)..];
    bool possible = true;
    int setCount = line.Split(setRanges, ';');
    foreach (var setRange in setRanges[..setCount])
    {
        var set = line[setRange];
        int pullCount = set.Split(pullRanges, ',', StringSplitOptions.TrimEntries);
        foreach (var pullRange in pullRanges[..pullCount])
        {
            var pull = set[pullRange];
            var cubeCount = int.Parse(pull[..pull.IndexOf(' ')]);
            possible &= pull[pull.IndexOf(' ') + 1] switch
            {
                'r' => cubeCount <= MaxRedCubes,
                'g' => cubeCount <= MaxGreenCubes,
                'b' => cubeCount <= MaxBlueCubes,
                _ => false
            };
        }        
    }
    if (possible)
        total += gameId;
}
Console.WriteLine(total);
