using System.Configuration;

namespace SecEdgar
{
    public static class Global
    {
        public static string SYMBOL_FILE_PATH = ConfigurationManager.AppSettings["SymbolFilePath"] ;
        
    }
}

