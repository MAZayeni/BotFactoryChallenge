namespace Models
{
    public class R2d2 : WorkingUnit
    {
        private readonly double _speed = 1.5;
        private readonly double _buildtime = 5.5;

        public R2d2() : base(nameof(R2d2))
        {
            this.BuildTime = _buildtime;
            this.Speed = _speed;
        }
    }
}
