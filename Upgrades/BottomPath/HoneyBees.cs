using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;

namespace BeeHiveTower.Upgrades.BottomPath
{
    internal class HoneyBees : ModUpgrade<BeeHive>
    {

        public override int Path => ModUpgrade.BOTTOM;
        public override int Tier => 3;
        public override int Cost => 1450;

        public override string Description => "The bees now produce honey when they pop a bloon. Significantly increases projectile count and range and starts generating honey for extra income.";
        public override string DisplayName => "Honey Bees";

        public override string Icon => "BottomPath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.range *= 1.5f;

            var attackModel = tower.GetAttackModel();
            attackModel.range = tower.range;

            var wep = tower.GetAttackModel().weapons[0];
            wep.RemoveBehavior<ArcEmissionModel>();
            var emissionModel = new ArcEmissionModel("ArcEmissionModel_", 27, 0.0f, 360, null, false, false);
            wep.emission = emissionModel;
        }
    }
}
