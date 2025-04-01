using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using UnityEngine;
using WhoIsTalking;
namespace WhoIsCheating.Patches
{
    [HarmonyPatch(typeof(NameTagHandler))]
    [HarmonyPatch("GetInfo", MethodType.Normal)]
    internal class WhoIsTalkingPatch0
    {
        private static void Postfix(NameTagHandler __instance)
        {
            __instance.GetOrAddComponent<PlatformHandler>(out var NTH);
            NTH.nameTagHandler = __instance;
            NTH.rig = __instance.rig;
            NTH.UpdatePlatformPatchThingy();

            if (NTH.fpPlatformIcon == null || NTH.tpPlatformIcon == null)
            {
                NTH.CreatePlatformIcons();
            }
        }
    }
}
