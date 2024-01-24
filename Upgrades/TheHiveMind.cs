using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;

namespace BeeHiveTower.Upgrades
{
    public class TheHiveMind : ModParagonUpgrade<BeeHive>
    {
        public override int Cost => 400000;
        public override string Description => "The Hive...";
        public override string DisplayName => "The Hive Mind";

        public override void ApplyUpgrade(TowerModel tower)
        {

        }
    }
}