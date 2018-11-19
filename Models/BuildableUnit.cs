namespace Models
{
    using Common.Tools;
    using Common.Interface;

    public abstract class BuildableUnit : IBuildableUnit
    {
        public double BuildTime { get; set; }

        public string ModelModel { get; set; }

        public BuildableUnit(double buildTime = 5)
        {
            this.BuildTime = buildTime;
        }
    }
}
