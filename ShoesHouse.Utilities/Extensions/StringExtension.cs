using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Utilities.Extensions
{
    public static class StringExtension
    {
        public static string ToVND(this decimal number)
        {
            var culture = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            return String.Format(culture, "{0:N0}", number) + " đ";
        }
    }
}
