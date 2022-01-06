using System;

namespace SecEdgar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello SecEdgar!");
            string stockSymbol = "HY";
            string cik = "";
            string symbolFile = Global.SYMBOL_FILE_PATH;

            System.Console.WriteLine("symbol file: " + symbolFile);

            Stock stock = new Stock(stockSymbol,symbolFile);
            cik = stock.find_cik();
            
            System.Console.WriteLine("CIK Found: " + cik);
        }
    }
}
