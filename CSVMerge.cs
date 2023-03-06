using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCMT
{
    class CSVMerge
    {
        public void Merge(string args)
        {
            //在csv路径下查找所有csv文件，并写入字符串
            string[] inputFiles = Directory.GetFiles(args, "*.csv").Where(file => Path.GetExtension(file) == ".csv").ToArray();

            if (inputFiles.Length == 0)
            {
                Console.WriteLine("所给路径不包含任何csv文件！");
            }

            // 定义输出文件名
            string outputFile = Path.Combine(args, "output.csv");


            // 从第一个文件中读取第一列和第二列的值
            string[] firstColumnValues = File.ReadLines(inputFiles[0])
                .Select(line => line.Split(','))
                .Select(parts => parts[0])
                .ToArray();

            string[] secondColumnValues = File.ReadLines(inputFiles[0])
                .Select(line => line.Split(','))
                .Select(parts => parts[1])
                .ToArray();

            // 从其余文件中读取第二列的值
            string[][] otherColumnValues = new string[inputFiles.Length - 1][];
            for (int i = 1; i < inputFiles.Length; i++)
            {
                otherColumnValues[i - 1] = File.ReadLines(inputFiles[i])
                    .Select(line => line.Split(','))
                    .Select(parts => parts[1])
                    .ToArray();
            }

            // 创建输出文件的内容
            string[] outputLines = new string[firstColumnValues.Length];
            for (int i = 0; i < firstColumnValues.Length; i++)
            {
                string line = $"{firstColumnValues[i]},{secondColumnValues[i]}";
                foreach (string[] columnValues in otherColumnValues)
                {
                    line += $",{columnValues[i]}";
                }
                outputLines[i] = line;
            }

            // 写入输出文件
            File.WriteAllLines(outputFile, outputLines);
        }
    }
}
