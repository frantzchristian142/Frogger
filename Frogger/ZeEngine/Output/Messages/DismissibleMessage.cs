using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ZeEngine
{
    public class DismissibleMessage : Message
    {


        public Button2d button;

        public Basic2d bkg;

        public PassObject ConfirmFunc;

        public DismissibleMessage(Vector2 POS, Vector2 DIMS, string MSG, Color COLOR, bool LOCKSCREEN, PassObject CONFIRM)
            : base(POS, DIMS, MSG, COLOR, LOCKSCREEN)
        {
            timer = new McTimer(1000);
            pos = new Vector2(POS.X, POS.Y);
            lockScreen = true;



            bkg = new Basic2d("2d\\Misc\\solid", new Vector2(pos.X, pos.Y), new Vector2(dims.X, dims.Y));

            button = new Button2d("2d\\Misc\\solid", new Vector2(pos.X + 20, pos.Y + 20), new Vector2(80, 40), new Vector2(1, 2), "Fonts\\Arial16", "Ok", new PassObject(CompleteClick), null);

            
            ConfirmFunc = CONFIRM;

        }

        public override void Update()
        {
            button.Update(Vector2.Zero);
        }

        public virtual void CompleteClick(object INFO)
        {
            ConfirmFunc(INFO);

            done = true;
        }

        public override void Draw()
        {
            bkg.Draw(Vector2.Zero);

            textZone.Draw(new Vector2(pos.X - textZone.dims.X/2, pos.Y - 20));

            if(button != null)
            {
                button.Draw(Vector2.Zero);
            }
        }
    }
}
