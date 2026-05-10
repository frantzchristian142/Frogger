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

using ZeEngine;
using System.Net.Http;
#endregion

namespace ZeEngine
{
    public class HttpHandler
    {
        public bool lastPingFailed;
        public bool completed;
        public HttpClient client;
        public HttpHandler()
        {
            lastPingFailed = false;
            completed = false;
            client = new HttpClient();
        }

        public virtual async void MakeRequest(string URL, Dictionary<string, string> DATA, PassObject PROCESSFUNC, PassObject FAILEDFUNC)
        {
            try
            {
                Dictionary<string, string> temp = DATA;
                if (temp == null)
                {
                    temp = new Dictionary<string, string>();
                }

                var data = new FormUrlEncodedContent(temp);
                var response = await client.PostAsync(URL, data);
                var responseString = await response.Content.ReadAsStringAsync();

                PROCESSFUNC(responseString);

                lastPingFailed = false;
                completed = true;
            }

            catch
            {
                if (FAILEDFUNC != null)
                {
                    FAILEDFUNC(null);
                }

                lastPingFailed = true;
                completed = true;
            }
        }
    }
}
