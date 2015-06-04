using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using SharpDX.DXGI;
using System.Diagnostics;
using SharpDX;
using SharpDX.Direct3D11;
using Device = SharpDX.Direct3D11.Device;
using SharpDX.Direct3D;
using System.Management;

namespace VRageRender
{
	partial class MyRender11
	{
		static MyRefreshRatePriorityComparer m_refreshRatePriorityComparer = new MyRefreshRatePriorityComparer();
        static MyAdapterInfo[] m_adapterInfoList;
        static Dictionary<int, ModeDescription[]> m_adapterModes = new Dictionary<int, ModeDescription[]>();

        static Factory1 m_factory;
        static Factory1 GetFactory()
        {
            if (m_factory == null)
                m_factory = new Factory1();
            return m_factory;
        }

        private static void LogInfoFromWMI()
        {
            try
            {
                //http://wutils.com/wmi/
                //create a management scope object
                ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

                //create object query
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_VideoController");

                //create object searcher
                ManagementObjectSearcher searcher =
                                        new ManagementObjectSearcher(scope, query);

                //get collection of WMI objects
                ManagementObjectCollection queryCollection = searcher.Get();

                MyRender11.Log.WriteLine("WMI {");
                MyRender11.Log.IncreaseIndent();

                //enumerate the collection.
                foreach (ManagementObject m in queryCollection)
                {
                    MyRender11.Log.WriteLine("{");
                    MyRender11.Log.IncreaseIndent();

                    MyRender11.Log.WriteLine("Caption = " + m["Caption"]);
                    MyRender11.Log.WriteLine("AdapterRam = " + m["AdapterRam"]);
                    MyRender11.Log.WriteLine("DriverVersion = " + m["DriverVersion"]);
                    MyRender11.Log.WriteLine("DriverDate = " + m["DriverDate"]);
                    MyRender11.Log.WriteLine("Description = " + m["Description"]);
                    MyRender11.Log.WriteLine("DeviceID = " + m["DeviceID"]);
                    MyRender11.Log.WriteLine("Name = " + m["Name"]);
                    MyRender11.Log.WriteLine("VideoProcessor = " + m["VideoProcessor"]);
                    MyRender11.Log.WriteLine("VideoArchitecture = " + m["VideoArchitecture"]);
                    MyRender11.Log.WriteLine("PNPDeviceID = " + m["PNPDeviceID"]);
                    MyRender11.Log.WriteLine("InstalledDisplayDrivers = " + m["InstalledDisplayDrivers"]);

                    MyRender11.Log.DecreaseIndent();
                    MyRender11.Log.WriteLine("}");
                }
                MyRender11.Log.DecreaseIndent();
                MyRender11.Log.WriteLine("}");
            }
            catch
            {
            }
        }

        static void LogAdapterInfoBegin(ref MyAdapterInfo info)
        {
            MyRender11.Log.WriteLine("AdapterInfo = {");
            MyRender11.Log.IncreaseIndent();
            MyRender11.Log.WriteLine("Name = " + info.Name);
            MyRender11.Log.WriteLine("Device name = " + info.DeviceName);
            MyRender11.Log.WriteLine("Description = " + info.Description);
            MyRender11.Log.WriteLine("DXGIAdapter id = " + info.AdapterDeviceId);
            MyRender11.Log.WriteLine("SUPPORTED = " + info.IsDx11Supported);
            MyRender11.Log.WriteLine("VRAM = " + info.VRAM);
            MyRender11.Log.WriteLine("Multithreaded rendering supported = " + info.MultithreadedRenderingSupported);
        }

        static void LogAdapterInfoEnd()
        {
            MyRender11.Log.DecreaseIndent();
            MyRender11.Log.WriteLine("}");
        }

        static void LogOutputDisplayModes(ref MyAdapterInfo info)
        {
            MyRender11.Log.WriteLine("Display modes = {");
            MyRender11.Log.IncreaseIndent();
            MyRender11.Log.WriteLine("DXGIOutput id = " + info.OutputId);
            for(int i=0; i< info.SupportedDisplayModes.Length; i++)
            {
                MyRender11.Log.WriteLine(info.SupportedDisplayModes[i].ToString());
            }
            MyRender11.Log.DecreaseIndent();
            MyRender11.Log.WriteLine("}");
        }

        unsafe static MyAdapterInfo[] CreateAdaptersList()
        {
            List<MyAdapterInfo> adaptersList = new List<MyAdapterInfo>();

            var factory = GetFactory();
            FeatureLevel[] featureLevels = { FeatureLevel.Level_11_0 };

            int adapterIndex = 0;

            LogInfoFromWMI();

            Adapter[] adapters = null;
            
            try
            {
//                var defaultdxdevice = new Device(DriverType.Hardware, DeviceCreationFlags.None, featureLevels);
                // SwapChain description 
                // Create the Rendering form 
                var form = new SharpDX.Windows.RenderForm("SharpDX - test");
                form.ClientSize = new System.Drawing.Size(100, 100);

                var desc = new SwapChainDescription()
                {
                    BufferCount = 2,
                    ModeDescription =
                        new ModeDescription(800, 600,
                                            new Rational(60, 1), Format.R8G8B8A8_UNorm),
                    IsWindowed = true,
                    SampleDescription = new SampleDescription(1, 0),
                    SwapEffect = SwapEffect.Discard,
                    Usage = Usage.RenderTargetOutput
                };

                // Create Device and SwapChain 
                Device defaultdxdevice;
                SwapChain swapChain;
                Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, desc, out defaultdxdevice, out swapChain);
                if (defaultdxdevice != null)
                {
                    var dxgidevice = defaultdxdevice.QueryInterface<SharpDX.DXGI.Device>();
                    var dxgiadapter = dxgidevice.GetParent<SharpDX.DXGI.Adapter>();
                    //var dxgifactory = dxgiadapter.GetParent<SharpDX.DXGI.Factory>();

                    //factory = dxgifactory;
                    if (dxgiadapter != null)
                    {
                        adapters = new Adapter[1];
                        adapters[0] = dxgiadapter;
                    }
                    dxgidevice.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
            
            if (adapters == null)
                adapters = factory.Adapters;

            for(int i=0; i < adapters.Length; i++)
            {
                var testadapter = adapters[i];
                Device adapterTestDevice = null;
                try
                {
                    adapterTestDevice = new Device(testadapter, DeviceCreationFlags.None, featureLevels);
                }
                catch(SharpDXException e)
                {

                }

                bool supportedDevice = adapterTestDevice != null;

                bool supportsConcurrentResources = false;
                bool supportsCommandLists = false;
                if (supportedDevice)
                {
                    adapterTestDevice.CheckThreadingSupport(out supportsConcurrentResources, out supportsCommandLists);
                }

                var dxgidevice = adapterTestDevice.QueryInterface<SharpDX.DXGI.Device>();
                var adapter = dxgidevice.GetParent<SharpDX.DXGI.Adapter>();
                
                //                void* ptr = ((IntPtr)adapter.Description.DedicatedVideoMemory).ToPointer();
//                ulong vram = (ulong)ptr;
                // DedicatedSystemMemory = bios or DVMT preallocated video memory, that cannot be used by OS - need retest on pc with only cpu/chipset based graphic
                // DedicatedVideoMemory = discrete graphic video memory
                // SharedSystemMemory = aditional video memory, that can be taken from OS RAM when needed
                UInt32 vram = (UInt32)((IntPtr)(adapter.Description.DedicatedSystemMemory != 0 ? adapter.Description.DedicatedSystemMemory : adapter.Description.DedicatedVideoMemory));
                UInt32 svram = (UInt32)((IntPtr)adapter.Description.SharedSystemMemory);

                // microsoft software renderer allocates 256MB shared memory, cpu integrated graphic on notebooks has 0 preallocated, all shared
                supportedDevice = supportedDevice && (vram > 500000000 || svram > 500000000);

                var deviceDesc = String.Format("{0}, dev id: {1}, mem: {2}, shared mem: {3}, Luid: {4}, rev: {5}, subsys id: {6}, vendor id: {7}",
                    adapter.Description.Description,
                    adapter.Description.DeviceId,
                    vram,
                    svram,
                    adapter.Description.Luid,
                    adapter.Description.Revision,
                    adapter.Description.SubsystemId,
                    adapter.Description.VendorId
                    );

                var info = new MyAdapterInfo
                {
                    Name = adapter.Description.Description,
                    DeviceName = adapter.Description.Description,
                    Description = deviceDesc,
                    IsDx11Supported = supportedDevice,
                    AdapterDeviceId = i,

                    HDRSupported = true,
                    MaxTextureSize = SharpDX.Direct3D11.Texture2D.MaximumTexture2DSize,

                    VRAM = vram > 0 ? vram : svram,
                    IsIntegrated = (vram < 200000000),
                    Has512MBRam = (vram > 500000000 || svram > 500000000),
                    MultithreadedRenderingSupported = supportsCommandLists
                };

                if(info.VRAM >= 2000000000)
                {
                    info.MaxTextureQualitySupported = MyTextureQuality.HIGH;
                }
                else if (info.VRAM >= 1000000000)
                {
                    info.MaxTextureQualitySupported = MyTextureQuality.MEDIUM;
                }
                else
                { 
                    info.MaxTextureQualitySupported = MyTextureQuality.LOW;
                }

                info.MaxAntialiasingModeSupported = MyAntialiasingMode.FXAA;
                if (supportedDevice)
                {
                    if (adapterTestDevice.CheckMultisampleQualityLevels(Format.R11G11B10_Float, 2) > 0)
                    {
                        info.MaxAntialiasingModeSupported = MyAntialiasingMode.MSAA_2;
                    }
                    if (adapterTestDevice.CheckMultisampleQualityLevels(Format.R11G11B10_Float, 4) > 0)
                    {
                        info.MaxAntialiasingModeSupported = MyAntialiasingMode.MSAA_4;
                    }
                    if (adapterTestDevice.CheckMultisampleQualityLevels(Format.R11G11B10_Float, 8) > 0)
                    {
                        info.MaxAntialiasingModeSupported = MyAntialiasingMode.MSAA_8;
                    }
                }

                LogAdapterInfoBegin(ref info);

                if(supportedDevice)
                {
                    for(int j=0; j<factory.Adapters[i].Outputs.Length; j++)
                    {
                        var output = factory.Adapters[i].Outputs[j];

                        info.Name = String.Format("{0} + {1}", adapter.Description.Description, output.Description.DeviceName);
                        info.OutputName = output.Description.DeviceName;
                        info.OutputId = j;

                        var displayModeList = factory.Adapters[i].Outputs[j].GetDisplayModeList(MyRender11Constants.BACKBUFFER_FORMAT, DisplayModeEnumerationFlags.Interlaced);
                        var adapterDisplayModes = new MyDisplayMode[displayModeList.Length];
                        for (int k = 0; k < displayModeList.Length; k++)
                        {
                            var displayMode = displayModeList[k];

                            adapterDisplayModes[k] = new MyDisplayMode 
                            { 
                                Height = displayMode.Height, 
                                Width = displayMode.Width, 
                                RefreshRate = displayMode.RefreshRate.Numerator, 
                                RefreshRateDenominator = displayMode.RefreshRate.Denominator 
                            }; 
                        }
                        Array.Sort(adapterDisplayModes, m_refreshRatePriorityComparer);

                        info.SupportedDisplayModes = adapterDisplayModes;
                        info.CurrentDisplayMode = adapterDisplayModes[adapterDisplayModes.Length - 1];


                        adaptersList.Add(info);
                        m_adapterModes[adapterIndex] = displayModeList;
                        adapterIndex++;

                        LogOutputDisplayModes(ref info);
                    }
                }
                /* nope, not supported
                else
                {
                    info.SupportedDisplayModes = new MyDisplayMode[0];
                    adaptersList.Add(info);
                    adapterIndex++;
                }
                */
                LogAdapterInfoEnd();

                if(adapterTestDevice != null)
                {
                    dxgidevice = null;
                    adapter = null;
                    adapterTestDevice.Dispose();
                    adapterTestDevice = null;
                }
            }

            return adaptersList.ToArray();
        }

		internal unsafe static MyAdapterInfo[] GetAdaptersList()
		{
            if(m_adapterInfoList == null)
            {
                m_adapterInfoList = CreateAdaptersList();
            }

            return m_adapterInfoList;
		}
	}
}
