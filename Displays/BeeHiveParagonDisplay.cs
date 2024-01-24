using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using System.Collections.Generic;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using UnityEngine;

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

        public override string BaseDisplay => Game.instance.model.GetTower(TowerType.SpikeFactory, 5, 0, 0).display.guidRef;

        public override int ParagonDisplayIndex { get; }

        public override bool UseForTower(int[] tiers) => IsParagon(tiers);


        public override IEnumerable<ModContent> Load()
        {
            for (var i = 0; i < TotalParagonDisplays; i++)
            {
                yield return new BeeHiveParagonDisplay(i);
            }
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            node.PrintInfo();
            node.SaveMeshTexture();


            SetMeshTexture(node, Name);
            //var outLineColor = new Color(235f, 188f, 78f);
            SetMeshOutlineColor(node, Color.yellow);
        }
    }

}