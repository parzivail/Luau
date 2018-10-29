using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;

namespace Luau
{
    class Simulator
    {
        public Simulator(GLControl control)
        {
            control.Resize += GlSimulationOnResize;
            control.Paint += GlSimulationOnPaint;
        }

        private void GlSimulationOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            throw new NotImplementedException();
        }

        private void GlSimulationOnResize(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
