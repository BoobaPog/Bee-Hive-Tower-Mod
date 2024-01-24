using BeeHiveTower;
using BTD_Mod_Helper;
using MelonLoader;
using Il2CppAssets.Scripts.Simulation.Bloons;

[assembly: MelonInfo(typeof(BeeHiveTowerMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BeeHiveTower
{
    public class BeeHiveTowerMod : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            ApplyHarmonyPatches(typeof(Bloon));
        }
    }
}
