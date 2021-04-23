using Move2.FileManager;
using Move2.Utils;
using System;
using System.Configuration;

namespace Move2
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            FileController fc = new FileController(new Config());
            log.Info("Se crea correctamente el objeto FileController");
            fc.start();
            
            Console.ReadLine();
        }
    }
}
