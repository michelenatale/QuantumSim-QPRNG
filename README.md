# QuantumSim‑QPRNG  

**Status**: ⚠️ Early Development   
**Version**: 0.0.1   
**Last Updated**: 2026.06.08

**Parallel Quantum‑Inspired Random Bit Generator**

QuantumSim‑QPRNG is an experimental high‑performance project that generates random bits using a quantum‑inspired simulation model.  

It combines:
- Qubit state simulation (complex amplitudes, superposition, measurement)
- Fully parallelized bit generation
- Precomputed double streams for maximum throughput
- Efficient bit‑to‑byte packing
- Integrated entropy and randomness tests

This repository serves as a testbed for fast, deterministic, and reproducible quantum‑inspired simulation techniques in .NET.

---

## 🚀 Features

- **Extremely fast bit generation**  
  Up to 100 million bits in ~1.5 seconds (hardware‑dependent).

- **Parallel qubit measurement**  
  Each thread receives its own slice of the precomputed double stream.

- **Quantum‑inspired RNG**  
  Hadamard gate + measurement → unbiased 0/1 output.

- **Efficient bit packing**  
  Converts bits to bytes using parallel block processing.

- **Built‑in entropy tests**  
  Bit bias, runs test, autocorrelation, byte histogram, entropy per bit/byte.

- **Clean and modular architecture**  
  Ideal for experimentation, research, and further extensions.

---

## 📊 Example Entropy Results

**10 million bits:**

- BitBias: p0 = 0.499941, p1 = 0.500059  
- Runs: 4,999,624 (Δ = 376 → well within expected range)  
- Entropy per bit: **1.000000**  
- Entropy per byte: **7.9998**  
- Autocorrelation (lag 1–8): all ≈ 0.5  
- Byte histogram: evenly distributed

These results match the behavior of an **ideal random process**.

---

## 🧩 Project Structure

```
QuantumSim-QPRNG /
│
├── src /
│   ├── QPRNG-Q1 /
│   │   ├── QPRNG-Q1 /
│   │   │   ├── Entropie
│   │   │   │   └── EntropieTest.cs
│   │   │   ├── Math /
│   │   │   │   ├── Cx.cs
│   │   │   │   ├── HadamardGate.cs
│   │   │   │   └── QubitState.cs
│   │   │   ├── Pipeline /
│   │   │   │   ├── DoubleStream.cs
│   │   │   │   └── IQuantumGate.cs
│   │   │   └── QPRNG.cs
│   │   └── QPRNG-Q1.csproj
│   └── QPRNGMultiQubits /
│       ├── xxxxxxxxxx.cs
│       ├── yyyyyyyyyy.cs
│       └── QPRNGMultiQubits.csproj
│
├── docs /
│   ├── Images /
│   ├── Script /
│   │   ├── Quanteninformatik.pdf
│   ├── QuantumInformationScience /
│   │   ├── Kapitel_01_Qubits.md
│   │   ├── Kapitel_02_Amplituden.md
│   │   ├── Kapitel_03_Superposition.md
│   │   ├── Kapitel_04_Tensorprodukte.md
│   │   ├── Kapitel_05_Quantenregister.md
│   │   ├── Kapitel_06_Gatter.md
│   │   ├── Kapitel_07_Messung.md
│   │   ├── Kapitel_08_GHZ_Bell.md
│   │   ├── Kapitel_09_QRNG.md
│   │   └── Kapitel_10_Simulationstechniken.md
│   └── README_QPRNG.md
│
├── tests /
│   ├── TestQPRNG-Q1 /
│   │   ├── Program.cs
│   │   └── TestQPRNG-Q1.csproj
│   ├── TestQPRNGMultiQubits /
│   │   ├── Program.cs
│   │   └── TestQPRNGMultiQubits.csproj
│   ├── TestQPRNG-Q1.sln
│   └── TestQPRNGMultiQubits.sln
│
├── LICENSE
└── README.md
```

---

## 🧪 Example: Generate Bits

```csharp
var qprng = new QPRNG();
var count = 100_000_000;
var bits = qprng.GenerateBits(count);
```

## 🧪 Example: Generate Bytes

```csharp
var count = 1_000_000;
var qprng = new QPRNG();
var bytes = qprng.GenerateBytes(count);
```

---

## ⚡ High‑Performance Computing (HPC)

High‑Performance Computing refers to techniques and architectures designed to perform large‑scale computations at maximum efficiency.

HPC focuses on:
- parallel execution across multiple CPU cores  
- efficient memory access and cache‑aware algorithms  
- vectorized operations (SIMD)  
- high‑throughput numerical processing  
- deterministic and reproducible performance at scale  

QuantumSim‑QPRNG uses HPC principles to generate millions of quantum‑inspired random bits with minimal overhead, leveraging parallel measurement, precomputed data streams, and optimized bit‑packing.

---

## 🇩🇪 German Version (Documentation)

A full German‑language version of the documentation is available in:

[docs/Readme-DE.md](docs/Readme-DE.md)

---

## 📘 Quanteninformatik Script (German)

The folder [docs/Script](docs/Script/) contains a set of lecture notes that explain the basics of quantum computing:
- Qubits
- Amplitudes
- Superposition
- Quantum registers
- Quantum gates
- Measurement
- GHZ/Bell states
- Quantum RNG
- Simulation techniques

This script is intentionally written in German.

---

## 📄 License

This project is released under the MIT License.
You are free to use, modify, and integrate the code into your own projects.

---

## ⭐ Project Status

This is an experimental test project, serving as a foundation for further research and optimization.
Future extensions may include:
- SIMD‑optimized operations
- Multi‑qubit batch measurement
- GPU backends
- Additional statistical test suites (NIST STS, Dieharder, etc.)

---

## 🙌 Author & Lead Architect

Developed by Michele Natale (2026)  
Quantum simulation, HPC (High‑Performance Computing), and .NET performance.

## 🔧 Maintainer

Michele Natale (2026)  
Maintenance, further development, bug fixing, and release management.

GitHub: [github.com/michelenatale](https://github.com/michelenatale)

--- 
