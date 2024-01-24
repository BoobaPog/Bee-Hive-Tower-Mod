using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;


namespace BeeHiveTower.Upgrades.TopPath
{
    internal class DeadlyBuzz : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.TOP;
        public override int Tier => 4;
        public override int Cost => 5850;

        public override string Description => "Greatly enhanced damage. Hornets cause extra damage against moabs";
        public override string DisplayName => "Deadly Buzz";
        public override string Icon => "TopPath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {

            var wep = tower.GetAttackModel().weapons[0];

            var proj = wep.projectile;
            
            var damageModifier = new DamageModifierForTagModel("Hornet_DamageModifierForTagModel_", "Moabs", 1.0f, 5, false, false);
            proj.AddBehavior(damageModifier);

            var projdmg = proj.GetBehavior<DamageModel>();
            projdmg.damage += 5;
            wep.GetBehavior<CritMultiplierModel>().damage = projdmg.damage * 2;
        }
    }
}

