using System.Collections.Frozen;
using Microsoft.CodeAnalysis.Tags;

namespace CSharpWasm;

[Flags]
public enum CSharpCodeCompletionTags : long
{
    Public = 1L << 0,
    Protected = 1L << 1,
    Private = 1L << 2,
    Internal = 1L << 3,
    File = 1L << 4,
    Project = 1L << 5,
    Folder = 1L << 6,
    Assembly = 1L << 7,
    Class = 1L << 8,
    Constant = 1L << 9,
    Delegate = 1L << 10,
    Enum = 1L << 11,
    EnumMember = 1L << 12,
    Event = 1L << 13,
    ExtensionMethod = 1L << 14,
    Field = 1L << 15,
    Interface = 1L << 16,
    Intrinsic = 1L << 17,
    Keyword = 1L << 18,
    Label = 1L << 19,
    Local = 1L << 20,
    Namespace = 1L << 21,
    Method = 1L << 22,
    Module = 1L << 23,
    Operator = 1L << 24,
    Parameter = 1L << 25,
    Property = 1L << 26,
    RangeVariable = 1L << 27,
    Reference = 1L << 28,
    Structure = 1L << 29,
    TypeParameter = 1L << 30,
    Snippet = 1L << 31,
    Error = 1L << 32,
    Warning = 1L << 33,
}

public static class CSharpCodeCompletionUtils
{
    public static CSharpCodeCompletionTags GetTagFromString(string tag) => s_lookup.GetValueOrDefault(tag, default);

    private static readonly FrozenDictionary<string, CSharpCodeCompletionTags> s_lookup = new Dictionary<string, CSharpCodeCompletionTags>()
    {
        { WellKnownTags.Public , CSharpCodeCompletionTags.Public },
        { WellKnownTags.Protected , CSharpCodeCompletionTags.Protected },
        { WellKnownTags.Private , CSharpCodeCompletionTags.Private },
        { WellKnownTags.Internal , CSharpCodeCompletionTags.Internal },
        { WellKnownTags.File , CSharpCodeCompletionTags.File },
        { WellKnownTags.Project , CSharpCodeCompletionTags.Project },
        { WellKnownTags.Folder , CSharpCodeCompletionTags.Folder },
        { WellKnownTags.Assembly , CSharpCodeCompletionTags.Assembly },
        { WellKnownTags.Class , CSharpCodeCompletionTags.Class },
        { WellKnownTags.Constant , CSharpCodeCompletionTags.Constant },
        { WellKnownTags.Delegate , CSharpCodeCompletionTags.Delegate },
        { WellKnownTags.Enum , CSharpCodeCompletionTags.Enum },
        { WellKnownTags.EnumMember , CSharpCodeCompletionTags.EnumMember },
        { WellKnownTags.Event , CSharpCodeCompletionTags.Event },
        { WellKnownTags.ExtensionMethod , CSharpCodeCompletionTags.ExtensionMethod },
        { WellKnownTags.Field , CSharpCodeCompletionTags.Field },
        { WellKnownTags.Interface , CSharpCodeCompletionTags.Interface },
        { WellKnownTags.Intrinsic , CSharpCodeCompletionTags.Intrinsic },
        { WellKnownTags.Keyword , CSharpCodeCompletionTags.Keyword },
        { WellKnownTags.Label , CSharpCodeCompletionTags.Label },
        { WellKnownTags.Local , CSharpCodeCompletionTags.Local },
        { WellKnownTags.Namespace , CSharpCodeCompletionTags.Namespace },
        { WellKnownTags.Method , CSharpCodeCompletionTags.Method },
        { WellKnownTags.Module , CSharpCodeCompletionTags.Module },
        { WellKnownTags.Operator , CSharpCodeCompletionTags.Operator },
        { WellKnownTags.Parameter , CSharpCodeCompletionTags.Parameter },
        { WellKnownTags.Property , CSharpCodeCompletionTags.Property },
        { WellKnownTags.RangeVariable , CSharpCodeCompletionTags.RangeVariable },
        { WellKnownTags.Reference , CSharpCodeCompletionTags.Reference },
        { WellKnownTags.Structure , CSharpCodeCompletionTags.Structure },
        { WellKnownTags.TypeParameter , CSharpCodeCompletionTags.TypeParameter },
        { WellKnownTags.Snippet , CSharpCodeCompletionTags.Snippet },
        { WellKnownTags.Error , CSharpCodeCompletionTags.Error },
        { WellKnownTags.Warning , CSharpCodeCompletionTags.Warning },
    }.ToFrozenDictionary();
}