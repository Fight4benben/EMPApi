using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EMSApi.Common
{
    public class DateTimeUtil
    {
        public static DateTime ConvertString2DateTime(string date, string formatPattern)
        {
            DateTime dt;
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = formatPattern;
            return dt = Convert.ToDateTime(date, dtFormat);
        }

        public static DateTime GetLastDayOfMonth(DateTime time)
        {
            return time.AddDays(1 - time.Day).AddMonths(1).AddDays(-1);
        }
    }
}
