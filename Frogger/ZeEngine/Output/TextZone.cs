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
    public class TextZone
    {

        public int maxWidth, lineHeight;
        string str;
        public Vector2 pos, dims;
        public Color color;

        public SpriteFont font;

        public List<string> lines = new List<string>();

        public TextZone(Vector2 POS, string STR, int MAXWIDTH, int LINEHEIGHT, string FONT, Color FONTCOLOR)
        {
            pos = POS;
            str = STR;

            maxWidth = MAXWIDTH;
            lineHeight = LINEHEIGHT;
            color = FONTCOLOR;

            font = Globals.content.Load<SpriteFont>(FONT);

            if(str != "")
            {
                ParseLines();
            }
        }

        public string Str
        {
            get
            {
                return str;
            }
            set
            {
                str = value;
                ParseLines();
            }
        }


        public virtual void ParseLines()
        {
            lines.Clear();

            List<string> wordList = new List<string>();
            string tempString="";

            int largestWidth = 0, currentWidth = 0;
            ;
            if(str != "" && str != null)
            {
                wordList = str.Split(' ').ToList<string>();

                for(int i=0;i< wordList.Count;i++)
                {
                    if(tempString != "")
                    {
                        tempString += " ";
                    }

                    currentWidth = (int)(font.MeasureString(tempString + wordList[i]).X);

                    if(currentWidth > largestWidth && currentWidth <= maxWidth)
                    {
                        largestWidth = currentWidth;
                    }

                    if(currentWidth <= maxWidth)
                    {
                        tempString += wordList[i];
                    }
                    else
                    {
                        lines.Add(tempString);

                        tempString = wordList[i];
                    }
                }
                lines.Add(tempString);


                SetDims(largestWidth);
            }
        }

        public virtual void SetDims(int LARGESTWIDTH)
        {
            dims = new Vector2(LARGESTWIDTH, lineHeight * lines.Count);
        }


        public virtual void Draw(Vector2 OFFSET)
        {
            Globals.normalEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.normalEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.normalEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.normalEffect.CurrentTechnique.Passes[0].Apply();



            for(int i=0;i<lines.Count;i++)
            {
                Globals.spriteBatch.DrawString(font, lines[i], OFFSET + new Vector2(pos.X, pos.Y) + new Vector2(0, lineHeight * i), color);
            }
        }
    }
}
