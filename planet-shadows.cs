

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;

namespace Chrono460
{
	[BepInPlugin("me.chrono460.dspplugin.MoreShadowsPlugin", "More Shadows", "1.0")]
	public class DSPMoreShadowsPlugin : BaseUnityPlugin
	{
		void Start()
		{
			// Harmony patch
			var harmony = new Harmony("me.chrono460.dspplugin.MoreShadows");
			harmony.PatchAll(typeof(DSPMoreShadows));
		}


		public static class DSPMoreShadows
		{
			[HarmonyPostfix, HarmonyPatch(typeof(PlanetSimulator), "UpdateUniversalPosition")]
			public static void Postfix(PlanetSimulator __instance)
			{
				foreach (Renderer renderer in __instance.surfaceRenderer)
				{
					renderer.shadowCastingMode = (!PlanetSimulator.sOptionCastShadow) ? ShadowCastingMode.Off : ShadowCastingMode.On;
				}
			}
		}

	}
}
