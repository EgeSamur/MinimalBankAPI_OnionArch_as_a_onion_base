namespace MinimalBankAPI_OnionArch.Application.Common.RuleBases
{
    public class BaseException : ApplicationException
    {
        public BaseException() { }
        public BaseException(string message) : base(message) { }
    }
}
