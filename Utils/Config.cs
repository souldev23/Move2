using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Move2.Utils
{
    class Config
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string rootPath;
        public string wavPath;
        public string xmlPath;
        public string destWAV;
        public string destXML;
        public int max_size;
        public bool debug;
        public Config()
        {
            try
            {
                log.Info("Inicializando App Move2 by Souldev23");
                log.Debug("Cargando la configuración");
                rootPath = ConfigurationManager.AppSettings["ROOT"].ToString();
                wavPath = ConfigurationManager.AppSettings["WAVDIR"].ToString();
                xmlPath = ConfigurationManager.AppSettings["XMLDIR"].ToString();
                destWAV = ConfigurationManager.AppSettings["WAVDEST"].ToString();
                destXML = ConfigurationManager.AppSettings["XMLDEST"].ToString();
                max_size = Convert.ToInt32(ConfigurationManager.AppSettings["MAX_SIZE"].ToString());
                debug = Convert.ToBoolean(ConfigurationManager.AppSettings["DEBUG"].ToString());
                log.Info("Carpeta raíz: " + rootPath);
                log.Info("Carpeta de audios: " + rootPath + wavPath);
                log.Info("Carpeta de metadata: " + rootPath + xmlPath);
                log.Info("Carpeta destino para los archivos wav: " + destWAV);
                log.Info("Carpeta destino para los archivos txt: " + destXML);
                log.Info("Tamaño máximo de los archivos que se seleccionarán: " + max_size + "KB.");
                log.Info("Modo debug activado: " + debug);
                log.Debug("Configuración cargada correctamente.");
            }catch(Exception e)
            {
                log.Error("Ocurrió un error al cargar la configuración.\nError: " + e.StackTrace);
            }
        }
    }
}
