using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHiveTower.Displays
{
    public class BeeHiveDisplay : ModTowerDisplay<BeeHive>
    {
        public override string BaseDisplay => GetDisplay(TowerType.MonkeyVillage, 0, 0, 0);

        public override bool UseForTower(int[] tiers)
        {
            return true;
        }

        public override float Scale => 1f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "BeeHiveDisplay");
        }
    }
}
