using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Drawing;

namespace Template
{
    class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        const float rotation_speed = 180.0f;
        float angle;
        private readonly Axes ax;
        private Cub cub;
        double miscareX=0;
        double miscareY=0;
        double miscareZ = 0;
        // DEFAULTS
        private readonly Color DEFAULT_BKG_COLOR = Color.FromArgb(49, 50, 51);
        private Vector3 eye = new Vector3(100, 50, 50);
        private Vector3 target = new Vector3(0, 0, 0);
        private Vector3 up_vector = new Vector3(0, 1, 0);

        public Window3D() : base(1280, 768, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            // inits
            ax = new Axes();
            cub = new Cub();
            cub.CitireFisier("input.txt");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // set background
            GL.ClearColor(DEFAULT_BKG_COLOR);

            // set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 512);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // set the eye
            Matrix4 camera = Matrix4.LookAt(eye, target, up_vector);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // LOGIC CODE
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }
            if (currentKeyboard[Key.T])
            {
                cub.Show();
            }
            if (currentKeyboard[Key.A])
            {
                miscareX--;
            }
            if (currentKeyboard[Key.D])
            {
                miscareX++;
            }
            if (currentKeyboard[Key.W])
            {
                miscareY++;
            }
            if (currentKeyboard[Key.S])
            {
                miscareY--;
            }
            if (currentKeyboard[Key.Left])
            {
                miscareZ++;
            }
            if (currentKeyboard[Key.Right])
            {
                miscareZ--;
            }
            previousKeyboard = currentKeyboard;
            previousMouse = currentMouse;
            // END logic code
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // RENDER CODE
            ax.Draw();
            GL.PushMatrix();
            angle += rotation_speed * (float)e.Time;
            GL.Rotate(angle, 10.1f, 0.0f, .0f);
            GL.Translate(miscareX, miscareY, miscareZ);
            cub.DrawFisier();
            GL.PopMatrix();
            


            // END render code

            SwapBuffers();
        }
    }
}
