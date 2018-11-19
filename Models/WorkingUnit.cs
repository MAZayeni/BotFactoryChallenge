namespace Models
{
    using Common.Tools;
    using Common.Interface;
    using System.Threading.Tasks;
    using System;

    public abstract class WorkingUnit : BaseUnit, IWorkingUnit
    {
        public WorkingUnit(string name) : base(name)
        {

        }

        public WorkingUnit(string name, double speed) : base(name, speed)
        {

        }

        public Coordinates ParkingPos { get; set; }

        public Coordinates WorkingPos { get; set; }

        public bool IsWorking { get; set; }

        public async virtual Task<bool> WorkBegins()
        {
            await Move(CurrentPos, WorkingPos);
            return true;
        }

        public async virtual Task<bool> WorkEnds()
        {
            await Move(CurrentPos, ParkingPos);
            return true;
        }

       
    }
}
