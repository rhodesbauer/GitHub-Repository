using System;

namespace Factory.Interfaces
{
    public interface IEntity:IDisposable
    {
        DateTime dtCreation { get; set; }
        DateTime? dtLastChange { get; set; }
        string userIDCreation { get; set; }
        string userIDLastChange { get; set; }
    }
}