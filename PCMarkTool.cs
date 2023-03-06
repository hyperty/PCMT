using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq;
using PCMT;

class PCMarkTool
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("未给出路径，请检查");
            return;
        }
       

        string[] xmlFiles = Directory.GetFiles(args[0], "*.xml").Where(file => Path.GetExtension(file) == ".xml").ToArray();

        if (xmlFiles.Length == 0)
        {
            Console.WriteLine("所给路径不包含任何xml文件！");
            return;
        }

        //在原路径下创建一个子目录“csv”
        string outputPath = Path.Combine(args[0], "csv");
        Directory.CreateDirectory(outputPath);


        XMLtoCSV XMLToCSV = new XMLtoCSV();
        XMLToCSV.XMLConvertCSV(outputPath, xmlFiles);

        CSVMerge CSVMerge = new CSVMerge();
        CSVMerge.Merge(outputPath);
    }
}





