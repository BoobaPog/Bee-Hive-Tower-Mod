using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace BeeHiveTower.Upgrades.BottomPath
{
    public class GreatSwarms : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.BOTTOM;
        public override int Tier => 2;
        public override int Cost => 800;

        public override string Description => "Modest increase in swarm size and the bee hive has a greater range.";
        public override string DisplayName => "Great swarms";

        public override string Icon => "BottomPath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.range *= 1.15f;

            var attackModel = tower.GetAttackModel();
            attackModel.range = tower.range;

            attackModel.weapons[0].RemoveBehavior<ArcEmissionModel>();
            var emissionModel = new ArcEmissionModel("ArcEmissionModel_", 15, 0.0f, 360, null, false, false);
            tower.GetAttackModel().weapons[0].emission = emissionModel;
        }
    }
}
