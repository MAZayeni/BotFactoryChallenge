namespace Common.Interface
{
    using System;

    public interface IReportingUnit
    {
        event EventHandler<IStatusChangedEventArgs> UnitStatusChanged;

        void OnStatusChanged(IStatusChangedEventArgs args);
    }
}