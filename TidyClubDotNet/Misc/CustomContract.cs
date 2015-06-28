namespace TidyClubDotNet.Misc
{
    using System;
    using System.Diagnostics;

    public class CustomContract
    {
        public static void Requires<TException>(bool predicate, string message) where TException : Exception, new()
        {
            if (!predicate)
            {
                Debug.WriteLine(message);
                throw new TException();
            }
        }
    }  
}
