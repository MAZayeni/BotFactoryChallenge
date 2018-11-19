namespace Models
{
    using System;
    using Common.Interface;

    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {
        public event EventHandler<IStatusChangedEventArgs> UnitStatusChanged;

        public ReportingUnit()
        {

        }

        public ReportingUnit(double buildTime) : base(buildTime)
        {

        }

        public virtual void OnStatusChanged(IStatusChangedEventArgs args)
        {
            if(this.UnitStatusChanged != null)
            {
                UnitStatusChanged(this, args);
            }
        }
    }
}
