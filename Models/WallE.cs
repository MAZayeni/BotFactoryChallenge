namespace Models
{
    public class WallE : WorkingUnit
    {
        private readonly double _speed = 2.0;
        private readonly double _buildtime = 4.0;

        public WallE() : base(nameof(WallE))
        {
            this.BuildTime = _buildtime;
            this.Speed = _speed;
        }
    }
}
