using System;

namespace CoordinateSystem 
{
    
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var errorWriter = new ErrorWriter();
            try
            {
                string[] lines = ReadInputHandler();
                if(lines.Count() == 0)
                {
                    throw new InvalidOperationException();
                }
                Dictionary<long,Point2D> points = Point2DParserHandler(lines);
                ResultHandler(points);

            }            
            catch (Exception ex) when (ex is FileNotFoundException || ex is InvalidOperationException)
            {
                errorWriter.Write($"Error info: {ex.Message}");
                Environment.ExitCode = 1; 
            }            
            
        }
        public static string[] ReadInputHandler(string filename = Constants.INPUT_FILE_NAME)
        {
            var fileReader = new FileReader(filename);
            try
            {
                string[] lines = fileReader.Read();
                return lines;
            }
            catch (FileNotFoundException )
            {
                throw;                            
            }
        }
        public static Dictionary<long,Point2D> Point2DParserHandler(string[] lines)
        {
            var errorWriter = new ErrorWriter();
            var point2DParser = new Point2DParser();
            var points = new Dictionary<long,Point2D>();

            foreach (var line in lines)
            {
                if(!point2DParser.IsValid(line))
                {
                    errorWriter.Write(line == string.Empty ? 
                        $"Error info: empty input line" : 
                        $"Error info: Invalid point format for {line}");
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
                    errorWriter.Write($"Error info: {line} with info:{ex.Message}");                            
                }
            }
            return points;
        }
        public static void ResultHandler(Dictionary<long,Point2D> points, 
                                                string filename = Constants.RESULT_FILE_NAME)
        {
            var fileWriter = new FileWriter(filename);
            var maxDistancePoint = points
                    .OrderByDescending(x => x.Value.DistanceFromOrigin)
                    .First(); 

            var maxDistancePoints = points
                .Where(x => x.Value.DistanceFromOrigin == maxDistancePoint.Value.DistanceFromOrigin)
                .ToDictionary(x => x.Key, x => x.Value);

            var linesToWrite = maxDistancePoints.Select(x => x.Value.ToString()).ToList();

            linesToWrite.ForEach(Console.WriteLine);
            fileWriter.Write(linesToWrite);
        }
    }
}