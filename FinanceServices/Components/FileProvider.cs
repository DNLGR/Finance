using FinanceServices.Interfaces;
using System.IO;

namespace FinanceServices.Components
{
    public class FileProvider : IFileProvider
    {
        #region Var
        private StreamReader reader;
        private StreamWriter writer;
        #endregion

        #region Propertyes
        public bool IsAppendMode { get; set; } = true;
        #endregion

        #region Ctor
        public FileProvider()
        {
            
        }
        #endregion

        public string Read(string path)
        {
            using (reader = new StreamReader(path))
            {
                return reader.ReadToEndAsync().Result;
            }
        }

        public void Write(string path, string value)
        {
            using (writer = new StreamWriter(path, IsAppendMode))
            {
                writer.WriteLineAsync(value);
            }
        }
    }
}
