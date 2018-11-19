namespace Factories
{
    using System;
    using Common.Tools;

    public interface IFactoryQueueElement
    {
        Type Model { get; set; }

        string Name { get; set; }

        Coordinates ParkingPos { get; set; }

        Coordinates WorkingPos { get; set; }
    }
}