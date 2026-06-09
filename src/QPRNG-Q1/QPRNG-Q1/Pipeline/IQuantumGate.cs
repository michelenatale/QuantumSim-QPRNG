

namespace QPRNG_Q1.Pipeline;

using Math;

public interface IQuantumGate
{
  void ApplyTo(QubitState q);
}
