using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luau
{
    static class Extensions
    {

        /// <summary>
        /// Converts a DateTime to a unix timestamp
        /// </summary>
        /// <param name="date">The date to convert</param>
        /// <returns>The unix timestamp</returns>
        public static double ConvertToUnixTimestamp(this DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}
