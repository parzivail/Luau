using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Luau.Lua
{
    [MoonSharpUserData]
    internal class LuaWeb : ILuaAddon
    {
        public string GetAddonName()
        {
            return "web";
        }

        /// <summary>
        /// Downloads a string from a web remote
        /// </summary>
        /// <param name="remote">The remote address to GET</param>
        /// <returns>The string returned by the remote</returns>
        public string getString(string remote)
        {
            using (var wc = new WebClient())
                return wc.DownloadString(remote);
        }

        /// <summary>
        /// Downloads binary data from a web remote
        /// </summary>
        /// <param name="remote">The remote address to GET</param>
        /// <returns>The binary data returned by the remote</returns>
        public byte[] getBinary(string remote)
        {
            using (var wc = new WebClient())
                return wc.DownloadData(remote);
        }

        /// <summary>
        /// Saves a remote file locally
        /// </summary>
        /// <param name="remote">The remote address to GET</param>
        /// <param name="filename">The file to save the requested data in</param>
        public void saveFile(string remote, string filename)
        {
            using (var wc = new WebClient())
                wc.DownloadFile(remote, filename);
        }
    }
}
