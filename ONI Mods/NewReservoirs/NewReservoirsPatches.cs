using HarmonyLib;
using UnityEngine;

namespace NewReservoirs
{
    public class NewReservoirsPatches
    {
        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class Db_Initialize_Patch
        {

            /*
			 * 
			 */

            public static void Prefix()
            {
                Debug.Log("I execute before Db.Initialize!");
            }

            public static void Postfix()
            {
                Debug.Log("I execute after Db.Initialize!");
            }
        }
    }

    public static class AddBuildingToUI
    {
        /*
         * Add to building 
         * 
         * Add to Tech Tree
         */
    }
}
