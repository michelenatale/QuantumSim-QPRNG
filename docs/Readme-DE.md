# QuantumSim‑QPRNG  

**Status**: ✅   
**Version**: 0.0.1   
**Last Updated**: 2026.06.08

**Parallel Quantum‑Inspired Random Bit Generator**

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
│   ├── QPRNG-Q1/
│   │   ├── QPRNG-Q1
│   │   │   ├── Entropie
│   │   │   │   └── EntropieTest.cs
│   │   │   ├── Mathematic
│   │   │   │   ├── Cx.cs
│   │   │   │   ├── DoubleStream.cs
│   │   │   │   ├── HadamardGate.cs
│   │   │   │   └── QubitState.cs
│   │   │   ├── IQuantumGate.cs
│   │   │   └── QPRNG.cs
│   │   ├── Program.cs
│   │   ├── QPRNG-Q1.csproj
│   │   └── QPRNG-Q1.slnx
│   └── QPRNG-Multi-Qubits/
│       ├── EntropyTests.cs
│       ├── BitPackingTests.cs
│       └── QuantumSimQPRNG.Tests.csproj
│
├── docs/
│   ├── README_QPRNG.md
│   ├── Quanteninformatik/   # German quantum computing script
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

## ⚡ High‑Performance Computing (HPC)

Unter Hochleistungsrechnen versteht man Techniken und Architekturen, die darauf ausgelegt sind, groß angelegte Berechnungen mit maximaler Effizienz durchzuführen. 

HPC konzentriert sich auf:
- parallele Ausführung über mehrere CPU-Kerne hinweg  
- effizienten Speicherzugriff und cache-optimierte Algorithmen  
- vektorisierte Operationen (SIMD)  
- numerische Verarbeitung mit hohem Durchsatz  
- deterministische und reproduzierbare Leistung im großen Maßstab  

QuantumSim-QPRNG nutzt HPC-Prinzipien, um Millionen quanteninspirierter Zufallsbits mit minimalem Overhead zu generieren, wobei parallele Messungen, vorberechnete Datenströme und optimiertes Bit-Packing zum Einsatz kommen.

---

## 🇬🇧 English Version (Dokumentation)

Eine vollständige deutschsprachige Version der Dokumentation finden Sie unter:

[Readme English](https://github.com/michelenatale/QuantumSim-QPRNG/blob/main/README.md)

---

## 📘 Quanteninformatik‑Skript

Im Ordner [docs/Script](Script) befindet sich ein begleitendes Skript, das die Grundlagen der Quanteninformatik erklärt:
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

## 🙌 Author & Lead Architect

Developed by Michele Natale (2026)  
Quantum simulation, HPC (High‑Performance Computing), and .NET performance.

## 🔧 Maintainer

Michele Natale (2026)  
Maintenance, further development, bug fixing, and release management.

GitHub: [github.com/michelenatale](https://github.com/michelenatale)

---
