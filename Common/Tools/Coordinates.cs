namespace Common.Tools
{
    using System;

    public class Coordinates 
    {
        public double X { get; set; }

        public double Y { get; set; }

        public Coordinates(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object coordinates) => this.X == (coordinates as Coordinates)?.X && this.Y == (coordinates as Coordinates)?.Y;

        public override int GetHashCode() => base.GetHashCode();
    }
}
