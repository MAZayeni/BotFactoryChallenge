using System.Threading.Tasks;
using Common.Tools;

namespace Common.Interface
{
    public interface IBaseUnit
    {
        Coordinates CurrentPos { get; set; }

        string Name { get; }

        double Speed { get; set; }

        Task<double> Move(Coordinates begin, Coordinates end);
    }
}