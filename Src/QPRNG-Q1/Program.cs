

using System.Diagnostics;

namespace QPRNG_Q1.Test;

using Pipeline;
using Entropie.Test;

public class Program
{
  public static void Main()
  {
    Test_QPRNG_Bits();
    Test_QPRNG_Bytes();
    Test_Entropie_Analyze();

    Console.WriteLine();
    Console.WriteLine("FINISH");
    Console.ReadLine();
  }

  private static void Test_QPRNG_Bits()
  {
    var bits = 10;
    var max_bits = 100_000_000;

    while (bits <= max_bits)
    {
      Test_QPRNG_Bits(bits);
      bits *= 10;
    }
    Console.WriteLine();
    Console.WriteLine();
  }

  private static void Test_QPRNG_Bytes()
  {
    var cnt = 10;
    var max_bits = 10_000_000;

    while (cnt <= max_bits)
    {
      Test_QPRNG_Bytes(cnt);
      cnt *= 10;
    }
    Console.WriteLine();
    Console.WriteLine();
  }

  private static void Test_QPRNG_Bytes(int count)
  {
    var qprng = new QPRNG();

    Console.WriteLine("=== QPRNG Bytes ===");

    var sw = Stopwatch.StartNew();
    var result = qprng.GenerateBytes(count);
    sw.Stop();

    Console.WriteLine($"Generated: {result.Length:n0} bytes; t = {sw.ElapsedMilliseconds} ms; ticks = {sw.ElapsedTicks:n0}");
    Console.WriteLine();
  }

  private static void Test_QPRNG_Bits(int bits)
  {
    var qprng = new QPRNG();

    Console.WriteLine("=== QPRNG Bits ===");

    var sw = Stopwatch.StartNew();
    var result = qprng.GenerateBits(bits);
    sw.Stop();

    Console.WriteLine($"Generated: {result.Length:n0} bits; t = {sw.ElapsedMilliseconds} ms; ticks = {sw.ElapsedTicks:n0}");
    Console.WriteLine();
  }

  private static void Test_Entropie_Analyze()
  {
    var qprng = new QPRNG();
    var bits = qprng.GenerateBits(10_000_000);
    Console.WriteLine($"Entropie Analyze Data Bits: size = {bits.Length:n0}");
    Console.WriteLine($"*********************************************\n");

    var (p0, p1) = EntropieTest.AnalyzeBitBias(bits);
    Console.WriteLine($"BitBias: p0 = {p0:F6}, p1 = {p1:F6}\n");

    var runs = EntropieTest.CountRuns(bits);
    Console.WriteLine($"Count Runs: {runs:n0}; delta = {(bits.Length / 2) - runs}\n");

    var h = EntropieTest.ShannonEntropy(bits);
    // max 1.0 für perfekte Bits
    Console.WriteLine($"Shannon Entropy per bit: {h:F6} (max 1.0)\n");

    Console.WriteLine("Autokorrelation (Bits):");
    for (int lag = 1; lag <= 8; lag++)
    {
      var ac = EntropieTest.AutoCorrelation(bits, lag);

      // Anteil gleicher Bits – ideal wäre ac = ~0.5
      Console.WriteLine($"lag {lag}: {ac:F6}");
    }

    Console.WriteLine(); Console.WriteLine();

    var bytes = qprng.GenerateBytes(1_000_000);
    Console.WriteLine($"Entropie Analyze Data Bytes: size = {bytes.Length:n0}");
    Console.WriteLine($"*********************************************\n");

    Console.WriteLine("Byte‑Histogramm + Entropie per Byte:");

    // max 8.0 für perfekte Bytes
    var hbytes = EntropieTest.ShannonEntropyBytes(bytes);
    Console.WriteLine($"Entropy per byte: {hbytes:F4} (max 8.0)");

    var hist = EntropieTest.ByteHistogram(bytes);
    for (int i = 0; i < 16; i++)
      Console.WriteLine($"{i:X2}: {hist[i]}");

    Console.WriteLine(); Console.WriteLine();
  }
}

