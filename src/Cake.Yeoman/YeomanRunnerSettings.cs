namespace Cake.Yeoman
{
    using Core;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Settings for <see cref="YeomanRunner"/> .
    /// </summary>
    public class YeomanRunnerSettings : ToolSettings
    {
        /// <summary>
        /// Argument string to pass to Yeoman.
        /// </summary>
        public string Arguments { get; private set; }

        /// <summary>
        /// The argument string to pass to Yeoman.
        /// </summary>
        /// <param name="arguments">Arguments to pass to Yeoman.</param>
        /// <returns>Setting instance.</returns>
        public YeomanRunnerSettings WithArguments(string arguments)
        {
            Arguments = arguments;
            return this;
        }

        /// <summary>
        /// Evaluates the settings and writes them into <paramref name="args"/>.
        /// </summary>
        /// <param name="args">Argument builder to which the settings should be added.</param>
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(Arguments))
            {
                args.Append(Arguments);
            }
        }
    }
}
