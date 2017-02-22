namespace Cake.Yeoman
{
    using Core;
    using Core.IO;
    using Core.Tooling;
    using System.Collections.Generic;

    /// <summary>
    /// Settings for <see cref="YeomanRunner"/> .
    /// </summary>
    public class YeomanRunnerSettings : ToolSettings
    {
        private readonly List<string> _arguments = new List<string>();

        /// <summary>
        /// Arguments to pass to the target script.
        /// </summary>
        public IList<string> Arguments => _arguments;

        /// <summary>
        /// Evaluates the settings and writes them into <paramref name="args"/>.
        /// </summary>
        /// <param name="args">Argument builder to which the settings should be added.</param>
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            foreach (var arg in Arguments)
            {
                args.Append(arg);
            }
        }
    }
}
