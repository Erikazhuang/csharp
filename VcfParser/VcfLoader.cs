using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using log4net;

namespace VcfService
{
    //read csv file 
    //set file name, delimiter, lines to skip and headerRow
    //check if file is valid
    //return data in DataTable
    public class VcfLoader
    {
        public static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _fileName;
        private string _sep = "\t";
        private string _skip= "##";
        private string _headerhint = "#";
        private bool _fileValid;

        public VcfLoader(string fileName, string delimiter, string commentsHint, string columnHeaderHint){
            log.Info("VcfLoader ctor");
            
            Debug.Assert(fileName!=null); //need fileName
            _fileName = fileName;

            _sep = delimiter;
            _skip = commentsHint;
            _headerhint = columnHeaderHint;
        }

        //Check if file format is valid
        //check if file include required columns
        public bool IsFileValid{
            get { return _fileValid; }
        }

        //read file, load and return data in DataTable
        public DataTable GetData(){
            DataTable dt = new DataTable("data");
            string[] lines;
            try{
                lines = System.IO.File.ReadAllLines(_fileName);

                foreach(string line in lines)
                {
                    if (!line.StartsWith(_skip)) //skip any comment lines
                    { 
                        if (line.StartsWith(_headerhint))  
                            {
                                string[] columnNames = line.Replace(_headerhint,"").Split(_sep);
                                foreach(var header in columnNames)
                                {
                                    dt.Columns.Add(header);
                                }

                            }
                            else
                            {   
                                string[] data = line.Split(_sep.ToCharArray());
                                
                                DataRow dr = dt.NewRow();
                                for (int i = 0; i < data.Length; i++)
                                {
                                    try{
                                        dr[i] = data[i];
                                    }
                                    catch(Exception ex){
                                        log.Error(String.Format("Error adding line {0}, {1}", i, ex.Message) );
                                    }
                                }
                                dt.Rows.Add(dr);
                                
                            }         
                    }

                }
            }
            catch(FileNotFoundException ex)
            {
                log.Error("VcfLoader read file error: " + ex.ToString());
            }           
           

            return dt;
        }
    }
}