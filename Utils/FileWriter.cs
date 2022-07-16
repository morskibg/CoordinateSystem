using System;
using System.IO;

namespace CoordinateSystem
{
    public class FileWriter:IWriter
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        

        public FileWriter(string fileName)
        {
            this.FileName = fileName;             
            this.FullPath = Path.Combine(Directory.GetCurrentDirectory(), this.FileName);             
        }
        public FileWriter():this(Constants.RESULT_FILE_NAME){}
    
        public void WriteAllLines(List<string> lines)
        {   
            File.WriteAllLines(this.FullPath, lines);                       
        }
        
    }
}