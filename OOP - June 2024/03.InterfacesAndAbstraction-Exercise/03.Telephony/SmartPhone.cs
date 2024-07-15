namespace Telephony
{
    internal class SmartPhone : ICalleble , IBrowsable
    {
        public string Browse(string url) => $"Browsing: {url}!";

        public string Call(string number) => $"Calling... {number}";
    }
}
