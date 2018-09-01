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
        /// Appends colored text to a Rich Text Box
        /// </summary>
        /// <param name="box">The text box to append to</param>
        /// <param name="text">The text to append</param>
        /// <param name="color">The color to append it in</param>
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

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
