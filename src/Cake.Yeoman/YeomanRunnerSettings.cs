namespace Cake.Yeoman
{
    using System.Collections.Generic;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// Settings for <see cref="YeomanRunner"/> .
    /// </summary>
    public class YeomanRunnerSettings : ToolSettings
    {
        private readonly List<string> arguments = new List<string>();

        /// <summary>
        /// Gets arguments to pass to the target script.
        /// </summary>
        public IList<string> Arguments => this.arguments;

        /// <summary>
        /// Evaluates the settings and writes them into <paramref name="args"/>.
        /// </summary>
        /// <param name="args">Argument builder to which the settings should be added.</param>
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            foreach (var arg in this.Arguments)
            {
                args.Append(arg);
            }
        }
    }
}
