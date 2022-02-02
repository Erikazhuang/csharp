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
           string symbolFile = @"C:\tmp\symbols.csv"; //file containing cik and symbol lookup columns
           string cik = "";

            Stock stock = new Stock(stockSymbol,symbolFile);
            cik = stock.find_cik();
    
            Assert.AreEqual(cik,"1173514");
        }

        [TestMethod]
        public void Testget_filing()
        {
            string stockSymbol = "HY";
            string symbolFile = @"C:\tmp\symbols.csv";
            Stock stock = new Stock(stockSymbol,symbolFile);

            string period = "quarterly";
            int year = 2020; //can use default of 0 to get the latest
            int quarter = 1; // 1, 2, 3, 4, or default value of 0 to get the latest
            Filing filing = stock.get_filing();
        }
    }
}
