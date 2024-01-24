using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using UnityEngine;

namespace BeeHiveTower.Displays
{
    public class BeeHiveBaseDisplay : ModTowerDisplay<BeeHive>
    {
        public BeeHiveBaseDisplay()
        {
        }
        
        public override string BaseDisplay => Game.instance.model.GetTower(TowerType.MonkeyVillage, 0, 0, 1).display.guidRef;

        public override bool UseForTower(int[] tiers)
        {
            return true;
        }

        public override float Scale => 1f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            node.PrintInfo();
            node.SaveMeshTexture();


            SetMeshTexture(node, Name);
            //var outLineColor = new Color(235f, 188f, 78f);
            SetMeshOutlineColor(node, Color.gray);
        }
    }
}
