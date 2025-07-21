using Microsoft.CodeAnalysis;
using System.Reflection;

namespace CSharpWasm;

public record CSharpCompilationResult(Assembly? OutputAssembly, bool Success, IEnumerable<Diagnostic> Diagnostics);