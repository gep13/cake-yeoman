namespace Cake.Yeoman.Tests
{
    using Testing.Fixtures;

    internal class YeomanRunnerFixture : ToolFixture<YeomanRunnerSettings>
    {
        public YeomanRunnerFixture() : base("yo.cmd") { }

        public string GeneratorName { get; set; }

        protected override void RunTool()
        {
            var tool = new YeomanRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.RunGenerator(GeneratorName, Settings);
        }
    }
}