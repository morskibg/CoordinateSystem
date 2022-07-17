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
        public string[] Read()
        {   
            string[] lines = File.ReadAllLines(this.FullPath);
            return lines;           
        }
        
    }
}