using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PCMT
{
    class XMLtoCSV
    {
        public void XMLConvertCSV(string outputPath, string[] xmlFiles)
        {


            foreach (string xmlFile in xmlFiles)
            {
                // 读取XML文件
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFile);

                // 定义CSV文件的第一列
                string[] csvColumn1 = { "benchmarkRunId", "PCMark10Score", "EssentialsScore", "AppStartupScore", "AppStartupChromiumCold", "AppStartupChromiumWarm", "AppStartupFirefoxCold", "AppStartupFirefoxWarm", "AppStartupGimpCold", "AppStartupGimpWarm", "AppStartupWriterCold", "AppStartupWriterWarm", "VideoConferencingScore", "VideoConferencingDetectGroupCpu", "VideoConferencingDetectGroupOcl", "VideoConferencingDetectPrivateCpu", "VideoConferencingDetectPrivateOcl", "VideoConferencingEncodeGroupOcl", "VideoConferencingEncodePrivateOcl", "VideoConferencingPlayGroupCpu", "VideoConferencingPlayGroupOcl", "VideoConferencingPlayPrivateCpu", "VideoConferencingPlayPrivateOcl", "WebBrowsingScore", "WebBrowsingMapInfo", "WebBrowsingMapZoom", "WebBrowsingShop3D", "WebBrowsingShopLoad", "WebBrowsingShopView", "WebBrowsingSocialFeed", "WebBrowsingSocialLoad", "WebBrowsingVideoFhdAvc", "WebBrowsingVideoFhdVp9", "WebBrowsingVideoUhdAvc", "WebBrowsingVideoUhdVp9", "ProductivityScore", "SpreadsheetsScore", "SpreadsheetBuilding", "SpreadsheetCompute", "SpreadsheetCompute2", "SpreadsheetCopy", "SpreadsheetCopyFormulas", "SpreadsheetEdit", "SpreadsheetEnergyMarketOcl", "SpreadsheetLoad", "SpreadsheetMonteCarloOcl", "SpreadsheetSave", "SpreadsheetStock", "WritingScore", "WritingCopy", "WritingCut", "WritingLoad", "WritingPicture", "WritingSave", "DigitalContentCreationScore", "PhotoEditingScore", "PhotoEditingBatchOcl", "PhotoEditingBlurOcl", "PhotoEditingColorCpu", "PhotoEditingContrastOcl", "PhotoEditingDenoiseOcl", "PhotoEditingJpg", "PhotoEditingNoiseCpu", "PhotoEditingPng", "PhotoEditingThumbnailCpu", "PhotoEditingUnsharp1Cpu", "PhotoEditingUnsharp2Ocl", "RenderingAndVisualizationScore", "RenderingAndVisualizationGt1", "RenderingAndVisualizationRaytracing", "VideoEditingScore", "VideoDeshakeOcl", "VideoEditingDeshakeCpu", "VideoEditingDownscaleCpu", "VideoEditingDownscaleOcl", "VideoEditingGo" };

                // 创建字典，以CSV文件的第一列作为键
                Dictionary<string, string> csvValues = new Dictionary<string, string>();
                foreach (string key in csvColumn1)
                {
                    csvValues[key] = "";
                }

                XmlNodeList resultNodes = doc.SelectNodes("//result/*");
                // 遍历XML文件中的所有元素
                foreach (XmlNode node in resultNodes)
                {
                    if (csvValues.ContainsKey(node.Name))
                    {
                        // 将元素值存储在字典的值中
                        csvValues[node.Name] = node.InnerText;
                    }
                }


                string csvFilePath = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(xmlFile) + ".csv");


                // 创建CSV文件并写入内容
                using (StreamWriter writer = new StreamWriter(csvFilePath))
                {
                    writer.WriteLine("Element," + Path.GetFileNameWithoutExtension(xmlFile)); // CSV文件头部

                    // 遍历字典，并将键和值写入CSV文件中
                    foreach (KeyValuePair<string, string> pair in csvValues)
                    {
                        writer.WriteLine($"{pair.Key},{pair.Value}");
                    }
                }

                Console.WriteLine(csvFilePath + "文件已创建。");
                Console.WriteLine(xmlFile);
            }

        }
    }
}
