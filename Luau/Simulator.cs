using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Luau
{
    public class Simulator
    {
        private readonly GLControl _control;
        private readonly List<SimBody> _bodies;

        public Simulator(GLControl control)
        {
            _control = control;
            _bodies = new List<SimBody>();

            control.Resize += GlSimulationOnResize;
            control.Paint += GlSimulationOnPaint;
        }

        private void GlSimulationOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            Render();
        }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (var simBody in _bodies)
                simBody.Render();

            _control.SwapBuffers();
        }

        private void GlSimulationOnResize(object sender, EventArgs eventArgs)
        {
            Resize();
        }

        public void Draw()
        {
            _control.Invalidate();
        }

        public void Reset()
        {
        }

        public void Restart()
        {
            Reset();
            Start();

            Draw();
        }

        private void Start()
        {
        }

        public void Resize()
        {
            GL.Viewport(_control.ClientRectangle);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, _control.ClientRectangle.Right, _control.ClientRectangle.Bottom, 0, 0, 1);

            GL.ClearColor(Color.White);
        }
    }

    internal abstract class SimBody
    {
        public float X { get; set; }
        public float Y { get; set; }

        public abstract void Render();
    }
}
