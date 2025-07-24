
using System.Net.Http;

namespace CSharpWasm.Services;

public class CSharpProviderWorker
{
    private readonly ICSharpProvider _cSharpProvider;
    private readonly HttpClient _httpClient;
    public CSharpProviderWorker(HttpClient httpClient)
    {
        _httpClient = httpClient;

        ServiceCollection services = new ServiceCollection();
        services.AddSingleton(httpClient);
        services.AddCSharpCompiler();

        _cSharpProvider = services.BuildServiceProvider().GetRequiredService<ICSharpProvider>();
    }

    public async Task<IEnumerable<(string Text, string SyntaxHints)>>  SyntaxHighlight(string rawText, string baseAddress, int start, int length)
    {
        _httpClient.BaseAddress ??= new Uri(baseAddress);
        return await _cSharpProvider.SyntaxHighlight(rawText, start, length);
    }
}