namespace Cake.Yeoman
{
    using Core;
    using Core.Annotations;
    using System;

    /// <summary>
    /// Provides a wrapper around Yeoman functionality within a Cake build script.
    /// </summary>
    [CakeAliasCategory("Yeoman")]
    public static class YeomanAliases
    {
        /// <summary>
        /// Runs a Yeoman generator with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="generator">Name of the generator to run.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     RunYeomanGenerator("myGenerator");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void RunYeomanGenerator(this ICakeContext context, string generator)
        {
            context.RunYeomanGenerator(generator, new YeomanRunnerSettings());
        }

        /// <summary>
        /// Runs a Yeoman generator with specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="generator">Name of the generator to run.</param>
        /// <param name="settings">Settings for running Yeoman.</param>
        /// <example>
        /// <para>Define working directory</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new YeomanRunnerSettings 
        ///         {
        ///            WorkingDirectory = "c:\myproject"
        ///         };
        ///     RunYeomanGenerator("myGenerator", settings);
        /// ]]>
        /// </code>
        /// <para>Pass arguments to generator</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new YeomanRunnerSettings 
        ///         {
        ///             Arguments = new List<string>("Foo")
        ///         };
        ///     RunYeomanGenerator("myGenerator", settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void RunYeomanGenerator(this ICakeContext context, string generator, YeomanRunnerSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var packer = new YeomanRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            packer.RunGenerator(generator, settings);
        }

    }
}
