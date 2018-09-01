namespace Luau.Lua
{
    internal interface ILuaAddon
    {
        /// <summary>
        /// Gets the name of the addon
        /// </summary>
        /// <returns>The addon's name</returns>
        string GetAddonName();
    }
}