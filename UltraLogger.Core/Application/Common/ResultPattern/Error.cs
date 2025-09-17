namespace UltraLogger.Core.Application.Common.ResultPattern
{
    public class Error
    {
        public static Error None = new Error(string.Empty, string.Empty);

        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; }

        public string Description { get; }
    }
}
