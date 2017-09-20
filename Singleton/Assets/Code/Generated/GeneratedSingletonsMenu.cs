﻿// Dynamically generated by SingletonAttribute

using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 

public static class GeneratedSingletonsMenu
{
#if UNITY_EDITOR
	[UnityEditor.MenuItem("Window/Singletons/SingletonTemplate")]
	public static void InspectSingletonTemplate()
	{
		UnityEditor.Selection.activeObject = SingletonTemplate.Instance;
	}
	[UnityEditor.MenuItem("Window/Singletons/SingletonTest")]
	public static void InspectSingletonTest()
	{
		UnityEditor.Selection.activeObject = SingletonTest.Instance;
	}
#endif
}