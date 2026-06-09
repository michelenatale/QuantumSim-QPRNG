
namespace QPRNG_Q1.Math;


public readonly struct Cx
{
  public double Re { get; } = 0.0;

  public double Im { get; } = 0.0;

  public Cx(double re, double im = 0.0)
  {
    this.Re = re;
    this.Im = im;
  }

  public bool IsValid => !double.IsNaN(Re);

  public double NormSquared
  {
    get
    {
      EnsureValid();
      return Re * Re + Im * Im;
    }
  }

  public static Cx operator +(Cx a, Cx b) =>
    new(a.Re + b.Re, a.Im + b.Im);

  public static Cx operator *(Cx a, Cx b) =>
    new(a.Re * b.Re - a.Im * b.Im,
        a.Re * b.Im + a.Im * b.Re);

  public Cx Scale(double dbl)
  {
    EnsureValid();
    return new Cx(Re * dbl, Im * dbl);
  }

  private void EnsureValid()
  {
    if (!IsValid)
      throw new InvalidOperationException(
          "Cx was not properly initialized. " +
          "Use new Cx(re, im).");
  }
}

