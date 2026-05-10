#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace ZeEngine
{
    public class ArrowSelector : FormPart
    {
        public int selected;

        public List<Button2d> buttons =  new List<Button2d>();

        public List<FormOption> options = new List<FormOption>();

        public ArrowSelector(Vector2 POS, Vector2 DIMS, string TITLE, PassObject CHANGED)
            : base(POS, DIMS, TITLE, CHANGED)
        {
            title = TITLE;

            selected = 0;

            pos = POS;
            dims = DIMS;


            buttons.Add(new Button2d("2d\\Misc\\ArrowLeft", new Vector2( - dims.X/2 + dims.Y/2, 0), new Vector2(dims.Y, dims.Y), new Vector2(1, 1), "Fonts\\Arial16", "", ArrowLeftClick, null));
            buttons.Add(new Button2d("2d\\Misc\\ArrowRight", new Vector2( dims.X/2 - dims.Y/2, 0), new Vector2(dims.Y, dims.Y), new Vector2(1, 1), "Fonts\\Arial16", "", ArrowRightClick, null));


        }

        public override void Update(Vector2 OFFSET)
        {
            for(int i=0; i<buttons.Count; i++)
            {
                buttons[i].Update(OFFSET + pos);
            }
        }

        public virtual void AddOption(FormOption OPTION)
        {
            options.Add(OPTION);
        }

        public virtual void ArrowLeftClick(object INFO)
        {
            selected--;

            if(selected < 0)
            {
                selected = 0;
            }
        }

        public virtual void ArrowRightClick(object INFO)
        {
            selected++;

            if(selected >= options.Count)
            {
                selected = options.Count-1;
            }
        }

        public override FormOption GetCurrentOption()
        {
            return options[selected];
        }

        public override void LoadData(XElement DATA)
        {
            if(DATA != null)
            {
                if(DATA.Element("selected") != null)
                {
                    selected = Convert.ToInt32(DATA.Element("selected").Value, Globals.culture);
                }
            }
        }

        public override XElement ReturnXML()
        {
            XElement xml = new XElement("Option",
                                new XElement("name", title),
                                new XElement("selected", selected));

            return xml;
        }

        public override void Draw(Vector2 OFFSET, SpriteFont FONT)
        {
            if(options.Count > 0)
            {
                for(int i=0; i<buttons.Count; i++)
                {
                    buttons[i].Draw(OFFSET + pos);
                }

                Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
                Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
                Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
                Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
                Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
                Globals.normalEffect.CurrentTechnique.Passes[0].Apply();

                Vector2 strDims = FONT.MeasureString(options[selected].name);

                Globals.spriteBatch.DrawString(FONT, options[selected].name, OFFSET+pos-strDims/2, Color.White);

                strDims = FONT.MeasureString(title);

                Globals.spriteBatch.DrawString(FONT, title, OFFSET+pos + new Vector2(-10 - dims.X/2 - strDims.X, -strDims.Y/2), Color.White);

            }

            
        }
    }
}
