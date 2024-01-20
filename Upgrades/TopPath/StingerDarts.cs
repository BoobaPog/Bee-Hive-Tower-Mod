using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace BeeHiveTower.Upgrades.TopPath
{
    public class StingerDarts : ModUpgrade<BeeHive>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 300; 

        public override string Description => "Slightly increased the damage each bee inflicts";
        public override string DisplayName => "Stinger Darts";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetAttackModel().weapons[0].projectile.GetBehavior<DamageModel>().damage += 1;
        }
    }
}
