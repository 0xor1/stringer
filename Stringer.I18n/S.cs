using Common.Shared;

namespace Stringer.I18n;

public static partial class S
{
    public static readonly Common.Shared.S Inst;

    static S()
    {
        Inst = Strings.FromCommon(Library);
    }
}
