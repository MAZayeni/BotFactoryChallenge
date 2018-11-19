namespace Models
{
    using Common.Interface;
    using System;

    public class StatusChangedEventArgs : EventArgs, IStatusChangedEventArgs
    {
        public string NewStatus { get; set; }
    }
}
