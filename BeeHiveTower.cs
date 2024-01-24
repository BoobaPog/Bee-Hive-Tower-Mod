using BeeHiveTower.Displays.projectile;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BeeHiveTower
{
    public class BeeHive : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;

        public override string BaseTower => TowerType.TackShooter;
        public override string Icon => "BeeHive-Icon";
        public override string Portrait => "BeeHive-Portrait";
        public override int Cost => 800;
        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        // I am still working on the Paragon
        public override ParagonMode ParagonMode => ParagonMode.Base000;

        public override string Description => "Realese furius bees at the Bloons";
        public override string DisplayName => "Bee Hive";
        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {

            var footprint = new CircleFootprintModel("CircleFootprintModel_", 11, false, false, false);
            towerModel.footprint = footprint;
            towerModel.AddBehavior(footprint);

            towerModel.range = 40;

            var attackModel = towerModel.GetAttackModel();
            attackModel.range = towerModel.range;
            attackModel.name = "beeHive_attackModel_";
            var weapon = attackModel.weapons[0];
            weapon.rate = 2.0f;

            var emissionModel = new ArcEmissionModel("ArcEmissionModel_", 8, 0.0f, 360, null, false, false);
            towerModel.GetAttackModel().weapons[0].emission = emissionModel;

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<BeeDisplay>();
            projectile.pierce = 1;
            projectile.GetBehavior<DamageModel>().damage = 1;

            projectile.RemoveBehavior<TravelStraitModel>();
            var TravelModel = new TravelStraitModel("TravelStraitModel_", 80, 2);
            projectile.AddBehavior(TravelModel);

            projectile.AddBehavior(new TrackTargetModel("TrackTargetModel_", 1000f, false, true, 90f, false, 180f, false, true));
        }

        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.BeastHandler).towerIndex + 1;
        }
        public override bool IsValidCrosspath(int[] tiers) =>
            ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);

    }

    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage))]
    internal static class Bloon_Damage
    {
        [HarmonyPrefix]
        private static void Prefix(Bloon __instance, Il2CppAssets.Scripts.Simulation.Towers.Tower tower)
        {
            var towerMod = tower.towerModel;
            int addCash = (new Random()).Next(1, 3);

            if (towerMod.name.Contains("BeeHiveTower-BeeHive") && (addCash == 1))
            {
                if (towerMod.name.EndsWith("3")) { InGame.instance.AddCash(1.0); tower.cashEarned += 1; }
                if (towerMod.name.EndsWith("4")) { InGame.instance.AddCash(2.0); tower.cashEarned += 2; }
                if (towerMod.name.EndsWith("5")) { InGame.instance.AddCash(4.0); tower.cashEarned += 4; }
                if (towerMod.isParagon) { InGame.instance.AddCash(10.0); tower.cashEarned += 10; }
            }
        }
    }
}