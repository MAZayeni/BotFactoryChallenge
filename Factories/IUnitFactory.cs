namespace Factories
{
    using System;
    using System.Collections.Generic;
    using Common.Tools;

    public interface IUnitFactory
    {
        event EventHandler FactoryStatus ;

        Queue<IFactoryQueueElement> Queue { get; set; }

        int QueueCapacity { get; }

        int QueueFreeSlots { get; }

        TimeSpan QueueTime { get; set; }

        List<ITestingUnit> Storage { get; set; }

        int StorageCapacity { get; }

        int StorageFreeSlots { get; }

        bool AddWorkableUnitToQueue(Type model, string name, Coordinates coordinatesStatio, Coordinates coordinatesWork);
    }
}