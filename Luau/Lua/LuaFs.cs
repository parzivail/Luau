using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Luau.Lua;
using MoonSharp.Interpreter;

namespace Luau
{
    [MoonSharpUserData]
    internal class LuaFs : ILuaAddon
    {
        public string GetAddonName()
        {
            return "fs";
        }

        /// <summary>
        /// Determines the existence of a directory
        /// </summary>
        /// <param name="path">The directory to determine</param>
        /// <returns>True if the directory exists</returns>
        public bool isDir(string path) => Directory.Exists(path);

        /// <summary>
        /// Returns the absolute paths of all the files in a directory
        /// </summary>
        /// <param name="path">The directory to query</param>
        /// <returns>An iterator of the absolute paths</returns>
        public IEnumerable<string> getDirectories(string path)
        {
            var dirs = Directory.GetDirectories(path);
            foreach (var t in dirs)
                yield return t;
        }

        /// <summary>
        /// Returns the absolute paths of all the files in current working directory
        /// </summary>
        /// <returns>An iterator of the absolute paths</returns>
        public IEnumerable<string> getDirectories() => getDirectories(Directory.GetCurrentDirectory());

        /// <summary>
        /// Moves a directory from one location to another
        /// </summary>
        /// <param name="origPath">The original absolute path of the directory</param>
        /// <param name="newPath">The new absolute path of the directory</param>
        public void moveDir(string origPath, string newPath) => Directory.Move(origPath, newPath);

        /// <summary>
        /// Determines the existence of a file
        /// </summary>
        /// <param name="path">The file to determine</param>
        /// <returns>True if the file exists</returns>
        public bool isFile(string path) => File.Exists(path);

        /// <summary>
        /// Returns the absolute filenames of all the files in a directory
        /// </summary>
        /// <param name="path">The directory to query</param>
        /// <returns>An iterator of the absolute filenames</returns>
        public IEnumerable<string> getFiles(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var t in files)
                yield return t;
        }

        /// <summary>
        /// Returns the absolute filenames of all the files in the current working directory
        /// </summary>
        /// <returns>An iterator of the absolute filenames</returns>
        public IEnumerable<string> getFiles() => getFiles(Directory.GetCurrentDirectory());

        /// <summary>
        /// Moves a file from one location to another
        /// </summary>
        /// <param name="origPath">The original absolute filename of the file</param>
        /// <param name="newPath">The new absolute filename of the file</param>
        public void moveFile(string origPath, string newPath) => File.Move(origPath, newPath);

        /// <summary>
        /// Gets the extension of a file
        /// </summary>
        /// <param name="path">The filename to query</param>
        /// <returns>The extension of the file</returns>
        public string getExtension(string path) => Path.GetExtension(path);

        /// <summary>
        /// Gets the name of a file
        /// </summary>
        /// <param name="path">The filename to query</param>
        /// <returns>The name of the file</returns>
        public string getFileName(string path) => Path.GetFileName(path);

        /// <summary>
        /// Gets the name of a file without the extension
        /// </summary>
        /// <param name="path">The filename to query</param>
        /// <returns>The name of the file without the extension</returns>
        public string getFileNameWithoutExtension(string path) => Path.GetFileNameWithoutExtension(path);

        /// <summary>
        /// Gets the name of a directory
        /// </summary>
        /// <param name="path">The path to query</param>
        /// <returns>The name of the directory</returns>
        public string getDirName(string path) => Path.GetDirectoryName(path);

        /// <summary>
        /// Gets the creation timestamp of a file
        /// </summary>
        /// <param name="path">The filename to query</param>
        /// <returns>The timestamp of the file</returns>
        public double getCreationTime(string path) => File.GetCreationTime(path).ConvertToUnixTimestamp();

        /// <summary>
        /// Gets the modified timestamp of a file
        /// </summary>
        /// <param name="path">The filename to query</param>
        /// <returns>The timestamp of the file</returns>
        public double getModifiedTime(string path) => File.GetLastWriteTime(path).ConvertToUnixTimestamp();
    }
}
