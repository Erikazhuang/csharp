using System;
using System.Data;
using System.Text;
using log4net;


namespace VcfService
{
    class Program
    {
        public static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            string chromosome= "chr1";
            string position= "10080";

            //get chromosome and position from args, if not empty, set default
            if(args.Length == 2)
            {   
                chromosome = args[0];
                position  = args[1];
            }
           
            //read input_tiny file into a datatable
            log.Info("Starting VcfLoader");

            string file = "C:/tmp/input_tiny.vcf";

            VcfLoader fileLoader = new VcfLoader(file,"\t","##","#");  //set file name, comments line to skip, header line and delimiter
            DataTable cvfTable = fileLoader.GetData();       


            //filter data by input and return result to console            
            DataRow[] results = cvfTable.Select(string.Format("CHROM = '{0}' AND POS='{1}' ", chromosome, position));

            if (results.Length> 0)
            {    
                StringBuilder refs = new StringBuilder();
                foreach(var row in results)
                {
                    refs.Append(row["REF"]);
                    
                }   

                System.Console.WriteLine("{0}: {1} is '{2}'" , chromosome, position,refs.ToString());           
            }
            else
            {
                System.Console.WriteLine("{0}: {1} not found!", chromosome, position);
            }

           log.Info("VcfLoader completed.");
        }
    }
}
