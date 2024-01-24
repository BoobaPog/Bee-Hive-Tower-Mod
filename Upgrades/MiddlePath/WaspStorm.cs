using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BeeHiveTower.Upgrades.MiddlePath
{
    public class WaspStorm : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.MIDDLE;
        public override int Tier => 4;
        public override int Cost => 1750;

        public override string Description => "Greatly improved Pierce and targeting efficiency. The paralysis effect is stronger and lasts longer. \r\n\nAbility: All bee hive tower swarm gain one pierce and damage while in range of the Wasp nest.";
        public override string DisplayName => "Wasp Storm";

        public override string Icon => "MiddlePath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var wep = attackModel.weapons[0];
            var proj = wep.projectile;

            var projMovment = proj.GetBehavior<TravelStraitModel>();
            projMovment.lifespan *= 2;
            projMovment.speed *= 1.25f;

            var HomingModel = tower.GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>();
            HomingModel.turnRate *= 2.0f;
            HomingModel.maxSeekAngle = 270.0f;
        }
    }

}