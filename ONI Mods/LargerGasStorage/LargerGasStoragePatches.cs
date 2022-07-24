using HarmonyLib;
using UnityEngine;

namespace LargerGasStorage
{
    public class LargerGasStoragePatches
    {
        [HarmonyPatch(typeof(GasReservoirConfig))]
        [HarmonyPatch(nameof(GasReservoirConfig.ConfigureBuildingTemplate))]
        public class GasReservoirConfig_ConfigureBuildingTemplate_Patch
        {

            /*
             * By default the gas reservoir stores 150kg, while the liquid reservoir stores 5000kg
             * 
             */

            public static void Postfix(ref GameObject go)
            { 
                #region The value displayed in the UI

                go.AddOrGet<Reservoir>();
                Storage defaultStorage = BuildingTemplates.CreateDefaultStorage(go);
                defaultStorage.capacityKg = 5000f;

                #endregion


                #region The value used in the game Logic

                var conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.capacityKG = 5000f; 

                #endregion
            }
        }
    }
}
