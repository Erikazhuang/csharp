using System.Configuration;
using System.Data;
using VcfService;

namespace SecEdgar
{
    public class Stock
    {
        private string _symbol;
        private string _symbolFilePath;

        public Stock(string symbol,string symbolfilePath)
        {
            _symbol = symbol;
            _symbolFilePath = symbolfilePath;
        }

        public string find_cik()
        {
          
            string cik = "";

            VcfLoader csvLoader = new VcfLoader(_symbolFilePath, ",", "##", "cik");
            DataTable symbolTable = csvLoader.GetData();

            DataRow[] results = symbolTable.Select(string.Format("symbol = '{0}' ", _symbol));

            if (results.Length == 1)
            {    
                cik = results[0]["cik"].ToString();   
            }
            else if (results.Length==0)
            {
                 cik= "";
            }
            else if (results.Length>1)
            {
                 cik = "multiple cik found. ";
            }

            return cik;
        }
    }
}