using HarmonyLib;
using KMod;
using System.Collections.Generic;


namespace LargerGasStorage
{
    public class LargerGasStorageMod : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
        }
        /*
        public override void OnAllModsLoaded(Harmony harmony, IReadOnlyList<Mod> mods)
        {
            foreach (var mod in mods)
            {
                // do some stuff
                Debug.Log("Found mod: " + mod.title + " with static ID of (" + mod.staticID + ")/n- " + mod.description + "\nMore information: " + mod.packagedModInfo);
            }
        }
        */

    }
}
