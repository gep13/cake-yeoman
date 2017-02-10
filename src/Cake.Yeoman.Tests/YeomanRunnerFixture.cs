namespace Cake.Yeoman.Tests
{
    using System;
    using Testing.Fixtures;
    using Yeoman;

    public class YeomanRunnerFixture : ToolFixture<YeomanRunnerSettings>
    {
        public YeomanRunnerFixture() : base("node") { }

        public string GeneratorName { get; set; }

        public Action<YeomanRunnerSettings> SettingsAction { get; set; }

        protected override void RunTool()
        {
            var tool = new YeomanRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.RunGenerator(GeneratorName, SettingsAction);
            tool.RunGenerator(GeneratorName);
        }
    }
}