namespace Factories
{
    using Common.Tools;
    using System;

    public class FactoryQueueElement : IFactoryQueueElement
    {

        public FactoryQueueElement(Type model, string name, Coordinates coordinatesStatio, Coordinates coordinatesWork)
        {
            this.Model = model;
            this.Name = name;
            this.ParkingPos = coordinatesStatio;
            this.WorkingPos = coordinatesWork;
        }

        public string Name { get; set; }

        public Type Model { get; set; }

        public Coordinates ParkingPos { get; set; }

        public Coordinates WorkingPos { get; set; }
    }
}
