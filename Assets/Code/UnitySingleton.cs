using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

/// <summary>
/// This is an example of a Singleton.
/// It's creation was inspired by Richard Fine's talk:
/// 	"Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution" https://www.youtube.com/watch?v=6vmRwLYWNRo
/// Rules:
/// - Only one instance should exist at anytime
/// - It will survive reloading, recompiling, starting and stopping
/// - It can exists outside of the game playing (in editor)
/// - There are only three callbacks that it receives: OnEnable, OnDisable and OnDestroy
/// - You could also load/create from a saved json file if it doesn't exist already
///     <see cref="JsonUtility.FromJsonOverwrite(string, object)"/>
/// - The <see cref="SingletonAttribute"/> (can also be just [Singleton]) tags the class,
///     automatically adding it to the Windows->Singletons menu list
///     which allows you to select it in the Inspector.
/// </summary>
[Singleton]
public class UnitySingleton : ScriptableObject
{
	private static UnitySingleton instance = null;
	public string startTime = System.DateTime.Now.ToString();

	public static UnitySingleton Instance
	{
		get
		{
			// Find it if it exists
			if (!instance)
			{
				Debug.Log("Looking for UnitySingleton...");
				UnitySingleton[] found = Resources.FindObjectsOfTypeAll<UnitySingleton>();

				Assert.IsFalse(Resources.FindObjectsOfTypeAll<UnitySingleton>().Length > 1, string.Format("There are {0} instances of UnitySingleton!", found.Length));

				if (found.Length == 1)
				{
					Debug.Log("... UnitySingleton found.");
					instance = found[0];
				}
			}
			// Create it if couldn't find it
			if (!instance)
			{
				Debug.Log("... UnitySingleton not found, creating.");
                
				// No assigment because it happens in OnEnable
				ScriptableObject.CreateInstance<UnitySingleton>();

				// https://docs.unity3d.com/ScriptReference/HideFlags.html
				// Will...
				// 1. Not show in the hierarchy (HideFlags.HideInHierarchy)
				// 2. Not be saved to the scene ( HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor)
				// 3. Not be unloaded by Resources.UnloadUnusedAssets (HideFlags.DontUnloadUnusedAsset)
				// HideFlags.HideAndDontSave = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor | HideFlags.DontUnloadUnusedAsset;   
				instance.hideFlags = HideFlags.HideAndDontSave;
				Debug.Log("... UnitySingleton created.");
			}

			return instance;
		}
	}

	public void Access()
	{
		Debug.Log(Instance.startTime);
	}

	// The only callbacks
	void OnEnable()
	{
		Debug.Log("UnitySingleton OnEnable");
	
		if (instance == null)
		{
			instance = this;

			// https://docs.unity3d.com/ScriptReference/HideFlags.html
			// Will...
			// 1. Not show in the hierarchy (HideFlags.HideInHierarchy)
			// 2. Not be saved to the scene ( HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor)
			// 3. Not be unloaded by Resources.UnloadUnusedAssets (HideFlags.DontUnloadUnusedAsset)
			// HideFlags.HideAndDontSave = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor | HideFlags.DontUnloadUnusedAsset;   
			instance.hideFlags = HideFlags.HideAndDontSave;
		}
		else if (Instance != this)
		{
			Debug.LogError("A new instance of SingletonExample was created, marking it for destruction.");

			if (Application.isEditor)
			{
				DestroyImmediate(this);
			}
			else
			{
				Destroy(this);
			}
		}
	}

	void OnDisable()
	{
		Debug.Log("UnitySingleton OnDisable");
	}

	void OnDestroy()
	{
		Debug.Log("UnitySingleton OnDestroy");
	}
}
