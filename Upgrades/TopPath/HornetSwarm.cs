using BeeHiveTower.Displays.projectile;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace BeeHiveTower.Upgrades.TopPath
{
    internal class HornetSwarm : ModUpgrade<BeeHive>
    {
        public override int Path => ModUpgrade.TOP;
        public override int Tier => 3;
        public override int Cost => 1200;

        public override string Description => "Bees are replaced with hornets that have significantly increased damage and attack speed. Hornets have a small chance of causing critical hits and can pop lead";
        public override string DisplayName => "Hornet Swarm";
        public override string Icon => "TopPath-Icon";
        public override void ApplyUpgrade(TowerModel tower)
        {

            var wep = tower.GetAttackModel().weapons[0];
            wep.rate /= 1.2f;

            var proj = wep.projectile;
            proj.ApplyDisplay<HornetDisplay>();

            var projdmg = proj.GetBehavior<DamageModel>();
            projdmg.damage += 2;
            projdmg.immuneBloonProperties = BloonProperties.None;

            var baseCritModel = Game.instance.model.GetTowerFromId("DartMonkey-005").Duplicate().GetWeapon();
            var textOnHit = baseCritModel.projectile.GetBehavior<ShowTextOnHitModel>();

            var Adora = Game.instance.model.GetHeroWithNameAndLevel("Adora", 3).Duplicate();
            var CritModel = Adora.GetBehavior<Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel>().GetBehavior<LongArmOfLightModel>().Duplicate();
            var CritProjectile = CritModel.projectileDisplay;
            var displayRef = new Il2CppAssets.Scripts.Utils.PrefabReference(CritProjectile.assetPath.GUID);

            var displayCata = new Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayCategory();
            var HornetCrit = new Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel("HornetCrit_", displayRef, 0, displayCata);
            HornetCrit.scale = 0.75f;
            var critHit = new CritMultiplierModel("BeeHive_CritMultiplierModel_", projdmg.damage * 2, 10, 10, HornetCrit, false);
            proj.AddBehavior(textOnHit);
            wep.AddBehavior(critHit);
        }
    }
}
