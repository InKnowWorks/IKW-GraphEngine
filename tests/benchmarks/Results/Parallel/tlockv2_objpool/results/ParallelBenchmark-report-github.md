``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 1 [1607, Anniversary Update] (10.0.14393.2068)
Intel Xeon CPU E5-2690 v3 2.60GHz, 1 CPU, 24 logical cores and 12 physical cores
Frequency=2539062 Hz, Resolution=393.8462 ns, Timer=TSC
  [Host]     : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0
  Job-JFKWFM : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  Job-KNTBNH : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0

Server=True  RunStrategy=Monitoring  

```
|       Method |     Toolchain | TotalSize | CellSize | ThreadCount |          Mean |       Error |      StdDev |
|------------- |-------------- |---------- |--------- |------------ |--------------:|------------:|------------:|
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |           **1** |     **30.686 ms** |   **1.2138 ms** |   **0.8029 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |           1 |     16.874 ms |   2.7373 ms |   1.8105 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |           1 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |           1 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |           **2** |     **16.811 ms** |   **0.8143 ms** |   **0.5386 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |           2 |      8.754 ms |   1.7446 ms |   1.1540 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |           2 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |           2 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |           **4** |      **9.652 ms** |   **0.7491 ms** |   **0.4955 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |           4 |      6.588 ms |   2.2384 ms |   1.4805 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |           4 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |           4 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |           **6** |      **7.109 ms** |   **0.8944 ms** |   **0.5916 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |           6 |      3.483 ms |   0.9597 ms |   0.6348 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |           6 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |           6 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |           **8** |      **5.682 ms** |   **0.8486 ms** |   **0.5613 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |           8 |      3.048 ms |   0.8664 ms |   0.5731 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |           8 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |           8 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **10** |      **5.128 ms** |   **0.8706 ms** |   **0.5758 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          10 |      3.520 ms |   1.5652 ms |   1.0353 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          10 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          10 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **12** |      **5.593 ms** |   **0.8877 ms** |   **0.5872 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          12 |      3.334 ms |   0.8753 ms |   0.5790 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          12 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          12 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **14** |      **5.158 ms** |   **0.8324 ms** |   **0.5506 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          14 |      3.015 ms |   0.6848 ms |   0.4529 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          14 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          14 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **16** |      **4.888 ms** |   **0.9940 ms** |   **0.6574 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          16 |      3.099 ms |   1.3975 ms |   0.9243 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          16 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          16 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **18** |      **4.669 ms** |   **0.8277 ms** |   **0.5475 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          18 |      2.903 ms |   0.6618 ms |   0.4378 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          18 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          18 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **20** |      **4.605 ms** |   **0.8650 ms** |   **0.5722 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          20 |      3.022 ms |   0.7127 ms |   0.4714 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          20 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          20 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **22** |      **4.976 ms** |   **0.9914 ms** |   **0.6558 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          22 |      3.080 ms |   0.7424 ms |   0.4910 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          22 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          22 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **24** |      **4.907 ms** |   **0.9004 ms** |   **0.5955 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          24 |      3.205 ms |   0.7612 ms |   0.5035 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          24 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          24 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **26** |      **5.072 ms** |   **1.0398 ms** |   **0.6878 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          26 |      3.315 ms |   0.7181 ms |   0.4750 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          26 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          26 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **28** |      **6.496 ms** |   **1.4905 ms** |   **0.9859 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          28 |      3.516 ms |   0.7036 ms |   0.4654 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          28 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          28 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **30** |      **5.227 ms** |   **0.9377 ms** |   **0.6202 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          30 |      3.608 ms |   0.7177 ms |   0.4747 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          30 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          30 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **32** |      **5.308 ms** |   **0.8223 ms** |   **0.5439 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          32 |      3.764 ms |   0.6878 ms |   0.4549 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          32 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          32 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **34** |      **6.341 ms** |   **2.0070 ms** |   **1.3275 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          34 |      3.897 ms |   0.7803 ms |   0.5161 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          34 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          34 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **36** |      **5.495 ms** |   **0.8883 ms** |   **0.5876 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          36 |      4.101 ms |   0.8452 ms |   0.5591 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          36 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          36 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **38** |      **5.568 ms** |   **0.8764 ms** |   **0.5797 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          38 |      4.220 ms |   0.6412 ms |   0.4241 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          38 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          38 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **40** |      **6.134 ms** |   **2.3235 ms** |   **1.5368 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          40 |      4.394 ms |   0.6688 ms |   0.4424 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          40 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          40 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **42** |      **5.880 ms** |   **0.7978 ms** |   **0.5277 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          42 |      4.563 ms |   0.7307 ms |   0.4833 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          42 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          42 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **44** |      **5.953 ms** |   **0.9627 ms** |   **0.6368 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          44 |      5.595 ms |   2.2596 ms |   1.4946 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          44 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          44 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **46** |      **6.032 ms** |   **0.8882 ms** |   **0.5875 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          46 |      4.823 ms |   0.7074 ms |   0.4679 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          46 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          46 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **48** |      **6.164 ms** |   **0.8694 ms** |   **0.5751 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          48 |      5.019 ms |   0.6403 ms |   0.4235 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          48 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          48 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **50** |      **6.279 ms** |   **0.8031 ms** |   **0.5312 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          50 |      6.426 ms |   2.4321 ms |   1.6087 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          50 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          50 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **52** |      **7.938 ms** |   **4.3480 ms** |   **2.8759 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          52 |      5.445 ms |   0.7873 ms |   0.5207 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          52 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          52 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **54** |      **6.529 ms** |   **0.8436 ms** |   **0.5580 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          54 |      5.543 ms |   0.5745 ms |   0.3800 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          54 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          54 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **56** |      **7.216 ms** |   **2.2150 ms** |   **1.4651 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          56 |      5.800 ms |   0.6485 ms |   0.4289 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          56 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          56 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **58** |      **6.832 ms** |   **0.9637 ms** |   **0.6375 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          58 |      5.907 ms |   0.7566 ms |   0.5004 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          58 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          58 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **60** |      **7.086 ms** |   **1.0733 ms** |   **0.7099 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          60 |      6.014 ms |   0.6989 ms |   0.4623 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          60 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          60 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **62** |      **8.716 ms** |   **3.0712 ms** |   **2.0314 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          62 |      6.156 ms |   0.7044 ms |   0.4659 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          62 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          62 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **64** |      **8.265 ms** |   **2.2508 ms** |   **1.4887 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          64 |      6.282 ms |   0.7724 ms |   0.5109 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          64 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          64 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **66** |      **7.484 ms** |   **0.9618 ms** |   **0.6362 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          66 |      6.514 ms |   0.7286 ms |   0.4820 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          66 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          66 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **68** |      **7.947 ms** |   **2.2707 ms** |   **1.5020 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          68 |      6.720 ms |   0.7254 ms |   0.4798 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          68 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          68 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **70** |      **7.805 ms** |   **0.8170 ms** |   **0.5404 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          70 |      6.902 ms |   0.7815 ms |   0.5169 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          70 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          70 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **72** |      **7.961 ms** |   **0.9621 ms** |   **0.6364 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          72 |      8.075 ms |   1.8109 ms |   1.1978 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          72 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          72 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **74** |      **8.096 ms** |   **0.8680 ms** |   **0.5741 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          74 |      7.495 ms |   0.5880 ms |   0.3889 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          74 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          74 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **76** |      **8.236 ms** |   **0.8640 ms** |   **0.5715 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          76 |      7.704 ms |   0.4361 ms |   0.2885 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          76 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          76 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **78** |      **8.425 ms** |   **0.9668 ms** |   **0.6395 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          78 |      9.075 ms |   2.9506 ms |   1.9516 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          78 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          78 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **80** |      **8.651 ms** |   **0.9036 ms** |   **0.5976 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          80 |      7.945 ms |   0.4934 ms |   0.3264 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          80 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          80 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **82** |      **8.829 ms** |   **0.9111 ms** |   **0.6026 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          82 |      8.095 ms |   0.6682 ms |   0.4420 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          82 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          82 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **84** |     **10.693 ms** |   **3.8534 ms** |   **2.5488 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          84 |      8.194 ms |   0.6116 ms |   0.4046 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          84 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          84 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **86** |      **9.252 ms** |   **1.0273 ms** |   **0.6795 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          86 |      8.519 ms |   0.8415 ms |   0.5566 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          86 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          86 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **88** |      **9.316 ms** |   **0.9227 ms** |   **0.6103 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          88 |      8.519 ms |   0.7951 ms |   0.5259 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          88 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          88 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **90** |     **11.408 ms** |   **4.2546 ms** |   **2.8141 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          90 |      8.687 ms |   0.9913 ms |   0.6557 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          90 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          90 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **92** |      **9.730 ms** |   **0.9699 ms** |   **0.6415 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          92 |      8.751 ms |   1.0271 ms |   0.6794 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          92 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          92 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **94** |      **9.938 ms** |   **0.8909 ms** |   **0.5893 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          94 |      9.845 ms |   2.9567 ms |   1.9557 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          94 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          94 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |       **17** |          **96** |     **10.023 ms** |   **1.0490 ms** |   **0.6939 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |       17 |          96 |      9.079 ms |   0.8190 ms |   0.5417 ms |
| ParallelSave |  CsProjnet462 |   1048576 |       17 |          96 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |       17 |          96 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |           **1** |      **6.211 ms** |   **0.9147 ms** |   **0.6050 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |           1 |      2.701 ms |   1.1664 ms |   0.7715 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |           1 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |           1 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |           **2** |      **3.645 ms** |   **1.0453 ms** |   **0.6914 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |           2 |      2.052 ms |   1.0197 ms |   0.6745 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |           2 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |           2 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |           **4** |      **2.386 ms** |   **0.8291 ms** |   **0.5484 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |           4 |      1.156 ms |   0.8019 ms |   0.5304 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |           4 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |           4 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |           **6** |      **2.020 ms** |   **0.8803 ms** |   **0.5822 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |           6 |      1.130 ms |   0.6881 ms |   0.4551 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |           6 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |           6 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |           **8** |      **2.032 ms** |   **0.8743 ms** |   **0.5783 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |           8 |      1.244 ms |   0.5914 ms |   0.3912 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |           8 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |           8 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **10** |      **2.082 ms** |   **0.7467 ms** |   **0.4939 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          10 |      1.402 ms |   0.5850 ms |   0.3869 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          10 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          10 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **12** |      **2.246 ms** |   **0.8076 ms** |   **0.5342 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          12 |      1.538 ms |   0.5434 ms |   0.3594 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          12 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          12 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **14** |      **2.355 ms** |   **0.7491 ms** |   **0.4955 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          14 |      1.707 ms |   0.5348 ms |   0.3537 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          14 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          14 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **16** |      **2.507 ms** |   **0.8841 ms** |   **0.5847 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          16 |      1.921 ms |   0.5420 ms |   0.3585 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          16 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          16 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **18** |      **2.655 ms** |   **0.8233 ms** |   **0.5445 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          18 |      2.095 ms |   0.5176 ms |   0.3423 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          18 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          18 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **20** |      **2.802 ms** |   **0.8171 ms** |   **0.5405 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          20 |      2.268 ms |   0.5401 ms |   0.3572 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          20 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          20 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **22** |      **2.984 ms** |   **0.8851 ms** |   **0.5854 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          22 |      2.408 ms |   0.7123 ms |   0.4712 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          22 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          22 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **24** |      **3.203 ms** |   **0.8012 ms** |   **0.5299 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          24 |      2.523 ms |   0.5645 ms |   0.3734 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          24 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          24 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **26** |      **3.336 ms** |   **0.8155 ms** |   **0.5394 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          26 |      2.695 ms |   0.5533 ms |   0.3660 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          26 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          26 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **28** |      **3.528 ms** |   **0.9613 ms** |   **0.6358 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          28 |      2.840 ms |   0.5908 ms |   0.3908 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          28 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          28 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **30** |      **3.607 ms** |   **0.8387 ms** |   **0.5548 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          30 |      3.036 ms |   0.5272 ms |   0.3487 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          30 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          30 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **32** |      **3.768 ms** |   **0.8582 ms** |   **0.5677 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          32 |      3.208 ms |   0.6009 ms |   0.3975 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          32 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          32 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **34** |      **4.029 ms** |   **0.8154 ms** |   **0.5393 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          34 |      3.381 ms |   0.5912 ms |   0.3910 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          34 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          34 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **36** |      **4.269 ms** |   **0.7973 ms** |   **0.5273 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          36 |      3.634 ms |   0.5217 ms |   0.3450 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          36 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          36 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **38** |      **4.453 ms** |   **0.8065 ms** |   **0.5334 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          38 |      3.852 ms |   0.5004 ms |   0.3310 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          38 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          38 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **40** |      **4.710 ms** |   **0.6895 ms** |   **0.4560 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          40 |      4.066 ms |   0.5978 ms |   0.3954 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          40 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          40 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **42** |      **4.884 ms** |   **0.7866 ms** |   **0.5203 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          42 |      4.331 ms |   0.4812 ms |   0.3183 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          42 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          42 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **44** |      **4.986 ms** |   **0.7733 ms** |   **0.5115 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          44 |      4.531 ms |   0.4700 ms |   0.3109 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          44 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          44 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **46** |      **5.223 ms** |   **0.8145 ms** |   **0.5387 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          46 |      4.801 ms |   0.6522 ms |   0.4314 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          46 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          46 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **48** |      **5.431 ms** |   **0.9082 ms** |   **0.6007 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          48 |      4.958 ms |   0.7328 ms |   0.4847 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          48 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          48 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **50** |      **5.459 ms** |   **0.8158 ms** |   **0.5396 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          50 |      5.145 ms |   0.5385 ms |   0.3562 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          50 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          50 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **52** |      **5.682 ms** |   **0.9620 ms** |   **0.6363 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          52 |      5.356 ms |   0.4852 ms |   0.3209 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          52 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          52 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **54** |      **5.787 ms** |   **0.8903 ms** |   **0.5889 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          54 |      5.494 ms |   0.5982 ms |   0.3957 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          54 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          54 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **56** |      **6.016 ms** |   **0.8675 ms** |   **0.5738 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          56 |      5.710 ms |   0.5407 ms |   0.3576 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          56 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          56 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **58** |      **6.129 ms** |   **0.8606 ms** |   **0.5692 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          58 |      5.911 ms |   0.5606 ms |   0.3708 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          58 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          58 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **60** |      **6.240 ms** |   **0.9176 ms** |   **0.6069 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          60 |      6.128 ms |   0.6643 ms |   0.4394 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          60 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          60 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **62** |      **6.390 ms** |   **0.8302 ms** |   **0.5491 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          62 |      6.304 ms |   0.5071 ms |   0.3354 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          62 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          62 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **64** |      **6.564 ms** |   **0.8367 ms** |   **0.5534 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          64 |      6.463 ms |   0.5681 ms |   0.3757 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          64 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          64 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **66** |      **6.733 ms** |   **0.8773 ms** |   **0.5803 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          66 |      6.640 ms |   0.7073 ms |   0.4678 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          66 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          66 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **68** |      **6.945 ms** |   **0.8501 ms** |   **0.5623 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          68 |      6.828 ms |   0.5811 ms |   0.3844 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          68 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          68 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **70** |      **7.070 ms** |   **0.9246 ms** |   **0.6116 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          70 |      7.086 ms |   0.6190 ms |   0.4094 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          70 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          70 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **72** |      **7.223 ms** |   **1.0188 ms** |   **0.6739 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          72 |      7.207 ms |   0.5793 ms |   0.3832 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          72 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          72 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **74** |      **7.406 ms** |   **0.8797 ms** |   **0.5818 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          74 |      7.441 ms |   0.6220 ms |   0.4114 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          74 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          74 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **76** |      **7.657 ms** |   **0.9510 ms** |   **0.6290 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          76 |      7.582 ms |   0.6326 ms |   0.4185 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          76 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          76 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **78** |      **7.796 ms** |   **1.0258 ms** |   **0.6785 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          78 |      7.809 ms |   0.5986 ms |   0.3959 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          78 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          78 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **80** |      **8.040 ms** |   **0.9998 ms** |   **0.6613 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          80 |      7.921 ms |   0.5492 ms |   0.3633 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          80 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          80 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **82** |      **8.253 ms** |   **0.8989 ms** |   **0.5945 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          82 |      8.223 ms |   0.8292 ms |   0.5485 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          82 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          82 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **84** |      **8.441 ms** |   **0.9121 ms** |   **0.6033 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          84 |      8.276 ms |   0.5970 ms |   0.3949 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          84 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          84 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **86** |      **8.688 ms** |   **0.9269 ms** |   **0.6131 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          86 |      8.465 ms |   0.6637 ms |   0.4390 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          86 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          86 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **88** |      **8.864 ms** |   **0.8123 ms** |   **0.5373 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          88 |      8.589 ms |   0.6311 ms |   0.4174 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          88 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          88 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **90** |      **9.253 ms** |   **1.0394 ms** |   **0.6875 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          90 |      8.819 ms |   0.6578 ms |   0.4351 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          90 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          90 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **92** |      **9.463 ms** |   **0.9570 ms** |   **0.6330 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          92 |      8.934 ms |   0.6697 ms |   0.4430 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          92 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          92 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **94** |      **9.670 ms** |   **0.7879 ms** |   **0.5212 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          94 |      9.214 ms |   0.7231 ms |   0.4783 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          94 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          94 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** |   **1048576** |      **134** |          **96** |      **9.846 ms** |   **0.8721 ms** |   **0.5769 ms** |
|  ParallelUse | .NET Core 2.0 |   1048576 |      134 |          96 |      9.286 ms |   0.6923 ms |   0.4579 ms |
| ParallelSave |  CsProjnet462 |   1048576 |      134 |          96 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 |   1048576 |      134 |          96 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |           **1** | **15,141.499 ms** | **211.8230 ms** | **140.1078 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |           1 | 10,246.319 ms | 136.6589 ms |  90.3914 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |           1 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |           1 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |           **2** |  **8,322.254 ms** | **327.5550 ms** | **216.6574 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |           2 |  5,258.986 ms |  43.2559 ms |  28.6111 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |           2 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |           2 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |           **4** |  **4,432.060 ms** | **135.8596 ms** |  **89.8627 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |           4 |  2,703.682 ms |  26.1617 ms |  17.3043 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |           4 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |           4 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |           **6** |  **3,122.996 ms** |  **91.9729 ms** |  **60.8344 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |           6 |  1,834.864 ms |  49.2634 ms |  32.5847 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |           6 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |           6 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |           **8** |  **2,399.176 ms** |  **63.9119 ms** |  **42.2738 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |           8 |  1,400.022 ms |  46.1793 ms |  30.5447 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |           8 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |           8 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **10** |  **1,974.077 ms** |  **38.4807 ms** |  **25.4526 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          10 |  1,192.673 ms | 126.8642 ms |  83.9128 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          10 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          10 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **12** |  **1,709.379 ms** |  **46.1593 ms** |  **30.5315 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          12 |  1,053.019 ms |  85.7200 ms |  56.6985 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          12 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          12 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **14** |  **1,586.493 ms** |  **32.6313 ms** |  **21.5836 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          14 |  1,058.225 ms |  48.9144 ms |  32.3539 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          14 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          14 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **16** |  **1,508.398 ms** |  **32.8582 ms** |  **21.7337 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          16 |    959.366 ms |  14.8946 ms |   9.8519 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          16 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          16 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **18** |  **1,417.855 ms** |  **17.8583 ms** |  **11.8121 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          18 |    862.406 ms |  13.8681 ms |   9.1729 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          18 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          18 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **20** |  **1,323.272 ms** |  **36.6545 ms** |  **24.2447 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          20 |    793.422 ms |  29.4294 ms |  19.4657 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          20 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          20 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **22** |  **1,246.200 ms** |  **12.7227 ms** |   **8.4153 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          22 |    739.824 ms |  34.1258 ms |  22.5721 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          22 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          22 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **24** |  **1,201.543 ms** |  **31.7431 ms** |  **20.9961 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          24 |    752.281 ms |  88.0420 ms |  58.2343 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          24 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          24 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **26** |  **1,258.723 ms** |  **55.7808 ms** |  **36.8956 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          26 |  1,072.352 ms |  13.4177 ms |   8.8750 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          26 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          26 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **28** |  **1,240.353 ms** |  **47.0249 ms** |  **31.1041 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          28 |  1,022.595 ms |  41.7661 ms |  27.6257 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          28 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          28 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **30** |  **1,251.596 ms** |  **45.2733 ms** |  **29.9455 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          30 |    949.277 ms |  10.3215 ms |   6.8270 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          30 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          30 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **32** |  **1,265.970 ms** |  **52.5566 ms** |  **34.7629 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          32 |    907.580 ms |  39.4119 ms |  26.0685 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          32 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          32 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **34** |  **1,249.871 ms** |  **54.6904 ms** |  **36.1743 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          34 |    870.452 ms |  41.0501 ms |  27.1521 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          34 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          34 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **36** |  **1,268.014 ms** |  **39.3365 ms** |  **26.0187 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          36 |    815.279 ms |  24.0609 ms |  15.9148 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          36 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          36 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **38** |  **1,328.051 ms** | **338.8779 ms** | **224.1468 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          38 |    838.332 ms |  16.4154 ms |  10.8578 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          38 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          38 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **40** |  **1,240.963 ms** |  **31.6369 ms** |  **20.9258 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          40 |    798.898 ms |   7.0367 ms |   4.6544 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          40 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          40 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **42** |  **1,246.054 ms** |  **41.7850 ms** |  **27.6382 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          42 |    771.593 ms |   6.0742 ms |   4.0177 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          42 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          42 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **44** |  **1,252.868 ms** |  **60.3451 ms** |  **39.9146 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          44 |    742.167 ms |  10.6892 ms |   7.0702 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          44 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          44 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **46** |  **1,257.391 ms** |  **49.5969 ms** |  **32.8053 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          46 |    729.098 ms |  33.3100 ms |  22.0325 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          46 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          46 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **48** |  **1,253.914 ms** |  **61.7083 ms** |  **40.8162 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          48 |    771.504 ms |  66.6894 ms |  44.1109 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          48 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          48 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **50** |  **1,264.328 ms** |  **67.4380 ms** |  **44.6060 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          50 |    878.786 ms |   8.8399 ms |   5.8471 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          50 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          50 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **52** |  **1,245.524 ms** |  **34.1072 ms** |  **22.5598 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          52 |    861.810 ms |   6.6593 ms |   4.4047 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          52 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          52 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **54** |  **1,255.663 ms** |  **62.6007 ms** |  **41.4065 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          54 |    840.641 ms |  10.4950 ms |   6.9418 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          54 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          54 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **56** |  **1,254.549 ms** |  **56.8135 ms** |  **37.5786 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          56 |    812.601 ms |  18.7332 ms |  12.3909 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          56 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          56 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **58** |  **1,245.806 ms** |  **53.4474 ms** |  **35.3522 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          58 |    789.179 ms |  16.2643 ms |  10.7578 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          58 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          58 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **60** |  **1,253.351 ms** |  **47.2712 ms** |  **31.2669 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          60 |    780.273 ms |  22.5954 ms |  14.9455 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          60 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          60 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **62** |            **NA** |          **NA** |          **NA** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          62 |    782.486 ms |   5.6210 ms |   3.7179 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          62 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          62 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **64** |  **1,254.569 ms** |  **74.0970 ms** |  **49.0106 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          64 |    764.985 ms |  11.9527 ms |   7.9060 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          64 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          64 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **66** |            **NA** |          **NA** |          **NA** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          66 |    743.658 ms |   8.9265 ms |   5.9043 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          66 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          66 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **68** |  **1,255.542 ms** |  **54.8614 ms** |  **36.2874 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          68 |    729.715 ms |  10.8617 ms |   7.1843 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          68 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          68 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **70** |  **1,258.636 ms** |  **55.6402 ms** |  **36.8025 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          70 |    718.445 ms |  16.6952 ms |  11.0428 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          70 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          70 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **72** |  **1,270.999 ms** |  **77.8927 ms** |  **51.5212 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          72 |    779.644 ms |  67.7742 ms |  44.8285 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          72 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          72 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **74** |  **1,233.099 ms** |  **64.1580 ms** |  **42.4365 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          74 |    822.490 ms |  11.3159 ms |   7.4848 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          74 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          74 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **76** |  **1,254.214 ms** |  **81.2761 ms** |  **53.7591 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          76 |    814.563 ms |  11.6420 ms |   7.7005 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          76 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          76 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **78** |  **1,288.396 ms** | **123.9792 ms** |  **82.0046 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          78 |    792.996 ms |  15.2940 ms |  10.1160 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          78 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          78 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **80** |  **1,264.799 ms** |  **76.2518 ms** |  **50.4359 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          80 |    775.108 ms |   8.5994 ms |   5.6880 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          80 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          80 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **82** |  **1,279.370 ms** |  **86.7967 ms** |  **57.4107 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          82 |            NA |          NA |          NA |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          82 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          82 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **84** |  **1,271.153 ms** | **106.5464 ms** |  **70.4739 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          84 |    759.172 ms |  17.5447 ms |  11.6048 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          84 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          84 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **86** |  **1,260.389 ms** | **122.8420 ms** |  **81.2524 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          86 |    755.544 ms |   3.3591 ms |   2.2218 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          86 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          86 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **88** |  **1,255.900 ms** |  **69.0416 ms** |  **45.6668 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          88 |    744.955 ms |  10.1286 ms |   6.6994 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          88 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          88 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **90** |            **NA** |          **NA** |          **NA** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          90 |    713.390 ms |   4.8003 ms |   3.1751 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          90 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          90 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **92** |  **1,248.425 ms** |  **62.2504 ms** |  **41.1748 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          92 |    715.963 ms |   7.7668 ms |   5.1373 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          92 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          92 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **94** |  **1,314.714 ms** | **127.8182 ms** |  **84.5438 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          94 |    710.832 ms |  32.2750 ms |  21.3479 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          94 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          94 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |       **17** |          **96** |            **NA** |          **NA** |          **NA** |
|  ParallelUse | .NET Core 2.0 | 536870912 |       17 |          96 |    789.002 ms |  65.9179 ms |  43.6006 ms |
| ParallelSave |  CsProjnet462 | 536870912 |       17 |          96 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |       17 |          96 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |           **1** |  **2,452.509 ms** |  **51.9378 ms** |  **34.3536 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |           1 |  1,277.259 ms |  30.3120 ms |  20.0495 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |           1 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |           1 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |           **2** |  **1,336.380 ms** |  **43.8976 ms** |  **29.0356 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |           2 |    649.008 ms |  15.2368 ms |  10.0782 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |           2 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |           2 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |           **4** |    **704.389 ms** |  **23.6183 ms** |  **15.6220 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |           4 |    331.304 ms |   6.0045 ms |   3.9716 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |           4 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |           4 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |           **6** |    **493.921 ms** |  **15.8267 ms** |  **10.4684 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |           6 |    225.047 ms |   4.3176 ms |   2.8558 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |           6 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |           6 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |           **8** |    **379.744 ms** |   **9.9099 ms** |   **6.5548 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |           8 |    170.465 ms |   4.7067 ms |   3.1132 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |           8 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |           8 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **10** |    **319.851 ms** |   **9.0247 ms** |   **5.9693 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          10 |    141.966 ms |   9.0594 ms |   5.9922 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          10 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          10 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **12** |    **284.962 ms** |  **23.5984 ms** |  **15.6089 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          12 |    131.138 ms |  18.4727 ms |  12.2185 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          12 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          12 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **14** |    **287.492 ms** |   **7.9440 ms** |   **5.2544 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          14 |    133.668 ms |   3.9296 ms |   2.5992 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          14 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          14 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **16** |    **274.190 ms** |   **6.6355 ms** |   **4.3890 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          16 |    116.085 ms |   2.3853 ms |   1.5777 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          16 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          16 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **18** |    **265.468 ms** |   **8.3945 ms** |   **5.5525 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          18 |    103.857 ms |   5.3255 ms |   3.5225 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          18 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          18 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **20** |    **264.495 ms** |   **9.2110 ms** |   **6.0925 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          20 |     97.582 ms |   3.0096 ms |   1.9906 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          20 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          20 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **22** |    **281.610 ms** |  **15.0866 ms** |   **9.9788 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          22 |     88.686 ms |   2.0892 ms |   1.3819 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          22 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          22 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **24** |    **296.600 ms** |  **22.7828 ms** |  **15.0694 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          24 |    103.596 ms |  40.2215 ms |  26.6040 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          24 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          24 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **26** |    **338.907 ms** |  **18.3247 ms** |  **12.1207 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          26 |    125.723 ms |   3.8154 ms |   2.5237 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          26 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          26 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **28** |    **336.127 ms** |  **18.3668 ms** |  **12.1485 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          28 |    118.475 ms |   3.5033 ms |   2.3172 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          28 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          28 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **30** |    **327.985 ms** |  **16.7681 ms** |  **11.0911 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          30 |    113.273 ms |   3.7070 ms |   2.4520 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          30 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          30 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **32** |    **325.512 ms** |  **12.5050 ms** |   **8.2713 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          32 |    108.662 ms |   6.0868 ms |   4.0261 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          32 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          32 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **34** |    **311.817 ms** |  **13.6679 ms** |   **9.0405 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          34 |    106.408 ms |   5.2190 ms |   3.4521 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          34 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          34 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **36** |    **299.483 ms** |  **11.3021 ms** |   **7.4756 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          36 |    101.533 ms |   3.9223 ms |   2.5943 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          36 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          36 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **38** |    **306.322 ms** |  **12.0359 ms** |   **7.9610 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          38 |     99.607 ms |   1.3081 ms |   0.8652 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          38 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          38 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **40** |    **301.042 ms** |  **11.9157 ms** |   **7.8815 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          40 |     97.252 ms |   1.2575 ms |   0.8318 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          40 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          40 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **42** |    **301.773 ms** |  **13.6860 ms** |   **9.0525 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          42 |     92.856 ms |   1.8566 ms |   1.2280 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          42 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          42 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **44** |    **299.716 ms** |  **11.7141 ms** |   **7.7482 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          44 |     86.550 ms |   1.4088 ms |   0.9318 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          44 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          44 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **46** |    **293.071 ms** |  **14.1730 ms** |   **9.3746 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          46 |     84.821 ms |   1.1535 ms |   0.7630 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          46 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          46 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **48** |    **300.207 ms** |  **18.6567 ms** |  **12.3402 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          48 |     86.108 ms |   3.3100 ms |   2.1894 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          48 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          48 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **50** |    **314.473 ms** |  **17.9393 ms** |  **11.8658 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          50 |    106.030 ms |   1.5298 ms |   1.0119 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          50 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          50 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **52** |    **315.715 ms** |  **14.3743 ms** |   **9.5077 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          52 |    105.064 ms |   3.1203 ms |   2.0639 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          52 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          52 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **54** |    **305.180 ms** |  **15.2122 ms** |  **10.0619 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          54 |    102.305 ms |   5.6224 ms |   3.7189 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          54 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          54 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **56** |    **301.796 ms** |  **15.7189 ms** |  **10.3971 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          56 |    101.859 ms |   3.4054 ms |   2.2525 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          56 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          56 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **58** |    **307.042 ms** |  **17.3017 ms** |  **11.4440 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          58 |    100.212 ms |   3.1007 ms |   2.0509 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          58 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          58 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **60** |    **314.917 ms** |  **12.5967 ms** |   **8.3320 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          60 |     98.408 ms |   1.2493 ms |   0.8264 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          60 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          60 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **62** |    **308.226 ms** |  **15.7353 ms** |  **10.4079 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          62 |     93.984 ms |   1.2551 ms |   0.8302 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          62 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          62 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **64** |    **315.458 ms** |  **16.0973 ms** |  **10.6473 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          64 |     92.184 ms |   0.8166 ms |   0.5401 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          64 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          64 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **66** |    **301.826 ms** |  **18.2955 ms** |  **12.1013 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          66 |     90.628 ms |   1.0446 ms |   0.6910 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          66 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          66 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **68** |    **314.917 ms** |  **14.4644 ms** |   **9.5673 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          68 |     89.636 ms |   1.3673 ms |   0.9044 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          68 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          68 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **70** |    **308.434 ms** |  **14.1948 ms** |   **9.3890 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          70 |     87.875 ms |   1.7770 ms |   1.1754 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          70 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          70 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **72** |    **330.383 ms** | **116.6695 ms** |  **77.1696 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          72 |     92.093 ms |   7.4115 ms |   4.9022 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          72 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          72 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **74** |    **304.498 ms** |  **14.2910 ms** |   **9.4526 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          74 |    101.231 ms |   1.3789 ms |   0.9121 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          74 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          74 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **76** |    **316.861 ms** |  **19.1448 ms** |  **12.6631 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          76 |     98.872 ms |   2.8138 ms |   1.8612 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          76 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          76 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **78** |    **316.112 ms** |  **18.7762 ms** |  **12.4193 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          78 |     98.261 ms |   3.9382 ms |   2.6049 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          78 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          78 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **80** |    **311.864 ms** |  **15.8631 ms** |  **10.4924 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          80 |     97.464 ms |   3.0799 ms |   2.0372 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          80 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          80 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **82** |    **316.461 ms** |  **16.0507 ms** |  **10.6166 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          82 |     96.042 ms |   1.3436 ms |   0.8887 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          82 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          82 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **84** |    **303.831 ms** |  **17.4535 ms** |  **11.5444 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          84 |     95.985 ms |   0.8156 ms |   0.5395 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          84 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          84 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **86** |    **315.867 ms** |  **13.5588 ms** |   **8.9683 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          86 |     92.631 ms |   1.3382 ms |   0.8851 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          86 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          86 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **88** |    **305.653 ms** |  **15.7951 ms** |  **10.4475 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          88 |     92.265 ms |   2.4699 ms |   1.6337 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          88 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          88 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **90** |    **304.074 ms** |  **18.1809 ms** |  **12.0255 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          90 |     89.959 ms |   1.0868 ms |   0.7189 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          90 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          90 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **92** |    **315.165 ms** |  **15.4626 ms** |  **10.2276 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          92 |     88.701 ms |   1.5543 ms |   1.0281 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          92 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          92 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **94** |    **307.163 ms** |  **15.3414 ms** |  **10.1474 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          94 |     91.637 ms |   5.7389 ms |   3.7960 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          94 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          94 |            NA |          NA |          NA |
| **ParallelSave** | **.NET Core 2.0** | **536870912** |      **134** |          **96** |    **305.954 ms** |  **16.3187 ms** |  **10.7938 ms** |
|  ParallelUse | .NET Core 2.0 | 536870912 |      134 |          96 |     93.658 ms |   3.8312 ms |   2.5341 ms |
| ParallelSave |  CsProjnet462 | 536870912 |      134 |          96 |            NA |          NA |          NA |
|  ParallelUse |  CsProjnet462 | 536870912 |      134 |          96 |            NA |          NA |          NA |

Benchmarks with issues:
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=1]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=1]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=2]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=2]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=4]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=4]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=6]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=6]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=8]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=8]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=10]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=10]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=12]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=12]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=14]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=14]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=16]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=16]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=18]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=18]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=20]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=20]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=22]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=22]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=24]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=24]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=26]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=26]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=28]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=28]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=30]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=30]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=32]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=32]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=34]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=34]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=36]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=36]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=38]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=38]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=40]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=40]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=42]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=42]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=44]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=44]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=46]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=46]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=48]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=48]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=50]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=50]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=52]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=52]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=54]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=54]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=56]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=56]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=58]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=58]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=60]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=60]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=62]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=62]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=64]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=64]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=66]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=66]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=68]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=68]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=70]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=70]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=72]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=72]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=74]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=74]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=76]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=76]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=78]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=78]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=80]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=80]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=82]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=82]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=84]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=84]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=86]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=86]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=88]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=88]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=90]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=90]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=92]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=92]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=94]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=94]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=96]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=17, ThreadCount=96]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=1]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=1]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=2]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=2]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=4]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=4]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=6]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=6]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=8]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=8]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=10]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=10]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=12]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=12]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=14]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=14]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=16]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=16]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=18]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=18]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=20]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=20]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=22]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=22]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=24]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=24]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=26]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=26]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=28]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=28]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=30]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=30]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=32]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=32]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=34]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=34]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=36]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=36]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=38]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=38]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=40]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=40]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=42]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=42]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=44]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=44]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=46]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=46]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=48]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=48]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=50]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=50]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=52]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=52]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=54]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=54]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=56]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=56]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=58]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=58]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=60]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=60]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=62]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=62]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=64]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=64]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=66]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=66]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=68]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=68]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=70]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=70]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=72]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=72]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=74]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=74]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=76]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=76]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=78]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=78]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=80]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=80]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=82]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=82]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=84]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=84]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=86]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=86]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=88]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=88]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=90]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=90]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=92]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=92]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=94]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=94]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=96]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=1048576, CellSize=134, ThreadCount=96]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=1]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=1]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=2]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=2]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=4]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=4]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=6]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=6]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=8]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=8]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=10]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=10]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=12]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=12]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=14]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=14]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=16]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=16]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=18]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=18]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=20]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=20]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=22]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=22]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=24]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=24]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=26]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=26]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=28]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=28]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=30]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=30]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=32]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=32]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=34]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=34]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=36]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=36]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=38]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=38]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=40]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=40]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=42]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=42]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=44]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=44]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=46]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=46]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=48]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=48]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=50]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=50]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=52]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=52]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=54]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=54]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=56]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=56]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=58]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=58]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=60]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=60]
  ParallelBenchmark.ParallelSave: Job-JFKWFM(Server=True, Toolchain=.NET Core 2.0, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=62]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=62]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=62]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=64]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=64]
  ParallelBenchmark.ParallelSave: Job-JFKWFM(Server=True, Toolchain=.NET Core 2.0, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=66]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=66]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=66]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=68]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=68]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=70]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=70]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=72]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=72]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=74]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=74]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=76]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=76]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=78]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=78]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=80]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=80]
  ParallelBenchmark.ParallelUse: Job-JFKWFM(Server=True, Toolchain=.NET Core 2.0, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=82]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=82]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=82]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=84]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=84]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=86]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=86]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=88]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=88]
  ParallelBenchmark.ParallelSave: Job-JFKWFM(Server=True, Toolchain=.NET Core 2.0, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=90]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=90]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=90]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=92]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=92]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=94]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=94]
  ParallelBenchmark.ParallelSave: Job-JFKWFM(Server=True, Toolchain=.NET Core 2.0, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=96]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=96]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=17, ThreadCount=96]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=1]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=1]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=2]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=2]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=4]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=4]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=6]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=6]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=8]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=8]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=10]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=10]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=12]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=12]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=14]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=14]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=16]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=16]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=18]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=18]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=20]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=20]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=22]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=22]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=24]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=24]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=26]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=26]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=28]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=28]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=30]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=30]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=32]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=32]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=34]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=34]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=36]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=36]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=38]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=38]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=40]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=40]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=42]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=42]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=44]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=44]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=46]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=46]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=48]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=48]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=50]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=50]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=52]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=52]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=54]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=54]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=56]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=56]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=58]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=58]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=60]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=60]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=62]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=62]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=64]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=64]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=66]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=66]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=68]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=68]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=70]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=70]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=72]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=72]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=74]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=74]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=76]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=76]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=78]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=78]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=80]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=80]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=82]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=82]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=84]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=84]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=86]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=86]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=88]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=88]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=90]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=90]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=92]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=92]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=94]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=94]
  ParallelBenchmark.ParallelSave: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=96]
  ParallelBenchmark.ParallelUse: Job-KNTBNH(Server=True, Toolchain=CsProjnet462, RunStrategy=Monitoring) [TotalSize=536870912, CellSize=134, ThreadCount=96]
