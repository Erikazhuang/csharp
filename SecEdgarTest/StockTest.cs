using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecEdgar;

namespace SecEdgarTest
{
    [TestClass]
    public class UnitTestStock
    {
        [TestMethod]
        public void Testfind_cik()
        {
           string stockSymbol = "HY";
           string cik = "";
           string symbolFile = @"C:\tmp\symbols.csv";

            Stock stock = new Stock(stockSymbol,symbolFile);
            cik = stock.find_cik();
            System.Console.WriteLine("cik is " + cik); //"1173514" ,
            Assert.AreEqual(cik,"1173514");
        }
    }
}
