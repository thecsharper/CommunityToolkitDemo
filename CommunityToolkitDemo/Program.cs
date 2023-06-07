// https://learn.microsoft.com/en-us/dotnet/communitytoolkit/high-performance/introduction

using CommunityToolkit.HighPerformance.Helpers;

var array = Enumerable.Range(1, 10000).Select(x => x * x).ToArray();

ParallelHelper.For(0, array.Length, new ArrayInitializer(array));

readonly struct ArrayInitializer : IAction
{
    private readonly int[] _array;

    public ArrayInitializer(int[] array)
    {
        _array = array;
    }

    public void Invoke(int i)
    {
        _array[i] = i;
        Console.WriteLine(i);
    }
}

