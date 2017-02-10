namespace Cake.Yeoman
{
    using Core.IO;

    /// <summary>
    /// Yeoman Runner configuration.
    /// </summary>
    public interface IYeomanRunnerConfiguration
    {
        /// <summary>
        /// Sets the working directory for Yeoman.
        /// </summary>
        /// <param name="path">Path to use as working directory.</param>
        /// <returns>Yeoman runner instance.</returns>
        IYeomanRunnerCommands WithWorkingDirectory(DirectoryPath path);
    }
}
