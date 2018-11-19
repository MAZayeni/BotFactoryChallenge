namespace Common.Interface
{
    using System.Threading.Tasks;
    using Common.Tools;

    public interface IWorkingUnit : IBuildableUnit 
    {
        bool IsWorking { get; set; }

        Coordinates ParkingPos { get; set; }

        Coordinates WorkingPos { get; set; }

        Task<bool> WorkBegins();

        Task<bool> WorkEnds();
    }
}