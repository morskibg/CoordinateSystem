using System;
using System.IO;

namespace CoordinateSystem
{
    public class FileReader:IReader
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        

        public FileReader(string fileName)
        {
            this.FileName = fileName;             
            this.FullPath = Path.Combine(Directory.GetCurrentDirectory(), this.FileName);             
        }
        public FileReader():this(Constants.INPUT_FILE_NAME){}
    
        public string[] ReadAllLines()
        {   
            string[] lines = File.ReadAllLines(this.FullPath);
            return lines;           
        }
        public string ReadAllText()
        {
            string text = File.ReadAllText(this.FullPath);
            return text;
        }
    }
}