using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CSharpWasm;

public class CSharpProviderOptions
{
    public List<string> Libraries { get; set; } = 
    [
        "/lib/mscorlib.dll",
        "/lib/System.dll",
        "/lib/System.Console.dll",
        "/lib/System.Buffers.dll",
        "/lib/System.Core.dll",
        "/lib/System.Collections.dll",
        "/lib/System.Runtime.dll",
        "/lib/System.Linq.dll",  
        "/lib/System.Private.CoreLib.dll",
        "/lib/System.Numerics.dll",
        "/lib/System.Text.Encoding.dll",
    ];
    
    public IReadOnlyList<Type> SourceGenerators => _incrementalSourceGenrators;

    private List<Type> _incrementalSourceGenrators = [];

    public CSharpCompilationOptions CSharpCompilationOptions { get; set; } = new(
        outputKind: OutputKind.ConsoleApplication,
        usings: ["System", "System.Text", "System.Collections.Generic", "System.Linq", "System.Threading", "System.Threading.Tasks"],
        concurrentBuild: false
    );

    public CSharpParseOptions CSharpParseOptions = new(languageVersion: LanguageVersion.Latest);

    public CSharpProviderOptions AddLibrary(string name)
    {
        Libraries.Add($"/lib/{name}.dll");
        return this;
    }

    public CSharpProviderOptions AddIncrementalSourceGenerator<T>()
        where T : IIncrementalGenerator
    {
        _incrementalSourceGenrators.Add(typeof(T));
        return this;
    }
}