# AboutCUDA

This application reports the CUDA properties for each available device. 

_Output_:
```
AboutCuda - 2025 (c) Steve Bjorg

Found 1 device(s)

=== Device #0: NVIDIA GeForce RTX 4090 Laptop GPU ===

--- Overview ---
* Driver Version: 12.80
* Compute Capability: 8.9
* Compute Mode: Default

--- Processors ---
* Processors: 76
* Clock Rate: 1455.00 MHz
* Warp Size: 32
* Max Grid Dimensions: (2147483647; 65535; 65535)
* Max Block Dimensions: (1024; 1024; 64)
* Max Blocks/Processor: 24
* Max Threads/Processor: 1536
* Max Registers/Processor: 65536
* Max Shared Memory/Processor: 102400

--- Blocks ---
* Max Threads/Block: 1024
* Registers/Block: 65536
* Shared Memory/Block: 48.00 KiB
* Max Shared Memory/Block: 99.00 KiB

--- Memory ---
* Global: 15.99 GiB
* Constant: 64.00 KiB
* Clock Rate: 9.00 GHz
* Managed Memory: True
* Unified Addressing: True
* Integrated: False
* ECC Enabled: False
* L2 Cache Size: 64.00 MiB
* Max Memory Pitch: 2147483647
* Max Persisting L2 Cache Size: 44.00 MiB bytes
* Global Memory Bus Width: 256 bits
```

## Options

Additional properties can be reported using the following options:
* `-a|--all`: show all properties
* `-f|--features`: show availability of CUDA features

## License

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see http://www.gnu.org/licenses/.

## Copyright

2025 (c) Steve Bjorg
