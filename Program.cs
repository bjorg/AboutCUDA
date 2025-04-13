// AboutCUDA
//
// Copyright (C) 2025 - Steve Bjorg
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/.

using System.CommandLine;
using ManagedCuda;
using ManagedCuda.BasicTypes;
using static System.Console;

// define command line options
var allOption = new Option<bool>([ "--all", "-a" ], "Show all properties");
var capabilityOption = new Option<bool>([ "--capability", "-c" ], "Show capabilities and enabled features");
var textureOption = new Option<bool>([ "--texture", "-t" ], "Show texture/surface properties");
var deviceTopologyOption = new Option<bool>([ "--device", "-d" ], "Show device topology properties");
var quietOption = new Option<bool>([ "--quiet", "-q" ],"Suppress banner");

// define command
var rootCommand = new RootCommand("Show CUDA properties") {
    allOption,
    capabilityOption,
    textureOption,
    deviceTopologyOption,
    quietOption
};
rootCommand.SetHandler(ShowCudaProperties, allOption, capabilityOption, textureOption, deviceTopologyOption, quietOption);
rootCommand.Invoke(args);
return;

static void ShowCudaProperties(bool showAll, bool showCapabilities, bool showTexture, bool showDeviceTopology, bool hideBanner) {
    if(!hideBanner) {
        WriteLine("AboutCUDA - 2025 (c) Steve Bjorg");
        WriteLine();
    }

    // determine how many CUDA devices are present
    var deviceCount = CudaContext.GetDeviceCount();
    if(deviceCount == 0) {
        WriteLine("No CUDA devices found");
        return;
    }
    WriteLine($"Found {deviceCount} device(s)");

    // loop over each CUDA device
    for(var deviceId = 0; deviceId < deviceCount; ++deviceId) {
        var info = CudaContext.GetDeviceInfo(deviceId);
        WriteLine();
        WriteLine($"=== Device #{deviceId}: {info.DeviceName} ===");
        WriteLine();
        WriteLine("--- Overview ---");
        WriteLine($"* Driver Version: {info.DriverVersion}");
        WriteLine($"* Compute Capability: {info.ComputeCapability}");
        WriteLine($"* Compute Mode: {info.ComputeMode}");
        WriteLine();
        WriteLine("--- Processors ---");
        WriteLine($"* Processors: {info.MultiProcessorCount}");
        WriteLine($"* Clock Rate: {ConvertKiloHertz(info.ClockRate)}");
        WriteLine($"* Warp Size: {info.WarpSize}");
        WriteLine($"* Registers/Block: {info.RegistersPerBlock}");
        WriteLine($"* Shared Memory/Block: {ConvertBytes(info.ReservedSharedMemoryPerBlock)}");
        WriteLine($"* Max Grid Dimensions: {info.MaxGridDim}");
        WriteLine($"* Max Block Dimensions: {info.MaxBlockDim}");
        WriteLine($"* Max Blocks/Processor: {info.MaxBlocksPerMultiProcessor}");
        WriteLine($"* Max Threads/Processor: {info.MaxThreadsPerMultiProcessor}");
        WriteLine($"* Max Registers/Processor: {info.MaxRegistersPerMultiprocessor}");
        WriteLine($"* Max Shared Memory/Processor: {ConvertBytes(info.MaxSharedMemoryPerMultiprocessor)}");
        WriteLine($"* Max Threads/Block: {info.MaxThreadsPerBlock}");
        WriteLine($"* Max Shared Memory/Block: {ConvertBytes(info.SharedMemoryPerBlock)}");
        WriteLine($"* Max Shared Memory (Optin)/Block: {ConvertBytes(info.MaxSharedMemoryPerBlockOptin)}");
        WriteLine();
        WriteLine("--- Memory ---");
        WriteLine($"* Global: {ConvertBytes(info.TotalGlobalMemory)}");
        WriteLine($"* Constant: {ConvertBytes(info.TotalConstantMemory)}");
        WriteLine($"* Clock Rate: {ConvertKiloHertz(info.MemoryClockRate)}");
        WriteLine($"* Managed Memory: {ConvertBool(info.ManagedMemory)}");
        WriteLine($"* Unified Addressing: {ConvertBool(info.UnifiedAddressing)}");
        WriteLine($"* Integrated: {ConvertBool(info.Integrated)}");
        WriteLine($"* ECC Enabled: {ConvertBool(info.EccEnabled)}");
        WriteLine($"* L2 Cache Size: {ConvertBytes(info.L2CacheSize)}");
        WriteLine($"* Max Memory Pitch: {info.MemoryPitch}");
        WriteLine($"* Max Persisting L2 Cache Size: {ConvertBytes(info.MaxPersistingL2CacheSize)} bytes");
        WriteLine($"* Global Memory Bus Width: {info.GlobalMemoryBusWidth} bits");

        // check if texture/surface properties should be shown
        if(showTexture || showAll) {
            WriteLine();
            WriteLine("--- Texture Properties ---");
            WriteLine($"* Texture Alignment: {info.TextureAlign}");
            WriteLine($"* Texture Pitch Alignment: {info.TexturePitchAlignment}");
            WriteLine($"* Max Texture1D Size: ({info.MaximumTexture1DWidth})");
            WriteLine($"* Max Texture1D Mipmapped Size: ({info.MaximumTexture1DMipmappedWidth})");
            WriteLine($"* Max Texture1D Layered Width: {info.MaximumTexture1DLayeredWidth}");
            WriteLine($"* Max Texture1D Layered Layers: {info.MaximumTexture1DLayeredLayers}");
            WriteLine($"* Max Texture2D Size: ({info.MaximumTexture2DWidth}, {info.MaximumTexture2DHeight})");
            WriteLine($"* Max Texture2D Mipmapped Size: ({info.MaximumTexture2DMipmappedWidth}, {info.MaximumTexture2DMipmappedHeight})");
            WriteLine($"* Max Texture2D Array Width: {info.MaximumTexture2DArrayWidth}");
            WriteLine($"* Max Texture2D Array Height: {info.MaximumTexture2DArrayHeight}");
            WriteLine($"* Max Texture2D Array Num Slices: {info.MaximumTexture2DArrayNumSlices}");
            WriteLine($"* Max Texture2D Linear Width: {info.MaximumTexture2DLinearWidth}");
            WriteLine($"* Max Texture2D Linear Height: {info.MaximumTexture2DLinearHeight}");
            WriteLine($"* Max Texture2D Linear Pitch: {info.MaximumTexture2DLinearPitch}");
            WriteLine($"* Max Texture3D Size: ({info.MaximumTexture3DWidth}, {info.MaximumTexture3DHeight}, {info.MaximumTexture3DDepth})");
            WriteLine($"* Max Texture Cube Map Width: {info.MaximumTextureCubeMapWidth}");
            WriteLine($"* Max Texture Cube Map Layered Width: {info.MaximumTextureCubeMapLayeredWidth}");
            WriteLine($"* Max Texture Cube Map Layered Layers: {info.MaximumTextureCubeMapLayeredLayers}");
            WriteLine();
            WriteLine("--- Surface Properties ---");
            WriteLine($"* Surface Alignment: {info.SurfaceAllignment}");
            WriteLine($"* Max Surface1D Size: ({info.MaximumSurface1DWidth})");
            WriteLine($"* Max Surface1D Layered Width: {info.MaximumSurface1DLayeredWidth}");
            WriteLine($"* Max Surface1D Layered Layers: {info.MaximumSurface1DLayeredLayers}");
            WriteLine($"* Max Surface2D Size: ({info.MaximumSurface2DWidth}, {info.MaximumSurface2DHeight})");
            WriteLine($"* Max Surface2D Layered Width: {info.MaximumSurface2DLayeredWidth}");
            WriteLine($"* Max Surface2D Layered Height: {info.MaximumSurface2DLayeredHeight}");
            WriteLine($"* Max Surface2D Layered Layers: {info.MaximumSurface2DLayeredLayers}");
            WriteLine($"* Max Surface3D Size: ({info.MaximumSurface3DWidth}, {info.MaximumSurface3DHeight}, {info.MaximumSurface3DDepth})");
            WriteLine($"* Max Surface Cubemap Width: {info.MaximumSurfaceCubemapWidth}");
            WriteLine($"* Max Surface Cubemap Layered Width: {info.MaximumSurfaceCubemapLayeredWidth}");
            WriteLine($"* Max Surface Cubemap Layered Layers: {info.MaximumSurfaceCubemapLayeredLayers}");
        }

        // check if hardware topology properties should be shown
        if(showDeviceTopology) {
            WriteLine();
            WriteLine("--- Device Topology ---");
            WriteLine($"* NUMA Config: {info.NumaConfig}");
            WriteLine($"* NUMA Device ID: {info.NumaID}");
            WriteLine($"* NUMA Host ID: {info.HostNumaID}");
            WriteLine($"* NUMA Host NUMA Multinode IPC Supported: {ConvertBool(info.HostNUMAMultinodeIPCSupported)}");
            WriteLine($"* PCI Bus ID: {info.PciBusId}");
            WriteLine($"* PCI Device ID: {info.PciDeviceId}");
            WriteLine($"* PCI Domain ID: {info.PCIDomainID}");
            WriteLine($"* GPU PCI Device ID: {info.GpuPciDeviceID}");
            WriteLine($"* GPU PCI Subsystem ID: {info.GpuPciSubsystemID}");
            WriteLine($"* Multi GPU Board: {info.MultiGPUBoard}");
            WriteLine($"* Multi GPU Board Group ID: {info.MultiGPUBoardGroupID}");
        }

        // check if capability properties should be shown
        if(showCapabilities || showAll) {
            WriteLine();
            WriteLine("--- Features ---");
            WriteLine($"* Async Engine Count: {info.AsyncEngineCount}");
            WriteLine($"* Single To Double Precision Perf Ratio: {info.SingleToDoublePrecisionPerfRatio}");
            WriteLine($"* Kernel Exec Timeout Enabled: {ConvertBool(info.KernelExecTimeoutEnabled)}");
            WriteLine($"* TCC Driver Model Enabled: {ConvertBool(info.TccDrivelModel)}");
            WriteLine($"* MPS Enabled: {ConvertBool(info.MPSEnabled)}");
            WriteLine($"* GPU Direct RDMA Flush WritesOptions: {info.GpuDirectRDMAFlushWritesOptions}");
            WriteLine($"* GPU Direct RDMA Writes Ordering: {info.GpuDirectRDMAWritesOrdering}");
            WriteLine($"* Mem Sync Domain Count: {info.MemSyncDomainCount}");
            WriteLine($"* Mem Decompress Algorithm Mask: {info.MemDecompressAlgorithmMask}");
            WriteLine($"* Mem Decompress Maximum Length: {info.MemDecompressMaximumLength}");
            WriteLine($"* Global L1 Cache Supported: {ConvertBool(info.GlobalL1CacheSupported)}");
            WriteLine($"* Local L1 Cache Supported: {ConvertBool(info.LocalL1CacheSupported)}");
            WriteLine($"* Concurrent Kernels Supported: {ConvertBool(info.ConcurrentKernels)}");
            WriteLine($"* Cooperative Launch Supported: {ConvertBool(info.CooperativeLaunch)}");
            WriteLine($"* GPU Overlap Supported: {ConvertBool(info.GpuOverlap)}");
            WriteLine($"* Compute Preemption Supported: {ConvertBool(info.ComputePreemptionSupported)}");
            WriteLine($"* Concurrent Managed Access Supported: {ConvertBool(info.ConcurrentManagedAccess)}");
            WriteLine($"* Generic Compression Supported: {ConvertBool(info.GenericCompressionSupported)}");
            WriteLine($"* DMA Buffer Supported: {ConvertBool(info.DmaBufSupported)}");
            WriteLine($"* Host Memory Register Supported: {ConvertBool(info.HostRegisterSupported)}");
            WriteLine($"* Pageable Memory Access Supported: {ConvertBool(info.PageableMemoryAccess)}");
            WriteLine($"* Stream Priorities Supported: {ConvertBool(info.SupportsStreamPriorities)}");
            WriteLine($"* Unified Function Pointers Supported: {ConvertBool(info.UnifiedFunctionPointers)}");
            WriteLine($"* Read Only Host Register Supported: {ConvertBool(info.ReadOnlyHostRegisterSupported)}");
            WriteLine($"* Cluster Launch Supported: {ConvertBool(info.ClusterLaunch)}");
            WriteLine($"* Multi Cast Supported: {ConvertBool(info.MultiCastSupported)}");
            WriteLine($"* Map Host Memory: {ConvertBool(info.CanMapHostMemory)}");
            WriteLine($"* Host Native Atomic: {ConvertBool(info.HostNativeAtomicSupported)}");
            WriteLine($"* Use Host Pointer For Registered Memory Supported: {ConvertBool(info.CanUseHostPointerForRegisteredMem)}");
            WriteLine($"* Use 64-Bit Stream Memory Operations Supported Supported: {ConvertBool(info.CanUse64BitStreamMemOps)}");
            WriteLine($"* Use CU_STREAM_WAIT_VALUE_NOR for Memory Operations Supported: {ConvertBool(info.CanUseStreamWaitValueNOr)}");
            WriteLine($"* Flush Remote Writes Supported: {ConvertBool(info.CanFlushRemoteWrites)}");
            WriteLine($"* Pageable Memory Access Uses Host Page Tables Supported: {ConvertBool(info.PageableMemoryAccessUsesHostPageTables)}");
            WriteLine($"* Direct Managed Memory Access From Host Supported: {ConvertBool(info.DirectManagedMemoryAccessFromHost)}");
            WriteLine($"* Virtual Memory Management Supported: {ConvertBool(info.VirtualMemoryManagementSupported)}");
            WriteLine($"* Handle Type Posix File Descriptor Supported: {ConvertBool(info.HandleTypePosixFileDescriptorSupported)}");
            WriteLine($"* Handle Type Win32 Handle Supported: {ConvertBool(info.HandleTypeWin32HandleSupported)}");
            WriteLine($"* Handle Type Win32 KMT Handle Supported: {ConvertBool(info.HandleTypeWin32KMTHandleSupported)}");
            WriteLine($"* Max Access Policy Window Size: {info.MaxAccessPolicyWindowSize}");
            WriteLine($"* GPU Direct RDMA With CUDA VMM Supported: {ConvertBool(info.GPUDirectRDMAWithCudaVMMSupported)}");
            WriteLine($"* GPU Direct RDMA Supported: {ConvertBool(info.GpuDirectRDMASupported)}");
            WriteLine($"* Sparse CUDA Array Supported: {ConvertBool(info.SparseCudaArraySupported)}");
            WriteLine($"* Mem Pool Supported Handle Types: {info.MempoolSupportedHandleTypes}");
            WriteLine($"* Deferred Mapping CUDA Array Supported: {ConvertBool(info.DeferredMappingCudaArraySupported)}");
            WriteLine($"* IPC Event Supported: {ConvertBool(info.IPCEventSupported)}");
            WriteLine($"* Tensor Map Access Supported: {ConvertBool(info.TensorMapAccessSupported)}");
            WriteLine($"* Handle Type Fabric Supported: {ConvertBool(info.HandleTypeFabricSupported)}");
            WriteLine($"* Direct3D 12 CIG Supported: {ConvertBool(info.D3D12CIGSupported)}");
            WriteLine($"* Cooperative Multi Device Launch Supported: {ConvertBool(info.CooperativeMultiDeviceLaunch)}");
        }
    }
}

// local functions

static string ConvertBool(bool value) => value ? "yes" : "no";
static string ConvertBytes(SizeT value) => Convert((long)value, 1024.0, [ "bytes", "KiB", "MiB", "GiB", "TiB", "PiB" ]);
static string ConvertKiloHertz(int value) => Convert(value, 1000.0, [ "kHz", "MHz", "GHz" ]);

static string Convert(double value, double unitBase, ReadOnlySpan<string> unitName) {
    var index = 0;
    var unitConversionThreshold = unitBase * 1.5;
    while(((index + 1) < unitName.Length) && (value > unitConversionThreshold)) {
        value /= unitBase;
        ++index;
    }
    return $"{value:F2} {unitName[index]}";
}
