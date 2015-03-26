using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public static class FileOperation
    {
        public static StreamWriter WriteToFile(List<string> pageItems, String filePath = "Local drop pages.txt",StreamWriter writer = null)
        {
            FileStream aFile = new FileStream("Local drop pages.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            for (int i = 0; i < pageItems.Count; i++)
            {
                sw.WriteLine(pageItems[i]);
            }
            return sw;
        }

        public static List<String> readFile(String filePath = "AllURLS.txt")
        {
            FileStream aFile = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(aFile);
            String temp = "";
            List<string> res = new List<string>();
            while ((temp = reader.ReadLine()) != null)
            {
                if(!temp.StartsWith("//"))
                    res.Add(temp);
            }

            return res;
        }
    }
}
