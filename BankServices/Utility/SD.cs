namespace BankServices.Utility
{
    public class SD
    {
        public static string AccountAPIBase { get; set; }
        public static string TransactionAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }

        public const string TokenCookie = "JWTToken";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
    
