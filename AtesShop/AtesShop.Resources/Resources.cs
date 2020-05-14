using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace AtesShop.Resources {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>IP Camera</summary>
        public static string CategoryName1 {
               get {
                   return resourceProvider.GetResource("CategoryName1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>IP Camera</summary>
        public static string CategoryDesc1 {
               get {
                   return resourceProvider.GetResource("CategoryDesc1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>NVR Device</summary>
        public static string CategoryName2 {
               get {
                   return resourceProvider.GetResource("CategoryName2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>NVR Device</summary>
        public static string CategoryDesc2 {
               get {
                   return resourceProvider.GetResource("CategoryDesc2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Solar Panel</summary>
        public static string CategoryName3 {
               get {
                   return resourceProvider.GetResource("CategoryName3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Solar Panel</summary>
        public static string CategoryDesc3 {
               get {
                   return resourceProvider.GetResource("CategoryDesc3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SC-N2MXXXX-I</summary>
        public static string ProductName1 {
               get {
                   return resourceProvider.GetResource("ProductName1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 2MP Economic IP Camera</summary>
        public static string ProductDesc1 {
               get {
                   return resourceProvider.GetResource("ProductDesc1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SC-N2MXXXX-IW</summary>
        public static string ProductName2 {
               get {
                   return resourceProvider.GetResource("ProductName2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 2MP WDR IP Camera</summary>
        public static string ProductDesc2 {
               get {
                   return resourceProvider.GetResource("ProductDesc2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SC-N4MXXXX-IW</summary>
        public static string ProductName3 {
               get {
                   return resourceProvider.GetResource("ProductName3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 4MP WDR IP Camera</summary>
        public static string ProductDesc3 {
               get {
                   return resourceProvider.GetResource("ProductDesc3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SR-N0800000</summary>
        public static string ProductName4 {
               get {
                   return resourceProvider.GetResource("ProductName4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 8CH NVR (E-version)</summary>
        public static string ProductDesc4 {
               get {
                   return resourceProvider.GetResource("ProductDesc4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SR-N1600000</summary>
        public static string ProductName5 {
               get {
                   return resourceProvider.GetResource("ProductName5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 16CH NVR (E-version) </summary>
        public static string ProductDesc5 {
               get {
                   return resourceProvider.GetResource("ProductDesc5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SR-N2400000</summary>
        public static string ProductName6 {
               get {
                   return resourceProvider.GetResource("ProductName6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 24CH NVR (E-version)</summary>
        public static string ProductDesc6 {
               get {
                   return resourceProvider.GetResource("ProductDesc6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SR-N0800001</summary>
        public static string ProductName7 {
               get {
                   return resourceProvider.GetResource("ProductName7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 8CH NVR (P-version)</summary>
        public static string ProductDesc7 {
               get {
                   return resourceProvider.GetResource("ProductDesc7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SR-N1600001</summary>
        public static string ProductName8 {
               get {
                   return resourceProvider.GetResource("ProductName8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 16CH NVR (P-version)</summary>
        public static string ProductDesc8 {
               get {
                   return resourceProvider.GetResource("ProductDesc8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SR-N2400001</summary>
        public static string ProductName9 {
               get {
                   return resourceProvider.GetResource("ProductName9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 24CH NVR (P-version)</summary>
        public static string ProductDesc9 {
               get {
                   return resourceProvider.GetResource("ProductDesc9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SC-N2MXXXP-I</summary>
        public static string ProductName10 {
               get {
                   return resourceProvider.GetResource("ProductName10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 2MP Economic Mini PT IP Dome Camera</summary>
        public static string ProductDesc10 {
               get {
                   return resourceProvider.GetResource("ProductDesc10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PA-SC-N4MXXXP-IW</summary>
        public static string ProductName11 {
               get {
                   return resourceProvider.GetResource("ProductName11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Active 4MP WDR Mini PT IP Dome Camera</summary>
        public static string ProductDesc11 {
               get {
                   return resourceProvider.GetResource("ProductDesc11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Home</summary>
        public static string HomeT1O1 {
               get {
                   return resourceProvider.GetResource("HomeT1O1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Products</summary>
        public static string ProductsT1O2 {
               get {
                   return resourceProvider.GetResource("ProductsT1O2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Shop</summary>
        public static string ShopT1O3 {
               get {
                   return resourceProvider.GetResource("ShopT1O3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Support</summary>
        public static string SupportT1O4 {
               get {
                   return resourceProvider.GetResource("SupportT1O4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>About</summary>
        public static string AboutT1O5 {
               get {
                   return resourceProvider.GetResource("AboutT1O5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>IP Camera</summary>
        public static string IPCameraT2O1 {
               get {
                   return resourceProvider.GetResource("IPCameraT2O1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>NVR Device</summary>
        public static string NVRDeviceT2O2 {
               get {
                   return resourceProvider.GetResource("NVRDeviceT2O2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Solar Panel</summary>
        public static string SolarPanelT2O3 {
               get {
                   return resourceProvider.GetResource("SolarPanelT2O3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>About Us</summary>
        public static string AboutUsT2O1 {
               get {
                   return resourceProvider.GetResource("AboutUsT2O1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Contact Us</summary>
        public static string ContactUsT2O2 {
               get {
                   return resourceProvider.GetResource("ContactUsT2O2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1/2.9” 2 Megapixel Progressive Scan CMOS</summary>
        public static string Feature1 {
               get {
                   return resourceProvider.GetResource("Feature1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1/2.8” 2 Megapixel Progressive Scan CMOS</summary>
        public static string Feature2 {
               get {
                   return resourceProvider.GetResource("Feature2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1/3” 4 Megapixel Progressive Scan CMOS</summary>
        public static string Feature3 {
               get {
                   return resourceProvider.GetResource("Feature3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>H.265 encoding</summary>
        public static string Feature4 {
               get {
                   return resourceProvider.GetResource("Feature4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>H.265 / MJPEG encoding</summary>
        public static string Feature5 {
               get {
                   return resourceProvider.GetResource("Feature5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Triple Stream</summary>
        public static string Feature6 {
               get {
                   return resourceProvider.GetResource("Feature6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>30 fps @ 2 Megapixel (1920x1080)</summary>
        public static string Feature7 {
               get {
                   return resourceProvider.GetResource("Feature7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>30 fps @ 4 Megapixel (2560x1440)</summary>
        public static string Feature8 {
               get {
                   return resourceProvider.GetResource("Feature8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>25 fps @ 4 Megapixel (2560x1440)</summary>
        public static string Feature9 {
               get {
                   return resourceProvider.GetResource("Feature9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>D-WDR</summary>
        public static string Feature10 {
               get {
                   return resourceProvider.GetResource("Feature10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>WDR (120dB)</summary>
        public static string Feature11 {
               get {
                   return resourceProvider.GetResource("Feature11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>3D DNR</summary>
        public static string Feature12 {
               get {
                   return resourceProvider.GetResource("Feature12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Smart IR</summary>
        public static string Feature13 {
               get {
                   return resourceProvider.GetResource("Feature13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Smart Functions</summary>
        public static string Feature14 {
               get {
                   return resourceProvider.GetResource("Feature14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Day/Night (IR CUT filter with auto switch)</summary>
        public static string Feature15 {
               get {
                   return resourceProvider.GetResource("Feature15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>2/1 Interface Input/Output</summary>
        public static string Feature16 {
               get {
                   return resourceProvider.GetResource("Feature16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>P2P and IE browser support</summary>
        public static string Feature17 {
               get {
                   return resourceProvider.GetResource("Feature17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Pan / Tilt control</summary>
        public static string Feature18 {
               get {
                   return resourceProvider.GetResource("Feature18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Preset Support</summary>
        public static string Feature19 {
               get {
                   return resourceProvider.GetResource("Feature19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>8 IP Camera Inputs</summary>
        public static string Feature20 {
               get {
                   return resourceProvider.GetResource("Feature20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>16 IP Camera Inputs</summary>
        public static string Feature21 {
               get {
                   return resourceProvider.GetResource("Feature21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>24 IP Camera Inputs</summary>
        public static string Feature22 {
               get {
                   return resourceProvider.GetResource("Feature22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Max. 64Mbps Incoming Bandwidth</summary>
        public static string Feature23 {
               get {
                   return resourceProvider.GetResource("Feature23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Max. 96Mbps Incoming Bandwidth</summary>
        public static string Feature24 {
               get {
                   return resourceProvider.GetResource("Feature24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Max. 192Mbps Incoming Bandwidth</summary>
        public static string Feature25 {
               get {
                   return resourceProvider.GetResource("Feature25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>8 Mp, 6 Mp, 5 Mp, 3Mp, 1080p, 720p, D1 Resolutions for Preview and Playback</summary>
        public static string Feature26 {
               get {
                   return resourceProvider.GetResource("Feature26", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1080p, 720p, D1 Resolutions for Preview and Playback</summary>
        public static string Feature27 {
               get {
                   return resourceProvider.GetResource("Feature27", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>8 Alarm Inputs, 4 Alarm Outputs</summary>
        public static string Feature28 {
               get {
                   return resourceProvider.GetResource("Feature28", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>2 SATA, 2 USB2.0, 1 RJ45(1000M)</summary>
        public static string Feature29 {
               get {
                   return resourceProvider.GetResource("Feature29", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>IP Camera</summary>
        public static string ASection1 {
               get {
                   return resourceProvider.GetResource("ASection1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Camera Features</summary>
        public static string ASection2 {
               get {
                   return resourceProvider.GetResource("ASection2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Lens</summary>
        public static string ASection3 {
               get {
                   return resourceProvider.GetResource("ASection3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Video</summary>
        public static string ASection4 {
               get {
                   return resourceProvider.GetResource("ASection4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Smart Functions</summary>
        public static string ASection5 {
               get {
                   return resourceProvider.GetResource("ASection5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Network</summary>
        public static string ASection6 {
               get {
                   return resourceProvider.GetResource("ASection6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>AUX Interface</summary>
        public static string ASection7 {
               get {
                   return resourceProvider.GetResource("ASection7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>General</summary>
        public static string ASection8 {
               get {
                   return resourceProvider.GetResource("ASection8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>System</summary>
        public static string ASection9 {
               get {
                   return resourceProvider.GetResource("ASection9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Audio and Video</summary>
        public static string ASection10 {
               get {
                   return resourceProvider.GetResource("ASection10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Display</summary>
        public static string ASection11 {
               get {
                   return resourceProvider.GetResource("ASection11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Recording</summary>
        public static string ASection12 {
               get {
                   return resourceProvider.GetResource("ASection12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Video Detection and Alarm</summary>
        public static string ASection13 {
               get {
                   return resourceProvider.GetResource("ASection13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Playback and Backup</summary>
        public static string ASection14 {
               get {
                   return resourceProvider.GetResource("ASection14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Storage</summary>
        public static string ASection15 {
               get {
                   return resourceProvider.GetResource("ASection15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Electrical</summary>
        public static string ASection16 {
               get {
                   return resourceProvider.GetResource("ASection16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Environmental</summary>
        public static string ASection17 {
               get {
                   return resourceProvider.GetResource("ASection17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Construction</summary>
        public static string ASection18 {
               get {
                   return resourceProvider.GetResource("ASection18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>PT Features</summary>
        public static string ASection19 {
               get {
                   return resourceProvider.GetResource("ASection19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Image Sensor</summary>
        public static string AType1 {
               get {
                   return resourceProvider.GetResource("AType1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Effective Pixels</summary>
        public static string AType2 {
               get {
                   return resourceProvider.GetResource("AType2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Scanning System</summary>
        public static string AType3 {
               get {
                   return resourceProvider.GetResource("AType3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Electronic Shutter Speed</summary>
        public static string AType4 {
               get {
                   return resourceProvider.GetResource("AType4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Min. Illumination</summary>
        public static string AType5 {
               get {
                   return resourceProvider.GetResource("AType5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>S/N Ratio</summary>
        public static string AType6 {
               get {
                   return resourceProvider.GetResource("AType6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Video Output</summary>
        public static string AType7 {
               get {
                   return resourceProvider.GetResource("AType7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>IR LED Illumination Distance</summary>
        public static string AType8 {
               get {
                   return resourceProvider.GetResource("AType8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Day / Night</summary>
        public static string AType9 {
               get {
                   return resourceProvider.GetResource("AType9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>BLC Mode</summary>
        public static string AType10 {
               get {
                   return resourceProvider.GetResource("AType10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>White Balance</summary>
        public static string AType11 {
               get {
                   return resourceProvider.GetResource("AType11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Gain Control</summary>
        public static string AType12 {
               get {
                   return resourceProvider.GetResource("AType12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Noise Reduction</summary>
        public static string AType13 {
               get {
                   return resourceProvider.GetResource("AType13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>WDR</summary>
        public static string AType14 {
               get {
                   return resourceProvider.GetResource("AType14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Privacy Masking</summary>
        public static string AType15 {
               get {
                   return resourceProvider.GetResource("AType15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Defog</summary>
        public static string AType16 {
               get {
                   return resourceProvider.GetResource("AType16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Mount Type</summary>
        public static string AType17 {
               get {
                   return resourceProvider.GetResource("AType17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Compression</summary>
        public static string AType18 {
               get {
                   return resourceProvider.GetResource("AType18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Resolution</summary>
        public static string AType19 {
               get {
                   return resourceProvider.GetResource("AType19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Frame Rate</summary>
        public static string AType20 {
               get {
                   return resourceProvider.GetResource("AType20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Bit Rate</summary>
        public static string AType21 {
               get {
                   return resourceProvider.GetResource("AType21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Smart Alarm</summary>
        public static string AType22 {
               get {
                   return resourceProvider.GetResource("AType22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Video Analysis</summary>
        public static string AType23 {
               get {
                   return resourceProvider.GetResource("AType23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Ethernet</summary>
        public static string AType24 {
               get {
                   return resourceProvider.GetResource("AType24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Wi-Fi</summary>
        public static string AType25 {
               get {
                   return resourceProvider.GetResource("AType25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Protocol</summary>
        public static string AType26 {
               get {
                   return resourceProvider.GetResource("AType26", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>ONVIF</summary>
        public static string AType27 {
               get {
                   return resourceProvider.GetResource("AType27", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Max. User Access</summary>
        public static string AType28 {
               get {
                   return resourceProvider.GetResource("AType28", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Smart Phone</summary>
        public static string AType29 {
               get {
                   return resourceProvider.GetResource("AType29", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Alarm</summary>
        public static string AType30 {
               get {
                   return resourceProvider.GetResource("AType30", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Analog</summary>
        public static string AType31 {
               get {
                   return resourceProvider.GetResource("AType31", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Supply</summary>
        public static string AType32 {
               get {
                   return resourceProvider.GetResource("AType32", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Power Consumption</summary>
        public static string AType33 {
               get {
                   return resourceProvider.GetResource("AType33", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Operating Conditions</summary>
        public static string AType34 {
               get {
                   return resourceProvider.GetResource("AType34", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Ingress Protection</summary>
        public static string AType35 {
               get {
                   return resourceProvider.GetResource("AType35", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Dimensions</summary>
        public static string AType36 {
               get {
                   return resourceProvider.GetResource("AType36", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Main Processor</summary>
        public static string AType37 {
               get {
                   return resourceProvider.GetResource("AType37", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Operating System</summary>
        public static string AType38 {
               get {
                   return resourceProvider.GetResource("AType38", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>IP Camera Input</summary>
        public static string AType39 {
               get {
                   return resourceProvider.GetResource("AType39", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Two-way Talk</summary>
        public static string AType40 {
               get {
                   return resourceProvider.GetResource("AType40", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Interface</summary>
        public static string AType41 {
               get {
                   return resourceProvider.GetResource("AType41", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Resolution</summary>
        public static string AType42 {
               get {
                   return resourceProvider.GetResource("AType42", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Live View / Playback Capacity</summary>
        public static string AType43 {
               get {
                   return resourceProvider.GetResource("AType43", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Multi Screen Display</summary>
        public static string AType44 {
               get {
                   return resourceProvider.GetResource("AType44", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>OSD</summary>
        public static string AType45 {
               get {
                   return resourceProvider.GetResource("AType45", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Record Rate</summary>
        public static string AType46 {
               get {
                   return resourceProvider.GetResource("AType46", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Record Mode</summary>
        public static string AType47 {
               get {
                   return resourceProvider.GetResource("AType47", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Trigger Events</summary>
        public static string AType48 {
               get {
                   return resourceProvider.GetResource("AType48", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Video Detection</summary>
        public static string AType49 {
               get {
                   return resourceProvider.GetResource("AType49", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Alarm Input and Output</summary>
        public static string AType50 {
               get {
                   return resourceProvider.GetResource("AType50", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Playback Synch</summary>
        public static string AType51 {
               get {
                   return resourceProvider.GetResource("AType51", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Search Mode</summary>
        public static string AType52 {
               get {
                   return resourceProvider.GetResource("AType52", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Backup Mode</summary>
        public static string AType53 {
               get {
                   return resourceProvider.GetResource("AType53", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Network Function</summary>
        public static string AType54 {
               get {
                   return resourceProvider.GetResource("AType54", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Internal HDD</summary>
        public static string AType55 {
               get {
                   return resourceProvider.GetResource("AType55", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>HDD Mode</summary>
        public static string AType56 {
               get {
                   return resourceProvider.GetResource("AType56", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>USB</summary>
        public static string AType57 {
               get {
                   return resourceProvider.GetResource("AType57", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>RS-485</summary>
        public static string AType58 {
               get {
                   return resourceProvider.GetResource("AType58", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Operating Temperature</summary>
        public static string AType59 {
               get {
                   return resourceProvider.GetResource("AType59", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Operating Humidity</summary>
        public static string AType60 {
               get {
                   return resourceProvider.GetResource("AType60", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Dimensions</summary>
        public static string AType61 {
               get {
                   return resourceProvider.GetResource("AType61", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Package Size</summary>
        public static string AType62 {
               get {
                   return resourceProvider.GetResource("AType62", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Net Weight</summary>
        public static string AType63 {
               get {
                   return resourceProvider.GetResource("AType63", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Pan</summary>
        public static string AType64 {
               get {
                   return resourceProvider.GetResource("AType64", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Tilt</summary>
        public static string AType65 {
               get {
                   return resourceProvider.GetResource("AType65", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Preset</summary>
        public static string AType66 {
               get {
                   return resourceProvider.GetResource("AType66", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1/2.9" 2 Megapixel CMOS</summary>
        public static string AValue1 {
               get {
                   return resourceProvider.GetResource("AValue1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1/2.8" 2 Megapixel CMOS</summary>
        public static string AValue2 {
               get {
                   return resourceProvider.GetResource("AValue2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1/3" 4 Megapixel CMOS </summary>
        public static string AValue3 {
               get {
                   return resourceProvider.GetResource("AValue3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1920(H)×1080(V)</summary>
        public static string AValue4 {
               get {
                   return resourceProvider.GetResource("AValue4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>2560(H)×1440(V) </summary>
        public static string AValue5 {
               get {
                   return resourceProvider.GetResource("AValue5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Progressive</summary>
        public static string AValue6 {
               get {
                   return resourceProvider.GetResource("AValue6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Auto/Manual, 1/3(4)~1/10000s</summary>
        public static string AValue7 {
               get {
                   return resourceProvider.GetResource("AValue7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Color: 0.1Lux@F1.2, B/W: 0.01Lux@F1.2</summary>
        public static string AValue8 {
               get {
                   return resourceProvider.GetResource("AValue8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>60dB</summary>
        public static string AValue9 {
               get {
                   return resourceProvider.GetResource("AValue9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 Interface BNC (1.0Vp-p,75Ω)</summary>
        public static string AValue10 {
               get {
                   return resourceProvider.GetResource("AValue10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>15 meter</summary>
        public static string AValue11 {
               get {
                   return resourceProvider.GetResource("AValue11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Auto(ICR) / Color / B/W</summary>
        public static string AValue12 {
               get {
                   return resourceProvider.GetResource("AValue12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>BLC / HLC / D-WDR</summary>
        public static string AValue13 {
               get {
                   return resourceProvider.GetResource("AValue13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>BLC / HLC / WDR 120dB</summary>
        public static string AValue14 {
               get {
                   return resourceProvider.GetResource("AValue14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Auto / Manual</summary>
        public static string AValue15 {
               get {
                   return resourceProvider.GetResource("AValue15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>DNR (2D/3D)</summary>
        public static string AValue16 {
               get {
                   return resourceProvider.GetResource("AValue16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>D-WDR</summary>
        public static string AValue17 {
               get {
                   return resourceProvider.GetResource("AValue17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>D-WDR, WDR</summary>
        public static string AValue18 {
               get {
                   return resourceProvider.GetResource("AValue18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>4 Area</summary>
        public static string AValue19 {
               get {
                   return resourceProvider.GetResource("AValue19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Support</summary>
        public static string AValue20 {
               get {
                   return resourceProvider.GetResource("AValue20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>4 mm (6 mm optional)</summary>
        public static string AValue21 {
               get {
                   return resourceProvider.GetResource("AValue21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>H.265 / H.264 High Profile/Main Profile/Base Line Profile</summary>
        public static string AValue22 {
               get {
                   return resourceProvider.GetResource("AValue22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>H.265 / H.264 High Profile/Main Profile/Base Line Profile / MJPEG </summary>
        public static string AValue23 {
               get {
                   return resourceProvider.GetResource("AValue23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1080p(1920×1080)/ 720p(1280×720)/ D1(704×576)/ CIF(352×288)</summary>
        public static string AValue24 {
               get {
                   return resourceProvider.GetResource("AValue24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>4Mp/ 1080p(1920×1080)/ 720p(1280×720)/ D1(704×576)/ CIF(352×288) </summary>
        public static string AValue25 {
               get {
                   return resourceProvider.GetResource("AValue25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Main Stream: 1080p (1~25/30 fps); Sub Stream: D1/ CIF (1~25/30 fps) </summary>
        public static string AValue26 {
               get {
                   return resourceProvider.GetResource("AValue26", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Main Stream: 1080p (1~25/30 fps); Sub Stream: D1/ CIF (1~25/30 fps); Third Stream: 720p (1~25/30 fps) </summary>
        public static string AValue27 {
               get {
                   return resourceProvider.GetResource("AValue27", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Main Stream: 4Mp (25fps) / 1080p (1~25/30 fps); Sub Stream: D1/ CIF (1~25/30 fps); Third Stream: 720p (1~25/30 fps) </summary>
        public static string AValue28 {
               get {
                   return resourceProvider.GetResource("AValue28", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>32kbps ~ 8Mbps</summary>
        public static string AValue29 {
               get {
                   return resourceProvider.GetResource("AValue29", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Network abnormal, cover alarm etc.</summary>
        public static string AValue30 {
               get {
                   return resourceProvider.GetResource("AValue30", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Face Detection</summary>
        public static string AValue31 {
               get {
                   return resourceProvider.GetResource("AValue31", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Tripwire Detection</summary>
        public static string AValue32 {
               get {
                   return resourceProvider.GetResource("AValue32", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Regional Invasion Detection</summary>
        public static string AValue33 {
               get {
                   return resourceProvider.GetResource("AValue33", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Abandoned/Missing Object Detection</summary>
        public static string AValue34 {
               get {
                   return resourceProvider.GetResource("AValue34", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Scene Change Detection</summary>
        public static string AValue35 {
               get {
                   return resourceProvider.GetResource("AValue35", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>RJ-45 (10/100/1000Base-T)</summary>
        public static string AValue36 {
               get {
                   return resourceProvider.GetResource("AValue36", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>-</summary>
        public static string AValue37 {
               get {
                   return resourceProvider.GetResource("AValue37", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>IPv4/IPv6, HTTP, TCP/IP, UDP, UPnP, ICMP, IGMP, SNMP, RTSP, RTP, SMTP, NTP, DHCP, PPPOE, DDNS, FTP, IP Filter</summary>
        public static string AValue38 {
               get {
                   return resourceProvider.GetResource("AValue38", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>ONVIF2.6 / CGI</summary>
        public static string AValue39 {
               get {
                   return resourceProvider.GetResource("AValue39", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>ONVIF2.6 / CGI / GB28181</summary>
        public static string AValue40 {
               get {
                   return resourceProvider.GetResource("AValue40", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>20 Users</summary>
        public static string AValue41 {
               get {
                   return resourceProvider.GetResource("AValue41", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>iPhone, iPad, Android</summary>
        public static string AValue42 {
               get {
                   return resourceProvider.GetResource("AValue42", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>2/1 Interface Input/Output </summary>
        public static string AValue43 {
               get {
                   return resourceProvider.GetResource("AValue43", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>DC 12V</summary>
        public static string AValue44 {
               get {
                   return resourceProvider.GetResource("AValue44", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>DC 12V / POE</summary>
        public static string AValue45 {
               get {
                   return resourceProvider.GetResource("AValue45", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Max 10W</summary>
        public static string AValue46 {
               get {
                   return resourceProvider.GetResource("AValue46", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 0 ⁰C ~ 50 ⁰C</summary>
        public static string AValue47 {
               get {
                   return resourceProvider.GetResource("AValue47", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>IP66</summary>
        public static string AValue48 {
               get {
                   return resourceProvider.GetResource("AValue48", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Bullet Model: 63.0mm × 63.0mm × 166.0mm; Dome Model: 93.2mm × 93.2mm × 66.5mm </summary>
        public static string AValue49 {
               get {
                   return resourceProvider.GetResource("AValue49", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Dome Model: 110mm × 96mm</summary>
        public static string AValue50 {
               get {
                   return resourceProvider.GetResource("AValue50", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>355⁰ / Speed: 0 ~ 25 degrees per second</summary>
        public static string AValue51 {
               get {
                   return resourceProvider.GetResource("AValue51", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>0 ~ 90⁰ / Speed: 0 ~ 20 degrees per second</summary>
        public static string AValue52 {
               get {
                   return resourceProvider.GetResource("AValue52", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>6</summary>
        public static string AValue53 {
               get {
                   return resourceProvider.GetResource("AValue53", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Dual-core, Embedded</summary>
        public static string AValue54 {
               get {
                   return resourceProvider.GetResource("AValue54", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Embedded LINUX</summary>
        public static string AValue55 {
               get {
                   return resourceProvider.GetResource("AValue55", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>8 Channel</summary>
        public static string AValue56 {
               get {
                   return resourceProvider.GetResource("AValue56", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>16 Channel</summary>
        public static string AValue57 {
               get {
                   return resourceProvider.GetResource("AValue57", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>24 Channel</summary>
        public static string AValue58 {
               get {
                   return resourceProvider.GetResource("AValue58", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 Channel Input, 1 Channel Output, RCA</summary>
        public static string AValue59 {
               get {
                   return resourceProvider.GetResource("AValue59", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 Interface, BNC (1.0Vp-p, 75Ω)</summary>
        public static string AValue60 {
               get {
                   return resourceProvider.GetResource("AValue60", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 HDMI, 1 VGA</summary>
        public static string AValue61 {
               get {
                   return resourceProvider.GetResource("AValue61", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>HDMI: 3840×2160, 1920×1080, 1280×1024, 1280×720, 1024×768; VGA: 1920×1080, 1280×1024, 1280×720, 1024×768 </summary>
        public static string AValue62 {
               get {
                   return resourceProvider.GetResource("AValue62", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>HDMI: 1920×1080, 1280×1024, 1280×720, 1024×768; VGA: 1920×1080, 1280×1024, 1280×720, 1024×768 </summary>
        public static string AValue63 {
               get {
                   return resourceProvider.GetResource("AValue63", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>4 Channel @1080p 30fps</summary>
        public static string AValue64 {
               get {
                   return resourceProvider.GetResource("AValue64", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>8 Channel @1440p 30fps</summary>
        public static string AValue65 {
               get {
                   return resourceProvider.GetResource("AValue65", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>16 Channel @1080p 30fps</summary>
        public static string AValue66 {
               get {
                   return resourceProvider.GetResource("AValue66", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 / 4 / 8 / 9</summary>
        public static string AValue67 {
               get {
                   return resourceProvider.GetResource("AValue67", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 / 4 / 8 / 9 / 16</summary>
        public static string AValue68 {
               get {
                   return resourceProvider.GetResource("AValue68", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Camera title, Time, Camera lock, Motion detection, Recording</summary>
        public static string AValue69 {
               get {
                   return resourceProvider.GetResource("AValue69", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>H.265 + / H.265 / H.264 + / H.264 </summary>
        public static string AValue70 {
               get {
                   return resourceProvider.GetResource("AValue70", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>8Mp / 6 Mp / 5 Mp / 4 Mp / 3 Mp / 1080p / 1.3 Mp / 720p </summary>
        public static string AValue71 {
               get {
                   return resourceProvider.GetResource("AValue71", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1080p / 1.3 Mp / 720p </summary>
        public static string AValue72 {
               get {
                   return resourceProvider.GetResource("AValue72", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>64Mbps</summary>
        public static string AValue73 {
               get {
                   return resourceProvider.GetResource("AValue73", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>96Mbps</summary>
        public static string AValue74 {
               get {
                   return resourceProvider.GetResource("AValue74", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>192Mbps </summary>
        public static string AValue75 {
               get {
                   return resourceProvider.GetResource("AValue75", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Manual, Schedule (Regular, MD (Motion Detection), Alarm), Holiday, Stop </summary>
        public static string AValue76 {
               get {
                   return resourceProvider.GetResource("AValue76", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Recording, Tour, Video Push, E-mail, Snapshot, Buzzer and Screen Tips </summary>
        public static string AValue77 {
               get {
                   return resourceProvider.GetResource("AValue77", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Motion Detection, MD Zone: 396 (22 × 18), Video Loss and Tampering </summary>
        public static string AValue78 {
               get {
                   return resourceProvider.GetResource("AValue78", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>8 Channel Input, 4 Channel Output </summary>
        public static string AValue79 {
               get {
                   return resourceProvider.GetResource("AValue79", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 / 4 / 9</summary>
        public static string AValue80 {
               get {
                   return resourceProvider.GetResource("AValue80", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 / 4 / 9 / 16</summary>
        public static string AValue81 {
               get {
                   return resourceProvider.GetResource("AValue81", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Time / Date, Alarm, MD and Exact Search (accurate to second), Smart Search, Face Search </summary>
        public static string AValue82 {
               get {
                   return resourceProvider.GetResource("AValue82", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>USB Device / Network </summary>
        public static string AValue83 {
               get {
                   return resourceProvider.GetResource("AValue83", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1 RJ-45, 10/100/1000Mbps suitable Ethernet Port</summary>
        public static string AValue84 {
               get {
                   return resourceProvider.GetResource("AValue84", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>HTTP, TCP/IP, IPv4, IPv6, UPnP, RTSP, UDP, SMTP, NTP, DHCP, DNS, IP Filter, PPPoE, DDNS, FTP, SNMP </summary>
        public static string AValue85 {
               get {
                   return resourceProvider.GetResource("AValue85", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>iPhone, iPad, Android</summary>
        public static string AValue86 {
               get {
                   return resourceProvider.GetResource("AValue86", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>ONVIF 2.6</summary>
        public static string AValue87 {
               get {
                   return resourceProvider.GetResource("AValue87", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>2 SATA, up to 8TB capacity per HDD</summary>
        public static string AValue88 {
               get {
                   return resourceProvider.GetResource("AValue88", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>Single</summary>
        public static string AValue89 {
               get {
                   return resourceProvider.GetResource("AValue89", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>2 USB 2.0 (1 on front panel, 1 on back panel)</summary>
        public static string AValue90 {
               get {
                   return resourceProvider.GetResource("AValue90", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>1, half-duplex</summary>
        public static string AValue91 {
               get {
                   return resourceProvider.GetResource("AValue91", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>DC +12V 3A</summary>
        public static string AValue92 {
               get {
                   return resourceProvider.GetResource("AValue92", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>6W (without HDD)</summary>
        public static string AValue93 {
               get {
                   return resourceProvider.GetResource("AValue93", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>-10 ⁰C ~ +55 ⁰C</summary>
        public static string AValue94 {
               get {
                   return resourceProvider.GetResource("AValue94", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>10% ~ 90%</summary>
        public static string AValue95 {
               get {
                   return resourceProvider.GetResource("AValue95", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>360mm × 262mm × 48mm</summary>
        public static string AValue96 {
               get {
                   return resourceProvider.GetResource("AValue96", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>405mm × 335mm × 120mm</summary>
        public static string AValue97 {
               get {
                   return resourceProvider.GetResource("AValue97", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>2.3kg (without HDD)</summary>
        public static string AValue98 {
               get {
                   return resourceProvider.GetResource("AValue98", CultureInfo.CurrentUICulture.Name) as string;
               }
            }

        }        
}
