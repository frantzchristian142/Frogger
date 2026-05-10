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
    public class OptionsMenu
    {

        Button2d exitBtn;

        public List<FormPart> formParts = new List<FormPart>();

        SpriteFont font;

        PassObject UpdateOptions;

        public OptionsMenu(PassObject UPDATEOPTIONS)
        {
            UpdateOptions = UPDATEOPTIONS;

            exitBtn = new Button2d("2d\\Misc\\SimpleBtn", new Vector2(Globals.screenWidth/2, Globals.screenHeight - 100), new Vector2(96, 32), new Vector2(1, 1), "Fonts\\Arial16", "Exit", ExitClick, null);

            ArrowSelector tempSelector = null;
            
            //new ArrowSelector(new Vector2(Globals.screenWidth/2, 300), new Vector2(128, 32), "Full Screen", null);
            //tempSelector.AddOption(new FormOption("No", 0));
            //tempSelector.AddOption(new FormOption("Yes", 1));
            formParts.Add(new CheckBox(new Vector2(Globals.screenWidth/2, 300), new Vector2(128, 32), "Full Screen", null));



            tempSelector = new ArrowSelector(new Vector2(Globals.screenWidth/2, 400), new Vector2(128, 32), "Music Volume", null);
            for(int i=0; i<31; i++)
            {
                tempSelector.AddOption(new FormOption(""+i, i));
            }
            tempSelector.selected = 15;
            formParts.Add(tempSelector);

            tempSelector = new ArrowSelector(new Vector2(Globals.screenWidth/2, 500), new Vector2(128, 32), "Sound Effects Volume", null);
            for(int i=0;i<31;i++)
            {
                tempSelector.AddOption(new FormOption(""+i, i));
            }
            tempSelector.selected = 15;
            formParts.Add(tempSelector);

            font = Globals.content.Load<SpriteFont>("Fonts\\Arial16");

            XDocument xml = Globals.save.GetFile("XML\\options.xml");


            LoadData(xml);
            
        }

        public virtual void Update()
        {
            for(int i=0; i<formParts.Count; i++)
            {
                formParts[i].Update(Vector2.Zero);
            }

            exitBtn.Update(Vector2.Zero);
        }

        public virtual void ExitClick(object INFO)
        {
            SaveOptions();

            Globals.gameState = 0;
        }

        public virtual FormOption GetOptionValue(string NAME)
        {
            for(int i=0; i<formParts.Count; i++)
            {
                if(formParts[i].title == NAME)
                {
                    return formParts[i].GetCurrentOption();
                }
            }

            return null;
        }

        public virtual void LoadData(XDocument DATA)
        {
            if(DATA != null)
            {
                List<string> allOptions = new List<string>();
                for(int i=0; i<formParts.Count; i++)
                {
                    allOptions.Add(formParts[i].title);
                }

                for(int i=0; i<allOptions.Count; i++)
                {
                    List<XElement> optionList = (from t in DATA.Element("Root").Element("Options").Descendants("Option")
                                                    where t.Element("name").Value == allOptions[i]
                                                    select t).ToList<XElement>();

                    if(optionList.Count > 0)
                    {
                        for(int j=0;j<formParts.Count;j++)
                        {
                            if(formParts[j].title == allOptions[i])
                            {
                                formParts[j].LoadData(optionList[0]);
                            }
                        }
                    }
                }
            }
        }

        public virtual void SaveOptions()
        {
            XDocument xml = new XDocument(new XElement("Root",
                                new XElement("Options", "")));

            for(int i=0;i<formParts.Count;i++)
            {
                xml.Element("Root").Element("Options").Add(formParts[i].ReturnXML());
            }

            Globals.save.HandleSaveFormates(xml, "options.xml");

            UpdateOptions(null);
        }

        public virtual void Draw()
        {
            Vector2 strDims = font.MeasureString("Options");

            Globals.spriteBatch.DrawString(font, "Options", new Vector2(Globals.screenWidth/2 - strDims.X/2, 80), Color.White);

            for(int i=0;i<formParts.Count;i++)
            {
                formParts[i].Draw(Vector2.Zero, font);
            }

            exitBtn.Draw(Vector2.Zero);
        }
    }
}
