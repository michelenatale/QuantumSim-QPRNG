
using System.Security.Cryptography;


namespace QPRNG_Parallel.Pipeline;

using Mathematic;

public sealed class QPRNG
{
  private readonly HadamardGate MHadamard = new();

  public byte GenerateSingleBit()
  {
    //Initialzustand (∣0⟩)
    var q = QubitState.Zero();

    //Hadamard anwenden um eine Superposition
    //zu bekommen: ∣𝜓⟩ = (1/√2) * (∣0⟩ + ∣1⟩)
    q.Apply(this.MHadamard);

    //Messung ∣ψ⟩ = 1/(√2) ∣0⟩ + 1/(√2) ∣1⟩
    return q.Measure();

    //Nach der Messung
    //a|0> + b|1> -->Messung--> |0>   oder   |1>

    //Kollabierung: alle ursprüngliche Informationen
    //zur Superposition verloren. Nur 0 oder 1 vorhanden.
  }

  public byte[] GenerateBits(
    int count, int batchsize = 1 << 15)
  {
    // 1) Pre-produce doubles
    var dbls = PreGenerateDoublesParallel(count);
    DoubleStream.SetValues(dbls);

    // 2) Create Bits
    var result = Generate_Bits_Parallel(count, batchsize);

    return result;
  }

  public byte[] GenerateBytes(int count)
  {
    var bit_cnt = 8 * count;
    var bits = GenerateBits(bit_cnt);
    return PackBitsToBytes(bits);
  }

  private static byte[] PackBitsToBytes(byte[] bits)
  {
    int bit_count = bits.Length;
    int byte_count = (bit_count + 7) >> 3; 
    var output = new byte[byte_count];

    Parallel.For(0, byte_count, i =>
    {
      byte b = 0;
      int bit_idx = i << 3; // i * 8
      if (bit_idx + 0 < bit_count) b |= (byte)(bits[bit_idx + 0] << 7);
      if (bit_idx + 1 < bit_count) b |= (byte)(bits[bit_idx + 1] << 6);
      if (bit_idx + 2 < bit_count) b |= (byte)(bits[bit_idx + 2] << 5);
      if (bit_idx + 3 < bit_count) b |= (byte)(bits[bit_idx + 3] << 4);
      if (bit_idx + 4 < bit_count) b |= (byte)(bits[bit_idx + 4] << 3);
      if (bit_idx + 5 < bit_count) b |= (byte)(bits[bit_idx + 5] << 2);
      if (bit_idx + 6 < bit_count) b |= (byte)(bits[bit_idx + 6] << 1);
      if (bit_idx + 7 < bit_count) b |= (byte)(bits[bit_idx + 7] << 0);

      output[i] = b;
    });

    return output;
  }

  private byte[] Generate_Bits_Parallel(
    int count, int batchsize = 1 << 15)
  {
    byte[] result = new byte[count];
    int batches = (count + batchsize - 1) / batchsize;

    Parallel.For(0, batches, b =>
    {
      int start = b * batchsize;
      int size = Math.Min(batchsize, count - start);

      // Each thread gets its own slice
      DoubleStream.AssignSlice(start, size);

      for (int i = 0; i < size; i++)
        result[start + i] = this.GenerateSingleBit();
    });

    return result;
  }

  private static double[] PreGenerateDoublesParallel(int count)
  {
    int bytes_per_double = 8;
    int block_size = 1 << 20; // 1 MB
    int doubles_per_block = block_size / bytes_per_double;

    double[] result = new double[count];
    int blocks = (count + doubles_per_block - 1) / doubles_per_block;

    Parallel.For(0, blocks, () => new
    {
      rng = RandomNumberGenerator.Create(),
      buffer = new byte[block_size]
    }, (block_idx, state, local) =>
    {
      int start = block_idx * doubles_per_block;
      int remaining = count - start;

      int doubles_this_block = Math.Min(doubles_per_block, remaining);
      int bytes_this_block = doubles_this_block * bytes_per_double;

      // RNG fills the local buffer
      local.rng.GetBytes(local.buffer.AsSpan(0, bytes_this_block));

      int out_idx = start;
      for (int i = 0; i < bytes_this_block; i += 8)
      {
        ulong v = BitConverter.ToUInt64(local.buffer, i);
        v >>= 11; ulong bits = (1023UL << 52) | v;
        result[out_idx++] = BitConverter.Int64BitsToDouble((long)bits) - 1.0;
      }

      return local;
    }, local => { });

    return result;
  }

}
