using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luau
{
    public partial class SimulatorForm : Form
    {
        private readonly LuauForm _parent;
        private Simulator _simulator;

        public SimulatorForm(LuauForm parent)
        {
            _parent = parent;
            InitializeComponent();

            Application.Idle += ApplicationOnIdle;
        }

        private void ApplicationOnIdle(object sender, EventArgs eventArgs)
        {
            _simulator?.Draw();
        }

        private void SimulatorForm_Load(object sender, EventArgs e)
        {
            _simulator = new Simulator(glControl);
            glControl.MakeCurrent();
            _simulator.Resize();
        }

        public void Stop()
        {
            if (InvokeRequired)
                Invoke(new Action(Close));
            else
                Close();
        }

        public Simulator GetSimulator()
        {
            return _simulator;
        }
    }
}
