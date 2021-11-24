``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 1 [1607, Anniversary Update] (10.0.14393.2007)
Intel Xeon CPU E5-2690 v3 2.60GHz, 1 CPU, 24 logical cores and 12 physical cores
Frequency=2539061 Hz, Resolution=393.8464 ns, Timer=TSC
  [Host]     : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0
  Job-JFKWFM : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  Job-KNTBNH : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2117.0

Server=True  RunStrategy=Monitoring  

```
|       Method |     Toolchain | TotalCellCount | CellSize | ThreadCount |            Mean |        Error |       StdDev |
|------------- |-------------- |--------------- |--------- |------------ |----------------:|-------------:|-------------:|
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |           **1** |     **24,432.0 us** |   **1,128.4 us** |     **746.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |           1 |     13,721.1 us |   2,572.3 us |   1,701.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |           1 |     25,228.9 us |   1,194.3 us |     790.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |           1 |     13,276.8 us |     945.7 us |     625.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |           **2** |     **14,135.0 us** |   **1,312.4 us** |     **868.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |           2 |      7,545.9 us |   1,727.8 us |   1,142.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |           2 |     15,085.5 us |   1,544.0 us |   1,021.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |           2 |      7,122.4 us |     796.2 us |     526.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |           **4** |      **8,344.0 us** |   **1,076.5 us** |     **712.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |           4 |      4,379.3 us |   1,754.6 us |   1,160.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |           4 |      8,122.4 us |     998.1 us |     660.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |           4 |      3,972.1 us |     679.4 us |     449.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |           **6** |      **6,001.9 us** |     **998.5 us** |     **660.5 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |           6 |      3,462.6 us |   1,524.0 us |   1,008.0 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |           6 |      5,965.9 us |     937.7 us |     620.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |           6 |      3,303.9 us |     846.2 us |     559.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |           **8** |      **4,776.9 us** |     **946.7 us** |     **626.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |           8 |      2,577.3 us |     868.8 us |     574.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |           8 |      4,952.1 us |     857.1 us |     566.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |           8 |      2,828.7 us |     947.3 us |     626.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **10** |      **4,263.5 us** |     **823.9 us** |     **544.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          10 |      2,378.8 us |     731.2 us |     483.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          10 |      4,629.2 us |     880.5 us |     582.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          10 |      2,363.4 us |     522.5 us |     345.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **12** |      **4,242.6 us** |     **957.7 us** |     **633.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          12 |      2,472.6 us |     787.6 us |     520.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          12 |      4,760.7 us |     710.5 us |     470.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          12 |      2,379.4 us |     474.0 us |     313.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **14** |      **4,276.1 us** |     **834.3 us** |     **551.8 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          14 |      2,600.3 us |     917.4 us |     606.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          14 |      4,346.2 us |     790.4 us |     522.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          14 |      2,384.7 us |     485.6 us |     321.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **16** |      **3,994.0 us** |     **821.6 us** |     **543.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          16 |      2,649.8 us |   1,009.3 us |     667.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          16 |      4,018.8 us |     772.5 us |     510.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          16 |      2,313.0 us |     635.4 us |     420.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **18** |      **3,985.3 us** |   **1,343.5 us** |     **888.7 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          18 |      2,375.8 us |     636.3 us |     420.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          18 |      3,884.8 us |     832.2 us |     550.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          18 |      2,376.0 us |     553.6 us |     366.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **20** |      **3,979.8 us** |   **1,572.3 us** |   **1,040.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          20 |      2,435.2 us |     663.5 us |     438.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          20 |      4,038.9 us |     884.1 us |     584.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          20 |      2,439.4 us |     604.4 us |     399.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **22** |      **3,691.3 us** |     **804.4 us** |     **532.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          22 |      2,473.2 us |     656.3 us |     434.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          22 |      3,870.8 us |     723.2 us |     478.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          22 |      2,478.1 us |     598.2 us |     395.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **24** |      **4,065.3 us** |   **1,029.7 us** |     **681.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          24 |      2,928.8 us |   1,049.0 us |     693.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          24 |      4,034.8 us |     992.6 us |     656.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          24 |      2,528.7 us |     581.5 us |     384.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **26** |      **4,007.3 us** |     **889.4 us** |     **588.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          26 |      2,644.4 us |     846.5 us |     559.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          26 |      4,426.4 us |   1,489.8 us |     985.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          26 |      2,640.3 us |     555.6 us |     367.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **28** |      **4,208.0 us** |   **1,631.2 us** |   **1,078.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          28 |      2,745.8 us |     665.0 us |     439.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          28 |      4,170.6 us |     831.2 us |     549.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          28 |      2,776.1 us |     544.0 us |     359.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **30** |      **4,082.7 us** |     **903.5 us** |     **597.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          30 |      3,037.6 us |   1,552.9 us |   1,027.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          30 |      4,204.8 us |     776.4 us |     513.5 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          30 |      2,869.3 us |     548.0 us |     362.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **32** |      **4,241.1 us** |     **771.2 us** |     **510.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          32 |      2,953.1 us |     726.7 us |     480.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          32 |      4,376.9 us |     735.7 us |     486.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          32 |      3,711.5 us |   1,623.0 us |   1,073.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **34** |      **4,256.5 us** |     **839.4 us** |     **555.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          34 |      3,018.8 us |     684.1 us |     452.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          34 |      4,379.7 us |     783.7 us |     518.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          34 |      3,053.6 us |     548.5 us |     362.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **36** |      **4,360.4 us** |     **786.8 us** |     **520.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          36 |      3,105.3 us |     699.5 us |     462.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          36 |      5,734.2 us |   1,949.9 us |   1,289.7 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          36 |      3,196.7 us |     803.8 us |     531.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **38** |      **4,444.5 us** |     **940.3 us** |     **622.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          38 |      3,263.6 us |     672.4 us |     444.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          38 |      4,581.8 us |     728.9 us |     482.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          38 |      3,351.4 us |     717.9 us |     474.9 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **40** |      **4,439.6 us** |     **817.0 us** |     **540.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          40 |      3,965.0 us |   2,397.3 us |   1,585.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          40 |      4,594.7 us |     776.0 us |     513.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          40 |      3,471.3 us |     761.2 us |     503.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **42** |      **4,459.0 us** |     **880.4 us** |     **582.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          42 |      3,470.5 us |     699.1 us |     462.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          42 |      4,606.3 us |     802.5 us |     530.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          42 |      4,444.1 us |   2,316.4 us |   1,532.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **44** |      **4,598.8 us** |     **865.0 us** |     **572.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          44 |      3,582.3 us |     718.4 us |     475.2 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          44 |      4,731.8 us |     809.4 us |     535.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          44 |      3,725.5 us |     778.8 us |     515.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **46** |      **4,732.7 us** |   **1,015.5 us** |     **671.7 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          46 |      3,759.2 us |     665.4 us |     440.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          46 |      5,826.5 us |   2,248.0 us |   1,486.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          46 |      3,943.9 us |     753.8 us |     498.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **48** |      **4,831.2 us** |     **831.3 us** |     **549.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          48 |      3,881.4 us |     623.9 us |     412.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          48 |      4,941.0 us |     821.9 us |     543.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          48 |      4,012.2 us |     747.0 us |     494.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **50** |      **4,840.8 us** |     **913.7 us** |     **604.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          50 |      4,608.5 us |   2,681.3 us |   1,773.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          50 |      5,084.5 us |     789.3 us |     522.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          50 |      4,107.5 us |     745.6 us |     493.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **52** |      **4,969.0 us** |     **954.2 us** |     **631.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          52 |      4,112.3 us |     653.3 us |     432.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          52 |      5,264.2 us |     818.8 us |     541.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          52 |      5,492.8 us |   2,970.2 us |   1,964.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **54** |      **5,049.0 us** |     **952.9 us** |     **630.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          54 |      4,189.7 us |     654.5 us |     432.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          54 |      5,317.7 us |     956.0 us |     632.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          54 |      4,374.8 us |     769.6 us |     509.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **56** |      **5,193.1 us** |     **905.5 us** |     **598.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          56 |      4,305.7 us |     694.9 us |     459.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          56 |      6,432.5 us |   2,066.8 us |   1,367.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          56 |      4,573.9 us |     767.2 us |     507.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **58** |      **5,265.7 us** |     **858.2 us** |     **567.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          58 |      4,508.6 us |     630.0 us |     416.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          58 |      5,521.7 us |     813.2 us |     537.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          58 |      4,803.8 us |     790.3 us |     522.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **60** |      **5,399.6 us** |     **934.7 us** |     **618.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          60 |      4,890.2 us |   1,859.2 us |   1,229.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          60 |      5,557.7 us |     911.3 us |     602.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          60 |      4,916.7 us |     821.1 us |     543.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **62** |      **5,502.6 us** |     **930.7 us** |     **615.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          62 |      4,832.6 us |     685.7 us |     453.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          62 |      5,712.6 us |     849.4 us |     561.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          62 |      6,242.5 us |   2,912.4 us |   1,926.3 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **64** |      **5,594.0 us** |     **888.1 us** |     **587.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          64 |      4,989.1 us |     599.9 us |     396.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          64 |      5,771.3 us |     820.8 us |     542.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          64 |      5,031.5 us |     769.7 us |     509.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **66** |      **5,775.9 us** |   **1,023.0 us** |     **676.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          66 |      5,078.8 us |     636.8 us |     421.2 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          66 |      6,002.6 us |     797.9 us |     527.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          66 |      5,246.4 us |     756.3 us |     500.3 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **68** |      **5,887.6 us** |     **902.8 us** |     **597.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          68 |      5,185.1 us |     661.8 us |     437.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          68 |      6,093.0 us |     862.7 us |     570.7 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          68 |      5,309.0 us |     878.4 us |     581.0 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **70** |      **5,890.0 us** |     **944.1 us** |     **624.5 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          70 |      5,248.9 us |     588.1 us |     389.0 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          70 |      6,219.7 us |     813.6 us |     538.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          70 |      5,385.8 us |     762.1 us |     504.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **72** |      **6,067.7 us** |     **953.9 us** |     **630.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          72 |      5,331.8 us |     634.3 us |     419.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          72 |      6,421.1 us |     879.7 us |     581.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          72 |      5,567.5 us |     800.2 us |     529.3 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **74** |      **6,191.0 us** |   **1,025.8 us** |     **678.5 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          74 |      5,468.0 us |     774.4 us |     512.2 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          74 |      6,387.8 us |     808.8 us |     535.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          74 |      5,716.1 us |     818.5 us |     541.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **76** |      **6,349.4 us** |     **917.8 us** |     **607.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          76 |      5,631.7 us |     755.0 us |     499.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          76 |      6,568.8 us |     859.9 us |     568.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          76 |      6,073.3 us |   2,292.0 us |   1,516.0 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **78** |      **6,440.5 us** |     **886.7 us** |     **586.5 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          78 |      5,694.9 us |     789.7 us |     522.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          78 |      6,648.2 us |     819.0 us |     541.7 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          78 |      6,132.1 us |     840.5 us |     555.9 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **80** |      **6,720.5 us** |   **1,034.1 us** |     **684.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          80 |      5,869.4 us |     831.0 us |     549.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          80 |      6,932.7 us |     800.8 us |     529.7 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          80 |      6,543.3 us |   2,294.3 us |   1,517.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **82** |      **6,705.2 us** |   **1,033.6 us** |     **683.7 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          82 |      6,007.7 us |     740.8 us |     490.0 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          82 |      7,052.6 us |     837.1 us |     553.7 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          82 |      6,758.1 us |   2,170.3 us |   1,435.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **84** |      **6,752.3 us** |     **927.5 us** |     **613.5 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          84 |      6,111.3 us |     865.7 us |     572.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          84 |      7,202.3 us |     849.4 us |     561.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          84 |      6,890.8 us |   2,032.3 us |   1,344.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **86** |      **6,905.5 us** |     **954.6 us** |     **631.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          86 |      6,369.9 us |     697.0 us |     461.0 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          86 |      7,320.3 us |     871.0 us |     576.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          86 |      7,068.2 us |   2,153.8 us |   1,424.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **88** |      **7,075.9 us** |     **984.8 us** |     **651.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          88 |      6,547.4 us |     590.7 us |     390.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          88 |      7,463.1 us |     910.1 us |     602.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          88 |      7,196.4 us |   2,024.3 us |   1,338.9 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **90** |      **7,121.8 us** |   **1,024.7 us** |     **677.8 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          90 |      6,715.5 us |     674.2 us |     445.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          90 |      7,626.1 us |     831.3 us |     549.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          90 |      7,423.6 us |   2,342.2 us |   1,549.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **92** |      **7,287.2 us** |   **1,097.5 us** |     **725.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          92 |      6,849.1 us |     598.2 us |     395.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          92 |      7,781.9 us |     896.6 us |     593.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          92 |      7,487.5 us |   2,338.4 us |   1,546.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **94** |      **7,478.2 us** |     **884.7 us** |     **585.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          94 |      6,976.4 us |     538.4 us |     356.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          94 |      7,800.0 us |     824.1 us |     545.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          94 |      7,568.3 us |   2,076.2 us |   1,373.3 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |       **17** |          **96** |      **7,642.3 us** |   **1,029.8 us** |     **681.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |       17 |          96 |      7,046.9 us |     490.4 us |     324.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |       17 |          96 |      7,957.6 us |     818.5 us |     541.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |       17 |          96 |      7,571.8 us |   2,359.9 us |   1,561.0 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |           **1** |      **5,621.8 us** |   **1,035.7 us** |     **685.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |           1 |      2,155.7 us |   1,005.9 us |     665.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |           1 |      5,625.6 us |     935.7 us |     618.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |           1 |      2,058.0 us |     645.8 us |     427.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |           **2** |      **3,192.4 us** |     **952.7 us** |     **630.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |           2 |      1,319.9 us |     872.8 us |     577.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |           2 |      3,304.7 us |     868.7 us |     574.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |           2 |      1,274.8 us |     753.5 us |     498.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |           **4** |      **2,156.9 us** |     **871.3 us** |     **576.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |           4 |        978.6 us |     772.3 us |     510.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |           4 |      2,136.0 us |     823.3 us |     544.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |           4 |        970.7 us |     706.3 us |     467.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |           **6** |      **1,817.1 us** |     **878.8 us** |     **581.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |           6 |        945.4 us |     692.2 us |     457.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |           6 |      1,752.5 us |     809.0 us |     535.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |           6 |        925.3 us |     661.4 us |     437.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |           **8** |      **1,731.9 us** |     **873.8 us** |     **578.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |           8 |      1,007.9 us |     631.6 us |     417.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |           8 |      1,703.9 us |     757.9 us |     501.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |           8 |      1,017.0 us |     574.0 us |     379.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **10** |      **1,691.3 us** |     **804.2 us** |     **531.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          10 |      1,118.8 us |     520.8 us |     344.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          10 |      1,730.0 us |     784.5 us |     518.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          10 |      1,113.8 us |     497.1 us |     328.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **12** |      **1,815.1 us** |     **751.4 us** |     **497.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          12 |      1,220.0 us |     501.2 us |     331.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          12 |      1,826.5 us |     732.5 us |     484.5 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          12 |      1,215.6 us |     542.6 us |     358.9 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **14** |      **1,895.4 us** |     **805.1 us** |     **532.5 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          14 |      1,317.8 us |     572.7 us |     378.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          14 |      1,947.2 us |     773.0 us |     511.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          14 |      1,306.0 us |     551.1 us |     364.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **16** |      **2,049.9 us** |     **894.6 us** |     **591.7 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          16 |      1,428.8 us |     557.3 us |     368.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          16 |      2,035.0 us |     744.3 us |     492.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          16 |      1,482.5 us |     528.6 us |     349.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **18** |      **2,121.5 us** |     **871.1 us** |     **576.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          18 |      1,631.0 us |     522.0 us |     345.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          18 |      2,207.5 us |     820.7 us |     542.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          18 |      1,602.4 us |     559.8 us |     370.3 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **20** |      **2,207.0 us** |     **815.7 us** |     **539.5 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          20 |      1,769.2 us |     538.3 us |     356.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          20 |      2,255.2 us |     758.4 us |     501.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          20 |      1,767.2 us |     550.6 us |     364.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **22** |      **2,347.7 us** |     **836.4 us** |     **553.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          22 |      1,883.6 us |     567.2 us |     375.2 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          22 |      2,392.1 us |     768.0 us |     508.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          22 |      1,900.7 us |     532.0 us |     351.9 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **24** |      **2,478.7 us** |     **869.5 us** |     **575.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          24 |      1,988.4 us |     560.8 us |     370.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          24 |      2,497.2 us |     760.4 us |     503.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          24 |      1,994.7 us |     561.1 us |     371.1 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **26** |      **2,637.7 us** |     **951.1 us** |     **629.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          26 |      2,123.1 us |     709.3 us |     469.2 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          26 |      2,657.9 us |     777.2 us |     514.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          26 |      2,095.6 us |     553.7 us |     366.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **28** |      **2,723.5 us** |     **862.1 us** |     **570.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          28 |      2,201.1 us |     565.6 us |     374.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          28 |      2,813.5 us |     783.9 us |     518.5 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          28 |      2,250.7 us |     545.4 us |     360.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **30** |      **2,918.8 us** |     **912.0 us** |     **603.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          30 |      2,275.1 us |     573.9 us |     379.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          30 |      2,989.1 us |     750.8 us |     496.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          30 |      2,352.1 us |     591.9 us |     391.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **32** |      **2,990.7 us** |     **862.7 us** |     **570.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          32 |      2,395.2 us |     600.8 us |     397.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          32 |      3,042.7 us |     791.2 us |     523.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          32 |      2,457.3 us |     593.7 us |     392.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **34** |      **3,123.7 us** |     **832.7 us** |     **550.8 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          34 |      2,551.7 us |     587.3 us |     388.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          34 |      3,176.7 us |     784.0 us |     518.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          34 |      2,706.6 us |     781.9 us |     517.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **36** |      **3,237.6 us** |     **845.2 us** |     **559.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          36 |      2,666.8 us |     566.8 us |     374.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          36 |      3,312.8 us |     769.3 us |     508.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          36 |      2,905.2 us |     733.0 us |     484.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **38** |      **3,362.9 us** |     **912.5 us** |     **603.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          38 |      2,813.4 us |     563.6 us |     372.8 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          38 |      3,444.4 us |     790.0 us |     522.5 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          38 |      3,006.4 us |     737.6 us |     487.9 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **40** |      **3,398.8 us** |     **852.4 us** |     **563.8 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          40 |      2,980.6 us |     549.6 us |     363.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          40 |      3,658.1 us |     771.3 us |     510.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          40 |      3,170.6 us |     833.4 us |     551.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **42** |      **3,659.5 us** |     **892.5 us** |     **590.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          42 |      3,170.7 us |     490.6 us |     324.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          42 |      4,041.3 us |   1,065.9 us |     705.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          42 |      3,359.2 us |     750.1 us |     496.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **44** |      **3,865.9 us** |     **863.6 us** |     **571.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          44 |      3,411.8 us |     596.3 us |     394.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          44 |      3,983.8 us |     765.6 us |     506.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          44 |      3,393.0 us |     792.5 us |     524.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **46** |      **3,963.0 us** |     **944.1 us** |     **624.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          46 |      3,454.0 us |     560.3 us |     370.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          46 |      4,117.4 us |     776.1 us |     513.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          46 |      3,569.1 us |     953.5 us |     630.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **48** |      **4,142.3 us** |     **857.7 us** |     **567.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          48 |      3,583.8 us |     492.0 us |     325.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          48 |      4,193.4 us |     747.2 us |     494.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          48 |      3,688.6 us |     838.6 us |     554.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **50** |      **4,299.6 us** |     **900.2 us** |     **595.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          50 |      3,776.0 us |     505.7 us |     334.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          50 |      4,359.8 us |     814.4 us |     538.7 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          50 |      3,883.5 us |     811.5 us |     536.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **52** |      **4,408.0 us** |     **864.9 us** |     **572.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          52 |      3,913.5 us |     552.6 us |     365.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          52 |      4,568.1 us |     762.4 us |     504.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          52 |      4,045.2 us |     797.3 us |     527.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **54** |      **4,597.2 us** |     **920.7 us** |     **609.0 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          54 |      4,075.2 us |     526.2 us |     348.0 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          54 |      4,718.1 us |     802.3 us |     530.7 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          54 |      4,257.5 us |     862.9 us |     570.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **56** |      **4,670.3 us** |     **883.2 us** |     **584.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          56 |      4,241.8 us |     490.4 us |     324.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          56 |      4,815.2 us |     785.2 us |     519.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          56 |      4,260.6 us |     835.6 us |     552.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **58** |      **4,818.6 us** |     **893.4 us** |     **590.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          58 |      4,391.1 us |     648.1 us |     428.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          58 |      4,935.1 us |     698.7 us |     462.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          58 |      4,412.9 us |     821.9 us |     543.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **60** |      **4,903.2 us** |     **894.7 us** |     **591.8 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          60 |      4,494.7 us |     462.7 us |     306.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          60 |      5,044.1 us |     752.9 us |     498.0 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          60 |      4,648.6 us |     813.0 us |     537.8 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **62** |      **5,046.7 us** |     **984.8 us** |     **651.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          62 |      4,631.5 us |     582.2 us |     385.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          62 |      5,224.5 us |     769.9 us |     509.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          62 |      4,744.1 us |     867.1 us |     573.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **64** |      **5,098.9 us** |     **916.4 us** |     **606.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          64 |      4,814.3 us |     560.2 us |     370.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          64 |      5,323.5 us |     792.7 us |     524.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          64 |      4,923.8 us |     809.5 us |     535.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **66** |      **5,233.2 us** |     **924.6 us** |     **611.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          66 |      4,938.8 us |     550.5 us |     364.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          66 |      5,385.0 us |     804.5 us |     532.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          66 |      5,058.3 us |     791.6 us |     523.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **68** |      **5,331.4 us** |     **975.3 us** |     **645.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          68 |      5,037.8 us |     507.3 us |     335.6 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          68 |      5,520.8 us |     779.1 us |     515.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          68 |      5,112.0 us |     955.4 us |     632.0 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **70** |      **5,482.5 us** |   **1,072.1 us** |     **709.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          70 |      5,201.1 us |     625.0 us |     413.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          70 |      5,608.3 us |     780.6 us |     516.3 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          70 |      5,345.9 us |     775.9 us |     513.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **72** |      **5,566.8 us** |     **933.4 us** |     **617.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          72 |      5,382.5 us |     682.6 us |     451.5 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          72 |      5,794.4 us |     784.4 us |     518.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          72 |      5,486.2 us |     829.0 us |     548.3 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **74** |      **5,680.3 us** |   **1,074.1 us** |     **710.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          74 |      5,485.7 us |     616.8 us |     407.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          74 |      5,762.8 us |     771.7 us |     510.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          74 |      5,563.4 us |     901.0 us |     595.9 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **76** |      **5,835.5 us** |     **933.0 us** |     **617.1 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          76 |      5,628.6 us |     623.0 us |     412.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          76 |      6,020.3 us |     743.2 us |     491.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          76 |      5,817.3 us |     781.0 us |     516.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **78** |      **5,890.0 us** |     **971.1 us** |     **642.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          78 |      5,760.6 us |     681.8 us |     450.9 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          78 |      6,207.7 us |     782.3 us |     517.5 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          78 |      5,808.3 us |     805.0 us |     532.5 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **80** |      **6,024.4 us** |   **1,015.0 us** |     **671.4 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          80 |      5,906.4 us |     579.4 us |     383.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          80 |      6,378.3 us |     871.0 us |     576.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          80 |      6,005.4 us |     927.0 us |     613.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **82** |      **6,138.8 us** |   **1,010.3 us** |     **668.3 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          82 |      6,036.4 us |     576.4 us |     381.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          82 |      6,511.6 us |     737.2 us |     487.6 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          82 |      6,273.8 us |     986.4 us |     652.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **84** |      **6,324.4 us** |     **972.0 us** |     **642.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          84 |      6,167.0 us |     587.2 us |     388.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          84 |      6,643.8 us |     734.5 us |     485.8 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          84 |      6,788.1 us |   2,256.0 us |   1,492.2 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **86** |      **6,416.1 us** |     **982.1 us** |     **649.6 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          86 |      6,315.4 us |     655.0 us |     433.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          86 |      6,919.7 us |     866.4 us |     573.1 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          86 |      6,896.1 us |   2,187.1 us |   1,446.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **88** |      **6,538.2 us** |     **913.0 us** |     **603.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          88 |      6,412.1 us |     612.8 us |     405.3 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          88 |      7,113.9 us |     708.1 us |     468.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          88 |      7,065.8 us |   2,384.7 us |   1,577.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **90** |      **6,663.5 us** |     **949.3 us** |     **627.9 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          90 |      6,625.0 us |     777.7 us |     514.4 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          90 |      7,119.7 us |     841.2 us |     556.4 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          90 |      7,238.2 us |   2,277.9 us |   1,506.7 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **92** |      **6,782.9 us** |     **979.2 us** |     **647.7 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          92 |      6,702.8 us |     622.5 us |     411.7 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          92 |      7,309.4 us |     776.9 us |     513.9 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          92 |      7,371.3 us |   2,091.5 us |   1,383.4 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **94** |      **6,986.8 us** |   **1,016.2 us** |     **672.2 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          94 |      6,879.3 us |     588.1 us |     389.0 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          94 |      7,595.2 us |     820.3 us |     542.5 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          94 |      7,497.8 us |   2,016.1 us |   1,333.6 us |
| **ParallelSave** | **.NET Core 2.0** |        **1048576** |      **134** |          **96** |      **7,128.6 us** |   **1,153.0 us** |     **762.7 us** |
|  ParallelUse | .NET Core 2.0 |        1048576 |      134 |          96 |      6,983.0 us |     603.4 us |     399.1 us |
| ParallelSave |  CsProjnet462 |        1048576 |      134 |          96 |      7,711.4 us |     892.3 us |     590.2 us |
|  ParallelUse |  CsProjnet462 |        1048576 |      134 |          96 |      7,571.7 us |   2,136.3 us |   1,413.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |           **1** | **11,686,050.1 us** | **149,776.1 us** |  **99,067.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |           1 |  8,843,947.6 us | 124,954.3 us |  82,649.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |           1 | 11,989,129.7 us | 435,752.4 us | 288,223.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |           1 |  8,787,329.4 us | 145,807.9 us |  96,442.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |           **2** |  **6,986,046.1 us** |  **99,172.1 us** |  **65,596.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |           2 |  4,500,877.8 us |  55,213.2 us |  36,520.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |           2 |  6,641,109.1 us |  59,738.0 us |  39,513.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |           2 |  4,486,557.6 us |  26,373.0 us |  17,444.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |           **4** |  **3,538,128.9 us** |  **23,460.2 us** |  **15,517.4 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |           4 |  2,358,550.2 us |  58,227.8 us |  38,514.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |           4 |  3,822,568.0 us |  44,016.3 us |  29,114.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |           4 |  2,378,559.5 us |   9,993.4 us |   6,610.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |           **6** |  **2,467,859.9 us** |  **76,519.8 us** |  **50,613.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |           6 |  1,627,401.2 us |  27,855.8 us |  18,424.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |           6 |  2,499,785.0 us |  33,659.3 us |  22,263.5 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |           6 |  1,626,819.7 us |  27,093.0 us |  17,920.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |           **8** |  **2,033,929.6 us** |  **74,038.6 us** |  **48,972.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |           8 |  1,256,633.8 us |  36,018.1 us |  23,823.8 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |           8 |  1,952,299.3 us |  67,708.3 us |  44,784.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |           8 |  1,249,867.4 us |  25,212.5 us |  16,676.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **10** |  **1,584,012.9 us** |  **73,744.1 us** |  **48,777.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          10 |  1,027,724.8 us |  16,677.7 us |  11,031.3 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          10 |  1,637,885.4 us |  96,289.5 us |  63,689.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          10 |  1,026,523.7 us |  21,717.3 us |  14,364.7 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **12** |  **1,397,553.6 us** |  **70,615.3 us** |  **46,707.7 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          12 |    903,441.3 us |  18,115.8 us |  11,982.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          12 |  1,466,416.3 us |  71,787.6 us |  47,483.1 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          12 |    933,694.1 us |  92,282.2 us |  61,038.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **14** |  **1,453,820.9 us** |  **45,304.3 us** |  **29,966.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          14 |    920,356.7 us |  28,022.1 us |  18,534.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          14 |  1,477,795.1 us |  31,493.7 us |  20,831.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          14 |    911,436.8 us |  24,815.0 us |  16,413.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **16** |  **1,254,190.3 us** |  **46,405.4 us** |  **30,694.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          16 |    817,503.8 us |  13,566.2 us |   8,973.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          16 |  1,328,114.0 us |  36,219.6 us |  23,957.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          16 |    805,759.1 us |  10,966.0 us |   7,253.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **18** |  **1,245,794.0 us** |  **18,189.3 us** |  **12,031.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          18 |    741,373.7 us |  12,260.1 us |   8,109.3 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          18 |  1,267,968.2 us |  20,621.6 us |  13,639.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          18 |    731,958.9 us |  15,200.8 us |  10,054.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **20** |  **1,179,074.9 us** |  **11,281.9 us** |   **7,462.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          20 |    682,823.6 us |  11,366.1 us |   7,518.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          20 |  1,106,002.4 us |   9,794.6 us |   6,478.5 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          20 |    675,009.0 us |  13,582.5 us |   8,984.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **22** |  **1,093,166.8 us** |  **22,065.2 us** |  **14,594.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          22 |    620,191.5 us |   6,373.7 us |   4,215.8 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          22 |  1,060,460.1 us |   7,602.5 us |   5,028.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          22 |    611,279.4 us |   6,128.5 us |   4,053.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **24** |  **1,093,458.1 us** |  **48,657.4 us** |  **32,183.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          24 |    569,528.2 us |  33,566.9 us |  22,202.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          24 |  1,136,614.9 us |  40,249.0 us |  26,622.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          24 |    643,897.1 us |  85,519.8 us |  56,566.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **26** |  **2,170,962.7 us** | **170,812.3 us** | **112,981.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          26 |    923,388.1 us |  12,564.2 us |   8,310.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          26 |  2,037,484.9 us | 191,076.7 us | 126,385.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          26 |    912,413.5 us |  12,003.4 us |   7,939.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **28** |  **2,415,682.5 us** | **171,348.4 us** | **113,336.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          28 |    867,452.6 us |   7,015.1 us |   4,640.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          28 |  2,401,769.9 us | 270,802.5 us | 179,119.1 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          28 |    866,404.5 us |   8,142.6 us |   5,385.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **30** |  **2,550,338.8 us** | **220,854.5 us** | **146,081.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          30 |    819,680.9 us |   6,959.3 us |   4,603.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          30 |  2,555,831.1 us | 314,099.0 us | 207,757.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          30 |    802,653.0 us |   9,637.0 us |   6,374.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **32** |  **2,630,558.4 us** | **242,106.8 us** | **160,138.7 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          32 |    777,889.5 us |   6,627.9 us |   4,384.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          32 |  2,710,149.7 us | 213,995.7 us | 141,544.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          32 |    773,561.5 us |   3,498.7 us |   2,314.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **34** |  **2,727,322.2 us** | **324,107.3 us** | **214,376.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          34 |    734,848.6 us |   5,192.9 us |   3,434.8 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          34 |  2,744,519.5 us | 306,130.0 us | 202,486.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          34 |    729,370.5 us |   6,130.8 us |   4,055.2 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **36** |  **2,684,523.6 us** | **343,856.3 us** | **227,439.7 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          36 |    709,360.1 us |  25,361.1 us |  16,774.8 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          36 |  2,706,620.9 us | 366,092.0 us | 242,147.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          36 |    692,630.2 us |   5,469.2 us |   3,617.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **38** |  **2,686,519.6 us** | **489,964.1 us** | **324,080.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          38 |    700,574.4 us |   7,503.2 us |   4,962.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          38 |  2,540,886.6 us | 455,098.3 us | 301,019.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          38 |    693,588.9 us |  22,192.5 us |  14,678.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **40** |  **2,678,179.8 us** | **441,805.0 us** | **292,226.7 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          40 |    676,882.9 us |   9,340.1 us |   6,177.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          40 |  2,640,246.5 us | 552,452.2 us | 365,412.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          40 |    664,633.1 us |   9,269.5 us |   6,131.2 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **42** |  **2,667,120.3 us** | **324,793.3 us** | **214,830.7 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          42 |    641,771.4 us |   5,614.2 us |   3,713.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          42 |  2,600,595.1 us | 361,813.1 us | 239,317.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          42 |    645,799.5 us |   6,151.6 us |   4,068.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **44** |  **2,459,564.6 us** | **360,193.3 us** | **238,245.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          44 |    619,076.4 us |   6,186.8 us |   4,092.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          44 |  2,497,788.3 us | 372,491.5 us | 246,380.1 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          44 |    617,546.4 us |   3,436.3 us |   2,272.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **46** |  **2,426,069.0 us** | **358,422.3 us** | **237,074.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          46 |    605,054.2 us |   7,430.3 us |   4,914.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          46 |  2,280,567.8 us | 264,845.1 us | 175,178.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          46 |    599,960.4 us |   3,374.9 us |   2,232.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **48** |  **2,234,803.4 us** | **367,728.5 us** | **243,229.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          48 |    611,994.2 us |  58,502.4 us |  38,695.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          48 |  2,319,013.2 us | 319,246.1 us | 211,161.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          48 |    635,718.8 us |  49,166.8 us |  32,520.8 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **50** |  **2,324,670.0 us** | **282,227.3 us** | **186,675.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          50 |    744,116.9 us |   7,471.9 us |   4,942.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          50 |  2,197,170.4 us | 322,866.9 us | 213,556.5 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          50 |    735,119.1 us |   9,717.4 us |   6,427.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **52** |  **2,131,225.2 us** | **265,090.8 us** | **175,341.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          52 |    719,729.1 us |   6,433.1 us |   4,255.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          52 |  2,221,742.6 us | 280,653.7 us | 185,635.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          52 |    712,408.8 us |   8,930.1 us |   5,906.7 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **54** |  **2,266,040.3 us** | **179,177.9 us** | **118,515.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          54 |    698,646.0 us |   5,094.2 us |   3,369.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          54 |  2,189,797.6 us | 218,193.7 us | 144,321.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          54 |    694,180.3 us |   6,764.5 us |   4,474.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **56** |  **2,340,908.4 us** | **311,279.5 us** | **205,892.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          56 |    679,301.6 us |   8,631.4 us |   5,709.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          56 |  2,222,897.9 us | 206,903.4 us | 136,853.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          56 |    678,689.3 us |   5,238.4 us |   3,464.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **58** |  **2,207,434.2 us** | **233,409.0 us** | **154,385.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          58 |    664,555.7 us |   9,865.1 us |   6,525.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          58 |  2,316,424.3 us | 145,941.6 us |  96,531.3 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          58 |    661,100.5 us |   7,163.6 us |   4,738.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **60** |  **2,416,004.1 us** | **292,551.9 us** | **193,505.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          60 |    657,735.4 us |  18,176.6 us |  12,022.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          60 |  2,194,345.2 us | 311,833.1 us | 206,258.3 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          60 |    651,750.5 us |  14,985.2 us |   9,911.8 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **62** |  **2,254,286.0 us** | **392,441.2 us** | **259,575.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          62 |    651,576.0 us |   7,255.3 us |   4,798.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          62 |  2,225,004.9 us | 420,365.6 us | 278,045.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          62 |    645,603.8 us |   4,215.5 us |   2,788.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **64** |  **2,280,261.9 us** | **168,720.2 us** | **111,598.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          64 |    633,147.1 us |   5,710.4 us |   3,777.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          64 |  2,257,179.7 us | 346,944.6 us | 229,482.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          64 |    628,514.6 us |   4,684.3 us |   3,098.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **66** |  **2,179,200.0 us** | **336,074.0 us** | **222,292.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          66 |    621,890.2 us |   7,283.9 us |   4,817.8 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          66 |  2,410,365.7 us | 444,883.2 us | 294,262.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          66 |    613,078.8 us |   6,366.2 us |   4,210.8 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **68** |  **2,333,674.4 us** | **355,176.8 us** | **234,927.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          68 |    608,193.6 us |   3,426.9 us |   2,266.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          68 |  2,188,913.9 us | 410,763.6 us | 271,694.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          68 |    600,449.9 us |   4,984.9 us |   3,297.2 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **70** |  **2,229,986.8 us** | **354,210.0 us** | **234,288.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          70 |    593,976.8 us |  24,074.0 us |  15,923.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          70 |  2,234,442.6 us | 287,886.1 us | 190,418.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          70 |    592,527.7 us |   3,470.4 us |   2,295.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **72** |  **2,049,247.1 us** | **239,933.5 us** | **158,701.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          72 |    676,272.0 us |  66,808.1 us |  44,189.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          72 |  2,128,191.3 us | 303,552.4 us | 200,781.1 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          72 |    620,189.2 us |  52,681.2 us |  34,845.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **74** |  **2,161,192.1 us** | **251,444.9 us** | **166,315.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          74 |    688,147.5 us |   4,838.6 us |   3,200.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          74 |  2,221,092.8 us | 260,601.2 us | 172,371.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          74 |    684,666.7 us |   9,865.6 us |   6,525.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **76** |  **1,996,284.6 us** | **337,871.2 us** | **223,480.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          76 |    667,808.1 us |   7,415.1 us |   4,904.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          76 |  2,181,794.6 us | 235,282.6 us | 155,624.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          76 |    676,480.3 us |   4,737.6 us |   3,133.7 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **78** |  **2,130,982.2 us** | **301,646.7 us** | **199,520.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          78 |    654,557.9 us |   7,036.0 us |   4,653.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          78 |  2,313,249.9 us | 279,985.2 us | 185,192.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          78 |    653,574.1 us |  10,491.5 us |   6,939.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **80** |  **2,157,693.6 us** | **177,650.7 us** | **117,504.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          80 |    643,945.0 us |   5,710.3 us |   3,777.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          80 |  2,084,337.0 us | 215,215.7 us | 142,351.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          80 |    644,278.4 us |  15,542.5 us |  10,280.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **82** |  **2,112,250.5 us** | **299,199.3 us** | **197,901.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          82 |    639,994.8 us |   6,143.3 us |   4,063.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          82 |  2,238,837.9 us | 264,784.8 us | 175,138.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          82 |    636,295.3 us |  15,931.2 us |  10,537.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **84** |  **2,184,962.6 us** | **355,741.8 us** | **235,301.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          84 |    632,305.5 us |   5,086.4 us |   3,364.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          84 |  2,113,115.3 us | 327,606.1 us | 216,691.1 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          84 |    633,324.4 us |   8,531.5 us |   5,643.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **86** |  **2,011,349.8 us** | **226,178.8 us** | **149,603.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          86 |    627,617.1 us |   5,064.3 us |   3,349.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          86 |  2,221,444.4 us | 309,772.8 us | 204,895.5 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          86 |    614,838.2 us |   4,596.6 us |   3,040.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **88** |  **1,938,044.6 us** | **244,361.9 us** | **161,630.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          88 |    610,806.7 us |   3,166.0 us |   2,094.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          88 |  2,109,542.7 us | 184,485.7 us | 122,025.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          88 |    612,940.7 us |   4,301.0 us |   2,844.8 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **90** |  **2,192,041.4 us** | **168,656.9 us** | **111,556.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          90 |    605,184.4 us |   6,505.9 us |   4,303.3 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          90 |  2,082,362.0 us | 228,455.5 us | 151,109.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          90 |    598,533.6 us |   4,448.1 us |   2,942.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **92** |  **2,008,870.1 us** | **262,787.3 us** | **173,817.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          92 |    595,983.2 us |   6,977.8 us |   4,615.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          92 |  2,114,425.9 us | 370,045.2 us | 244,762.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          92 |    590,520.7 us |   4,764.0 us |   3,151.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **94** |  **2,110,392.3 us** | **258,193.5 us** | **170,779.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          94 |    588,308.6 us |   6,328.1 us |   4,185.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          94 |  1,959,853.2 us | 164,478.9 us | 108,792.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          94 |    588,375.8 us |  12,428.6 us |   8,220.8 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |       **17** |          **96** |  **1,933,259.0 us** | **222,880.7 us** | **147,421.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |       17 |          96 |    631,685.8 us |  48,041.5 us |  31,776.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |       17 |          96 |  2,023,215.7 us | 226,232.4 us | 149,638.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |       17 |          96 |    644,516.9 us |  46,042.0 us |  30,453.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |           **1** |  **2,003,805.3 us** |  **43,236.7 us** |  **28,598.4 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |           1 |  1,067,240.9 us |  29,863.9 us |  19,753.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |           1 |  2,052,582.2 us |  63,147.6 us |  41,768.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |           1 |  1,073,352.3 us |   2,631.3 us |   1,740.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |           **2** |  **1,097,350.4 us** |  **32,648.2 us** |  **21,594.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |           2 |    544,761.7 us |  11,901.4 us |   7,872.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |           2 |  1,112,764.1 us |  43,992.7 us |  29,098.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |           2 |    544,782.9 us |   6,423.3 us |   4,248.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |           **4** |    **612,374.9 us** |  **18,100.6 us** |  **11,972.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |           4 |    284,633.1 us |   4,439.6 us |   2,936.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |           4 |    624,118.0 us |  25,982.4 us |  17,185.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |           4 |    280,280.0 us |   4,699.1 us |   3,108.2 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |           **6** |    **437,224.1 us** |  **15,242.4 us** |  **10,081.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |           6 |    202,241.1 us |   4,143.4 us |   2,740.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |           6 |    426,000.7 us |  59,305.3 us |  39,226.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |           6 |    214,066.5 us |  34,565.5 us |  22,862.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |           **8** |    **350,189.8 us** |  **28,029.5 us** |  **18,539.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |           8 |    157,849.6 us |  11,965.1 us |   7,914.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |           8 |    328,087.3 us |  19,357.4 us |  12,803.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |           8 |    156,927.5 us |   3,690.5 us |   2,441.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **10** |    **287,130.6 us** |  **11,127.8 us** |   **7,360.4 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          10 |    129,746.6 us |   4,316.6 us |   2,855.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          10 |    298,071.3 us |  19,152.1 us |  12,667.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          10 |    130,550.3 us |   5,559.5 us |   3,677.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **12** |    **263,501.5 us** |  **22,436.7 us** |  **14,840.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          12 |    124,354.6 us |  10,264.1 us |   6,789.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          12 |    266,802.6 us |  19,189.0 us |  12,692.3 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          12 |    122,290.7 us |   9,747.7 us |   6,447.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **14** |    **257,365.4 us** |   **7,441.6 us** |   **4,922.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          14 |    110,612.8 us |   3,122.9 us |   2,065.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          14 |    256,983.4 us |   4,737.0 us |   3,133.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          14 |    110,435.2 us |   3,318.5 us |   2,195.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **16** |    **249,094.8 us** |   **5,422.4 us** |   **3,586.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          16 |     99,996.0 us |   2,493.8 us |   1,649.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          16 |    245,579.1 us |   7,258.8 us |   4,801.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          16 |     97,043.2 us |   2,041.4 us |   1,350.2 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **18** |    **242,721.6 us** |   **7,805.1 us** |   **5,162.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          18 |     90,206.8 us |   2,056.7 us |   1,360.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          18 |    244,495.2 us |   8,199.9 us |   5,423.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          18 |     88,873.4 us |   1,678.3 us |   1,110.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **20** |    **255,174.8 us** |  **10,501.3 us** |   **6,945.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          20 |     81,371.2 us |   1,760.6 us |   1,164.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          20 |    253,446.6 us |   9,820.1 us |   6,495.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          20 |     80,659.3 us |   2,580.2 us |   1,706.7 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **22** |    **255,399.3 us** |  **12,430.8 us** |   **8,222.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          22 |     73,928.2 us |   1,326.7 us |     877.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          22 |    276,192.9 us |  11,777.4 us |   7,790.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          22 |     73,893.8 us |   1,265.3 us |     836.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **24** |    **299,181.6 us** |  **13,193.2 us** |   **8,726.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          24 |     70,057.9 us |   8,783.7 us |   5,809.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          24 |    279,763.9 us |  11,337.7 us |   7,499.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          24 |     69,326.7 us |   4,652.7 us |   3,077.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **26** |    **681,727.3 us** | **132,200.8 us** |  **87,442.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          26 |    106,076.7 us |   3,199.6 us |   2,116.3 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          26 |    684,877.9 us | 125,018.2 us |  82,691.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          26 |    105,499.1 us |   3,575.6 us |   2,365.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **28** |    **741,182.2 us** |  **73,749.9 us** |  **48,781.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          28 |    100,825.7 us |   2,492.6 us |   1,648.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          28 |    689,254.2 us | 154,759.3 us | 102,363.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          28 |     99,654.6 us |   1,202.8 us |     795.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **30** |    **741,673.6 us** | **102,959.5 us** |  **68,101.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          30 |     97,310.6 us |   3,150.2 us |   2,083.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          30 |    680,183.1 us | 134,447.2 us |  88,928.5 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          30 |     98,501.9 us |   4,060.5 us |   2,685.8 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **32** |    **710,815.6 us** |  **96,245.7 us** |  **63,660.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          32 |     93,471.1 us |   4,164.3 us |   2,754.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          32 |    715,586.6 us | 129,199.9 us |  85,457.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          32 |     92,862.6 us |   2,847.5 us |   1,883.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **34** |    **733,468.8 us** | **160,231.5 us** | **105,983.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          34 |     90,367.9 us |   2,790.2 us |   1,845.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          34 |    710,203.3 us | 102,390.1 us |  67,724.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          34 |     90,339.1 us |   1,571.6 us |   1,039.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **36** |    **728,658.1 us** |  **74,152.3 us** |  **49,047.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          36 |     85,048.5 us |   1,591.4 us |   1,052.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          36 |    707,408.4 us | 126,581.3 us |  83,725.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          36 |     85,556.6 us |   1,443.1 us |     954.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **38** |    **686,583.6 us** | **165,059.9 us** | **109,176.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          38 |     83,015.9 us |   1,561.8 us |   1,033.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          38 |    714,423.4 us | 127,305.3 us |  84,204.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          38 |     80,806.0 us |   1,171.8 us |     775.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **40** |    **616,264.9 us** | **146,053.3 us** |  **96,605.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          40 |     79,177.9 us |     834.8 us |     552.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          40 |    714,949.2 us | 145,454.5 us |  96,209.1 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          40 |     78,472.5 us |   1,201.9 us |     795.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **42** |    **680,834.2 us** | **171,488.2 us** | **113,428.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          42 |     75,961.1 us |   1,084.3 us |     717.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          42 |    715,459.5 us | 245,126.5 us | 162,136.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          42 |     75,705.6 us |   1,349.0 us |     892.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **44** |    **557,712.5 us** | **156,777.8 us** | **103,698.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          44 |     73,392.5 us |   1,061.4 us |     702.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          44 |    658,005.2 us | 162,485.8 us | 107,474.3 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          44 |     73,406.9 us |   1,795.1 us |   1,187.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **46** |    **573,136.8 us** | **117,478.9 us** |  **77,705.1 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          46 |     70,420.4 us |   1,280.0 us |     846.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          46 |    575,307.1 us | 140,554.4 us |  92,968.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          46 |     69,548.8 us |     773.0 us |     511.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **48** |    **500,847.0 us** |  **95,947.5 us** |  **63,463.4 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          48 |     73,950.1 us |  10,042.4 us |   6,642.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          48 |    617,704.4 us | 186,801.6 us | 123,557.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          48 |     71,643.7 us |   9,702.9 us |   6,417.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **50** |    **594,411.9 us** | **162,972.4 us** | **107,796.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          50 |     88,305.3 us |   3,202.0 us |   2,118.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          50 |    650,469.4 us |  93,109.0 us |  61,585.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          50 |     89,309.6 us |   1,818.3 us |   1,202.7 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **52** |    **627,389.3 us** | **168,845.5 us** | **111,680.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          52 |     86,510.6 us |   3,845.7 us |   2,543.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          52 |    702,087.1 us | 127,756.7 us |  84,503.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          52 |     85,945.3 us |   1,044.1 us |     690.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **54** |    **729,900.0 us** | **169,797.2 us** | **112,310.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          54 |     85,329.1 us |   3,360.1 us |   2,222.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          54 |    686,550.3 us | 112,036.0 us |  74,104.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          54 |     86,726.4 us |   3,440.9 us |   2,275.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **56** |    **739,042.6 us** | **106,672.8 us** |  **70,557.4 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          56 |     84,270.3 us |   3,961.8 us |   2,620.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          56 |    697,328.8 us | 110,669.6 us |  73,201.1 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          56 |     82,509.2 us |   2,782.3 us |   1,840.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **58** |    **711,396.4 us** | **138,404.1 us** |  **91,545.7 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          58 |     83,218.4 us |   1,697.9 us |   1,123.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          58 |    693,817.6 us | 155,287.8 us | 102,713.3 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          58 |     82,005.2 us |   1,998.7 us |   1,322.0 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **60** |    **664,979.7 us** | **142,993.8 us** |  **94,581.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          60 |     80,627.3 us |   1,117.4 us |     739.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          60 |    700,724.4 us | 131,370.1 us |  86,893.2 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          60 |     79,818.8 us |   1,256.6 us |     831.2 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **62** |    **747,184.6 us** |  **80,233.1 us** |  **53,069.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          62 |     77,519.2 us |   1,100.9 us |     728.2 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          62 |    716,235.4 us | 136,027.6 us |  89,973.8 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          62 |     78,109.6 us |     780.3 us |     516.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **64** |    **679,270.8 us** | **141,390.6 us** |  **93,521.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          64 |     77,023.2 us |     602.8 us |     398.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          64 |    716,082.5 us | 124,156.1 us |  82,121.5 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          64 |     75,540.5 us |     974.5 us |     644.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **66** |    **729,423.1 us** | **146,660.5 us** |  **97,006.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          66 |     73,978.4 us |   1,265.8 us |     837.3 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          66 |    715,112.9 us | 136,814.6 us |  90,494.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          66 |     73,940.2 us |   1,012.4 us |     669.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **68** |    **679,188.4 us** | **151,796.4 us** | **100,403.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          68 |     73,151.7 us |     874.5 us |     578.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          68 |    662,614.5 us | 155,219.2 us | 102,667.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          68 |     73,726.5 us |   2,395.7 us |   1,584.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **70** |    **737,051.5 us** |  **98,045.8 us** |  **64,851.2 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          70 |     71,969.1 us |   1,216.2 us |     804.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          70 |    719,697.9 us | 118,406.3 us |  78,318.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          70 |     71,463.7 us |   1,608.0 us |   1,063.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **72** |    **593,045.5 us** | **153,439.8 us** | **101,491.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          72 |     75,200.5 us |   5,206.0 us |   3,443.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          72 |    713,553.5 us | 102,364.7 us |  67,707.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          72 |     72,737.3 us |   2,013.1 us |   1,331.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **74** |    **675,508.7 us** | **141,885.4 us** |  **93,848.4 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          74 |     82,153.2 us |   1,790.9 us |   1,184.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          74 |    709,475.4 us | 137,128.9 us |  90,702.3 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          74 |     81,528.6 us |     767.1 us |     507.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **76** |    **787,000.5 us** | **234,648.5 us** | **155,205.4 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          76 |     80,637.6 us |   1,812.8 us |   1,199.0 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          76 |    655,218.1 us | 141,888.7 us |  93,850.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          76 |     80,013.9 us |   1,618.6 us |   1,070.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **78** |    **676,048.3 us** | **161,241.0 us** | **106,651.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          78 |     79,934.6 us |   2,527.6 us |   1,671.8 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          78 |    705,179.2 us | 138,298.5 us |  91,475.9 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          78 |     79,089.8 us |   2,077.1 us |   1,373.9 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **80** |    **739,865.9 us** |  **67,333.6 us** |  **44,537.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          80 |     78,814.4 us |   2,326.3 us |   1,538.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          80 |    656,387.3 us | 157,173.3 us | 103,960.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          80 |     79,025.8 us |   3,512.2 us |   2,323.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **82** |    **615,598.7 us** | **158,184.1 us** | **104,629.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          82 |     77,497.9 us |   2,121.8 us |   1,403.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          82 |    714,160.2 us | 103,206.4 us |  68,264.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          82 |     76,564.3 us |   1,600.4 us |   1,058.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **84** |    **717,596.9 us** | **120,874.5 us** |  **79,951.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          84 |     76,449.8 us |   1,489.8 us |     985.4 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          84 |    658,703.6 us | 142,949.7 us |  94,552.4 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          84 |     76,429.0 us |     684.2 us |     452.5 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **86** |    **603,050.5 us** | **163,726.4 us** | **108,294.9 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          86 |     75,085.8 us |   1,348.2 us |     891.8 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          86 |    715,435.0 us | 143,727.2 us |  95,066.7 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          86 |     75,353.5 us |   1,102.8 us |     729.4 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **88** |    **650,353.9 us** | **172,715.5 us** | **114,240.6 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          88 |     74,184.0 us |   1,179.1 us |     779.9 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          88 |    572,456.5 us | 117,364.8 us |  77,629.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          88 |     73,829.8 us |     748.9 us |     495.3 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **90** |    **624,595.5 us** | **179,846.0 us** | **118,957.0 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          90 |     72,575.9 us |     645.8 us |     427.1 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          90 |    677,028.8 us | 170,228.5 us | 112,595.6 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          90 |     72,371.2 us |     428.0 us |     283.1 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **92** |    **613,840.9 us** | **179,163.1 us** | **118,505.3 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          92 |     72,335.8 us |     779.7 us |     515.7 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          92 |    519,478.3 us |  73,070.3 us |  48,331.5 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          92 |     71,640.7 us |   1,006.3 us |     665.6 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **94** |    **583,128.0 us** | **146,058.3 us** |  **96,608.5 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          94 |     71,792.3 us |   1,208.9 us |     799.6 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          94 |    569,568.0 us | 148,127.3 us |  97,977.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          94 |     71,030.0 us |   1,100.3 us |     727.8 us |
| **ParallelSave** | **.NET Core 2.0** |      **536870912** |      **134** |          **96** |    **515,467.3 us** | **102,913.3 us** |  **68,070.8 us** |
|  ParallelUse | .NET Core 2.0 |      536870912 |      134 |          96 |     78,078.4 us |   3,405.5 us |   2,252.5 us |
| ParallelSave |  CsProjnet462 |      536870912 |      134 |          96 |    535,491.4 us | 105,030.2 us |  69,471.0 us |
|  ParallelUse |  CsProjnet462 |      536870912 |      134 |          96 |     75,809.8 us |   2,879.3 us |   1,904.5 us |
