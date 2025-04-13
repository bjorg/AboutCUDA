// AboutCuda
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

using ManagedCuda;
using static System.Console;

WriteLine("AboutCuda - 2025 (c) Steve Bjorg");
WriteLine();

var deviceCount = CudaContext.GetDeviceCount();
WriteLine($"Found {deviceCount} devices");
WriteLine();

for(var deviceId = 0; deviceId < deviceCount; ++deviceId) {
    var info = CudaContext.GetDeviceInfo(deviceId);
    WriteLine($"=== {info.DeviceName} ===");
    WriteLine();

    WriteLine("--- Versions ---");
    WriteLine($"* Driver: {info.DriverVersion}");
    WriteLine($"* Compute: {info.ComputeCapability}");
    WriteLine();

    WriteLine("--- Processing ---");
    WriteLine($"* Compute Mode: {info.ComputeMode}");
    WriteLine($"* Multi Processors: {info.MultiProcessorCount}");
    WriteLine($"* Warp Size: {info.WarpSize}");
    WriteLine($"* Registers/Block: {info.RegistersPerBlock}");
    WriteLine($"* Async Engine Count: {info.AsyncEngineCount}");
    WriteLine($"* Clock Rate: {info.ClockRate} kHz");
    WriteLine($"* Max Block Dimensions: {info.MaxBlockDim}");
    WriteLine($"* Max Grid Dimensions: {info.MaxGridDim}");
    WriteLine($"* Max Threads/Block: {info.MaxThreadsPerBlock}");
    WriteLine($"* Max Threads/Processor: {info.MaxThreadsPerMultiProcessor}");
    WriteLine($"* Max Registers/Multiprocessor: {info.MaxRegistersPerMultiprocessor}");
    WriteLine($"* Max Shared Memory/Multiprocessor: {info.MaxSharedMemoryPerMultiprocessor}");
    WriteLine($"* Single To Double Precision Perf Ratio: {info.SingleToDoublePrecisionPerfRatio}");
    WriteLine();

    WriteLine("--- Memory ---");
    WriteLine($"* Global Memory: {(long)info.TotalGlobalMemory / 1024.0 / 1024.0 / 1024.0:F2} GiB");
    WriteLine($"* Shared Memory/Block: {info.SharedMemoryPerBlock} bytes");
    WriteLine($"* Constant Memory: {info.TotalConstantMemory} bytes");
    WriteLine($"* Managed Memory: {info.ManagedMemory}");
    WriteLine($"* Unified Addressing: {info.UnifiedAddressing}");
    WriteLine($"* Integrated: {info.Integrated}");
    WriteLine($"* ECC Enabled: {info.EccEnabled}");
    WriteLine($"* Memory Clock Rate: {info.MemoryClockRate} kHz");
    WriteLine($"* L2 Cache Size: {info.L2CacheSize} bytes");
    WriteLine($"* Max Memory Pitch: {info.MemoryPitch}");
    WriteLine($"* Global L1 Cache Supported: {info.GlobalL1CacheSupported}");
    WriteLine($"* Local L1 Cache Supported: {info.LocalL1CacheSupported}");
    WriteLine($"* Max Persisting L2 Cache Size: {info.MaxPersistingL2CacheSize} bytes");
    WriteLine($"* Global Memory Bus Width: {info.GlobalMemoryBusWidth} bits");
    WriteLine();

    WriteLine("--- Features ---");
    WriteLine($"* Concurrent Kernels: {info.ConcurrentKernels}");
    WriteLine($"* Cooperative Launch: {info.CooperativeLaunch}");
    WriteLine($"* GPU Overlap: {info.GpuOverlap}");
    WriteLine($"* Compute Preemption: {info.ComputePreemptionSupported}");
    WriteLine($"* Concurrent Managed Access: {info.ConcurrentManagedAccess}");
    WriteLine($"* Generic Compression: {info.GenericCompressionSupported}");
    WriteLine($"* DMA Buffer: {info.DmaBufSupported}");
    WriteLine($"* Host Memory Register: {info.HostRegisterSupported}");
    WriteLine($"* Pageable Memory Access: {info.PageableMemoryAccess}");
    WriteLine($"* Stream Priorities: {info.SupportsStreamPriorities}");
    WriteLine($"* Unified Function Pointers: {info.UnifiedFunctionPointers}");
    WriteLine($"* Read Only Host Register: {info.ReadOnlyHostRegisterSupported}");
    WriteLine($"* Cluster Launch: {info.ClusterLaunch}");
    WriteLine($"* Multi Cast: {info.MultiCastSupported}");
    WriteLine($"* Map Host Memory: {info.CanMapHostMemory}");
    WriteLine($"* Host Native Atomic: {info.HostNativeAtomicSupported}");
    WriteLine($"* Can Use Host Pointer For Registered Memory: {info.CanUseHostPointerForRegisteredMem}");
    WriteLine($"* Can Use 64-Bit Stream Memory Operations: {info.CanUse64BitStreamMemOps}");
    WriteLine($"* Can Use CU_STREAM_WAIT_VALUE_NOR for Memory Operations: {info.CanUseStreamWaitValueNOr}");
    WriteLine($"* Can Flush Remote Writes: {info.CanFlushRemoteWrites}");
    WriteLine($"* Pageable Memory Access Uses Host Page Tables: {info.PageableMemoryAccessUsesHostPageTables}");
    WriteLine($"* Direct Managed Memory Access From Host: {info.DirectManagedMemoryAccessFromHost}");
    WriteLine($"* Virtual Memory Management Supported: {info.VirtualMemoryManagementSupported}");
    WriteLine();

    WriteLine("--- NUMA ---");
    WriteLine($"* Config: {info.NumaConfig}");
    WriteLine($"* Device ID: {info.NumaID}");
    WriteLine($"* Host ID: {info.HostNumaID}");
    WriteLine($"* Host NUMA Multinode IPC Supported: {info.HostNUMAMultinodeIPCSupported}");
    WriteLine();

    WriteLine("--- PCI ---");
    WriteLine($"* PCI Bus ID: {info.PciBusId}");
    WriteLine($"* PCI Device ID: {info.PciDeviceId}");
    WriteLine($"* PCI Domain ID: {info.PCIDomainID}");
    WriteLine($"* GPU PCI Device ID: {info.GpuPciDeviceID}");
    WriteLine($"* GPU PCI Subsystem ID: {info.GpuPciSubsystemID}");
    WriteLine();

    WriteLine("--- Misc. ---");
    WriteLine($"* SurfaceAllignment: {info.SurfaceAllignment}");
    WriteLine($"* TextureAlign: {info.TextureAlign}");
    WriteLine($"* TccDrivelModel: {info.TccDrivelModel}");
    WriteLine($"* TexturePitchAlignment: {info.TexturePitchAlignment}");
    WriteLine($"* TextureAlign: {info.TextureAlign}");
    WriteLine($"* KernelExecTimeoutEnabled: {info.KernelExecTimeoutEnabled}");
    WriteLine($"* MaximumTexture1DWidth: {info.MaximumTexture1DWidth}");
    WriteLine($"* MaximumTexture2DWidth: {info.MaximumTexture2DWidth}");
    WriteLine($"* MaximumTexture2DHeight: {info.MaximumTexture2DHeight}");
    WriteLine($"* MaximumTexture3DWidth: {info.MaximumTexture3DWidth}");
    WriteLine($"* MaximumTexture3DHeight: {info.MaximumTexture3DHeight}");
    WriteLine($"* MaximumTexture3DDepth: {info.MaximumTexture3DDepth}");
    WriteLine($"* MaximumTexture2DArrayWidth: {info.MaximumTexture2DArrayWidth}");
    WriteLine($"* MaximumTexture2DArrayHeight: {info.MaximumTexture2DArrayHeight}");
    WriteLine($"* MaximumTexture2DArrayNumSlices: {info.MaximumTexture2DArrayNumSlices}");
    WriteLine($"* MaximumTexture1DLayeredWidth: {info.MaximumTexture1DLayeredWidth}");
    WriteLine($"* MaximumTexture1DLayeredLayers: {info.MaximumTexture1DLayeredLayers}");
    WriteLine($"* MaximumTextureCubeMapWidth: {info.MaximumTextureCubeMapWidth}");
    WriteLine($"* MaximumTextureCubeMapLayeredWidth: {info.MaximumTextureCubeMapLayeredWidth}");
    WriteLine($"* MaximumTextureCubeMapLayeredLayers: {info.MaximumTextureCubeMapLayeredLayers}");
    WriteLine($"* MaximumSurface1DWidth: {info.MaximumSurface1DWidth}");
    WriteLine($"* MaximumSurface2DWidth: {info.MaximumSurface2DWidth}");
    WriteLine($"* MaximumSurface2DHeight: {info.MaximumSurface2DHeight}");
    WriteLine($"* MaximumSurface3DWidth: {info.MaximumSurface3DWidth}");
    WriteLine($"* MaximumSurface3DHeight: {info.MaximumSurface3DHeight}");
    WriteLine($"* MaximumSurface3DDepth: {info.MaximumSurface3DDepth}");
    WriteLine($"* MaximumSurface1DLayeredWidth: {info.MaximumSurface1DLayeredWidth}");
    WriteLine($"* MaximumSurface1DLayeredLayers: {info.MaximumSurface1DLayeredLayers}");
    WriteLine($"* MaximumSurface2DLayeredWidth: {info.MaximumSurface2DLayeredWidth}");
    WriteLine($"* MaximumSurface2DLayeredHeight: {info.MaximumSurface2DLayeredHeight}");
    WriteLine($"* MaximumSurface2DLayeredLayers: {info.MaximumSurface2DLayeredLayers}");
    WriteLine($"* MaximumSurfaceCubemapWidth: {info.MaximumSurfaceCubemapWidth}");
    WriteLine($"* MaximumSurfaceCubemapLayeredWidth: {info.MaximumSurfaceCubemapLayeredWidth}");
    WriteLine($"* MaximumSurfaceCubemapLayeredLayers: {info.MaximumSurfaceCubemapLayeredLayers}");
    WriteLine($"* MaximumTexture2DLinearWidth: {info.MaximumTexture2DLinearWidth}");
    WriteLine($"* MaximumTexture2DLinearHeight: {info.MaximumTexture2DLinearHeight}");
    WriteLine($"* MaximumTexture2DLinearPitch: {info.MaximumTexture2DLinearPitch}");
    WriteLine($"* MaximumTexture2DMipmappedWidth: {info.MaximumTexture2DMipmappedWidth}");
    WriteLine($"* MaximumTexture2DMipmappedHeight: {info.MaximumTexture2DMipmappedHeight}");
    WriteLine($"* MaximumTexture1DMipmappedWidth: {info.MaximumTexture1DMipmappedWidth}");
    WriteLine($"* MultiGPUBoard: {info.MultiGPUBoard}");
    WriteLine($"* MultiGPUBoardGroupID: {info.MultiGPUBoardGroupID}");
    WriteLine($"* CooperativeMultiDeviceLaunch: {info.CooperativeMultiDeviceLaunch}");
    WriteLine($"* MaxSharedMemoryPerBlockOptin: {info.MaxSharedMemoryPerBlockOptin}");
    WriteLine($"* HandleTypePosixFileDescriptorSupported: {info.HandleTypePosixFileDescriptorSupported}");
    WriteLine($"* HandleTypeWin32HandleSupported: {info.HandleTypeWin32HandleSupported}");
    WriteLine($"* HandleTypeWin32KMTHandleSupported: {info.HandleTypeWin32KMTHandleSupported}");
    WriteLine($"* MaxBlocksPerMultiProcessor: {info.MaxBlocksPerMultiProcessor}");
    WriteLine($"* MaxAccessPolicyWindowSize: {info.MaxAccessPolicyWindowSize}");
    WriteLine($"* GPUDirectRDMAWithCudaVMMSupported: {info.GPUDirectRDMAWithCudaVMMSupported}");
    WriteLine($"* ReservedSharedMemoryPerBlock: {info.ReservedSharedMemoryPerBlock}");
    WriteLine($"* SparseCudaArraySupported: {info.SparseCudaArraySupported}");
    WriteLine($"* GpuDirectRDMASupported: {info.GpuDirectRDMASupported}");
    WriteLine($"* GpuDirectRDMAFlushWritesOptions: {info.GpuDirectRDMAFlushWritesOptions}");
    WriteLine($"* GpuDirectRDMAWritesOrdering: {info.GpuDirectRDMAWritesOrdering}");
    WriteLine($"* MempoolSupportedHandleTypes: {info.MempoolSupportedHandleTypes}");
    WriteLine($"* DeferredMappingCudaArraySupported: {info.DeferredMappingCudaArraySupported}");
    WriteLine($"* IPCEventSupported: {info.IPCEventSupported}");
    WriteLine($"* MemSyncDomainCount: {info.MemSyncDomainCount}");
    WriteLine($"* TensorMapAccessSupported: {info.TensorMapAccessSupported}");
    WriteLine($"* HandleTypeFabricSupported: {info.HandleTypeFabricSupported}");
    WriteLine($"* MultiCastSupported: {info.MultiCastSupported}");
    WriteLine($"* MPSEnabled: {info.MPSEnabled}");
    WriteLine($"* D3D12CIGSupported: {info.D3D12CIGSupported}");
    WriteLine($"* MemDecompressAlgorithmMask: {info.MemDecompressAlgorithmMask}");
    WriteLine($"* MemDecompressMaximumLength: {info.MemDecompressMaximumLength}");
    WriteLine();
}
