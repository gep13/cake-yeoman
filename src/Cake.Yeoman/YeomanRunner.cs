namespace Cake.Yeoman
{
    using System;
    using System.Collections.Generic;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// A wrapper around the Yeoman scaffolding tool.
    /// </summary>
    internal class YeomanRunner : Tool<YeomanRunnerSettings>
    {
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
        }

        /// <summary>
        /// Runs a Yeoman generator with specified settings.
        /// </summary>
        /// <param name="generator">Name of the generator to run.</param>
        /// <param name="settings">Settings for running Yeoman.</param>
        public void RunGenerator(string generator, YeomanRunnerSettings settings)
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
                RedirectStandardError = true,
            };

            this.Run(settings, null, processSettings, process => process.GetStandardError());
        }

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
    }
}
