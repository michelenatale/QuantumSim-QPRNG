



namespace QPRNG_Q1.Mathematic;

using Pipeline;

public sealed class QubitState //Qubit-Zustand
{
  public Cx Alpha { get; private set; } = default!;

  public Cx Beta { get; private set; } = default!;

  public QubitState(Cx alpha, Cx beta)
  {
    this.Beta = beta;
    this.Alpha = alpha;
    this.Normalize();
  }

  public static QubitState Zero() =>
    new(new Cx(1.0), new Cx(0.0));

  private void Normalize()
  {
    var n2 = this.Alpha.NormSquared + this.Beta.NormSquared;
    var inv = 1.0 / Math.Sqrt(n2);

    this.Beta = this.Beta.Scale(inv);
    this.Alpha = this.Alpha.Scale(inv);
  }

  public void Apply(IQuantumGate gate) =>
    gate.ApplyTo(this);


  public byte Measure()
  {
    double rnd = DoubleStream.Next();
    double p0 = this.Alpha.NormSquared;

    if (rnd < p0)
    {
      this.Beta = new Cx(0.0);
      this.Alpha = new Cx(1.0);
      return 0;
    }

    this.Beta = new Cx(1.0);
    this.Alpha = new Cx(0.0);
    return 1;
  }

  public void SetState(Cx alpha, Cx beta)
  {
    this.Beta = beta;
    this.Alpha = alpha;
  } 
}
