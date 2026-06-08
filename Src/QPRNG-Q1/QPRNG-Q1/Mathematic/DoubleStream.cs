
namespace QPRNG_Parallel.Mathematic;

public static class DoubleStream
{
  private static readonly ThreadLocal<(
    int Start, int End, int Index)> State =
      new(() => (0, 0, 0));

  public static double[] Values { get; private set; } = [];

  public static void SetValues(double[] values) =>
    Values = values ?? throw new ArgumentNullException(nameof(values));

  public static void AssignSlice(int start, int length) =>
    State.Value = (start, start + length, start);

  public static double Next()
  {
    var (start, end, index) = State.Value;

    if (index >= end)
      throw new InvalidOperationException("DoubleStream: Slice exhausted!");

    double d = Values[index];
    State.Value = (start, end, index + 1);
    return d;
  }
}

//public sealed class DoubleStream
//{
//  private static readonly ThreadLocal<(
//    int Start, int End, int Index)> State =
//      new(() => (0, 0, 0));

//  private static readonly ThreadLocal<int> MIndex =
//      new(() => 0, trackAllValues: false);

//  public static double[] Values { get; set; } = [];

//  public static void AssignSlice(int start, int length) =>
//    State.Value = (start, start + length, start);

//  public static void SetValues(double[] values)
//  {
//    Reset();
//    Values = values ?? throw new 
//      ArgumentNullException(nameof(values));
//    MIndex.Value = 0; // Reset current thread
//  }

//  public static void Reset() =>
//    MIndex.Value = 0;

//  public static double Next()
//  {
//    int i = MIndex.Value;
//    if (i >= Values.Length) //Check it
//      throw new InvalidOperationException(
//        "DoubleStream: Out of random doubles!");

//    double d = Values[i];
//    MIndex.Value = i + 1;
//    return d;
//  }
//}
