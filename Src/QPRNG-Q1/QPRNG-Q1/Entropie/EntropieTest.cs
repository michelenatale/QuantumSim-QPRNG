
namespace QPRNG_Q1.Entropie.Test;

public sealed class EntropieTest
{
  public static (double p0, double p1) AnalyzeBitBias(
    ReadOnlySpan<byte> bits)
  {
    //1. Bit‑Bias (Anteil 1er vs. 0er)

    long ones = 0;
    for (int i = 0; i < bits.Length; i++)
      if (bits[i] == 1) ones++;

    long zeros = bits.Length - ones;

    return ((double)zeros / bits.Length, (double)ones / bits.Length);
  }

  public static int CountRuns(ReadOnlySpan<byte> bits)
  {
    //2. Runs‑Test (Wechselhäufigkeit)

    if (bits.Length == 0) return 0;

    int runs = 1;
    byte last = bits[0];

    for (int i = 1; i < bits.Length; i++)
    {
      if (bits[i] != last)
      {
        runs++;
        last = bits[i];
      }
    }

    return runs;
  }

  public static double ShannonEntropy(ReadOnlySpan<byte> bits)
  {
    //3. Shannon‑Entropie pro Bit

    long zeros = 0;
    for (int i = 0; i < bits.Length; i++)
      if (bits[i] == 0) zeros++;

    long ones = bits.Length - zeros;

    double p0 = (double)zeros / bits.Length;
    double p1 = (double)ones / bits.Length;

    double h = 0.0;
    if (p0 > 0) h -= p0 * Math.Log2(p0);
    if (p1 > 0) h -= p1 * Math.Log2(p1);

    return h; // max 1.0 für perfekte Bits
              // 1.0 = Ist das Idealbild eines perfekten Bernoulli‑Prozesses.
  }

  public static double AutoCorrelation(
    ReadOnlySpan<byte> bits, int lag)
  {
    //4. Einfache Autokorrelation (Lag‑k)

    if (lag <= 0 || lag >= bits.Length)
      throw new ArgumentOutOfRangeException(nameof(lag));

    long equal = 0;
    long total = bits.Length - lag;

    for (int i = 0; i < total; i++)
    {
      if (bits[i] == bits[i + lag])
        equal++;
    }

    // Anteil gleicher Bits – ideal wäre ~0.5
    return (double)equal / total;
  }

  public static double ShannonEntropyBytes(
    ReadOnlySpan<byte> data)
  { 
    //5. Byte‑Histogramm + Entropie pro Byte

    var hist = ByteHistogram(data);
    double n = data.Length, h = 0.0;

    for (int i = 0; i < 256; i++)
    {
      if (hist[i] == 0) continue;
      double p = hist[i] / n;
      h -= p * Math.Log2(p);
    }

    return h; // max 8.0 für perfekte Bytes
  }

  public static int[] ByteHistogram(ReadOnlySpan<byte> data)
  {
    //5. Byte‑Histogramm + Entropie pro Byte

    var hist = new int[256];
    for (int i = 0; i < data.Length; i++)
      hist[data[i]]++;
    return hist;
  }
}
