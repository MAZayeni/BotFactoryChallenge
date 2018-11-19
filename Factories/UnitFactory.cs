namespace Factories
{
    using Common.Interface;
    using Common.Tools;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class UnitFactory : IUnitFactory
    {
        private object lockObj = new object();

        public int QueueCapacity { get; private set; }

        public int StorageCapacity { get; private set; }

        public Queue<IFactoryQueueElement> Queue { get; set; } = new Queue<IFactoryQueueElement>();

        public List<ITestingUnit> Storage { get; set; } = new List<ITestingUnit>();

        public TimeSpan QueueTime { get; set; }

        public int QueueFreeSlots => QueueCapacity - Queue.Count;

        public int StorageFreeSlots => StorageCapacity - Storage.Count;

        public event EventHandler FactoryStatus;

        
        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            this.QueueCapacity = queueCapacity;
            this.StorageCapacity = storageCapacity;
        }

        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates coordinatesStatio, Coordinates coordinatesWork)
        {


            bool result = false;
            IWorkingUnit workingUnit = Activator.CreateInstance(model) as IWorkingUnit;            
            workingUnit.ParkingPos = coordinatesStatio;
            workingUnit.WorkingPos = coordinatesWork;
            Thread th = new Thread(() =>
            {
                lock (lockObj)
                {
                    if (QueueFreeSlots == 0 && StorageFreeSlots == 0)
                    {
                        result = false;
                    }
                    else
                    {
                        FactoryQueueElement element = new FactoryQueueElement(model, name, coordinatesStatio, coordinatesWork);
                        Queue.Enqueue(element);
                        Thread.Sleep(TimeSpan.FromSeconds(workingUnit.BuildTime));                        
                        QueueTime += TimeSpan.FromSeconds(workingUnit.BuildTime);
                        if (StorageFreeSlots > 0)
                        {
                            Queue.Dequeue();
                            IBaseUnit baseUnit = (IBaseUnit)workingUnit;
                            baseUnit.Move(coordinatesStatio, coordinatesWork);

                            Storage.Add(Activator.CreateInstance(model) as ITestingUnit);
                        }
                        result = true;
                    }
                    
                }
            });
            th.Start();
            return result;
        }

        public void Builder_FactoryProgress()
        {

        }
    }
}