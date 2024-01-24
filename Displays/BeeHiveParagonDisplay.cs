using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers;
using System.Collections.Generic;

namespace BeeHiveTower.Displays
{
    public class BeeHiveParagonDisplay : ModTowerDisplay<BeeHive>
    {
        public BeeHiveParagonDisplay()
        {
        }

        public BeeHiveParagonDisplay(int i)
        {
            ParagonDisplayIndex = i;
        }

        public override float Scale => .75f + ParagonDisplayIndex * .025f;

        public override string BaseDisplay => GetDisplay(TowerType.MonkeyVillage, 0, 0, 3);

        public override int ParagonDisplayIndex { get; }

        public override string Name => nameof(BeeHiveParagonDisplay) + ParagonDisplayIndex;

        public override bool UseForTower(int[] tiers) => IsParagon(tiers);


        public override IEnumerable<ModContent> Load()
        {
            for (var i = 0; i < TotalParagonDisplays; i++)
            {
                yield return new BeeHiveParagonDisplay(i);
            }
        }
    }

}