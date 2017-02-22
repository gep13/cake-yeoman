namespace Cake.Yeoman.Tests
{
    using Shouldly;
    using Xunit;

    public sealed class YeomanRunnerTests
    {
        public sealed class TheRunGeneratorMethod
        {
            [Fact]
            public void Should_Throw_If_Generator_Name_Is_Null()
            {
                // Given
                var fixture = new YeomanRunnerFixture
                {
                    GeneratorName = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("generator");
            }

            [Fact]
            public void Should_Throw_If_Generator_Name_Is_Empty()
            {
                // Given
                var fixture = new YeomanRunnerFixture
                {
                    GeneratorName = string.Empty
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentOutOfRangeException("generator");
            }

            [Fact]
            public void Should_Throw_If_Generator_Name_Is_Whitespace()
            {
                // Given
                var fixture = new YeomanRunnerFixture()
                {
                    GeneratorName = "   "
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentOutOfRangeException("generator");
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new YeomanRunnerFixture
                {
                    GeneratorName = "Foo",
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void No_Settings_Specified_Should_Execute_Command_Without_Arguments()
            {
                var fixture = new YeomanRunnerFixture
                {
                    GeneratorName = "Foo"
                };

                var result = fixture.Run();

                result.Args.ShouldBe(fixture.GeneratorName);
            }

            [Fact]
            public void Arguments_Should_Be_Added_If_Settings_Are_Passed()
            {
                var fixture = new YeomanRunnerFixture()
                {
                    GeneratorName = "Foo"
                };
                fixture.Settings.Arguments.Add("Bar");

                var result = fixture.Run();

                result.Args.ShouldBe("Foo Bar");
            }
        }
    }
}