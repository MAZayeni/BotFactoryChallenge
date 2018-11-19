namespace Common.Tools
{
    using System;

    public class Vector
    {

        public double X { get; set; }

        public double Y { get; set; }

        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            return new Vector() { X = end.X - begin.X, Y = end.Y - end.Y };
        }

        public double Lenght => Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));

    }
}
