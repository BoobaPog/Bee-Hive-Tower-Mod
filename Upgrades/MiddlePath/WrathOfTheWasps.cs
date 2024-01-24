using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BeeHiveTower.Upgrades.MiddlePath
{
    public class WrathOfTheWasps : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.MIDDLE;
        public override int Tier => 5;
        public override int Cost => 35000;

        public override string Description => "Unleashes devastating wasp swarms that can pierce through multiple bloons and stunning larger bloons ones. \r\n\nAbility: All bee hive tower’s swarms become extremely agile, move incredibly fast, and gain one extra pierce. All Tier 3 and above Bee Hive towers gain a buff connected to their upgrade path strengths.";
        public override string DisplayName => "Wrath Of The Wasps";

        public override string Icon => "WrathOfTheWasps-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var wep = attackModel.weapons[0];
            var proj = wep.projectile;
            proj.pierce += 10;

            var projdmg = proj.GetBehavior<DamageModel>();
            projdmg.damage += 1;

            var projMovment = proj.GetBehavior<TravelStraitModel>();
            projMovment.lifespan *= 2;
            projMovment.speed *= 1.25f;

            var HomingModel = tower.GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>();
            HomingModel.turnRate *= 2.0f;
            HomingModel.ignoreSeekAngle = true;
            HomingModel.trackNewTargets = true;
        }
    }

}