namespace CoordinateSystem
{
    static class Constants
    {
        public const string INPUT_FILE_NAME = "input.txt";
        public const string RESULT_FILE_NAME = "result.txt";
        public const string POINT_PATTERN_2D = @"^Point\d+\(\s*?(?:-|\+)?\d+\s*?,\s*?(?:-|\+)?\d+\s*?\)$"; 
        public const string COORD_PATTERN_2D = @"^Point(?<number>\d+)\((?<x>\s*?(?:-|\+)?\d+\s*?)(?=,),(?<y>\s*?(?:-|\+)?\d+\s*?)(?=\))\)$"; 
        
    }
}
