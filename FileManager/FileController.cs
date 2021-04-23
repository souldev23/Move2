using Move2.model;
using Move2.Utils;
using System;
using System.Collections.Generic;


namespace Move2.FileManager
{
    class FileController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string root;
        string wavPath;
        string xmlPath;
        string destWAV;
        string destXML;
        int max_size;
        bool debug;
        public FileController(Config cfg)
        {
            this.root = cfg.rootPath;
            this.wavPath = cfg.wavPath;
            this.xmlPath = cfg.xmlPath;
            this.destWAV = cfg.destWAV;
            this.destXML = cfg.destXML;
            this.max_size = cfg.max_size;
            this.debug = cfg.debug;
        }

        public void start()
        {
            log.Debug("Se inicializa correctamente la tarea");
            List<string> files = getFilesInDIr();
            log.Debug(string.Format("Se encontraron {0} archivos WAV en el directorio {1}.", files.Count, root + wavPath));
            List<string> selectedFiles = getSelectFiles(files);
            log.Debug(string.Format("Se seleccionaron {0} archivos WAV bajo el criterio de tamaño máximo de {1} KB.", selectedFiles.Count, max_size));
            moveFiles(selectedFiles);
        }

        public List<string> getFilesInDIr()
        {
            return FileHelper.getFiles(root + wavPath);
        }

        public FileDetail getFileInfo(string file)
        {
            return FileHelper.getInfo(file);
        }

        public List<string> getSelectFiles(List<string> files)
        {
            List<string> selected = new List<string>();
            foreach(string item in files)
            {
                FileDetail fd = getFileInfo(item);
                if((fd.length/1024) < max_size)
                {
                    selected.Add(item);
                }
            }
            return selected;
        }

        public void moveFiles(List<string> lst)
        {
            int counter = 0;
            foreach(string item in lst)
            {
                FileDetail fd = getFileInfo(item);
                if(FileHelper.moveFile(fd.name, fd.directoryName + @"\", destWAV + @"\", debug))
                {
                    if(FileHelper.moveFile(getTXTFile(fd.name), root + xmlPath + @"\", destXML + @"\", debug))
                    {
                        counter++;
                    }
                }
            }
            log.Debug("Se movieron " + counter + " archivos");
        }

        public string getTXTFile(string name)
        {
            return name.Replace(".WAV", ".wav").Replace(".wav", ".xml");
        }
    }
}
