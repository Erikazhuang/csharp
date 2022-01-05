using Microsoft.VisualStudio.TestTools.UnitTesting;
using VcfService;
using System.Data;
using System.Text;


namespace VcfParserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetData()
        {
            VcfLoader loader = new VcfLoader(@"C:/tmp/input_tiny.vcf","\t","##","#");
            DataTable dt = loader.GetData();

            string chromosome= "chr1";
            string position= "10080";
            DataRow[] results = dt.Select(string.Format("CHROM = '{0}' AND POS='{1}' ", chromosome, position));
            StringBuilder refs = new StringBuilder();
            foreach(var row in results)
            {
                refs.Append(row["REF"]);
                
            }   
            Assert.IsTrue(refs.ToString()=="A" );
        }
    }
}
