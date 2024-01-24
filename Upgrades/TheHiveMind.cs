using BeeHiveTower.Displays.projectile;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace BeeHiveTower.Upgrades
{
    public class TheHiveMind : ModParagonUpgrade<BeeHive>
    {
        public override int Cost => 400000;
        public override string Description => "The Hive...";
        public override string DisplayName => "The Hive Mind";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var AdoraCopy = Game.instance.model.GetHeroWithNameAndLevel("Adora", 20).Duplicate();
            var adoraProjDisplay = AdoraCopy.GetAttackModel().weapons[0].projectile.display;
            tower.GetAttackModel().weapons[0].projectile.display = adoraProjDisplay;
        }
    }
}