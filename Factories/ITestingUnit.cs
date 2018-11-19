namespace Factories
{
    using Common.Interface;

    public interface ITestingUnit :  IWorkingUnit, IBaseUnit, IReportingUnit, IBuildableUnit
    {
    }
}
