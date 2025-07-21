using CSharpWasm;

namespace CSharpWasm.Services;

public interface ICSharpProvider
{
    Task<CSharpCompilationResult> Compile(string source, bool isExecutable);
    Task<IEnumerable<(string Text, string SyntaxHints)>> SyntaxHighlight(string source);
    Task<IEnumerable<(string CompleitionText, CSharpCodeCompletionTags Tags)>> GetCompletions(string source, int position);
}