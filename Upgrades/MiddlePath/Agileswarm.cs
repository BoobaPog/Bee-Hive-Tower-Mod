using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BeeHiveTower.Upgrades.MiddlePath
{
    public class Agileswarm : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.MIDDLE;
        public override int Tier => 2;
        public override int Cost => 540;

        public override string Description => "The swarms can curve more aggressively toward targets";
        public override string DisplayName => "Agile swarm";

        public override string Icon => "MiddlePath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var HomingModel = tower.GetAttackModel().weapons[0].projectile.GetBehavior<TrackTargetModel>();
            HomingModel.turnRate *= 2.0f;
            HomingModel.maxSeekAngle *= 2.0f;
        }
    }
}