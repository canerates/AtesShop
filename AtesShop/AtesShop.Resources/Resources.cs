using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace AtesShop.Resources {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary> IP Camera </summary>
        public static string CategoryName1 {
               get {
                   return resourceProvider.GetResource("CategoryName1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IP Camera </summary>
        public static string CategoryDesc1 {
               get {
                   return resourceProvider.GetResource("CategoryDesc1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Network Video Recorder </summary>
        public static string CategoryName2 {
               get {
                   return resourceProvider.GetResource("CategoryName2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Network Video Recorder </summary>
        public static string CategoryDesc2 {
               get {
                   return resourceProvider.GetResource("CategoryDesc2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Solar Panel </summary>
        public static string CategoryName3 {
               get {
                   return resourceProvider.GetResource("CategoryName3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Solar Panel </summary>
        public static string CategoryDesc3 {
               get {
                   return resourceProvider.GetResource("CategoryDesc3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Accessories </summary>
        public static string CategoryName4 {
               get {
                   return resourceProvider.GetResource("CategoryName4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Accessories </summary>
        public static string CategoryDesc4 {
               get {
                   return resourceProvider.GetResource("CategoryDesc4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N2M36B0-I </summary>
        public static string ProductName1 {
               get {
                   return resourceProvider.GetResource("ProductName1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 2MP Economic IP Bullet Camera </summary>
        public static string ProductDesc1 {
               get {
                   return resourceProvider.GetResource("ProductDesc1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N2M36D0-I </summary>
        public static string ProductName2 {
               get {
                   return resourceProvider.GetResource("ProductName2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 2MP Economic IP Dome Camera </summary>
        public static string ProductDesc2 {
               get {
                   return resourceProvider.GetResource("ProductDesc2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N2M40B0-IW </summary>
        public static string ProductName3 {
               get {
                   return resourceProvider.GetResource("ProductName3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 2MP WDR IP Bullet Camera </summary>
        public static string ProductDesc3 {
               get {
                   return resourceProvider.GetResource("ProductDesc3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N2M40D0-IW </summary>
        public static string ProductName4 {
               get {
                   return resourceProvider.GetResource("ProductName4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 2MP WDR IP Dome Camera </summary>
        public static string ProductDesc4 {
               get {
                   return resourceProvider.GetResource("ProductDesc4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N4M40B0-IW </summary>
        public static string ProductName5 {
               get {
                   return resourceProvider.GetResource("ProductName5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 4MP WDR IP Bullet Camera </summary>
        public static string ProductDesc5 {
               get {
                   return resourceProvider.GetResource("ProductDesc5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N4M40D0-IW </summary>
        public static string ProductName6 {
               get {
                   return resourceProvider.GetResource("ProductName6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 4MP WDR IP Dome Camera </summary>
        public static string ProductDesc6 {
               get {
                   return resourceProvider.GetResource("ProductDesc6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N2M36P0-IP </summary>
        public static string ProductName7 {
               get {
                   return resourceProvider.GetResource("ProductName7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 2MP Economic Mini PT IP Dome Camera </summary>
        public static string ProductDesc7 {
               get {
                   return resourceProvider.GetResource("ProductDesc7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N4M40P0-IWP </summary>
        public static string ProductName8 {
               get {
                   return resourceProvider.GetResource("ProductName8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 4MP WDR Mini PT IP Dome Camera </summary>
        public static string ProductDesc8 {
               get {
                   return resourceProvider.GetResource("ProductDesc8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SR-N0800000 </summary>
        public static string ProductName9 {
               get {
                   return resourceProvider.GetResource("ProductName9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 8CH NVR (E-version) </summary>
        public static string ProductDesc9 {
               get {
                   return resourceProvider.GetResource("ProductDesc9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SR-N1600000 </summary>
        public static string ProductName10 {
               get {
                   return resourceProvider.GetResource("ProductName10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 16CH NVR (E-version) </summary>
        public static string ProductDesc10 {
               get {
                   return resourceProvider.GetResource("ProductDesc10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Home </summary>
        public static string HomeT1O1 {
               get {
                   return resourceProvider.GetResource("HomeT1O1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Products </summary>
        public static string ProductsT1O2 {
               get {
                   return resourceProvider.GetResource("ProductsT1O2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Shop </summary>
        public static string ShopT1O3 {
               get {
                   return resourceProvider.GetResource("ShopT1O3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Download </summary>
        public static string SupportT1O4 {
               get {
                   return resourceProvider.GetResource("SupportT1O4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> About </summary>
        public static string AboutT1O5 {
               get {
                   return resourceProvider.GetResource("AboutT1O5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IP Camera </summary>
        public static string IPCameraT2O1 {
               get {
                   return resourceProvider.GetResource("IPCameraT2O1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> NVR Device </summary>
        public static string NVRDeviceT2O2 {
               get {
                   return resourceProvider.GetResource("NVRDeviceT2O2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Solar Panel </summary>
        public static string SolarPanelT2O3 {
               get {
                   return resourceProvider.GetResource("SolarPanelT2O3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> About Us </summary>
        public static string AboutUsT2O1 {
               get {
                   return resourceProvider.GetResource("AboutUsT2O1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Contact Us </summary>
        public static string ContactUsT2O2 {
               get {
                   return resourceProvider.GetResource("ContactUsT2O2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/2.9” 2 Megapixel Progressive Scan CMOS </summary>
        public static string Feature1 {
               get {
                   return resourceProvider.GetResource("Feature1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/2.8” 2 Megapixel Progressive Scan CMOS </summary>
        public static string Feature2 {
               get {
                   return resourceProvider.GetResource("Feature2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/3” 4 Megapixel Progressive Scan CMOS </summary>
        public static string Feature3 {
               get {
                   return resourceProvider.GetResource("Feature3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> H.265 encoding </summary>
        public static string Feature4 {
               get {
                   return resourceProvider.GetResource("Feature4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> H.265 / MJPEG encoding </summary>
        public static string Feature5 {
               get {
                   return resourceProvider.GetResource("Feature5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Triple Stream </summary>
        public static string Feature6 {
               get {
                   return resourceProvider.GetResource("Feature6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 30 fps @ 2 Megapixel (1920x1080) </summary>
        public static string Feature7 {
               get {
                   return resourceProvider.GetResource("Feature7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 30 fps @ 4 Megapixel (2560x1440) </summary>
        public static string Feature8 {
               get {
                   return resourceProvider.GetResource("Feature8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 25 fps @ 4 Megapixel (2560x1440) </summary>
        public static string Feature9 {
               get {
                   return resourceProvider.GetResource("Feature9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> D-WDR </summary>
        public static string Feature10 {
               get {
                   return resourceProvider.GetResource("Feature10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> WDR (120dB) </summary>
        public static string Feature11 {
               get {
                   return resourceProvider.GetResource("Feature11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 3D DNR </summary>
        public static string Feature12 {
               get {
                   return resourceProvider.GetResource("Feature12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart IR </summary>
        public static string Feature13 {
               get {
                   return resourceProvider.GetResource("Feature13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Functions </summary>
        public static string Feature14 {
               get {
                   return resourceProvider.GetResource("Feature14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Day/Night (IR CUT filter with auto switch) </summary>
        public static string Feature15 {
               get {
                   return resourceProvider.GetResource("Feature15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/1 Interface Input/Output </summary>
        public static string Feature16 {
               get {
                   return resourceProvider.GetResource("Feature16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> P2P and IE browser support </summary>
        public static string Feature17 {
               get {
                   return resourceProvider.GetResource("Feature17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Pan / Tilt control </summary>
        public static string Feature18 {
               get {
                   return resourceProvider.GetResource("Feature18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Preset Support </summary>
        public static string Feature19 {
               get {
                   return resourceProvider.GetResource("Feature19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 IP Camera Inputs </summary>
        public static string Feature20 {
               get {
                   return resourceProvider.GetResource("Feature20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 16 IP Camera Inputs </summary>
        public static string Feature21 {
               get {
                   return resourceProvider.GetResource("Feature21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 24 IP Camera Inputs </summary>
        public static string Feature22 {
               get {
                   return resourceProvider.GetResource("Feature22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Max. 64Mbps Incoming Bandwidth </summary>
        public static string Feature23 {
               get {
                   return resourceProvider.GetResource("Feature23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Max. 96Mbps Incoming Bandwidth </summary>
        public static string Feature24 {
               get {
                   return resourceProvider.GetResource("Feature24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Max. 192Mbps Incoming Bandwidth </summary>
        public static string Feature25 {
               get {
                   return resourceProvider.GetResource("Feature25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Mp, 6 Mp, 5 Mp, 3Mp, 1080p, 720p, D1 Resolutions for Preview and Playback </summary>
        public static string Feature26 {
               get {
                   return resourceProvider.GetResource("Feature26", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1080p, 720p, D1 Resolutions for Preview and Playback </summary>
        public static string Feature27 {
               get {
                   return resourceProvider.GetResource("Feature27", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Alarm Inputs, 4 Alarm Outputs, 1 CVBS Output </summary>
        public static string Feature28 {
               get {
                   return resourceProvider.GetResource("Feature28", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2 SATA, 2 USB2.0, 1 RJ45(1000M) </summary>
        public static string Feature29 {
               get {
                   return resourceProvider.GetResource("Feature29", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IP Camera </summary>
        public static string ASection1 {
               get {
                   return resourceProvider.GetResource("ASection1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Camera Features </summary>
        public static string ASection2 {
               get {
                   return resourceProvider.GetResource("ASection2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Lens </summary>
        public static string ASection3 {
               get {
                   return resourceProvider.GetResource("ASection3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Video </summary>
        public static string ASection4 {
               get {
                   return resourceProvider.GetResource("ASection4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Functions </summary>
        public static string ASection5 {
               get {
                   return resourceProvider.GetResource("ASection5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Network </summary>
        public static string ASection6 {
               get {
                   return resourceProvider.GetResource("ASection6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> AUX Interface </summary>
        public static string ASection7 {
               get {
                   return resourceProvider.GetResource("ASection7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> General </summary>
        public static string ASection8 {
               get {
                   return resourceProvider.GetResource("ASection8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> System </summary>
        public static string ASection9 {
               get {
                   return resourceProvider.GetResource("ASection9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Audio and Video </summary>
        public static string ASection10 {
               get {
                   return resourceProvider.GetResource("ASection10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Display </summary>
        public static string ASection11 {
               get {
                   return resourceProvider.GetResource("ASection11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Recording </summary>
        public static string ASection12 {
               get {
                   return resourceProvider.GetResource("ASection12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Video Detection and Alarm </summary>
        public static string ASection13 {
               get {
                   return resourceProvider.GetResource("ASection13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Playback and Backup </summary>
        public static string ASection14 {
               get {
                   return resourceProvider.GetResource("ASection14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Storage </summary>
        public static string ASection15 {
               get {
                   return resourceProvider.GetResource("ASection15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Electrical </summary>
        public static string ASection16 {
               get {
                   return resourceProvider.GetResource("ASection16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Environmental </summary>
        public static string ASection17 {
               get {
                   return resourceProvider.GetResource("ASection17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Construction </summary>
        public static string ASection18 {
               get {
                   return resourceProvider.GetResource("ASection18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PT Features </summary>
        public static string ASection19 {
               get {
                   return resourceProvider.GetResource("ASection19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Image Sensor </summary>
        public static string AType1 {
               get {
                   return resourceProvider.GetResource("AType1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Effective Pixels </summary>
        public static string AType2 {
               get {
                   return resourceProvider.GetResource("AType2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Scanning System </summary>
        public static string AType3 {
               get {
                   return resourceProvider.GetResource("AType3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Electronic Shutter Speed </summary>
        public static string AType4 {
               get {
                   return resourceProvider.GetResource("AType4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Min. Illumination </summary>
        public static string AType5 {
               get {
                   return resourceProvider.GetResource("AType5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> S/N Ratio </summary>
        public static string AType6 {
               get {
                   return resourceProvider.GetResource("AType6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Video Output </summary>
        public static string AType7 {
               get {
                   return resourceProvider.GetResource("AType7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IR LED Illumination Distance </summary>
        public static string AType8 {
               get {
                   return resourceProvider.GetResource("AType8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Day / Night </summary>
        public static string AType9 {
               get {
                   return resourceProvider.GetResource("AType9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> BLC Mode </summary>
        public static string AType10 {
               get {
                   return resourceProvider.GetResource("AType10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> White Balance </summary>
        public static string AType11 {
               get {
                   return resourceProvider.GetResource("AType11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Gain Control </summary>
        public static string AType12 {
               get {
                   return resourceProvider.GetResource("AType12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Noise Reduction </summary>
        public static string AType13 {
               get {
                   return resourceProvider.GetResource("AType13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> WDR </summary>
        public static string AType14 {
               get {
                   return resourceProvider.GetResource("AType14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Privacy Masking </summary>
        public static string AType15 {
               get {
                   return resourceProvider.GetResource("AType15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Defog </summary>
        public static string AType16 {
               get {
                   return resourceProvider.GetResource("AType16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Mount Type </summary>
        public static string AType17 {
               get {
                   return resourceProvider.GetResource("AType17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Compression </summary>
        public static string AType18 {
               get {
                   return resourceProvider.GetResource("AType18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Resolution </summary>
        public static string AType19 {
               get {
                   return resourceProvider.GetResource("AType19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Frame Rate </summary>
        public static string AType20 {
               get {
                   return resourceProvider.GetResource("AType20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Bit Rate </summary>
        public static string AType21 {
               get {
                   return resourceProvider.GetResource("AType21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Alarm </summary>
        public static string AType22 {
               get {
                   return resourceProvider.GetResource("AType22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Video Analysis </summary>
        public static string AType23 {
               get {
                   return resourceProvider.GetResource("AType23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Ethernet </summary>
        public static string AType24 {
               get {
                   return resourceProvider.GetResource("AType24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Wi-Fi </summary>
        public static string AType25 {
               get {
                   return resourceProvider.GetResource("AType25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Protocol </summary>
        public static string AType26 {
               get {
                   return resourceProvider.GetResource("AType26", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> ONVIF </summary>
        public static string AType27 {
               get {
                   return resourceProvider.GetResource("AType27", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Max. User Access </summary>
        public static string AType28 {
               get {
                   return resourceProvider.GetResource("AType28", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Phone </summary>
        public static string AType29 {
               get {
                   return resourceProvider.GetResource("AType29", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Alarm </summary>
        public static string AType30 {
               get {
                   return resourceProvider.GetResource("AType30", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Analog </summary>
        public static string AType31 {
               get {
                   return resourceProvider.GetResource("AType31", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Supply </summary>
        public static string AType32 {
               get {
                   return resourceProvider.GetResource("AType32", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Consumption </summary>
        public static string AType33 {
               get {
                   return resourceProvider.GetResource("AType33", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Operating Conditions </summary>
        public static string AType34 {
               get {
                   return resourceProvider.GetResource("AType34", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Ingress Protection </summary>
        public static string AType35 {
               get {
                   return resourceProvider.GetResource("AType35", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Dimensions </summary>
        public static string AType36 {
               get {
                   return resourceProvider.GetResource("AType36", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Main Processor </summary>
        public static string AType37 {
               get {
                   return resourceProvider.GetResource("AType37", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Operating System </summary>
        public static string AType38 {
               get {
                   return resourceProvider.GetResource("AType38", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IP Camera Input </summary>
        public static string AType39 {
               get {
                   return resourceProvider.GetResource("AType39", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Two-way Talk </summary>
        public static string AType40 {
               get {
                   return resourceProvider.GetResource("AType40", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Interface </summary>
        public static string AType41 {
               get {
                   return resourceProvider.GetResource("AType41", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> CVBS Output </summary>
        public static string AType42 {
               get {
                   return resourceProvider.GetResource("AType42", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Live View / Playback Capacity </summary>
        public static string AType43 {
               get {
                   return resourceProvider.GetResource("AType43", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Multi Screen Display </summary>
        public static string AType44 {
               get {
                   return resourceProvider.GetResource("AType44", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> OSD </summary>
        public static string AType45 {
               get {
                   return resourceProvider.GetResource("AType45", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Record Rate </summary>
        public static string AType46 {
               get {
                   return resourceProvider.GetResource("AType46", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Record Mode </summary>
        public static string AType47 {
               get {
                   return resourceProvider.GetResource("AType47", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Trigger Events </summary>
        public static string AType48 {
               get {
                   return resourceProvider.GetResource("AType48", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Video Detection </summary>
        public static string AType49 {
               get {
                   return resourceProvider.GetResource("AType49", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Alarm Input and Output </summary>
        public static string AType50 {
               get {
                   return resourceProvider.GetResource("AType50", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Playback Synch </summary>
        public static string AType51 {
               get {
                   return resourceProvider.GetResource("AType51", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Search Mode </summary>
        public static string AType52 {
               get {
                   return resourceProvider.GetResource("AType52", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Backup Mode </summary>
        public static string AType53 {
               get {
                   return resourceProvider.GetResource("AType53", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Network Function </summary>
        public static string AType54 {
               get {
                   return resourceProvider.GetResource("AType54", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Internal HDD </summary>
        public static string AType55 {
               get {
                   return resourceProvider.GetResource("AType55", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> HDD Mode </summary>
        public static string AType56 {
               get {
                   return resourceProvider.GetResource("AType56", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> USB </summary>
        public static string AType57 {
               get {
                   return resourceProvider.GetResource("AType57", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> RS-485 </summary>
        public static string AType58 {
               get {
                   return resourceProvider.GetResource("AType58", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Operating Temperature </summary>
        public static string AType59 {
               get {
                   return resourceProvider.GetResource("AType59", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Operating Humidity </summary>
        public static string AType60 {
               get {
                   return resourceProvider.GetResource("AType60", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Dimensions </summary>
        public static string AType61 {
               get {
                   return resourceProvider.GetResource("AType61", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Package Size </summary>
        public static string AType62 {
               get {
                   return resourceProvider.GetResource("AType62", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Net Weight </summary>
        public static string AType63 {
               get {
                   return resourceProvider.GetResource("AType63", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Pan </summary>
        public static string AType64 {
               get {
                   return resourceProvider.GetResource("AType64", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Tilt </summary>
        public static string AType65 {
               get {
                   return resourceProvider.GetResource("AType65", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Preset </summary>
        public static string AType66 {
               get {
                   return resourceProvider.GetResource("AType66", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/2.9" 2 Megapixel CMOS </summary>
        public static string AValue1 {
               get {
                   return resourceProvider.GetResource("AValue1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/2.8" 2 Megapixel CMOS </summary>
        public static string AValue2 {
               get {
                   return resourceProvider.GetResource("AValue2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/3" 4 Megapixel CMOS  </summary>
        public static string AValue3 {
               get {
                   return resourceProvider.GetResource("AValue3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1920(H)×1080(V) </summary>
        public static string AValue4 {
               get {
                   return resourceProvider.GetResource("AValue4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2560(H)×1440(V)  </summary>
        public static string AValue5 {
               get {
                   return resourceProvider.GetResource("AValue5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Progressive </summary>
        public static string AValue6 {
               get {
                   return resourceProvider.GetResource("AValue6", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Auto/Manual, 1/3(4)~1/10000s </summary>
        public static string AValue7 {
               get {
                   return resourceProvider.GetResource("AValue7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Color: 0.1Lux@F1.2, B/W: 0.01Lux@F1.2 </summary>
        public static string AValue8 {
               get {
                   return resourceProvider.GetResource("AValue8", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 60dB </summary>
        public static string AValue9 {
               get {
                   return resourceProvider.GetResource("AValue9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 Interface BNC (1.0Vp-p,75Ω) </summary>
        public static string AValue10 {
               get {
                   return resourceProvider.GetResource("AValue10", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 15 meter </summary>
        public static string AValue11 {
               get {
                   return resourceProvider.GetResource("AValue11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Auto(ICR) / Color / B/W </summary>
        public static string AValue12 {
               get {
                   return resourceProvider.GetResource("AValue12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> BLC / HLC / D-WDR </summary>
        public static string AValue13 {
               get {
                   return resourceProvider.GetResource("AValue13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> BLC / HLC / WDR 120dB </summary>
        public static string AValue14 {
               get {
                   return resourceProvider.GetResource("AValue14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Auto / Manual </summary>
        public static string AValue15 {
               get {
                   return resourceProvider.GetResource("AValue15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> DNR (2D/3D) </summary>
        public static string AValue16 {
               get {
                   return resourceProvider.GetResource("AValue16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> D-WDR </summary>
        public static string AValue17 {
               get {
                   return resourceProvider.GetResource("AValue17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> D-WDR, WDR </summary>
        public static string AValue18 {
               get {
                   return resourceProvider.GetResource("AValue18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 4 Area </summary>
        public static string AValue19 {
               get {
                   return resourceProvider.GetResource("AValue19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Support </summary>
        public static string AValue20 {
               get {
                   return resourceProvider.GetResource("AValue20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 4 mm (6 mm optional) </summary>
        public static string AValue21 {
               get {
                   return resourceProvider.GetResource("AValue21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> H.265 / H.264 High Profile/Main Profile/Base Line Profile </summary>
        public static string AValue22 {
               get {
                   return resourceProvider.GetResource("AValue22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> H.265 / H.264 High Profile/Main Profile/Base Line Profile / MJPEG  </summary>
        public static string AValue23 {
               get {
                   return resourceProvider.GetResource("AValue23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1080p(1920×1080)/ 720p(1280×720)/ D1(704×576)/ CIF(352×288) </summary>
        public static string AValue24 {
               get {
                   return resourceProvider.GetResource("AValue24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 4Mp/ 1080p(1920×1080)/ 720p(1280×720)/ D1(704×576)/ CIF(352×288)  </summary>
        public static string AValue25 {
               get {
                   return resourceProvider.GetResource("AValue25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Main Stream: 1080p (1~25/30 fps); Sub Stream: D1/ CIF (1~25/30 fps)  </summary>
        public static string AValue26 {
               get {
                   return resourceProvider.GetResource("AValue26", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Main Stream: 1080p (1~25/30 fps); Sub Stream: D1/ CIF (1~25/30 fps); Third Stream: 720p (1~25/30 fps)  </summary>
        public static string AValue27 {
               get {
                   return resourceProvider.GetResource("AValue27", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Main Stream: 4Mp (25fps) / 1080p (1~25/30 fps); Sub Stream: D1/ CIF (1~25/30 fps); Third Stream: 720p (1~25/30 fps)  </summary>
        public static string AValue28 {
               get {
                   return resourceProvider.GetResource("AValue28", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 32kbps ~ 8Mbps </summary>
        public static string AValue29 {
               get {
                   return resourceProvider.GetResource("AValue29", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Network abnormal, cover alarm etc. </summary>
        public static string AValue30 {
               get {
                   return resourceProvider.GetResource("AValue30", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Face Detection </summary>
        public static string AValue31 {
               get {
                   return resourceProvider.GetResource("AValue31", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Tripwire Detection </summary>
        public static string AValue32 {
               get {
                   return resourceProvider.GetResource("AValue32", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Regional Invasion Detection </summary>
        public static string AValue33 {
               get {
                   return resourceProvider.GetResource("AValue33", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Abandoned/Missing Object Detection </summary>
        public static string AValue34 {
               get {
                   return resourceProvider.GetResource("AValue34", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Scene Change Detection </summary>
        public static string AValue35 {
               get {
                   return resourceProvider.GetResource("AValue35", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> RJ-45 (10/100/1000Base-T) </summary>
        public static string AValue36 {
               get {
                   return resourceProvider.GetResource("AValue36", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> - </summary>
        public static string AValue37 {
               get {
                   return resourceProvider.GetResource("AValue37", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IPv4/IPv6, HTTP, TCP/IP, UDP, UPnP, ICMP, IGMP, SNMP, RTSP, RTP, SMTP, NTP, DHCP, PPPOE, DDNS, FTP, IP Filter </summary>
        public static string AValue38 {
               get {
                   return resourceProvider.GetResource("AValue38", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> ONVIF2.6 / CGI </summary>
        public static string AValue39 {
               get {
                   return resourceProvider.GetResource("AValue39", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> ONVIF2.6 / CGI / GB28181 </summary>
        public static string AValue40 {
               get {
                   return resourceProvider.GetResource("AValue40", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 20 Users </summary>
        public static string AValue41 {
               get {
                   return resourceProvider.GetResource("AValue41", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> iPhone, iPad, Android </summary>
        public static string AValue42 {
               get {
                   return resourceProvider.GetResource("AValue42", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1/1 Interface Input/Output  </summary>
        public static string AValue43 {
               get {
                   return resourceProvider.GetResource("AValue43", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> DC 12V </summary>
        public static string AValue44 {
               get {
                   return resourceProvider.GetResource("AValue44", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> DC 12V / POE </summary>
        public static string AValue45 {
               get {
                   return resourceProvider.GetResource("AValue45", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Max 10W </summary>
        public static string AValue46 {
               get {
                   return resourceProvider.GetResource("AValue46", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>  0 ⁰C ~ 50 ⁰C </summary>
        public static string AValue47 {
               get {
                   return resourceProvider.GetResource("AValue47", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IP66 </summary>
        public static string AValue48 {
               get {
                   return resourceProvider.GetResource("AValue48", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Bullet Model: 63.0mm × 63.0mm × 166.0mm; Dome Model: 93.2mm × 93.2mm × 66.5mm  </summary>
        public static string AValue49 {
               get {
                   return resourceProvider.GetResource("AValue49", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Dome Model: 110mm × 96mm </summary>
        public static string AValue50 {
               get {
                   return resourceProvider.GetResource("AValue50", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 355⁰ / Speed: 0 ~ 25 degrees per second </summary>
        public static string AValue51 {
               get {
                   return resourceProvider.GetResource("AValue51", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 0 ~ 90⁰ / Speed: 0 ~ 20 degrees per second </summary>
        public static string AValue52 {
               get {
                   return resourceProvider.GetResource("AValue52", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 6 </summary>
        public static string AValue53 {
               get {
                   return resourceProvider.GetResource("AValue53", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Dual-core, Embedded </summary>
        public static string AValue54 {
               get {
                   return resourceProvider.GetResource("AValue54", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Embedded LINUX </summary>
        public static string AValue55 {
               get {
                   return resourceProvider.GetResource("AValue55", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel </summary>
        public static string AValue56 {
               get {
                   return resourceProvider.GetResource("AValue56", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 16 Channel </summary>
        public static string AValue57 {
               get {
                   return resourceProvider.GetResource("AValue57", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 24 Channel </summary>
        public static string AValue58 {
               get {
                   return resourceProvider.GetResource("AValue58", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 Channel Input, 1 Channel Output, RCA </summary>
        public static string AValue59 {
               get {
                   return resourceProvider.GetResource("AValue59", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 Interface, BNC (1.0Vp-p, 75Ω) </summary>
        public static string AValue60 {
               get {
                   return resourceProvider.GetResource("AValue60", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 HDMI, 1 VGA </summary>
        public static string AValue61 {
               get {
                   return resourceProvider.GetResource("AValue61", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> HDMI: 3840×2160, 1920×1080, 1280×1024, 1280×720, 1024×768; VGA: 1920×1080, 1280×1024, 1280×720, 1024×768  </summary>
        public static string AValue62 {
               get {
                   return resourceProvider.GetResource("AValue62", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> HDMI: 1920×1080, 1280×1024, 1280×720, 1024×768; VGA: 1920×1080, 1280×1024, 1280×720, 1024×768  </summary>
        public static string AValue63 {
               get {
                   return resourceProvider.GetResource("AValue63", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 4 Channel @1080p 30fps </summary>
        public static string AValue64 {
               get {
                   return resourceProvider.GetResource("AValue64", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel @1440p 30fps </summary>
        public static string AValue65 {
               get {
                   return resourceProvider.GetResource("AValue65", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 16 Channel @1080p 30fps </summary>
        public static string AValue66 {
               get {
                   return resourceProvider.GetResource("AValue66", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 / 4 / 8 / 9 </summary>
        public static string AValue67 {
               get {
                   return resourceProvider.GetResource("AValue67", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 / 4 / 8 / 9 / 16 </summary>
        public static string AValue68 {
               get {
                   return resourceProvider.GetResource("AValue68", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Camera title, Time, Camera lock, Motion detection, Recording </summary>
        public static string AValue69 {
               get {
                   return resourceProvider.GetResource("AValue69", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> H.265 + / H.265 / H.264 + / H.264  </summary>
        public static string AValue70 {
               get {
                   return resourceProvider.GetResource("AValue70", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8Mp / 6 Mp / 5 Mp / 4 Mp / 3 Mp / 1080p / 1.3 Mp / 720p  </summary>
        public static string AValue71 {
               get {
                   return resourceProvider.GetResource("AValue71", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1080p / 1.3 Mp / 720p  </summary>
        public static string AValue72 {
               get {
                   return resourceProvider.GetResource("AValue72", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 64Mbps </summary>
        public static string AValue73 {
               get {
                   return resourceProvider.GetResource("AValue73", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 96Mbps </summary>
        public static string AValue74 {
               get {
                   return resourceProvider.GetResource("AValue74", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 192Mbps  </summary>
        public static string AValue75 {
               get {
                   return resourceProvider.GetResource("AValue75", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Manual, Schedule (Regular, MD (Motion Detection), Alarm), Holiday, Stop  </summary>
        public static string AValue76 {
               get {
                   return resourceProvider.GetResource("AValue76", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Recording, Tour, Video Push, E-mail, Snapshot, Buzzer and Screen Tips  </summary>
        public static string AValue77 {
               get {
                   return resourceProvider.GetResource("AValue77", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Motion Detection, MD Zone: 396 (22 × 18), Video Loss and Tampering  </summary>
        public static string AValue78 {
               get {
                   return resourceProvider.GetResource("AValue78", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel Input, 4 Channel Output  </summary>
        public static string AValue79 {
               get {
                   return resourceProvider.GetResource("AValue79", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 / 4 / 9 </summary>
        public static string AValue80 {
               get {
                   return resourceProvider.GetResource("AValue80", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 / 4 / 9 / 16 </summary>
        public static string AValue81 {
               get {
                   return resourceProvider.GetResource("AValue81", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Time / Date, Alarm, MD and Exact Search (accurate to second), Smart Search, Face Search  </summary>
        public static string AValue82 {
               get {
                   return resourceProvider.GetResource("AValue82", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> USB Device / Network  </summary>
        public static string AValue83 {
               get {
                   return resourceProvider.GetResource("AValue83", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1 RJ-45, 10/100/1000Mbps suitable Ethernet Port </summary>
        public static string AValue84 {
               get {
                   return resourceProvider.GetResource("AValue84", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> HTTP, TCP/IP, IPv4, IPv6, UPnP, RTSP, UDP, SMTP, NTP, DHCP, DNS, IP Filter, PPPoE, DDNS, FTP, SNMP  </summary>
        public static string AValue85 {
               get {
                   return resourceProvider.GetResource("AValue85", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>  </summary>
        public static string AValue86 {
               get {
                   return resourceProvider.GetResource("AValue86", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> ONVIF 2.6 </summary>
        public static string AValue87 {
               get {
                   return resourceProvider.GetResource("AValue87", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2 SATA, up to 8TB capacity per HDD </summary>
        public static string AValue88 {
               get {
                   return resourceProvider.GetResource("AValue88", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Single </summary>
        public static string AValue89 {
               get {
                   return resourceProvider.GetResource("AValue89", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2 USB 2.0 (1 on front panel, 1 on back panel) </summary>
        public static string AValue90 {
               get {
                   return resourceProvider.GetResource("AValue90", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1, half-duplex </summary>
        public static string AValue91 {
               get {
                   return resourceProvider.GetResource("AValue91", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> DC +12V 3A </summary>
        public static string AValue92 {
               get {
                   return resourceProvider.GetResource("AValue92", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 6W (without HDD) </summary>
        public static string AValue93 {
               get {
                   return resourceProvider.GetResource("AValue93", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> -10 ⁰C ~ +55 ⁰C </summary>
        public static string AValue94 {
               get {
                   return resourceProvider.GetResource("AValue94", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 10% ~ 90% </summary>
        public static string AValue95 {
               get {
                   return resourceProvider.GetResource("AValue95", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 360mm × 262mm × 48mm </summary>
        public static string AValue96 {
               get {
                   return resourceProvider.GetResource("AValue96", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 405mm × 335mm × 120mm </summary>
        public static string AValue97 {
               get {
                   return resourceProvider.GetResource("AValue97", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2.3kg (without HDD) </summary>
        public static string AValue98 {
               get {
                   return resourceProvider.GetResource("AValue98", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Electrical Data </summary>
        public static string ASection20 {
               get {
                   return resourceProvider.GetResource("ASection20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Operating Conditions </summary>
        public static string ASection21 {
               get {
                   return resourceProvider.GetResource("ASection21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Temperature Characteristics </summary>
        public static string ASection22 {
               get {
                   return resourceProvider.GetResource("ASection22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Mechanical Data </summary>
        public static string ASection23 {
               get {
                   return resourceProvider.GetResource("ASection23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Maximum Rating Power (Pmax) </summary>
        public static string AType67 {
               get {
                   return resourceProvider.GetResource("AType67", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Module Efficiency </summary>
        public static string AType68 {
               get {
                   return resourceProvider.GetResource("AType68", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Open Circuit Voltage (Voc) </summary>
        public static string AType69 {
               get {
                   return resourceProvider.GetResource("AType69", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Maximum Power Voltage </summary>
        public static string AType70 {
               get {
                   return resourceProvider.GetResource("AType70", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Short Circuit Current (Isc) </summary>
        public static string AType71 {
               get {
                   return resourceProvider.GetResource("AType71", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Maximum Power Current </summary>
        public static string AType72 {
               get {
                   return resourceProvider.GetResource("AType72", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Maximum System Voltage </summary>
        public static string AType73 {
               get {
                   return resourceProvider.GetResource("AType73", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Series Fuse Rating </summary>
        public static string AType74 {
               get {
                   return resourceProvider.GetResource("AType74", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Nominal Module Operating Temp. </summary>
        public static string AType75 {
               get {
                   return resourceProvider.GetResource("AType75", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Temperature Coefficient of Isc </summary>
        public static string AType76 {
               get {
                   return resourceProvider.GetResource("AType76", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Temperature Coefficient of Voc </summary>
        public static string AType77 {
               get {
                   return resourceProvider.GetResource("AType77", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Temperature Coefficient of Pmax </summary>
        public static string AType78 {
               get {
                   return resourceProvider.GetResource("AType78", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Weight </summary>
        public static string AType79 {
               get {
                   return resourceProvider.GetResource("AType79", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Solar Cell </summary>
        public static string AType80 {
               get {
                   return resourceProvider.GetResource("AType80", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Front Sheet </summary>
        public static string AType81 {
               get {
                   return resourceProvider.GetResource("AType81", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Cell Encapsulation </summary>
        public static string AType82 {
               get {
                   return resourceProvider.GetResource("AType82", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Rear Sheet </summary>
        public static string AType83 {
               get {
                   return resourceProvider.GetResource("AType83", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Junction Box </summary>
        public static string AType84 {
               get {
                   return resourceProvider.GetResource("AType84", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Frame </summary>
        public static string AType85 {
               get {
                   return resourceProvider.GetResource("AType85", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Packaging Configuration </summary>
        public static string AType86 {
               get {
                   return resourceProvider.GetResource("AType86", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> [W] 250 </summary>
        public static string AValue99 {
               get {
                   return resourceProvider.GetResource("AValue99", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> [%] 21.5 </summary>
        public static string AValue100 {
               get {
                   return resourceProvider.GetResource("AValue100", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> [V] 60.4 </summary>
        public static string AValue101 {
               get {
                   return resourceProvider.GetResource("AValue101", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> [V] 48 </summary>
        public static string AValue102 {
               get {
                   return resourceProvider.GetResource("AValue102", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> [A] 5.69 </summary>
        public static string AValue103 {
               get {
                   return resourceProvider.GetResource("AValue103", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> [A] 5.19 </summary>
        public static string AValue104 {
               get {
                   return resourceProvider.GetResource("AValue104", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> TUV 1000 </summary>
        public static string AValue105 {
               get {
                   return resourceProvider.GetResource("AValue105", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 13 A </summary>
        public static string AValue106 {
               get {
                   return resourceProvider.GetResource("AValue106", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> -40 to +85 °C </summary>
        public static string AValue107 {
               get {
                   return resourceProvider.GetResource("AValue107", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 40.6 °C ± 2 °C </summary>
        public static string AValue108 {
               get {
                   return resourceProvider.GetResource("AValue108", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 0.03 % / °C </summary>
        public static string AValue109 {
               get {
                   return resourceProvider.GetResource("AValue109", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> -0.32 % / °C </summary>
        public static string AValue110 {
               get {
                   return resourceProvider.GetResource("AValue110", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> -0.42 % / °C </summary>
        public static string AValue111 {
               get {
                   return resourceProvider.GetResource("AValue111", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 1380 mm (L) × 990 mm (W) × 35 mm (D) </summary>
        public static string AValue112 {
               get {
                   return resourceProvider.GetResource("AValue112", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 9 kg </summary>
        public static string AValue113 {
               get {
                   return resourceProvider.GetResource("AValue113", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 192 monocrystalline FE-PERC solar cells </summary>
        public static string AValue114 {
               get {
                   return resourceProvider.GetResource("AValue114", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Anti-reflective tempered patterned glass </summary>
        public static string AValue115 {
               get {
                   return resourceProvider.GetResource("AValue115", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Polyolefin </summary>
        public static string AValue116 {
               get {
                   return resourceProvider.GetResource("AValue116", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PET </summary>
        public static string AValue117 {
               get {
                   return resourceProvider.GetResource("AValue117", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IP 7 rated; Cable: 1000 mm </summary>
        public static string AValue118 {
               get {
                   return resourceProvider.GetResource("AValue118", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Anodized aluminum frame, original or black </summary>
        public static string AValue119 {
               get {
                   return resourceProvider.GetResource("AValue119", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 40 pcs Per Pallet, 1390 mm (L) × 1000 mm (W) × 1550 mm (D) , 370 kg </summary>
        public static string AValue120 {
               get {
                   return resourceProvider.GetResource("AValue120", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active Smart Solar Panel increases efficiency by Smart Structure modules that provides free shading resistance. </summary>
        public static string Feature30 {
               get {
                   return resourceProvider.GetResource("Feature30", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Structure modules offer %50 more power output compared to standard PV modules in case of shading and insufficient sunlight exposure.  </summary>
        public static string Feature31 {
               get {
                   return resourceProvider.GetResource("Feature31", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SR-N2400000 </summary>
        public static string ProductName11 {
               get {
                   return resourceProvider.GetResource("ProductName11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 24CH NVR (E-version) </summary>
        public static string ProductDesc11 {
               get {
                   return resourceProvider.GetResource("ProductDesc11", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SR-N0800001 </summary>
        public static string ProductName12 {
               get {
                   return resourceProvider.GetResource("ProductName12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 8CH NVR (P-version) </summary>
        public static string ProductDesc12 {
               get {
                   return resourceProvider.GetResource("ProductDesc12", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SR-N1600001 </summary>
        public static string ProductName13 {
               get {
                   return resourceProvider.GetResource("ProductName13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 16CH NVR (P-version) </summary>
        public static string ProductDesc13 {
               get {
                   return resourceProvider.GetResource("ProductDesc13", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SR-N2400001 </summary>
        public static string ProductName14 {
               get {
                   return resourceProvider.GetResource("ProductName14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 24CH NVR (P-version) </summary>
        public static string ProductDesc14 {
               get {
                   return resourceProvider.GetResource("ProductDesc14", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-GS-P482500-S </summary>
        public static string ProductName15 {
               get {
                   return resourceProvider.GetResource("ProductName15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active Smart Solar Panel </summary>
        public static string ProductDesc15 {
               get {
                   return resourceProvider.GetResource("ProductDesc15", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Big Sale </summary>
        public static string BigSale {
               get {
                   return resourceProvider.GetResource("BigSale", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Surveillance </summary>
        public static string SmartSurveillance {
               get {
                   return resourceProvider.GetResource("SmartSurveillance", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> IP Camera & NVR </summary>
        public static string IPCameraNVR {
               get {
                   return resourceProvider.GetResource("IPCameraNVR", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Shop Now </summary>
        public static string ShopNow {
               get {
                   return resourceProvider.GetResource("ShopNow", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Call Us </summary>
        public static string CallUs {
               get {
                   return resourceProvider.GetResource("CallUs", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Sign in </summary>
        public static string SignIn {
               get {
                   return resourceProvider.GetResource("SignIn", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Register </summary>
        public static string Register {
               get {
                   return resourceProvider.GetResource("Register", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Log out </summary>
        public static string LogOut {
               get {
                   return resourceProvider.GetResource("LogOut", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> My Account </summary>
        public static string MyAccount {
               get {
                   return resourceProvider.GetResource("MyAccount", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Checkout </summary>
        public static string Checkout {
               get {
                   return resourceProvider.GetResource("Checkout", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Total </summary>
        public static string Total {
               get {
                   return resourceProvider.GetResource("Total", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Search Your Product </summary>
        public static string SearchYourProduct {
               get {
                   return resourceProvider.GetResource("SearchYourProduct", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Wishlist </summary>
        public static string Wishlist {
               get {
                   return resourceProvider.GetResource("Wishlist", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Top Products </summary>
        public static string TopProducts {
               get {
                   return resourceProvider.GetResource("TopProducts", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> New Arrivals </summary>
        public static string NewArrivals {
               get {
                   return resourceProvider.GetResource("NewArrivals", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Featured </summary>
        public static string Featured {
               get {
                   return resourceProvider.GetResource("Featured", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Top Rated </summary>
        public static string TopRated {
               get {
                   return resourceProvider.GetResource("TopRated", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Best Seller Products </summary>
        public static string BestSellerProducts {
               get {
                   return resourceProvider.GetResource("BestSellerProducts", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Functions </summary>
        public static string SmartFunctions {
               get {
                   return resourceProvider.GetResource("SmartFunctions", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Contact Us </summary>
        public static string ContactUs {
               get {
                   return resourceProvider.GetResource("ContactUs", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Specifications </summary>
        public static string Specifications {
               get {
                   return resourceProvider.GetResource("Specifications", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Reviews </summary>
        public static string Reviews {
               get {
                   return resourceProvider.GetResource("Reviews", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Check Price </summary>
        public static string CheckPrice {
               get {
                   return resourceProvider.GetResource("CheckPrice", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Related Products </summary>
        public static string RelatedProducts {
               get {
                   return resourceProvider.GetResource("RelatedProducts", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Add to Cart </summary>
        public static string AddToCart {
               get {
                   return resourceProvider.GetResource("AddToCart", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Cart </summary>
        public static string Cart {
               get {
                   return resourceProvider.GetResource("Cart", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> REGISTER ACCOUNT </summary>
        public static string RegisterAccount {
               get {
                   return resourceProvider.GetResource("RegisterAccount", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Your Personal Details </summary>
        public static string YourPersonalDetails {
               get {
                   return resourceProvider.GetResource("YourPersonalDetails", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> First Name </summary>
        public static string FirstName {
               get {
                   return resourceProvider.GetResource("FirstName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Last Name </summary>
        public static string LastName {
               get {
                   return resourceProvider.GetResource("LastName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Username </summary>
        public static string Username {
               get {
                   return resourceProvider.GetResource("Username", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Enter your email address here... </summary>
        public static string EnterYourEmail {
               get {
                   return resourceProvider.GetResource("EnterYourEmail", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Your Password </summary>
        public static string YourPassword {
               get {
                   return resourceProvider.GetResource("YourPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Password </summary>
        public static string Password {
               get {
                   return resourceProvider.GetResource("Password", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Confirm Password </summary>
        public static string ConfirmPassword {
               get {
                   return resourceProvider.GetResource("ConfirmPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Newsletter </summary>
        public static string Newsletter {
               get {
                   return resourceProvider.GetResource("Newsletter", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Subscribe </summary>
        public static string Subscribe {
               get {
                   return resourceProvider.GetResource("Subscribe", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Yes </summary>
        public static string Yes {
               get {
                   return resourceProvider.GetResource("Yes", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No </summary>
        public static string No {
               get {
                   return resourceProvider.GetResource("No", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> I have read and agree to the Privacy Policy. </summary>
        public static string PrivacyPolicyAgree {
               get {
                   return resourceProvider.GetResource("PrivacyPolicyAgree", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Continue </summary>
        public static string Continue {
               get {
                   return resourceProvider.GetResource("Continue", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Email Address </summary>
        public static string EmailAddress {
               get {
                   return resourceProvider.GetResource("EmailAddress", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Email </summary>
        public static string Email {
               get {
                   return resourceProvider.GetResource("Email", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Sign out </summary>
        public static string SignOut {
               get {
                   return resourceProvider.GetResource("SignOut", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Login </summary>
        public static string Login {
               get {
                   return resourceProvider.GetResource("Login", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> NEW CUSTOMER </summary>
        public static string NewCustomer {
               get {
                   return resourceProvider.GetResource("NewCustomer", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> By creating an account you will be able to shop faster, be up to date on an order's status, and keep track of the orders you have previously made. </summary>
        public static string CreateAccountDescription {
               get {
                   return resourceProvider.GetResource("CreateAccountDescription", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> RETURNING CUSTOMER </summary>
        public static string ReturningCustomer {
               get {
                   return resourceProvider.GetResource("ReturningCustomer", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> I am returning customer </summary>
        public static string IamReturningCustomer {
               get {
                   return resourceProvider.GetResource("IamReturningCustomer", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Email address or Username </summary>
        public static string EmailAddressOrUsername {
               get {
                   return resourceProvider.GetResource("EmailAddressOrUsername", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Enter your email address or username here... </summary>
        public static string EnterYourEmailOrUsername {
               get {
                   return resourceProvider.GetResource("EnterYourEmailOrUsername", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Forgot your password? </summary>
        public static string ForgotYourPassword {
               get {
                   return resourceProvider.GetResource("ForgotYourPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Sign Up For Newsletters </summary>
        public static string SignUpForNewsletter {
               get {
                   return resourceProvider.GetResource("SignUpForNewsletter", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Get email updates about our latest shop and special offers </summary>
        public static string GetEmailUpdates {
               get {
                   return resourceProvider.GetResource("GetEmailUpdates", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Enter your email address </summary>
        public static string EnterYourEmailAddress {
               get {
                   return resourceProvider.GetResource("EnterYourEmailAddress", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> If you aready have an account with us, please login at the login page. </summary>
        public static string HaveAccount {
               get {
                   return resourceProvider.GetResource("HaveAccount", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Mobile Phone </summary>
        public static string MobilePhone {
               get {
                   return resourceProvider.GetResource("MobilePhone", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Password must be at least 6 characters long. </summary>
        public static string PasswordSixCharactersLong {
               get {
                   return resourceProvider.GetResource("PasswordSixCharactersLong", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Password must have at least one non letter or digit character. </summary>
        public static string PasswordNonLetterOrDigit {
               get {
                   return resourceProvider.GetResource("PasswordNonLetterOrDigit", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Password must have at least one digit. ('0'-'9') </summary>
        public static string PasswordAtLeastOneDigit {
               get {
                   return resourceProvider.GetResource("PasswordAtLeastOneDigit", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Password must have at least one uppercase. ('A'-'Z') </summary>
        public static string PasswordAtLeastOneUppercase {
               get {
                   return resourceProvider.GetResource("PasswordAtLeastOneUppercase", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Your Business </summary>
        public static string YourBusiness {
               get {
                   return resourceProvider.GetResource("YourBusiness", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> User </summary>
        public static string User {
               get {
                   return resourceProvider.GetResource("User", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Installer </summary>
        public static string Installer {
               get {
                   return resourceProvider.GetResource("Installer", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Distributor </summary>
        public static string Distributor {
               get {
                   return resourceProvider.GetResource("Distributor", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Company Name </summary>
        public static string CompanyName {
               get {
                   return resourceProvider.GetResource("CompanyName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Tax Number </summary>
        public static string TaxNumber {
               get {
                   return resourceProvider.GetResource("TaxNumber", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Remember me? </summary>
        public static string RememberMe {
               get {
                   return resourceProvider.GetResource("RememberMe", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Valid </summary>
        public static string Valid {
               get {
                   return resourceProvider.GetResource("Valid", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Invalid number </summary>
        public static string InvalidNumber {
               get {
                   return resourceProvider.GetResource("InvalidNumber", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Invalid country code </summary>
        public static string InvalidCountryCode {
               get {
                   return resourceProvider.GetResource("InvalidCountryCode", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Too short </summary>
        public static string TooShort {
               get {
                   return resourceProvider.GetResource("TooShort", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Too long </summary>
        public static string TooLong {
               get {
                   return resourceProvider.GetResource("TooLong", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Recover Password </summary>
        public static string RecoverPassword {
               get {
                   return resourceProvider.GetResource("RecoverPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Recover </summary>
        public static string Recover {
               get {
                   return resourceProvider.GetResource("Recover", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Your Recover Email Address </summary>
        public static string YourRecoverEmail {
               get {
                   return resourceProvider.GetResource("YourRecoverEmail", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Send </summary>
        public static string Send {
               get {
                   return resourceProvider.GetResource("Send", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Check your email </summary>
        public static string CheckYourEmail {
               get {
                   return resourceProvider.GetResource("CheckYourEmail", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> We have been sent an email to your inbox. Please check your email to reset your password. </summary>
        public static string EmailSentDescription {
               get {
                   return resourceProvider.GetResource("EmailSentDescription", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Reset Password </summary>
        public static string ResetPassword {
               get {
                   return resourceProvider.GetResource("ResetPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Reset </summary>
        public static string Reset {
               get {
                   return resourceProvider.GetResource("Reset", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Categories </summary>
        public static string Categories {
               get {
                   return resourceProvider.GetResource("Categories", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> All </summary>
        public static string All {
               get {
                   return resourceProvider.GetResource("All", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Price </summary>
        public static string Price {
               get {
                   return resourceProvider.GetResource("Price", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Apply </summary>
        public static string Apply {
               get {
                   return resourceProvider.GetResource("Apply", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Sort By </summary>
        public static string SortBy {
               get {
                   return resourceProvider.GetResource("SortBy", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Default </summary>
        public static string Default {
               get {
                   return resourceProvider.GetResource("Default", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Name </summary>
        public static string Name {
               get {
                   return resourceProvider.GetResource("Name", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Rate </summary>
        public static string Rate {
               get {
                   return resourceProvider.GetResource("Rate", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Showing </summary>
        public static string Showing {
               get {
                   return resourceProvider.GetResource("Showing", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Show </summary>
        public static string Show {
               get {
                   return resourceProvider.GetResource("Show", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> per page </summary>
        public static string PerPage {
               get {
                   return resourceProvider.GetResource("PerPage", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Add to Compare </summary>
        public static string AddToCompare {
               get {
                   return resourceProvider.GetResource("AddToCompare", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Add to Wishlist </summary>
        public static string AddToWishlist {
               get {
                   return resourceProvider.GetResource("AddToWishlist", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Comparison limit (3) </summary>
        public static string ComparisonLimit {
               get {
                   return resourceProvider.GetResource("ComparisonLimit", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Do you want to compare products now? </summary>
        public static string WantToCompare {
               get {
                   return resourceProvider.GetResource("WantToCompare", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Please choose the same category for the comparison. </summary>
        public static string ChooseSameCategory {
               get {
                   return resourceProvider.GetResource("ChooseSameCategory", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Documents </summary>
        public static string Documents {
               get {
                   return resourceProvider.GetResource("Documents", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No products based on criteria. </summary>
        public static string NoProducts {
               get {
                   return resourceProvider.GetResource("NoProducts", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No Stock </summary>
        public static string NoStock {
               get {
                   return resourceProvider.GetResource("NoStock", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Out of Stock </summary>
        public static string OutOfStock {
               get {
                   return resourceProvider.GetResource("OutOfStock", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Compare </summary>
        public static string Compare {
               get {
                   return resourceProvider.GetResource("Compare", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Cancel </summary>
        public static string Cancel {
               get {
                   return resourceProvider.GetResource("Cancel", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Ok </summary>
        public static string Ok {
               get {
                   return resourceProvider.GetResource("Ok", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> In Stock </summary>
        public static string InStock {
               get {
                   return resourceProvider.GetResource("InStock", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Shop </summary>
        public static string Shop {
               get {
                   return resourceProvider.GetResource("Shop", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Product </summary>
        public static string Product {
               get {
                   return resourceProvider.GetResource("Product", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Image </summary>
        public static string Image {
               get {
                   return resourceProvider.GetResource("Image", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Quantity </summary>
        public static string Quantity {
               get {
                   return resourceProvider.GetResource("Quantity", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Remove </summary>
        public static string Remove {
               get {
                   return resourceProvider.GetResource("Remove", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Update Cart </summary>
        public static string UpdateCart {
               get {
                   return resourceProvider.GetResource("UpdateCart", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Cart Totals </summary>
        public static string CartTotals {
               get {
                   return resourceProvider.GetResource("CartTotals", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Subtotal </summary>
        public static string Subtotal {
               get {
                   return resourceProvider.GetResource("Subtotal", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Tax </summary>
        public static string Tax {
               get {
                   return resourceProvider.GetResource("Tax", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Proceed to Checkout </summary>
        public static string ProceedToCheckout {
               get {
                   return resourceProvider.GetResource("ProceedToCheckout", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No products in cart. </summary>
        public static string NoProductsInCart {
               get {
                   return resourceProvider.GetResource("NoProductsInCart", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Continue Shopping </summary>
        public static string ContinueShopping {
               get {
                   return resourceProvider.GetResource("ContinueShopping", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Returning customer? </summary>
        public static string ReturningCustomerQ {
               get {
                   return resourceProvider.GetResource("ReturningCustomerQ", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Click here to login </summary>
        public static string ClickHereToLogin {
               get {
                   return resourceProvider.GetResource("ClickHereToLogin", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Username or Email </summary>
        public static string UsernameOrEmail {
               get {
                   return resourceProvider.GetResource("UsernameOrEmail", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Lost your password? </summary>
        public static string LostYourPassword {
               get {
                   return resourceProvider.GetResource("LostYourPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Address </summary>
        public static string Address {
               get {
                   return resourceProvider.GetResource("Address", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Town / City </summary>
        public static string TownCity {
               get {
                   return resourceProvider.GetResource("TownCity", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> State / County </summary>
        public static string StateCounty {
               get {
                   return resourceProvider.GetResource("StateCounty", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Postcode / Zip </summary>
        public static string PostcodeZip {
               get {
                   return resourceProvider.GetResource("PostcodeZip", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Ship to a different address? </summary>
        public static string ShipDifferent {
               get {
                   return resourceProvider.GetResource("ShipDifferent", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Order Notes </summary>
        public static string OrderNotes {
               get {
                   return resourceProvider.GetResource("OrderNotes", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Notes about your order, e.g. special notes for delivery. </summary>
        public static string OrderNotesDescription {
               get {
                   return resourceProvider.GetResource("OrderNotesDescription", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Billing Detail </summary>
        public static string BillingDetail {
               get {
                   return resourceProvider.GetResource("BillingDetail", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Your Order </summary>
        public static string YourOrder {
               get {
                   return resourceProvider.GetResource("YourOrder", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Cart Subtotal </summary>
        public static string CartSubtotal {
               get {
                   return resourceProvider.GetResource("CartSubtotal", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Order Total </summary>
        public static string OrderTotal {
               get {
                   return resourceProvider.GetResource("OrderTotal", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Place Order </summary>
        public static string PlaceOrder {
               get {
                   return resourceProvider.GetResource("PlaceOrder", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 5F., No.23, Wugong 6th Rd., Wugu Dist., New Taipei City 248, Taiwan (R.O.C) </summary>
        public static string PowerActiveAddress {
               get {
                   return resourceProvider.GetResource("PowerActiveAddress", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Country </summary>
        public static string Country {
               get {
                   return resourceProvider.GetResource("Country", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Company Name is required. </summary>
        public static string CompanyNameRequired {
               get {
                   return resourceProvider.GetResource("CompanyNameRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Tax Number is required. </summary>
        public static string TaxNumberRequired {
               get {
                   return resourceProvider.GetResource("TaxNumberRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> First Name is required. </summary>
        public static string FirstNameRequired {
               get {
                   return resourceProvider.GetResource("FirstNameRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Last Name is required. </summary>
        public static string LastNameRequired {
               get {
                   return resourceProvider.GetResource("LastNameRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Email is required. </summary>
        public static string EmailRequired {
               get {
                   return resourceProvider.GetResource("EmailRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> State / County is required. </summary>
        public static string StateCountyRequired {
               get {
                   return resourceProvider.GetResource("StateCountyRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Town / City is required. </summary>
        public static string TownCityRequired {
               get {
                   return resourceProvider.GetResource("TownCityRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Postcode / Zip is required. </summary>
        public static string PostcodeZipRequired {
               get {
                   return resourceProvider.GetResource("PostcodeZipRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Address is required. </summary>
        public static string AddressRequired {
               get {
                   return resourceProvider.GetResource("AddressRequired", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Save in Address book </summary>
        public static string SaveAddress {
               get {
                   return resourceProvider.GetResource("SaveAddress", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Taiwan </summary>
        public static string Taiwan {
               get {
                   return resourceProvider.GetResource("Taiwan", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Vietnam </summary>
        public static string Vietnam {
               get {
                   return resourceProvider.GetResource("Vietnam", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Turkey </summary>
        public static string Turkey {
               get {
                   return resourceProvider.GetResource("Turkey", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> USA </summary>
        public static string USA {
               get {
                   return resourceProvider.GetResource("USA", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Account </summary>
        public static string Account {
               get {
                   return resourceProvider.GetResource("Account", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Hello </summary>
        public static string Hello {
               get {
                   return resourceProvider.GetResource("Hello", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Not </summary>
        public static string Not {
               get {
                   return resourceProvider.GetResource("Not", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Need Assistance? </summary>
        public static string NeedAssistance {
               get {
                   return resourceProvider.GetResource("NeedAssistance", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Customer Service At. </summary>
        public static string CustomerService {
               get {
                   return resourceProvider.GetResource("CustomerService", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Email Them At. </summary>
        public static string EmailThem {
               get {
                   return resourceProvider.GetResource("EmailThem", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> View Cart </summary>
        public static string ViewCart {
               get {
                   return resourceProvider.GetResource("ViewCart", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Dashboard </summary>
        public static string Dashboard {
               get {
                   return resourceProvider.GetResource("Dashboard", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Orders </summary>
        public static string Orders {
               get {
                   return resourceProvider.GetResource("Orders", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Downloads </summary>
        public static string Downloads {
               get {
                   return resourceProvider.GetResource("Downloads", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Addresses </summary>
        public static string Addresses {
               get {
                   return resourceProvider.GetResource("Addresses", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Account Details </summary>
        public static string AccountDetails {
               get {
                   return resourceProvider.GetResource("AccountDetails", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Order </summary>
        public static string Order {
               get {
                   return resourceProvider.GetResource("Order", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Date </summary>
        public static string Date {
               get {
                   return resourceProvider.GetResource("Date", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Status </summary>
        public static string Status {
               get {
                   return resourceProvider.GetResource("Status", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Actions </summary>
        public static string Actions {
               get {
                   return resourceProvider.GetResource("Actions", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> View </summary>
        public static string View {
               get {
                   return resourceProvider.GetResource("View", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Expires </summary>
        public static string Expires {
               get {
                   return resourceProvider.GetResource("Expires", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Download </summary>
        public static string Download {
               get {
                   return resourceProvider.GetResource("Download", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Click Here To Download Your File </summary>
        public static string ClickToDownload {
               get {
                   return resourceProvider.GetResource("ClickToDownload", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Add </summary>
        public static string Add {
               get {
                   return resourceProvider.GetResource("Add", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Edit </summary>
        public static string Edit {
               get {
                   return resourceProvider.GetResource("Edit", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Delete </summary>
        public static string Delete {
               get {
                   return resourceProvider.GetResource("Delete", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Social title </summary>
        public static string SocialTitle {
               get {
                   return resourceProvider.GetResource("SocialTitle", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Change password </summary>
        public static string ChangePassword {
               get {
                   return resourceProvider.GetResource("ChangePassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Current password </summary>
        public static string CurrentPassword {
               get {
                   return resourceProvider.GetResource("CurrentPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> New password </summary>
        public static string NewPassword {
               get {
                   return resourceProvider.GetResource("NewPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Confirm new password </summary>
        public static string ConfirmNewPassword {
               get {
                   return resourceProvider.GetResource("ConfirmNewPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Business Type </summary>
        public static string BusinessType {
               get {
                   return resourceProvider.GetResource("BusinessType", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> New Business Type </summary>
        public static string NewBusinessType {
               get {
                   return resourceProvider.GetResource("NewBusinessType", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Sign up for our newsletter </summary>
        public static string SignUpOurNews {
               get {
                   return resourceProvider.GetResource("SignUpOurNews", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Subscribe to our newsletters now and stay up-to-date with new collections, the latest lookbooks and exclusive offers.. </summary>
        public static string SubscribeToOur {
               get {
                   return resourceProvider.GetResource("SubscribeToOur", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Save </summary>
        public static string Save {
               get {
                   return resourceProvider.GetResource("Save", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Back </summary>
        public static string Back {
               get {
                   return resourceProvider.GetResource("Back", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> From Your Account Dashboard. You Can Easily Check & View Your Recent Orders, Manage Your Shipping And Billing Addresses And Edit Your Password And Account Details. </summary>
        public static string DashboardInfo {
               get {
                   return resourceProvider.GetResource("DashboardInfo", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No orders. </summary>
        public static string NoOrders {
               get {
                   return resourceProvider.GetResource("NoOrders", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Pending </summary>
        public static string Pending {
               get {
                   return resourceProvider.GetResource("Pending", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> In Process </summary>
        public static string InProcess {
               get {
                   return resourceProvider.GetResource("InProcess", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Shipped </summary>
        public static string Shipped {
               get {
                   return resourceProvider.GetResource("Shipped", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Delivered </summary>
        public static string Delivered {
               get {
                   return resourceProvider.GetResource("Delivered", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Completed </summary>
        public static string Completed {
               get {
                   return resourceProvider.GetResource("Completed", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Cancelled </summary>
        public static string Cancelled {
               get {
                   return resourceProvider.GetResource("Cancelled", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No registered address. </summary>
        public static string NoAddress {
               get {
                   return resourceProvider.GetResource("NoAddress", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Do you want to delete the selected address? </summary>
        public static string DeleteAddressQ {
               get {
                   return resourceProvider.GetResource("DeleteAddressQ", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> New Address </summary>
        public static string NewAddress {
               get {
                   return resourceProvider.GetResource("NewAddress", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Edit Address </summary>
        public static string EditAddress {
               get {
                   return resourceProvider.GetResource("EditAddress", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Set </summary>
        public static string CategoryName5 {
               get {
                   return resourceProvider.GetResource("CategoryName5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Set </summary>
        public static string CategoryDesc5 {
               get {
                   return resourceProvider.GetResource("CategoryDesc5", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel WDR Surveillance Set </summary>
        public static string ProductName16 {
               get {
                   return resourceProvider.GetResource("ProductName16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 4 * N2M36D0-I, 2 * N2M40B0-IW, 1 * N2M28D0-IA, 1 * N2M36P0-I, 1 * N080000 </summary>
        public static string ProductDesc16 {
               get {
                   return resourceProvider.GetResource("ProductDesc16", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Offers </summary>
        public static string OffersT1O4 {
               get {
                   return resourceProvider.GetResource("OffersT1O4", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel Economic Surveillance Set </summary>
        public static string ProductName17 {
               get {
                   return resourceProvider.GetResource("ProductName17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 6 * N2M36D0-I, 2 * N2M36B0-I, 1 * N080000 </summary>
        public static string ProductDesc17 {
               get {
                   return resourceProvider.GetResource("ProductDesc17", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8CH POE Switch </summary>
        public static string ProductName18 {
               get {
                   return resourceProvider.GetResource("ProductName18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8CH POE Switch </summary>
        public static string ProductDesc18 {
               get {
                   return resourceProvider.GetResource("ProductDesc18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> POE Splitter </summary>
        public static string ProductName19 {
               get {
                   return resourceProvider.GetResource("ProductName19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> POE Splitter </summary>
        public static string ProductDesc19 {
               get {
                   return resourceProvider.GetResource("ProductDesc19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Seagate 4TB HDD </summary>
        public static string ProductName20 {
               get {
                   return resourceProvider.GetResource("ProductName20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Seagate 4TB HDD </summary>
        public static string ProductDesc20 {
               get {
                   return resourceProvider.GetResource("ProductDesc20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N2M28D0-IAP </summary>
        public static string ProductName21 {
               get {
                   return resourceProvider.GetResource("ProductName21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 2MP Economic IP Camera with Audio </summary>
        public static string ProductDesc21 {
               get {
                   return resourceProvider.GetResource("ProductDesc21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Audio </summary>
        public static string ASection24 {
               get {
                   return resourceProvider.GetResource("ASection24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Audio </summary>
        public static string AType87 {
               get {
                   return resourceProvider.GetResource("AType87", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 30 meter </summary>
        public static string AValue121 {
               get {
                   return resourceProvider.GetResource("AValue121", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 3.6 mm (2.8 mm / 6 mm optional) </summary>
        public static string AValue122 {
               get {
                   return resourceProvider.GetResource("AValue122", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Dome Model: 127mm × 96mm </summary>
        public static string AValue123 {
               get {
                   return resourceProvider.GetResource("AValue123", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> (PA-SC-N2M36D0-I) Power Active 2MP Economic IP Dome Camera </summary>
        public static string SetItemName2 {
               get {
                   return resourceProvider.GetResource("SetItemName2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2M Pixel , Two stream H.265/ H.264High Profile/Main Profile/Base Line Profile AES/AWB/2D DNR/3D DNR/DWDR TCP/IP；UDP；HTTP；IGMP ；ICMP；DHCP；RTP/RTSP；DNS；DDNS；FTP；NTP；PPPOE；UPNP；SMTP；SNMP </summary>
        public static string SetItemDesc2 {
               get {
                   return resourceProvider.GetResource("SetItemDesc2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> (PA-SC-N2M40B0-IW) Power Active 2MP WDR IP Bullet Camera </summary>
        public static string SetItemName3 {
               get {
                   return resourceProvider.GetResource("SetItemName3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2M Pixel , Three stream H.265/ H.264High Profile/Main Profile/Base Line Profile/ MJPEG AES/AWB/2D DNR/3D DNR/WDR Smart Function: Tripwire；Regional invasion；Items stolen；Items move；Density Detection；Number Stat；Through the fence ；Wandering detection ；Retrograde motion detection ；Face CaptureTCP/IP；UDP；HTTP；IGMP ；ICMP；DHCP；RTP/RTSP；DNS；DDNS；FTP；NTP；PPPOE；UPNP；SMTP；SNMP </summary>
        public static string SetItemDesc3 {
               get {
                   return resourceProvider.GetResource("SetItemDesc3", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> (PA-SC-N2M28D0-IA)  Power Active 2MP Economic IP Camera with Audio </summary>
        public static string SetItemName21 {
               get {
                   return resourceProvider.GetResource("SetItemName21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2M Pixel , Two stream AudioH.265/ H.264High Profile/Main Profile/Base Line ProfileAES/AWB/2D DNR/3D DNR/DWDRTCP/IP；UDP；HTTP；IGMP ；ICMP；DHCP；RTP/RTSP；DNS；DDNS；FTP；NTP；PPPOE；UPNP；SMTP；SNMP </summary>
        public static string SetItemDesc21 {
               get {
                   return resourceProvider.GetResource("SetItemDesc21", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> (PA-SC-N2MM36P0-I) Power Active 2MP Economic Mini PT IP Dome Camera </summary>
        public static string SetItemName7 {
               get {
                   return resourceProvider.GetResource("SetItemName7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2M Pixel , Two streamH.265/ H.264High Profile/Main Profile/Base Line ProfileAES/AWB/2D DNR/3D DNR/DWDRTCP/IP；UDP；HTTP；IGMP ；ICMP；DHCP；RTP/RTSP；DNS；DDNS；FTP；NTP；PPPOE；UPNP；SMTP；SNMPPan :355⁰ / Speed: 0 ~ 25 degrees per second   ;  Tile: 0 ~ 90⁰ / Speed: 0 ~ 20 degrees per second </summary>
        public static string SetItemDesc7 {
               get {
                   return resourceProvider.GetResource("SetItemDesc7", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> (PA-SR-N080000) Power Active 8CH NVR (E-version) </summary>
        public static string SetItemName9 {
               get {
                   return resourceProvider.GetResource("SetItemName9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Max 8 Channel 6.0MP IPC input, ONVIF SPEC 2.6, Input Bandwidth:64M; 1 Channel Face Detection or 2 Channel Intrusion Detection; Max 8 Channel synchronous playback; One 1000M Ethernet Port; one HDMI interface, Support 4K HD output; 2 SATA HDD interface,  P2P, APP Alarm Push; Support 1*3.0 USB </summary>
        public static string SetItemDesc9 {
               get {
                   return resourceProvider.GetResource("SetItemDesc9", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Seagate 4TB HDD </summary>
        public static string SetItemName20 {
               get {
                   return resourceProvider.GetResource("SetItemName20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Seagate SkyHawk 4TB 3.5" HDD (ST4000VX007) </summary>
        public static string SetItemDesc20 {
               get {
                   return resourceProvider.GetResource("SetItemDesc20", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8CH POE Switch </summary>
        public static string SetItemName18 {
               get {
                   return resourceProvider.GetResource("SetItemName18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8+2 port POE SwitchIEEE802.3、IEEE802.3u、IEEE802.3x、IEEE802.3af/at </summary>
        public static string SetItemDesc18 {
               get {
                   return resourceProvider.GetResource("SetItemDesc18", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> POE Splitter </summary>
        public static string SetItemName19 {
               get {
                   return resourceProvider.GetResource("SetItemName19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PoE Splitter , PoE Splitter Adapter IEEE 802.3af Compliant 10/100Mbps, DC 12V / 1-2A Output for IP Camera </summary>
        public static string SetItemDesc19 {
               get {
                   return resourceProvider.GetResource("SetItemDesc19", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> (PA-SC-N2M36B0-I) Power Active 2MP Economic IP Bullet Camera </summary>
        public static string SetItemName1 {
               get {
                   return resourceProvider.GetResource("SetItemName1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 2M Pixel , Two streamH.265/ H.264High Profile/Main Profile/Base Line ProfileAES/AWB/2D DNR/3D DNR/DWDRTCP/IP；UDP；HTTP；IGMP ；ICMP；DHCP；RTP/RTSP；DNS；DDNS；FTP；NTP；PPPOE；UPNP；SMTP；SNMP </summary>
        public static string SetItemDesc1 {
               get {
                   return resourceProvider.GetResource("SetItemDesc1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Installation Fee </summary>
        public static string InstallationFee {
               get {
                   return resourceProvider.GetResource("InstallationFee", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Subtotal (Products) </summary>
        public static string SubTotalProducts {
               get {
                   return resourceProvider.GetResource("SubTotalProducts", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Details </summary>
        public static string Details {
               get {
                   return resourceProvider.GetResource("Details", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Package Details </summary>
        public static string PackageDetails {
               get {
                   return resourceProvider.GetResource("PackageDetails", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel </summary>
        public static string SetBannerTitle1 {
               get {
                   return resourceProvider.GetResource("SetBannerTitle1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Basic Surveillance Set </summary>
        public static string SetBannerText1 {
               get {
                   return resourceProvider.GetResource("SetBannerText1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> $560 </summary>
        public static string SetBannerPrice1 {
               get {
                   return resourceProvider.GetResource("SetBannerPrice1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel </summary>
        public static string SetBannerTitle2 {
               get {
                   return resourceProvider.GetResource("SetBannerTitle2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Smart Surveillance Set </summary>
        public static string SetBannerText2 {
               get {
                   return resourceProvider.GetResource("SetBannerText2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> $733 </summary>
        public static string SetBannerPrice2 {
               get {
                   return resourceProvider.GetResource("SetBannerPrice2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Invalid login attempt. </summary>
        public static string InvalidLoginAttempt {
               get {
                   return resourceProvider.GetResource("InvalidLoginAttempt", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Email is confirmed </summary>
        public static string EmailConfirmed {
               get {
                   return resourceProvider.GetResource("EmailConfirmed", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Thank you for confirming your email. </summary>
        public static string EmailConfirmationInfo {
               get {
                   return resourceProvider.GetResource("EmailConfirmationInfo", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Sign in with new password </summary>
        public static string SignWithNewPassword {
               get {
                   return resourceProvider.GetResource("SignWithNewPassword", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Your password has been changed. Please login with your new password. </summary>
        public static string PasswordChangedInfo {
               get {
                   return resourceProvider.GetResource("PasswordChangedInfo", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Invalid Email </summary>
        public static string InvalidEmail {
               get {
                   return resourceProvider.GetResource("InvalidEmail", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Your email is not registered or confirmed yet. </summary>
        public static string InvalidEmailInfo {
               get {
                   return resourceProvider.GetResource("InvalidEmailInfo", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Invalid Code </summary>
        public static string InvalidCode {
               get {
                   return resourceProvider.GetResource("InvalidCode", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Code validation is expired. </summary>
        public static string InvalidCodeInfo {
               get {
                   return resourceProvider.GetResource("InvalidCodeInfo", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Confirmation Error </summary>
        public static string ConfirmationError {
               get {
                   return resourceProvider.GetResource("ConfirmationError", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> There is something wrong during confirmation, please contact us. </summary>
        public static string ConfirmationErrorInfo {
               get {
                   return resourceProvider.GetResource("ConfirmationErrorInfo", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Unit Price </summary>
        public static string UnitPrice {
               get {
                   return resourceProvider.GetResource("UnitPrice", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Stock Status </summary>
        public static string StockStatus {
               get {
                   return resourceProvider.GetResource("StockStatus", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No products in wishlist. </summary>
        public static string NoProductsWishlist {
               get {
                   return resourceProvider.GetResource("NoProductsWishlist", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Compare Products </summary>
        public static string CompareProducts {
               get {
                   return resourceProvider.GetResource("CompareProducts", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> My Wishlist </summary>
        public static string MyWishlist {
               get {
                   return resourceProvider.GetResource("MyWishlist", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Description </summary>
        public static string Description {
               get {
                   return resourceProvider.GetResource("Description", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Rating </summary>
        public static string Rating {
               get {
                   return resourceProvider.GetResource("Rating", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> No products to compare. </summary>
        public static string NoProductsCompare {
               get {
                   return resourceProvider.GetResource("NoProductsCompare", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Tools </summary>
        public static string Tools {
               get {
                   return resourceProvider.GetResource("Tools", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active Smart Surveillance </summary>
        public static string PASmartSurveillance {
               get {
                   return resourceProvider.GetResource("PASmartSurveillance", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Website </summary>
        public static string Website {
               get {
                   return resourceProvider.GetResource("Website", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Subject </summary>
        public static string Subject {
               get {
                   return resourceProvider.GetResource("Subject", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Write your message </summary>
        public static string WriteYourMessage {
               get {
                   return resourceProvider.GetResource("WriteYourMessage", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Submit </summary>
        public static string Submit {
               get {
                   return resourceProvider.GetResource("Submit", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active Smart Surveillance is a new brand for the surveillance market. We focus on end user’s application and system security especially in network application.We know what you want and what you need, all we done is focus on your request. </summary>
        public static string PowerActiveAboutText {
               get {
                   return resourceProvider.GetResource("PowerActiveAboutText", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> POWER ACTIVE SMART SURVEILLANCE </summary>
        public static string PowerActiveAboutTitle {
               get {
                   return resourceProvider.GetResource("PowerActiveAboutTitle", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Message </summary>
        public static string Message {
               get {
                   return resourceProvider.GetResource("Message", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Password has been changed successfully. </summary>
        public static string PasswordChangedSuccess {
               get {
                   return resourceProvider.GetResource("PasswordChangedSuccess", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> New Business Type request has been made. Please contact with us for details. </summary>
        public static string RoleRequestMailSent {
               get {
                   return resourceProvider.GetResource("RoleRequestMailSent", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Mail Us </summary>
        public static string MailUs {
               get {
                   return resourceProvider.GetResource("MailUs", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Special Offers </summary>
        public static string SpecialOffers {
               get {
                   return resourceProvider.GetResource("SpecialOffers", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Subscription is successful! </summary>
        public static string SubscriptionSuccess {
               get {
                   return resourceProvider.GetResource("SubscriptionSuccess", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Whole Sale </summary>
        public static string WholeSale {
               get {
                   return resourceProvider.GetResource("WholeSale", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Mr. </summary>
        public static string Mr {
               get {
                   return resourceProvider.GetResource("Mr", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Mrs. </summary>
        public static string Mrs {
               get {
                   return resourceProvider.GetResource("Mrs", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Language </summary>
        public static string Language {
               get {
                   return resourceProvider.GetResource("Language", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Error </summary>
        public static string Error {
               get {
                   return resourceProvider.GetResource("Error", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Success </summary>
        public static string Success {
               get {
                   return resourceProvider.GetResource("Success", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Opps! PAGE NOT BE FOUND </summary>
        public static string PageNotFound {
               get {
                   return resourceProvider.GetResource("PageNotFound", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Sorry but the page you are looking for does not exist, have been removed, name changed or is temporarily unavailable. </summary>
        public static string Error404 {
               get {
                   return resourceProvider.GetResource("Error404", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Bullet Model: 63.0mm × 63.0mm × 166.0mm </summary>
        public static string AValue124 {
               get {
                   return resourceProvider.GetResource("AValue124", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Dome Model: 93.2mm × 93.2mm × 66.5mm </summary>
        public static string AValue125 {
               get {
                   return resourceProvider.GetResource("AValue125", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Installation Service </summary>
        public static string ProductName22 {
               get {
                   return resourceProvider.GetResource("ProductName22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Basic installation, no decoration, indoor within 20 square meters </summary>
        public static string ProductDesc22 {
               get {
                   return resourceProvider.GetResource("ProductDesc22", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel WDR Surveillance Set (+ Installation Service) </summary>
        public static string ProductName23 {
               get {
                   return resourceProvider.GetResource("ProductName23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 4 * N2M36D0-I, 2 * N2M40B0-IW, 1 * N2M28D0-IA, 1 * N2M36P0-I, 1 * N080000, Installation Service </summary>
        public static string ProductDesc23 {
               get {
                   return resourceProvider.GetResource("ProductDesc23", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 8 Channel Economic Surveillance Set (+ Installation Service) </summary>
        public static string ProductName24 {
               get {
                   return resourceProvider.GetResource("ProductName24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 6 * N2M36D0-I, 2 * N2M36B0-I, 1 * N080000, Installation Service </summary>
        public static string ProductDesc24 {
               get {
                   return resourceProvider.GetResource("ProductDesc24", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> PA-SC-N4M28D0-IWAP </summary>
        public static string ProductName25 {
               get {
                   return resourceProvider.GetResource("ProductName25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Power Active 4MP WDR IP Camera with Audio </summary>
        public static string ProductDesc25 {
               get {
                   return resourceProvider.GetResource("ProductDesc25", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> User Manuals </summary>
        public static string UserManuals {
               get {
                   return resourceProvider.GetResource("UserManuals", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> <h1>Privacy Policy for Power Active Co. Ltd.</h1><p>At Power Active Smart Surveillance, accessible from www.poweractivesmartsurveillance.com, one of our main priorities is the privacy of our visitors. This Privacy Policy document contains types of information that is collected and recorded by Power Active Smart Surveillance and how we use it.</p><p>If you have additional questions or require more information about our Privacy Policy, do not hesitate to contact us.</p><p>This Privacy Policy applies only to our online activities and is valid for visitors to our website with regards to the information that they shared and/or collect in Power Active Smart Surveillance. This policy is not applicable to any information collected offline or via channels other than this website.</p><h2>Consent</h2><p>By using our website, you hereby consent to our Privacy Policy and agree to its terms.</p><h2>Information we collect</h2><p>The personal information that you are asked to provide, and the reasons why you are asked to provide it, will be made clear to you at the point we ask you to provide your personal information.</p><p>If you contact us directly, we may receive additional information about you such as your name, email address, phone number, the contents of the message and/or attachments you may send us, and any other information you may choose to provide.</p><p>When you register for an Account, we may ask for your contact information, including items such as name, company name, address, email address, and telephone number.</p><h2>How we use your information</h2><p>We use the information we collect in various ways, including to:</p><ul> <li>Provide, operate, and maintain our webste</li> <li>Improve, personalize, and expand our webste</li> <li>Understand and analyze how you use our webste</li> <li>Develop new products, services, features, and functionality</li> <li>Communicate with you, either directly or through one of our partners, including for customer service, to provide you with updates and other information relating to the webste, and for marketing and promotional purposes</li> <li>Send you emails</li> <li>Find and prevent fraud</li></ul><h2>Log Files</h2><p>Power Active Smart Surveillance follows a standard procedure of using log files. These files log visitors when they visit websites. All hosting companies do this and a part of hosting services' analytics. The information collected by log files include internet protocol (IP) addresses, browser type, Internet Service Provider (ISP), date and time stamp, referring/exit pages, and possibly the number of clicks. These are not linked to any information that is personally identifiable. The purpose of the information is for analyzing trends, administering the site, tracking users' movement on the website, and gathering demographic information.</p><h2>Cookies and Web Beacons</h2><p>Like any other website, Power Active Smart Surveillance uses 'cookies'. These cookies are used to store information including visitors' preferences, and the pages on the website that the visitor accessed or visited. The information is used to optimize the users' experience by customizing our web page content based on visitors' browser type and/or other information.</p><p>For more general information on cookies, please read <a href="https://www.cookieconsent.com/what-are-cookies/">"What Are Cookies"</a>.</p><h2>Advertising Partners Privacy Policies</h2><P>You may consult this list to find the Privacy Policy for each of the advertising partners of Power Active Smart Surveillance.</P><p>Third-party ad servers or ad networks uses technologies like cookies, JavaScript, or Web Beacons that are used in their respective advertisements and links that appear on Power Active Smart Surveillance, which are sent directly to users' browser. They automatically receive your IP address when this occurs. These technologies are used to measure the effectiveness of their advertising campaigns and/or to personalize the advertising content that you see on websites that you visit.</p><p>Note that Power Active Smart Surveillance has no access to or control over these cookies that are used by third-party advertisers.</p><h2>Third Party Privacy Policies</h2><p>Power Active Smart Surveillance's Privacy Policy does not apply to other advertisers or websites. Thus, we are advising you to consult the respective Privacy Policies of these third-party ad servers for more detailed information. It may include their practices and instructions about how to opt-out of certain options. </p><p>You can choose to disable cookies through your individual browser options. To know more detailed information about cookie management with specific web browsers, it can be found at the browsers' respective websites.</p><h2>CCPA Privacy Rights (Do Not Sell My Personal Information)</h2><p>Under the CCPA, among other rights, California consumers have the right to:</p><p>Request that a business that collects a consumer's personal data disclose the categories and specific pieces of personal data that a business has collected about consumers.</p><p>Request that a business delete any personal data about the consumer that a business has collected.</p><p>Request that a business that sells a consumer's personal data, not sell the consumer's personal data.</p><p>If you make a request, we have one month to respond to you. If you would like to exercise any of these rights, please contact us.</p><h2>GDPR Data Protection Rights</h2><p>We would like to make sure you are fully aware of all of your data protection rights. Every user is entitled to the following:</p><p>The right to access – You have the right to request copies of your personal data. We may charge you a small fee for this service.</p><p>The right to rectification – You have the right to request that we correct any information you believe is inaccurate. You also have the right to request that we complete the information you believe is incomplete.</p><p>The right to erasure – You have the right to request that we erase your personal data, under certain conditions.</p><p>The right to restrict processing – You have the right to request that we restrict the processing of your personal data, under certain conditions.</p><p>The right to object to processing – You have the right to object to our processing of your personal data, under certain conditions.</p><p>The right to data portability – You have the right to request that we transfer the data that we have collected to another organization, or directly to you, under certain conditions.</p><p>If you make a request, we have one month to respond to you. If you would like to exercise any of these rights, please contact us.</p><h2>Children's Information</h2><p>Another part of our priority is adding protection for children while using the internet. We encourage parents and guardians to observe, participate in, and/or monitor and guide their online activity.</p><p>Power Active Smart Surveillance does not knowingly collect any Personal Identifiable Information from children under the age of 13. If you think that your child provided this kind of information on our website, we strongly encourage you to contact us immediately and we will do our best efforts to promptly remove such information from our records.</p> </summary>
        public static string PrivacyPolicyText {
               get {
                   return resourceProvider.GetResource("PrivacyPolicyText", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> By creating an account, you agree to Power Active's </summary>
        public static string PrivacyPolicyAgreePart1 {
               get {
                   return resourceProvider.GetResource("PrivacyPolicyAgreePart1", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>   </summary>
        public static string PrivacyPolicyAgreePart2 {
               get {
                   return resourceProvider.GetResource("PrivacyPolicyAgreePart2", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Privacy Policy </summary>
        public static string PrivacyPolicy {
               get {
                   return resourceProvider.GetResource("PrivacyPolicy", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Direct Bank Transfer </summary>
        public static string DirectBankTransfer {
               get {
                   return resourceProvider.GetResource("DirectBankTransfer", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Make your payment directly into our bank account. Please use your Order ID as the payment reference. Your order won’t be shipped until the funds have cleared in our account. </summary>
        public static string DirectBankTransferInfo {
               get {
                   return resourceProvider.GetResource("DirectBankTransferInfo", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Account Name (same as company name) </summary>
        public static string BankAccountName {
               get {
                   return resourceProvider.GetResource("BankAccountName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Bank Name </summary>
        public static string BankName {
               get {
                   return resourceProvider.GetResource("BankName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Branch Name </summary>
        public static string BankBranchName {
               get {
                   return resourceProvider.GetResource("BankBranchName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> Bank Account Number </summary>
        public static string BankAccountNumber {
               get {
                   return resourceProvider.GetResource("BankAccountNumber", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 勤力合實業股份有限公司 </summary>
        public static string PABankAccountName {
               get {
                   return resourceProvider.GetResource("PABankAccountName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 玉山銀行 </summary>
        public static string PABankName {
               get {
                   return resourceProvider.GetResource("PABankName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 五股分行 </summary>
        public static string PABankBranchName {
               get {
                   return resourceProvider.GetResource("PABankBranchName", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary> 0543-940-013886 </summary>
        public static string PABankAccountNumber {
               get {
                   return resourceProvider.GetResource("PABankAccountNumber", CultureInfo.CurrentUICulture.Name) as string;
               }
            }

        /// <summary> Order is succesful ! </summary>
        public static string OrderSuccess
        {
            get
            {
                return resourceProvider.GetResource("OrderSuccess", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Your Order ID is </summary>
        public static string YourOrderId
        {
            get
            {
                return resourceProvider.GetResource("YourOrderId", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Please use your Order ID as the payment reference. </summary>
        public static string OrderSuccessPaymentInfo
        {
            get
            {
                return resourceProvider.GetResource("OrderSuccessPaymentInfo", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Your order won't be shipped until the funds have cleared in our account. </summary>
        public static string OrderSuccessShipmentInfo
        {
            get
            {
                return resourceProvider.GetResource("OrderSuccessShipmentInfo", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> You can check your order progress from "My Account" section. </summary>
        public static string OrderSuccessRegisteredProgress
        {
            get
            {
                return resourceProvider.GetResource("OrderSuccessRegisteredProgress", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Your order progress will be sent to your email address. </summary>
        public static string OrderSuccessUnregisteredProgress
        {
            get
            {
                return resourceProvider.GetResource("OrderSuccessUnregisteredProgress", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> In need of more information about your order progress, you can also call or email us from the "Contact Us" section. </summary>
        public static string OrderSuccessContactUs
        {
            get
            {
                return resourceProvider.GetResource("OrderSuccessContactUs", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Accessories </summary>
        public static string AccessoriesT2O4
        {
            get
            {
                return resourceProvider.GetResource("AccessoriesT2O4", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Shipment Fee </summary>
        public static string ShipmentFee
        {
            get
            {
                return resourceProvider.GetResource("ShipmentFee", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Order Id </summary>
        public static string OrderId
        {
            get
            {
                return resourceProvider.GetResource("OrderId", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Tracking Id </summary>
        public static string TrackingId
        {
            get
            {
                return resourceProvider.GetResource("TrackingId", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Transfer should be completed in 3 days, otherwise the order will be cancelled. </summary>
        public static string OrderSuccessTransferDeadline
        {
            get
            {
                return resourceProvider.GetResource("OrderSuccessTransferDeadline", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Waiting For Payment  </summary>
        public static string WaitingForPayment
        {
            get
            {
                return resourceProvider.GetResource("WaitingForPayment", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> User name must contain only letters or digits.  </summary>
        public static string UsernameContainLettersOrDigits
        {
            get
            {
                return resourceProvider.GetResource("UsernameContainLettersOrDigits", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> {0} {1}  </summary>
        public static string PersonFullNameFormat
        {
            get
            {
                return resourceProvider.GetResource("PersonFullNameFormat", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> New Account Registered!  </summary>
        public static string CreateAccountMailTitle
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountMailTitle", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Dear {0} {1},  </summary>
        public static string CreateAccountMailReceiver
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountMailReceiver", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> You successfully created your Customer Acoount, please confirm your Power Active Account by clicking the link below.  </summary>
        public static string CreateAccountMailFirstP
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountMailFirstP", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Email: {0}  </summary>
        public static string CreateAccountUserEmailInfo
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountUserEmailInfo", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Username: {0} </summary>
        public static string CreateAccountUserNameInfo
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountUserNameInfo", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Confirm My Email  </summary>
        public static string CreateAccountButtonInfo
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountButtonInfo", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> If you have any question, please,  </summary>
        public static string CreateAccountMailFooter
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountMailFooter", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Contact Us  </summary>
        public static string CreateAccountMailFooterLinkText
        {
            get
            {
                return resourceProvider.GetResource("CreateAccountMailFooterLinkText", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Your Order! </summary>
        public static string NewOrderMailTitle
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailTitle", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Dear {0} {1}, </summary>
        public static string NewOrderMailReceiver
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailReceiver", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Your Order Number {0} registered! Please use your Order Number as the payment reference. Your order won't be shipped until the funds have cleared in our account.  </summary>
        public static string NewOrderMailFirstP
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailFirstP", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Transfer should be completed in 3 days, otherwise the order will be cancelled.  </summary>
        public static string NewOrderMailSecondP
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailSecondP", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Check Order Status  </summary>
        public static string NewOrderMailButtonInfo
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailButtonInfo", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> If you have any questions, please,   </summary>
        public static string NewOrderMailFooter
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailFooter", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Contact Us  </summary>
        public static string NewOrderMailFooterLinkText
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailFooterLinkText", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Bank Information  </summary>
        public static string NewOrderMailBankInformation
        {
            get
            {
                return resourceProvider.GetResource("NewOrderMailBankInformation", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Order Date </summary>
        public static string OrderDate
        {
            get
            {
                return resourceProvider.GetResource("OrderDate", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Reset your Power Active Password </summary>
        public static string ResetPasswordMailTitle
        {
            get
            {
                return resourceProvider.GetResource("ResetPasswordMailTitle", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Dear {0} {1}, </summary>
        public static string ResetPasswordMailReceiver
        {
            get
            {
                return resourceProvider.GetResource("ResetPasswordMailReceiver", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> You receive this mail because you required a new password. Please reset your password with the following link. If you didn't make this request, please ignore this mail. </summary>
        public static string ResetPasswordMailFirstP
        {
            get
            {
                return resourceProvider.GetResource("ResetPasswordMailFirstP", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Reset My Password </summary>
        public static string ResetPasswordMailButtonInfo
        {
            get
            {
                return resourceProvider.GetResource("ResetPasswordMailButtonInfo", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> If you have any questions, please,  </summary>
        public static string ResetPasswordMailFooter
        {
            get
            {
                return resourceProvider.GetResource("ResetPasswordMailFooter", CultureInfo.CurrentUICulture.Name) as string;
            }
        }

        /// <summary> Contact Us </summary>
        public static string ResetPasswordMailFooterLinkText
        {
            get
            {
                return resourceProvider.GetResource("ResetPasswordMailFooterLinkText", CultureInfo.CurrentUICulture.Name) as string;
            }
        }


    }        
}
