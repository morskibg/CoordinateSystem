using System.Text.RegularExpressions;

namespace CoordinateSystem
{
    public class Point2DParser:IValidator, IParser<Tuple<long, long, long>>
    {
        public Boolean IsValid(string rawData)
        {
            var rx = new Regex(Constants.POINT_PATTERN_2D, RegexOptions.Compiled);
            
            return rx.IsMatch(rawData);
        }

        public Tuple<long,long, long> Parse(string rawData)
        {
            var rx = new Regex(Constants.COORD_PATTERN_2D, RegexOptions.Compiled);
            Match match = rx.Match(rawData);
            string matchedNumber = match.Groups["number"].Value.Trim();
            string matchedX = match.Groups["x"].Value.Trim();
            string matchedY = match.Groups["y"].Value.Trim();
            long num = Int64.Parse(matchedNumber);
            long x = Int64.Parse(matchedX);
            long y = Int64.Parse(matchedY);
                      
            return new Tuple<long, long, long>(num, x, y);
        }
    }
}