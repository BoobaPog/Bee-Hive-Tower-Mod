using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;

namespace BeeHiveTower.Upgrades.TopPath
{
    internal class HornetsNestFury : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.TOP;
        public override int Tier => 5;
        public override int Cost => 48500;

        public override string Description => "Unleashes unending powerful hornet swarms that deal massive damage and inflict frequent high critical damage.";
        public override string DisplayName => "Hornet's Nest Fury";

        public override string Icon => "HornetsNestFury-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {

            var wep = tower.GetAttackModel().weapons[0];
            wep.rate /= 1.3f;

            var CritDMG = wep.GetBehavior<CritMultiplierModel>();
            var proj = wep.projectile;
            proj.pierce += 1;

            proj.GetBehavior<DamageModifierForTagModel>().damageAddative = 25;

            var projdmg = proj.GetBehavior<DamageModel>();
            projdmg.damage += 20;
            CritDMG.damage = projdmg.damage * 3;
            CritDMG.lower = 3;
            CritDMG.upper = 3;
        }
    }
}
