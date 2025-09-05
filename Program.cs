// Program.cs — VIOS.DevSandbox (mdk2pbscript)
using System;
using Sandbox.ModAPI.Ingame;
using VRage.Game;

namespace IngameScript
{
    public partial class Program : MyGridProgram
    {
        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
            Echo("VIOS.DevSandbox: ready");
        }

        public void Save() { }

        public void Main(string argument, UpdateType updateSource)
        {
            try { /* sandbox */ }
            catch (Exception ex) { Echo("VIOS ERROR: " + ex.Message); }
        }
    }
}
