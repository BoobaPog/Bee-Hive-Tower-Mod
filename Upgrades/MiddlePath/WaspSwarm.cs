using BeeHiveTower.Displays.projectile;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BeeHiveTower.Upgrades.MiddlePath
{
    public class WaspSwarm : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.MIDDLE;
        public override int Tier => 3;
        public override int Cost => 700;

        public override string Description => "Bees are replaced with Wasps that have enhanced pierce and agility. Wasps have a chance to temporarily stun bloons and can pop Camo.";
        public override string DisplayName => "Wasp Swarm";

        public override string Icon => "MiddlePath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var wep = attackModel.weapons[0];
            var proj = wep.projectile;

            proj.ApplyDisplay<WaspDisplay>();
            proj.pierce += 2;

            var projMovment = proj.GetBehavior<TravelStraitModel>();
            projMovment.lifespan *= 2;

            var HomingModel = tower.GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>();
            HomingModel.turnRate *= 1.5f;
            HomingModel.maxSeekAngle = 270.0f;

            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }
}