using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luau.Sim;
using NanoVGDotNet;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Luau
{
    class SimulatorWindow : GameWindow
    {
        private bool _shouldDie;

        private NVGcontext _nvg = new NVGcontext();
        private KeyboardState _keyboard;
        private MouseState _mouse;
        private Simulator _simulator;

        public SimulatorWindow() : base(800, 600, new GraphicsMode(new ColorFormat(32), 24, 8, 0))
        {
            // Wire up window
            Load += LoadHandler;
            Closing += CloseHandler;
            Resize += ResizeHandler;
            UpdateFrame += UpdateHandler;
            RenderFrame += RenderHandler;
        }
        
        private void LoadHandler(object sender, EventArgs e)
        {
            // Set up caps
            GL.Disable(EnableCap.DepthTest);
            GL.Enable(EnableCap.RescaleNormal);

            // Set up blending
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            // Set background color
            GL.ClearColor(Color.White);

            // Init keyboard to ensure first frame won't NPE
            _keyboard = Keyboard.GetState();
            _mouse = Mouse.GetState();

            GlNanoVG.nvgCreateGL(ref _nvg, (int)NvgCreateFlags.AntiAlias | (int)NvgCreateFlags.StencilStrokes);
            NanoVG.nvgStrokeWidth(_nvg, 1);
            NanoVG.nvgStrokeColor(_nvg, NanoVG.nvgRGBA(0, 0, 0, 255));

            _simulator = new Simulator();
        }

        private void CloseHandler(object sender, CancelEventArgs e)
        {
        }

        public void Kill()
        {
            _shouldDie = true;
        }

        private void ResizeHandler(object sender, EventArgs e)
        {
            GL.Viewport(ClientRectangle);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        private void UpdateHandler(object sender, FrameEventArgs e)
        {
            if (_shouldDie)
                Exit();

            // Grab the new keyboard state
            _keyboard = Keyboard.GetState();
            _mouse = Mouse.GetState();
        }

        private void RenderHandler(object sender, FrameEventArgs e)
        {
            // Reset the view
            GL.Clear(ClearBufferMask.ColorBufferBit |
                     ClearBufferMask.DepthBufferBit |
                     ClearBufferMask.StencilBufferBit);

            NanoVG.nvgBeginFrame(_nvg, Width, Height, 1);
            _simulator.Render(_nvg);
            NanoVG.nvgEndFrame(_nvg);

            // Swap the graphics buffer
            SwapBuffers();
        }

        public Simulator GetSimulator()
        {
            return _simulator;
        }
    }
}