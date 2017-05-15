# Build Script

To use the Cake Yeoman addin in your Cake file simply import it. Then define a task.


:::{.alert .alert-info}
The addin requires Yeoman to already be installed.
You can use the [Cake.Npm Addin](http://cakebuild.net/dsl/npm/) to install Yeoman from your Cake build script.
:::

```csharp
#addin "Cake.Yeoman"

Task("run-generator").Does(() =>
{
    RunYeomanGenerator("my-generator");
}
```