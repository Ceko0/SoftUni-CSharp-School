namespace Telephony
{
    public class StationaryPhone : ICalleble
    {
        public string Call(string number) => $"Dialing... {number}";
        
    }
}
