using System;
using System.IO;

namespace CoordinateSystem
{
    public class FileWriter:IWriter<List<string>>
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        

        public FileWriter(string fileName)
        {
            this.FileName = fileName;             
            this.FullPath = Path.Combine(Directory.GetCurrentDirectory(), this.FileName);             
        }        
    
        public void Write(List<string> lines)
        {   
            File.WriteAllLines(this.FullPath, lines);                       
        }
        
    }
}