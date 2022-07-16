namespace CoordinateSystem
{
    public class Point2D
    {   
        private long _x;
        private long _y;
        public long Num{get; private set;}
        public long X
        {
            get{return _x;}
            private set
            {
                this.DistanceFromOrigin = double.NaN;
                this._x = value;
            }
        }
        public long Y
        {
            get{return _y;}
            private set
            {
                this.DistanceFromOrigin = double.NaN;
                this._y = value;
            }
        }
        public double DistanceFromOrigin{get; private set;} = double.NaN;
        public string Quadrant{get; private set;} = String.Empty;

        public Point2D(long num, long x, long y)
        {
            this.Num = num;
            this.X = x;
            this.Y = y;
            this.DistanceFromOrigin = this.GetDistanceFromOrigin();
            this.Quadrant = this.GetQuadrant();
        }

        private string GetQuadrant()
        {
            if(!String.IsNullOrEmpty(this.Quadrant))
            {
                return this.Quadrant;
            }
            var result = "on axis";
            if(this.X > 0 && this.Y > 0)
            {
                result = "I";
            }
            else if(this.X > 0 && this.Y < 0)
            {
                result = "II";
            }
            else if(this.X < 0 && this.Y < 0)
            {
                result = "III";
            }
            else if(this.X < 0 && this.Y > 0)
            {
                result = "IV";
            }
            else if(this.X == 0 && this.Y == 0)
            {
                result = "on origin";
            }
            return result;
            
        }
        private double GetDistanceFromOrigin()
        {
            try
            {
                checked
                {                    
                    var distance = Double.IsNaN(this.DistanceFromOrigin) ? 
                        Math.Sqrt(this.X * this.X + this.Y * this.Y) : 
                        this.DistanceFromOrigin;
                    return distance;
                }
            }
            catch (OverflowException)
            {                
                throw;
            }           
            
        }

        public override string ToString()
        {
            return ($"Point{this.Num}({this.X}, {this.Y}) with distance from origin(0, 0) = {this.DistanceFromOrigin} and " + 
            ((this.Quadrant == "on axis" || this.Quadrant == "on origin") ? $"is the {this.Quadrant}." : $"in {this.Quadrant} quadrant."));
        }
    }
}