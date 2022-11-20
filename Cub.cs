using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    internal class Cub
    {
        private bool myVisibility;
        private int[,] coordonate=new int[32,3];
        public Cub()
        {
            myVisibility = false;

        }
        public void Draw()
        {
            if (myVisibility)
            {
                GL.LineWidth(1.0f);
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.Brown);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, 20);
                GL.Vertex3(20, 0, 20);
                GL.Vertex3(20, 0, 0);
                GL.Color3(Color.Violet);
                GL.Vertex3(20, 20, 0);
                GL.Vertex3(0, 20, 0);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(20,0,0);
                GL.Color3(Color.Gray);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, 20);
                GL.Vertex3(0, 20, 20);
                GL.Vertex3(0, 20, 0);
                GL.Color3(Color.Blue);
                GL.Vertex3(0, 20, 20);
                GL.Vertex3(20, 20, 20);
                GL.Vertex3(20, 0, 20);
                GL.Vertex3(0, 0, 20);
                GL.Color3(Color.Green);
                GL.Vertex3(20,20,20);
                GL.Vertex3(20,20,0);
                GL.Vertex3(20, 0, 0);
                GL.Vertex3(20, 0, 20);
                GL.Color3(Color.Red);
                GL.Vertex3(20,20,20);
                GL.Vertex3(0,20,20);
                GL.Vertex3(0,20,0);
                GL.Vertex3(20,20,0);
                GL.End();
            }
        }
        public void Show()
        {
            myVisibility = true;
        }

        /// <summary>
        /// Sets visibility of the object OFF.
        /// </summary>
        public void Hide()
        {
            myVisibility = false;
        }

        /// <summary>
        /// Toggles the myVisibility of the object. Once triggered, the attribute is applied automatically on drawing.
        /// </summary>
        public void ToggleVisibility()
        {
            myVisibility = !myVisibility;
        }
        public void CitireFisier(string numeFisier)
        {
            int count = 0;
            string[] lines = File.ReadAllLines(numeFisier);
            foreach (string line in lines)
            {
                string[] continut=line.Split(' ');
                for(int i = 0; i < continut.Length; i++)
                {
                    coordonate[count,i] = Int32.Parse(continut[i]);
                }
                count++;
            }
        }
        public void DrawFisier()
        {
            GL.Begin(PrimitiveType.Quads);
            for(int i=0;i<coordonate.GetLength(0);i++)
            {
                GL.Vertex3(coordonate[i,0], coordonate[i,1], coordonate[i,2]);
            }
            GL.End();
        }
        public void MutareX(double factor)
        {
            GL.Translate(factor, 0, 0);
        }
        public void MutareY(double factor)
        {
            GL.Translate(0,factor, 0);
        }
        public void MutareZ(double factor)
        {
            GL.Translate(0,0,factor);
        }
    }
}
