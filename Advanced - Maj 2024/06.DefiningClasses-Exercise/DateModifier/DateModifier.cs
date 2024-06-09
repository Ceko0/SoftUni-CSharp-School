namespace DateModifier
{
    public class DateModifier
    {
        public int CalculateDifference(string date1Str, string date2Str)
        {           
            DateTime date1 = DateTime.ParseExact(date1Str, "yyyy MM dd", null);
            DateTime date2 = DateTime.ParseExact(date2Str, "yyyy MM dd", null);
                        
            int difference = Math.Abs((date2 - date1).Days);

            return difference;
        }
    }
}
