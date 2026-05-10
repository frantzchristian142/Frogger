using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeEngine;

namespace ZeEngine
{
    public class Camera2d
    {
        public Matrix transform;
        public Vector2 position;

        public Camera2d()
        {
            
        }

        public void Follow(Vector2 TARGETPOS)
        {
            var offset = Matrix.CreateTranslation(Globals.screenWidth / 2, Globals.screenHeight / 2, 0);
            var position = Matrix.CreateTranslation(-TARGETPOS.X, -TARGETPOS.Y, 0);

            transform = position * offset;
        }
    }
}
