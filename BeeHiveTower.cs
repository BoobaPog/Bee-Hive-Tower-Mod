using BeeHiveTower.Displays.projectile;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
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

        /// <summary>
        //public override int TopPathUpgrades => 1;
        // </summary>
        // public override int MiddlePathUpgrades => 5;
        // public override int BottomPathUpgrades => 5;
        public override string Description => "Realese furius bees at the Bloons";

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
            weapon.rate = 1.0f;

            var emissionModel = new ArcEmissionModel("ArcEmissionModel_", 8, 0.0f, 360, null, false, false);
            towerModel.GetAttackModel().weapons[0].emission = emissionModel;

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<BeeDisplay>();
            projectile.pierce = 1;
            projectile.GetBehavior<DamageModel>().damage = 1;

            projectile.RemoveBehavior<TravelStraitModel>();
            var TravelModel = new TravelStraitModel("TravelStraitModel_", 80, 2);
            projectile.AddBehavior(TravelModel);

            projectile.AddBehavior(new TrackTargetModel("TrackTargetModel_", 1000f, false, false, 90f, false, 270f, false, true));

            foreach (var behaviorItem in towerModel.behaviors)
            {
                ModHelper.Msg<BeeHiveTowerMod>(behaviorItem.name);
            }
        }

        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.BeastHandler).towerIndex + 1;
        }
    }
}