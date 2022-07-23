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
            public static void Postfix(ref GameObject go)
            {
                
                go.AddOrGet<Reservoir>();
                Storage defaultStorage = BuildingTemplates.CreateDefaultStorage(go);
                defaultStorage.capacityKg = 5000f;
                


                var conduitConsumer = go.AddOrGet<ConduitConsumer>();

                // 5000kg is the same size as the Liquid Reservoir
                conduitConsumer.capacityKG = 5000f;
            }
        }
    }
}
