

namespace QPRNG_Q1.Pipeline;

using Mathematic;

public interface IQuantumGate
{
  void ApplyTo(QubitState q);
}
