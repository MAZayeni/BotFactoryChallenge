namespace Models
{
    public class T800 : WorkingUnit
    {
        private readonly double _speed = 3.0;
        private readonly double _buildtime = 10.0;

        public T800() : base(nameof(T800))
        {
            this.BuildTime = _buildtime;
            this.Speed = _speed;
        }
    }
}
