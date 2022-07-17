using System;


namespace CoordinateSystem
{
    public class ErrorWriter:IWriter<string>
    {   
        public void Write(string message)
        {   
            Console.WriteLine(message);                      
        }
        
    }
}