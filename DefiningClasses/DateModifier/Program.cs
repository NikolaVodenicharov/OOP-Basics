namespace DateModifier
{
    using System;
    using System.Globalization;

    class Program
    {
        static void Main(string[] args)
        {
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();

            var days = DateModifi.CalculateDates(date1, date2);
            Console.WriteLine(days);
        }
    }

    public class DateModifi
    {
        public static int CalculateDates(string date1, string date2)
        {
            DateTime firstDate = DateTime.ParseExact(date1, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(date2, "yyyy MM dd", CultureInfo.InvariantCulture);
            TimeSpan time = firstDate.Subtract(secondDate);
            int days = (int)Math.Abs(time.TotalDays);

            return days;
        }
    }
}
