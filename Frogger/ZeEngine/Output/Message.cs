#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#if WINDOWS_PHONE
using Microsoft.Xna.Framework.Input.Touch;
#endif
using Microsoft.Xna.Framework.Media;
#endregion


namespace ZeEngine
{
    public class Message
    {

        public  McTimer timer = new McTimer(3500);
        public Vector2 pos, dims;
        public bool done = false, lockScreen;
        public Color color;
        public TextZone textZone;

        public Message(Vector2 POS, Vector2 DIMS, string MSG, Color COLOR, bool LOCKSCREEN)
        {
            pos = POS;
            dims = DIMS;
            color = COLOR;

            textZone = new TextZone(new Vector2(0, 0), MSG, (int)(DIMS.X * .9f), 22 , "Fonts\\Arial16", COLOR);

            lockScreen = LOCKSCREEN;

        }


        public virtual void Update()
        {
            timer.UpdateTimer();
            if(timer.Test())
            {
                done = true;
            }
        }


        public virtual void Draw()
        {

            textZone.color = color * (float)(.9f * ((float)timer.MSec - (float)timer.Timer)/(float)timer.MSec);
            textZone.Draw( new Vector2(pos.X - textZone.dims.X/2, pos.Y));

        }
    }
}
