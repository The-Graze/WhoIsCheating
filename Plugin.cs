using System;
using BepInEx;
using UnityEngine;
using Utilla;
using WhoIsTalking;

namespace WhoIsCheating
{
    // This is your mod's main class.
    [BepInDependency("Graze.WhoIsTalking")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        Plugin()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void Start()
        {
            GorillaTagger.OnPlayerSpawned(Setup);
        }

        private void Setup()
        {
            CosmeticsV2Spawner_Dirty.OnPostInstantiateAllPrefabs += SetProp;
        }

        private void SetProp()
        {
            ExitGames.Client.Photon.Hashtable properties = NetworkSystem.Instance.LocalPlayer.GetPlayerRef().CustomProperties;
            properties.AddOrUpdate("cheese is gouda", PluginInfo.Name);
            PhotonNetwork.LocalPlayer.SetCustomProperties(properties);
        }
    }
}
