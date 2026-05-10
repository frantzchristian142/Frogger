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
    public class SoundControl
    {

        public SoundItem BkgMusic;

        public List<SoundItem> sounds = new List<SoundItem>();

        public SoundControl(string MUSICPATH)
        {

            
            if(MUSICPATH != "")
            {
                ChangeMusic(MUSICPATH);
            }
        }

        public virtual void Update()
        {

        }

        public virtual void AddSound(string NAME, string SOUNDPATH, float VOLUME)
        {
            sounds.Add(new SoundItem(NAME, SOUNDPATH, VOLUME));
        }

        public virtual void AdjustMusicVolume(float PECERCENT)
        {
            BkgMusic.instance.Volume = PECERCENT * BkgMusic.volume;
        }

        public virtual void ChangeMusic(string MUSICPATH)
        {
            BkgMusic = new SoundItem("Bkg Music", MUSICPATH, .25f);


            FormOption musicVolume = Globals.optionsMenu.GetOptionValue("Music Volume");
            float musicVolumePercent = 1.0f;
            if(musicVolume != null)
            {
                musicVolumePercent = (float)Convert.ToDecimal(musicVolume.value, Globals.culture)/30.0f;
            }

            BkgMusic.instance.Volume = musicVolumePercent * BkgMusic.volume;
            BkgMusic.instance.IsLooped = true;
            BkgMusic.instance.Play();
        }


        public virtual void PlaySound(string NAME)
        {
            for(int i=0;i<sounds.Count;i++)
            {
                if(sounds[i].name == NAME)
                {
                    sounds[i].CreateInstance();
                    RunSound(sounds[i].sound, sounds[i].instance, sounds[i].volume);
                }
            }
        }

        public void RunSound(SoundEffect SOUND, SoundEffectInstance INSANCE, float VOLUME)
        {

            FormOption soundVolume = Globals.optionsMenu.GetOptionValue("Sound Volume");
            float soundVolumePercent = 1.0f;
            if(soundVolume != null)
            {
                soundVolumePercent = (float)Convert.ToDecimal(soundVolume.value, Globals.culture)/30.0f;
            }

            INSANCE.Volume = soundVolumePercent * VOLUME ;
            INSANCE.Play();
            
        }
    }
}
