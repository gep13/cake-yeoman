namespace Cake.Yeoman
{
    using Core;
    using Core.IO;
    using Core.Tooling;
    using System.Collections.Generic;
    using System.IO;
    using System;

    /// <summary>
    /// A wrapper around the Yeoman scaffolding tool.
    /// </summary>
    public class YeomanRunner : Tool<YeomanRunnerSettings>, IYeomanRunnerCommands, IYeomanRunnerConfiguration
    {
        private readonly IFileSystem fileSystem;
        private DirectoryPath workingDirectoryPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="YeomanRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The Cake environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="toolLocator">The tool locator.</param>
        public YeomanRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator toolLocator)
            : base(fileSystem, environment, processRunner, toolLocator)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException(nameof(fileSystem));
            }

            this.fileSystem = fileSystem;
        }

        #region IYeomanRunnerConfiguration

        /// <summary>
        /// Sets the working directory for Yeoman.
        /// </summary>
        /// <param name="path">Path to use as working directory.</param>
        /// <returns>Yeoman runner instance.</returns>
        public IYeomanRunnerCommands WithWorkingDirectory(DirectoryPath path)
        {
            this.workingDirectoryPath = path;
            return this;
        }

        #endregion

        #region IYeomanRunnerCommands

        /// <summary>
        /// Runs a Yeoman generator with default settings.
        /// </summary>
        /// <param name="generator">Name of the generator to run.</param>
        /// <returns>Yeoman runner instance.</returns>
        public IYeomanRunnerCommands RunGenerator(string generator)
        {
            return this.RunGenerator(generator, new YeomanRunnerSettings());
        }

        /// <summary>
        /// Runs a Yeoman generator with specified settings.
        /// </summary>
        /// <param name="generator">Name of the generator to run.</param>
        /// <param name="configure">Settings for running Yeoman.</param>
        /// <returns>Yeoman runner instance.</returns>
        public IYeomanRunnerCommands RunGenerator(string generator, Action<YeomanRunnerSettings> configure)
        {
            var settings = new YeomanRunnerSettings();
            configure?.Invoke(settings);
            return this.RunGenerator(generator, settings);
        }

        /// <summary>
        /// Runs a Yeoman generator with specified settings.
        /// </summary>
        /// <param name="generator">Name of the generator to run.</param>
        /// <param name="settings">Settings for running Yeoman.</param>
        /// <returns>Yeoman runner instance.</returns>
        public IYeomanRunnerCommands RunGenerator(string generator, YeomanRunnerSettings settings)
        {
            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            if (string.IsNullOrWhiteSpace(generator))
            {
                throw new ArgumentOutOfRangeException(nameof(generator));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var args = new ProcessArgumentBuilder();
            args.Append(generator);
            settings.Evaluate(args);

            var processSettings = new ProcessSettings
            {
                Arguments = args.Render(),

                RedirectStandardError = true
            };

            Run(settings, null, processSettings, process => process.GetStandardError());
            return this;
        }

        #endregion

        #region Tool<YeomanRunnerSettings>

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "Yeoman Runner";
        }

        /// <summary>
        /// Gets the names of the tool executables.
        /// </summary>
        /// <returns>The tool executable names.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "yo.cmd";
            yield return "yo";
        }

        #endregion

        /// <summary>
        /// Gets the working directory from the <see cref="YeomanRunnerSettings"/>.
        /// Defaults to the currently set working directory.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// The working directory for the tool.
        /// </returns>
        protected override DirectoryPath GetWorkingDirectory(YeomanRunnerSettings settings)
        {
            if (this.workingDirectoryPath == null)
            {
                return base.GetWorkingDirectory(settings);
            }

            if (!this.fileSystem.Exist(this.workingDirectoryPath))
            {
                throw new DirectoryNotFoundException(
                    $"Working directory path not found [{this.workingDirectoryPath.FullPath}]");
            }

            return this.workingDirectoryPath;
        }
    }
}
