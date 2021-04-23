using System;

namespace Move2.model
{
    class FileDetail
    {
        public string name { get; set; }
        public string directoryName { get; set; }
        public string fullName { get; set; }
        public long length { get; set; }
        public DateTime creationTime { get; set; }

        public string toString()
        {
            return string.Format("Nombre: {0}\r\nDirectorio: {1}\r\nTamaño: {2}\r\nFecha de creación: {3}\r\nNombre completo: {4}\r\n",
                name, directoryName, (length / 1000), creationTime.ToString("dd/MM/yyyy HH:mm:ss"), fullName);
        }
    }
}
