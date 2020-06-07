using System.ComponentModel;

namespace Common.Models
{
    public enum GeneralStatus
    {
        [Description("Success")]
        Success = 0,
        [Description("Not A Positive Number")]
        NegativeNumber = 1,
        [Description("Not A Number")]
        NotANumber = 2,
        [Description("Unknown Error")]
        UnknownError = 3
    }
}
