using STRINGS;
using TUNING;
using UnityEngine;
using System.Collections.Generic;
using PeterHan.PLib.Options;
using NewReservoirs.Settings;

namespace NewReservoirs
{
    public class NewLiquidReservoirConfig : IBuildingConfig
    {
        public const string ID = "AdvancedLiquidReservoir";
        public const ConduitType CONDUIT_TYPE = ConduitType.Liquid;
        private const int WIDTH = 3;
        private const int HEIGHT = 3;
        public static readonly List<Storage.StoredItemModifier> AdvancedLiquidReservoirModifiers;

        

        static NewLiquidReservoirConfig()
        {
            List<Storage.StoredItemModifier> modifiers = new List<Storage.StoredItemModifier>();
            modifiers.Add(Storage.StoredItemModifier.Hide);
            modifiers.Add(Storage.StoredItemModifier.Seal);
            modifiers.Add(Storage.StoredItemModifier.Insulate);
            AdvancedLiquidReservoirModifiers = modifiers;
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues decor = BuildingSchemes.Decor.PENALTY.AdvLiqResDECORPenalty;
            EffectorValues noise = BuildingSchemes.NOISY.TIER0;
            string[] materials = MATERIALS.REFINED_METALS;

            BuildingDef buildingDef = BuildingTemplates.CreateStandardBuildingDef("Advanced Liquid Reservoir", WIDTH, HEIGHT, /* animation */, 200, 240f, 1000f, materials, 1000f, BuildLocationRule.OnFloor, decor, noise);

            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.OutputConduitType = ConduitType.Liquid;
            buildingDef.Floodable = false;
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.UtilityInputOffset = new CellOffset(1, 2);
            buildingDef.UtilityOutputOffset = new CellOffset(0, 0);
            buildingDef.LogicOutputPorts = new List<LogicPorts.Port>()
            {
              LogicPorts.Port.OutputPort(SmartReservoir.PORT_ID, new CellOffset(0, 0), (string) STRINGS.BUILDINGS.PREFABS.SMARTRESERVOIR.LOGIC_PORT, (string) STRINGS.BUILDINGS.PREFABS.SMARTRESERVOIR.LOGIC_PORT_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.SMARTRESERVOIR.LOGIC_PORT_INACTIVE)
            };
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, "LiquidReservoir");
            return buildingDef;

        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<UserNameable>();
            go.AddOrGet<Reservoir>();

            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.GASES;
            storage.capacityKg = 7500f;
            storage.SetDefaultStoredItemModifiers(AdvancedLiquidReservoirModifiers);
            storage.showCapacityStatusItem = true;
            storage.showCapacityAsMainStatus = true;

            go.AddOrGet<SmartReservoir>();

            ConduitConsumer consumer = go.AddOrGet<ConduitConsumer>();
            consumer.conduitType = ConduitType.Gas;
            consumer.ignoreMinMassCheck = true;
            consumer.forceAlwaysSatisfied = true;
            consumer.alwaysConsume = true;
            consumer.capacityKG = storage.capacityKg;
            ConduitDispenser dispenser = go.AddOrGet<ConduitDispenser>();
            dispenser.conduitType = ConduitType.Gas;
            dispenser.elementFilter = null;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {

        }

    }
}
