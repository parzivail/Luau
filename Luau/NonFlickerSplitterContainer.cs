using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luau
{
    public partial class NonFlickerSplitContainer : SplitContainer
    {
        public NonFlickerSplitContainer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            var objMethodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);

            var objArgs = new object[] { ControlStyles.AllPaintingInWmPaint |
                                              ControlStyles.UserPaint |
                                              ControlStyles.OptimizedDoubleBuffer, true };

            objMethodInfo?.Invoke(Panel1, objArgs);
            objMethodInfo?.Invoke(Panel2, objArgs);
        }
    }
}
