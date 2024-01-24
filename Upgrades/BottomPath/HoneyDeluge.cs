using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace BeeHiveTower.Upgrades.BottomPath
{
    internal class HoneyDeluge : ModUpgrade<BeeHive>
    {

        public override int Path => ModUpgrade.BOTTOM;
        public override int Tier => 4;
        public override int Cost => 2950;

        public override string Description => "Greatly increases honey production; projectiles slow bloons due to sticky honey.";
        public override string DisplayName => "Honey Deluge";

        public override string Icon => "BottomPath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {

            var attackModel = tower.GetAttackModel();
            var wep = attackModel.weapons[0];
            var proj = wep.projectile;

            var baseGlue = Game.instance.model.GetTowerFromId("GlueGunner").GetAttackModel().weapons[0].projectile.Duplicate();
            var honeyBaseBehav = baseGlue.GetBehavior<SlowModel>().Duplicate();
            honeyBaseBehav.Multiplier = 0.7f;
            honeyBaseBehav.multiplier = 0.7f;
            honeyBaseBehav.lifespan = 11.0f;
            honeyBaseBehav.layers = 4;
            honeyBaseBehav.mutator.multiplier = 0.7f;

            proj.AddBehavior(honeyBaseBehav);
        }
    }
}
