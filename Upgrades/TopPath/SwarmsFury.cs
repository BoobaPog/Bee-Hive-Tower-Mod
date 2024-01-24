using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace BeeHiveTower.Upgrades.TopPath
{
    public class SwarmsFury : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.TOP;
        public override int Tier => 2;
        public override int Cost => 250;

        public override string Description => "Increased the bee hive’s attack speed";
        public override string DisplayName => "Swarm's Fury";

        public override string Icon => "TopPath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetAttackModel().weapons[0].rate /= 1.1f;
        }
    }
}