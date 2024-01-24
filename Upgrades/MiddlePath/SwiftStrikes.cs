using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BeeHiveTower.Upgrades.MiddlePath
{
    public class SwiftStrikes : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.MIDDLE;
        public override int Tier => 1;
        public override int Cost => 120;

        public override string Description => "Increased bee's fly speed";
        public override string DisplayName => "Swift Strikes";

        public override string Icon => "MiddlePath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            var projMovment = tower.GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>();
            projMovment.speed *= 1.25f;
        }
    }
}