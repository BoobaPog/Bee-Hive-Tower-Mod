using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BeeHiveTower.Upgrades.BottomPath
{
    internal class MonkeysDelight : ModUpgrade<BeeHive>
    {

        public override int Path => ModUpgrade.BOTTOM;
        public override int Tier => 5;
        public override int Cost => 25450;

        public override string Description => "Maximizes honey production, range and increese the number of bees to 60. The honey effect is stronger, and bees create temporary honey traps on the track when they die.";
        public override string DisplayName => "Monkeys' Delight";

        public override string Icon => "MonkeysDelight-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {

            var attackModel = tower.GetAttackModel();
            var wep = attackModel.weapons[0];
            var proj = wep.projectile;

            tower.range *= 2.0f;
            attackModel.range = tower.range;

            tower.GetAttackModel().weapons[0].RemoveBehavior<ArcEmissionModel>();

            var emissionModel = new ArcEmissionModel("ArcEmissionModel_", 60, 0.0f, 360, null, false, false);
            tower.GetAttackModel().weapons[0].emission = emissionModel;

            var honeyModel = proj.GetBehavior<SlowModel>();
            honeyModel.Multiplier = 0.3f;
            honeyModel.multiplier = 0.3f;

        }
    }
}