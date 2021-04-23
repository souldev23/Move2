using Move2.FileManager;
using Move2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move2.Utils
{
    class ListUtils
    {
        public static void printList(List<string> lst)
        {
            int line = 1;
            foreach(string item in lst)
            {
                Console.WriteLine("Line " + line + ": " + item);
                line++;
            }
        }

        public static void printDetails(List<string> lst)
        {
            foreach (string item in lst)
            {
                FileDetail fd = FileHelper.getInfo(item);
                int line = 1;
                if (fd != null)
                {
                    Console.WriteLine("Line " + line + ": " + fd.toString());
                    line++;
                }
            }
        }
    }
}
