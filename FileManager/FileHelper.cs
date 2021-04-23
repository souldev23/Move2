using Move2.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Move2.FileManager
{
    class FileHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<string> getFiles(string root)
        {
            List<string> allFiles = new List<string>();
            try
            {
                allFiles = Directory.GetFiles(root, "*.wav", SearchOption.TopDirectoryOnly).ToList();
                log.Debug("Se obtienen todos los archivos wav contenidos en el directorio " + root);
            }
            catch (Exception ex)
            {
                log.Error("No se pudieron obtener los archivos wav del directorio " + root + ". \nError: " + ex.StackTrace);
            }
            return allFiles;
        }

        public static FileDetail getInfo(string file)
        {
            try
            {
                FileInfo info = new FileInfo(file);
                FileDetail detail = new FileDetail();
                detail.name = info.Name;
                detail.directoryName = info.DirectoryName;
                detail.fullName = info.FullName;
                detail.length = info.Length;
                detail.creationTime = info.CreationTime;
                info = null;
                return detail;
            }catch(Exception ex)
            {
                log.Error("Ocurrió un error al obtener la información del archivo: " + file + ".\nError: " + ex.StackTrace);
                return null;
            }
        }

        public static bool moveFile(string name, string src, string dest, bool debugMode)
        {
            bool moved = false;
            if(!debugMode)
            {
                try
                {
                    FileInfo fi = new FileInfo(src + name);
                    fi.MoveTo(dest + name);
                    log.Debug(string.Format("Se movió el archivo {0} a {1}", src + name, dest + name));
                    moved = true;
                }
                catch(Exception e)
                {
                    log.Error("No se pudo mover el archivo. Error: " + e.StackTrace);
                }
            }
            else
            {
                log.Debug(string.Format("Se movió el archivo {0} a {1}", src + name, dest + name));
                moved = true;
            }
            return moved;
        }
    }
}
