﻿namespace BankServices.Utility
{
    public class SD
    {
        public static string AccountHolderAPIBase { get; set; }
        public static string AccountAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
    
