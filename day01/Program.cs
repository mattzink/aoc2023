var digits = System.Buffers.SearchValues.Create("0123456789");

int total = 0;
ReadOnlySpan<char> line;
while (!(line = Console.ReadLine().AsSpan()).IsEmpty)
{
    var firstDigit = line[line.IndexOfAny(digits)] - '0';
    var lastDigit = line[line.LastIndexOfAny(digits)] - '0';
    total += (firstDigit * 10) + lastDigit;
}
Console.WriteLine(total);
