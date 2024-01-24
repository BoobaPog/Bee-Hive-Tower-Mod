using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace BeeHiveTower.Upgrades.BottomPath
{
    public class LargeSwarms : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.BOTTOM;
        public override int Tier => 1;
        public override int Cost => 500;

        public override string Description => "Slightly increase in swarm size.";
        public override string DisplayName => "Large swarms";

        public override string Icon => "BottomPath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetAttackModel().weapons[0].RemoveBehavior<ArcEmissionModel>();

            var emissionModel = new ArcEmissionModel("ArcEmissionModel_", 10, 0.0f, 360, null, false, false);
            tower.GetAttackModel().weapons[0].emission = emissionModel;
        }
    }
}
