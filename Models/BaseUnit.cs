namespace Models
{
    using Common.Interface;
    using Common.Tools;
    using System;
    using System.Threading.Tasks;

    public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {

        public string Name { get; }

        public Coordinates CurrentPos { get; set; }

        public double Speed { get; set; }

        public BaseUnit(string name, double speed = 1) : base()
        {
            this.Name = name;
            this.Speed = speed;
            this.CurrentPos = new Coordinates(0, 0);
        }

        public async Task<double> Move(Coordinates begin, Coordinates end)
        {
            Vector vec = Vector.FromCoordinates(begin, end);
            double distance =  vec.Lenght;
            double time = distance / Speed;
            await Task.Delay(TimeSpan.FromSeconds(time));
            return time;
        }        

    }
}
