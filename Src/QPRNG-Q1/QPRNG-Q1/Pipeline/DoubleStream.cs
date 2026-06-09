
namespace QPRNG_Q1.Pipeline;

public static class DoubleStream
{
  private static readonly ThreadLocal<(
    int Start, int End, int Index)> State =
      new(() => (0, 0, 0));

  public static double[] Values { get; private set; } = [];

  public static void SetValues(double[] values) =>
    Values = values ?? throw new 
      ArgumentNullException(nameof(values));

  public static void AssignSlice(int start, int length) =>
    State.Value = (start, start + length, start);

  public static double Next()
  {
    var (start, end, index) = State.Value;

    if (index >= end)
      throw new InvalidOperationException(
        "DoubleStream: Slice exhausted!");

    double d = Values[index];
    State.Value = (start, end, index + 1);
    return d;
  }
}