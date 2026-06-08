# QuantumSim‑QPRNG  

**Status**: ✅   
**Version**: 0.0.1   
**Last Updated**: 2026.06.08

**Parallel Quantum‑Inspired Random Bit Generator**

[English-Version](https://github.com/michelenatale/QuantumSim-QPRNG/blob/main/README.md)

QuantumSim‑QPRNG ist ein experimentelles, hochperformantes Testprojekt zur Erzeugung von Zufallsbits durch eine quanteninspirierte Simulation.  

Es kombiniert:
- Qubit‑Simulation (Amplitude, Superposition, Messung)
- Parallelisierte Bit‑Erzeugung
- Vorberechnete Double‑Streams für maximale Geschwindigkeit
- Effizientes Bit‑Packing zu Bytes
- Entropietests zur Qualitätsanalyse

Das Projekt dient als Testlauf für schnelle, deterministische und reproduzierbare Quanten‑Simulationstechniken in .NET.

---

## 🚀 Features

- **Extrem schnelle Bit‑Erzeugung**  
  Bis zu 100 Millionen Bits in ~1.5 Sekunden (abhängig vom System).

- **Parallelisierte Qubit‑Messung**  
  Jeder Thread erhält einen eigenen Slice des Double‑Streams.

- **Quantum‑Inspired RNG**  
  Hadamard‑Gate + Messung → 0/1‑Ergebnis wie ein idealer Qubit‑Kollaps.

- **Effizientes Bit‑Packing**  
  Bits → Bytes in parallelisierten Blöcken.

- **Entropietests integriert**  
  Bit‑Bias, Runs‑Test, Autokorrelation, Byte‑Histogramm.

- **Saubere, modulare Architektur**  
  Ideal für Experimente, Forschung und Erweiterungen.

---

## 📊 Beispielhafte Entropie‑Ergebnisse

**10 Millionen Bits:**

- BitBias: p0 = 0.499941, p1 = 0.500059  
- Runs: 4'999'624 (Δ = 376 → perfekt im Erwartungsbereich)  
- Entropy per bit: **1.000000**  
- Entropy per byte: **7.9998**  
- Autokorrelation (lag 1–8): alle ≈ 0.5  
- Byte‑Histogramm: gleichmäßig verteilt

Diese Werte entsprechen einem **nahezu idealen Zufallsprozess**.

---

## 🧩 Projektstruktur

```
QuantumSim-QPRNG/
│
├── src/
│   ├── QuantumSimQPRNG/
│   │   ├── DoubleStream.cs
│   │   ├── QubitState.cs
│   │   ├── Gates/
│   │   ├── RNG/
│   │   └── QuantumSimQPRNG.csproj
│   └── QuantumSimQPRNG.Tests/
│       ├── EntropyTests.cs
│       ├── BitPackingTests.cs
│       └── QuantumSimQPRNG.Tests.csproj
│
├── docs/
│   ├── README_QPRNG.md
│   ├── Quanteninformatik/
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
│   └── images/
│
├── examples/
│   ├── Example_BitGeneration.cs
│   ├── Example_EntropyTest.cs
│   └── Example_BytePacking.cs
│
├── LICENSE
└── README.md
```
---

## 🧪 Beispiel: Bits generieren

```csharp
var qprng = new QPRNG();
var count = 100_000_000;
var bits = qprng.GenerateBits(count);
```

## 🧪 Beispiel: Bytes generieren

```csharp
var count = 1_000_000;
var qprng = new QPRNG();
var bytes = qprng.GenerateBytes(count);
```
---

## 📘 Quanteninformatik‑Skript

Im Ordner docs/Quanteninformatik befindet sich ein begleitendes Skript, das die Grundlagen der Quanteninformatik erklärt:
- Qubits
- Amplituden
- Superposition
- Quantenregister
- Gatter
- Messung
- GHZ/Bell‑Zustände
- Quanten‑RNG
- Simulationstechniken
Ideal für Einsteiger und Fortgeschrittene.

---

## 📄 Lizenz

Dieses Projekt steht unter der MIT‑Lizenz.
Du kannst den Code frei verwenden, verändern und in eigenen Projekten einsetzen.

---

## ⭐ Status

Dies ist ein experimentelles Testprojekt, das als Grundlage für weitere Forschung und Optimierung dient.
Performance‑Optimierungen, SIMD‑Versionen und GPU‑Backends sind mögliche zukünftige Erweiterungen.

---

## 🙌 Autor

**Autor und leitender Architekt**  

*Entwickelt von Michele Natale 2026*  
- QPRNG-Q1 und Cryptography Engineering   
- Konzept, Testarchitektur, Dokumentation, Implementierung

**Betreuer**  

Michele Natale 2026  
- Wartung, Weiterentwicklung, Fehlerbehebung, Release-Management

Experimentiert mit Quanten‑Simulation, HPC und .NET‑Performance.

GitHub: [https://github.com/michelenatale](https://github.com/michelenatale)

---
