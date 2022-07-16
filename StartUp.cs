using System;

namespace CoordinateSystem 
{
    
    internal class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                string[] lines = ReadInputHandler();
                Dictionary<long,Point2D> points = Point2DParserHandler(lines);
                ResultHandler(points);

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error info:{ex.Message}");
                Environment.ExitCode = 1; 
            }            
            
        }
        public static string[] ReadInputHandler()
        {
            var fileReader = new FileReader();
            try
            {
                string[] lines = fileReader.ReadAllLines();
                return lines;
            }
            catch (FileNotFoundException )
            {
                throw;                            
            }
        }
        public static Dictionary<long,Point2D> Point2DParserHandler(string[] lines)
        {
            var point2DParser = new Point2DParser();
            var points = new Dictionary<long,Point2D>();

            foreach (var line in lines)
            {
                if(!point2DParser.IsValid(line))
                {
                    continue;
                }
                try
                {                            
                    (long num, long x, long y) = point2DParser.Parse(line); 

                    var currPoint2D = new Point2D(num, x, y);
                    if(points.ContainsKey(num))
                    {
                        throw new ArgumentException($"Point with number {num} already exist!");                            
                    }
                    points[num] = currPoint2D;                     
                }
                catch (Exception ex) when (ex is ArgumentException || ex is OverflowException)                    
                {
                    Console.WriteLine($"Error for {line} with info:{ex.Message}");                            
                }
            }
            return points;
        }
        public static void ResultHandler(Dictionary<long,Point2D> points)
        {
            FileWriter fileWriter = new FileWriter();
            var maxDistancePoint = points
                    .OrderByDescending(x => x.Value.DistanceFromOrigin)
                    .First(); 

            var maxDistancePoints = points
                .Where(x => x.Value.DistanceFromOrigin == maxDistancePoint.Value.DistanceFromOrigin)
                .ToDictionary(x => x.Key, x => x.Value);

            var linesToWrite = maxDistancePoints.Select(x => x.Value.ToString()).ToList();

            linesToWrite.ForEach(Console.WriteLine);
            fileWriter.WriteAllLines(linesToWrite);
        }
    }
}