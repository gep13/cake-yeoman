namespace Cake.Yeoman
{
    using System;

    /// <summary>
    /// Yeoman Runner command interface.
    /// </summary>
    public interface IYeomanRunnerCommands
    {
        /// <summary>
        /// Runs a Yeoman generator with default settings.
        /// </summary>
        /// <param name="generator">Name of the generator to run.</param>
        /// <returns>Yeoman runner instance.</returns>
        IYeomanRunnerCommands RunGenerator(string generator);

        /// <summary>
        /// Runs a Yeoman generator.
        /// </summary>
        /// <param name="generator">Name of the generator to run.</param>
        /// <param name="configure">Options for running the generator.</param>
        /// <returns>Yeoman runner instance.</returns>
        IYeomanRunnerCommands RunGenerator(string generator, Action<YeomanRunnerSettings> configure);

        /// <summary>
        /// Runs a Yeoman generator.
        /// </summary>
        /// <param name="generator">Name of the generator to run.</param>
        /// <param name="settings">Options passed to the generator.</param>
        /// <returns>Yeoman runner instance.</returns>
        IYeomanRunnerCommands RunGenerator(string generator, YeomanRunnerSettings settings);
    }
}
