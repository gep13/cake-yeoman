namespace Cake.Yeoman
{
    using System;
    using Core;
    using Core.Annotations;

    /// <summary>
    /// Provides a wrapper around Yeoman functionality within a Cake build script.
    /// </summary>
    [CakeAliasCategory("Node")]
    public static class YeomanAliases
    {
        /// <summary>
        /// Gets a Yeoman runner.
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <returns>Yeoman runner.</returns>
        /// <example>
        /// <para>Run Yeoman generator</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Yeoman-RunGenerator")
        ///     .Does(() =>
        /// {
        ///     Yeoman.RunGenerator("myGenerator");
        /// });
        /// ]]>
        /// </code>
        /// <para>Run Yeoman generator in specific working directory</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Yeoman-WithWorkingDirectory")
        ///     .Does(() =>
        /// {
        ///     Yeoman.WithWorkingDirectory("./working-dir").RunGenerator("myGenerator");
        /// });
        /// ]]>
        /// </code>
        /// <para>Pass parameters to generator</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Yeoman-WithArguments")
        ///     .Does(() =>
        /// {
        ///     Yeoman.RunGenerator("myGenerator", settings => settings.WithArguments("foo"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias]
        public static YeomanRunner Yeoman(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new YeomanRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}
