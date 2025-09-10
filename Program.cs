// Program.cs — VIOS.DevSandbox (mdk2pbscript)
// Path: Scripts/VIOS.DevSandbox/Program.cs
// Guardrails: PB scripts MUST inherit MyGridProgram; uses the ScreenMgr mixin APIs.


using Sandbox.ModAPI.Ingame;
using System;
using VRage.Game;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript
{
    public partial class Program : MyGridProgram
    {
        // Reuse mixin methods/fields compiled via partial Program

        IMyTextSurface _pbLcd;

        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;

            // Setup default breadcrumb surface to PB LCD 0
            _pbLcd = Me.GetSurface(0);
            ScreenSetBreadcrumbSurface(_pbLcd);

            // Seed demo stack
            ScreenReset();
            ScreenPush(1, "Main");
            ScreenPush(2, "Power");
        }

        public void Save() { }

        public void Main(string argument, UpdateType updateSource)
        {
            try
            {
            // Very small command router (no allocations):
            if (!string.IsNullOrEmpty(argument))
            {
                if (argument == "push") { ScreenPush(ScreenCurrentId() + 1, "Page" + (ScreenCurrentId() + 1)); }
                else if (argument == "pop") { ScreenPop(); }
                else if (argument == "reset") { ScreenReset(); }
            }

            // Render breadcrumb every tick
            ScreenRenderBreadcrumb();
            }
            catch (Exception ex) { Echo("VIOS ERROR: " + ex.Message); }
        }
    }
}
