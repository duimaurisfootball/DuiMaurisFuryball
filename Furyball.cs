global using BepInEx;
global using BrutalAPI;
global using Dui_Mauris_Furyball.CustomEffects;
global using Dui_Mauris_Furyball.ExtraStoredValues;
global using HarmonyLib;
global using MonoMod.RuntimeDetour;
global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.Linq;
global using System.Reflection;
global using System.Reflection.Emit;
global using UnityEngine;
global using System.Collections;
global using static Dui_Mauris_Furyball.FoolBossUnlockSystem;
using Dui_Mauris_Furyball.Characters;
using Dui_Mauris_Furyball.NonUnlockItems;

namespace Dui_Mauris_Furyball
{
    public static class ResourceLoader
    {
        public static Texture2D LoadTexture(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
            var resource = assembly.GetManifestResourceStream(resourceName);
            using var memoryStream = new MemoryStream();
            var buffer = new byte[48685];
            int count;
            while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                memoryStream.Write(buffer, 0, count);
            var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
            {
                anisoLevel = 1,
                filterMode = 0
            };

            spriteTexture.LoadImage(memoryStream.ToArray());
            return spriteTexture;
        }

        public static Sprite LoadSprite(string name, int ppu = 1, Vector2? pivot = null)
        {
            if (pivot == null) { pivot = new Vector2(0.5f, 0.5f); }
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
            var resource = assembly.GetManifestResourceStream(resourceName);
            using var memoryStream = new MemoryStream();
            var buffer = new byte[16354];
            int count;
            while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                memoryStream.Write(buffer, 0, count);
            var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
            {
                anisoLevel = 1,
                filterMode = 0
            };

            spriteTexture.LoadImage(memoryStream.ToArray());
            var sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), (Vector2)pivot, ppu);
            return sprite;
        }

        public static byte[] ResourceBinary(string name)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            var resourceName = a.GetManifestResourceNames().First(r => r.Contains(name));
            using (Stream resFilestream = a.GetManifestResourceStream(resourceName))
            {
                if (resFilestream == null) return null;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
    [BepInPlugin("Dui_Mauris_Football.Furyball", "Dui Mauris Furyball", "2.3.0")]
    public class Furyball : BaseUnityPlugin
    {
        public void Awake()
        {
            Debug.Log("Dui Mauris Furyball did something i think");

            new Harmony("Dui_Mauris_Football.Furyball").PatchAll();

            FoolBossUnlockSystem.Setup();

            //add characters
            Vandander.Add();
            VandanderHoles.Add();
            Spoogle.Add();
            Filemarm.Add();
            Salad.Add();
            PreFabSalad.Add();
            Rodney.Add();
            Vat.Add();
            Malebolge.Add();
            Felix.Add();
            Alvinar.Add();
            Naba.Add();
            Aelie.Add();
            Gomma.Add();
            Hills.Add();
            Maecenas.Add();
            Toby.Add();

            //add items
            SpearItem.Add();
            BowlingPinTap.Add();
            BowlingPinSplit.Add();
            BowlingPinGreek.Add();
            BowlingPinHead.Add();
            BowlingPinBaby.Add();
            NumberMagnet.Add();
            AlumSalt.Add();
            AppleCiderVinegar.Add();
            Sauerkraut.Add();
            PickledBeets.Add();
            DeadCream.Add();
            PaintedDie.Add();
            Beeper.Add();
            //TestItemRealFreeDownload.Add();
        }
    }
}








