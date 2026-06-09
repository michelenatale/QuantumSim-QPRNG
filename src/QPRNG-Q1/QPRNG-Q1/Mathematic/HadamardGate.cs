

namespace QPRNG_Q1.Math;

using Pipeline;

public sealed class HadamardGate : IQuantumGate
{
  private static readonly double InvSqrt2 =
    1.0 / System.Math.Sqrt(2.0);

  public void ApplyTo(QubitState qstate)
  {
    Cx a = qstate.Alpha, b = qstate.Beta;
    var newalpha = (a + b).Scale(InvSqrt2);
    var newbeta = (a + new Cx(-b.Re, -b.Im)).Scale(InvSqrt2);
    qstate.SetState(newalpha, newbeta);
  }
}

