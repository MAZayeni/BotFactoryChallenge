namespace Models
{
    public class Hal : WorkingUnit
    {
        private readonly double _speed = 0.5;
        private readonly double _buildtime = 7.0;

        public Hal() : base(nameof(Hal))
        {
            this.BuildTime = _buildtime;
            this.Speed = _speed;
        }
    }
}
