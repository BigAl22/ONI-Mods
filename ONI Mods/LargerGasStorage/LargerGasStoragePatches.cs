using HarmonyLib;
using KMod;
using System;
using System.IO;
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

            


            #region Prefix used to check for the file
            public static void Prefix(ref GameObject go)
            {
                Debug.Log("LargerGasStorage - Prefix: Checking if the file exists");

                Debug.Log("LargerGasStorage - " + System.IO.Directory.GetCurrentDirectory());


                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\BDR\\ONI\\LargerGasStorage";
                Debug.Log("LargerGasStorage - " + path);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                
                path += "\\Values.txt";

                if (!File.Exists(path)) {
                    using (StreamWriter sw = (File.CreateText(path)))
                    {
                        sw.WriteLine("Change the value below to what you desire (in kg, 1 metric ton = 1000kg).");
                        sw.WriteLine("5000");
                    }
                }

            }
            #endregion



            public static void Postfix(ref GameObject go)
            {
                Debug.Log("LargerGasStorage - Postfix: Changing the value");
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\BDR\\ONI\\LargerGasStorage\\Values.txt";

                StreamReader sr = new StreamReader(path);
                string[] lines = new string[2];
                for (int i = 0; i < 2; i++){
                    lines[i] = sr.ReadLine();
                }

                float value = float.Parse(lines[1]);
                Debug.Log("LargerGasStorage - New value is : " + value);

                #region The value displayed in the UI

                go.AddOrGet<Reservoir>();
                Storage defaultStorage = BuildingTemplates.CreateDefaultStorage(go);
                defaultStorage.capacityKg = value;

                #endregion


                #region The value used in the game Logic

                var conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.capacityKG = value; 

                #endregion
            }
        }
    }
}
