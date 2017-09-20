using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Singleton]
public class SingletonTest : ScriptableObject
{
	private static SingletonTest instance = null;
	public string startTime = System.DateTime.Now.ToString();

	public static SingletonTest Instance
	{
		get
		{
			// Find it if it exists
			if (!instance)
			{
				Debug.Log("Looking for Singleton...");
				SingletonTest[] found = Resources.FindObjectsOfTypeAll<SingletonTest>();

				if (found.Length > 1)
				{
					Debug.LogErrorFormat("There are {0} instance of Singleton!", found.Length);
				}

				if (found.Length == 1)
				{
					Debug.Log("... Singleton found.");
					instance = found[0];
				}
			}
			// Create it if couldn't find it
			if (!instance)
			{
				Debug.Log("... Singleton not found, creating.");
                
				instance = ScriptableObject.CreateInstance<SingletonTest>();

				// https://docs.unity3d.com/ScriptReference/HideFlags.html
				// Will...
				// 1. Not show in the hierarchy (HideFlags.HideInHierarchy)
				// 2. Not be saved to the scene ( HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor)
				// 3. Not be unloaded by Resources.UnloadUnusedAssets (HideFlags.DontUnloadUnusedAsset)
				instance.hideFlags = HideFlags.None;
				Debug.Log("... Singleton created.");
			}

			return instance;
		}
	}

	public void Set(string value)
	{
		Instance.startTime = value;
	}

	public void Access()
	{
		Debug.Log(Instance.startTime);
	}

	// The only callbacks
	void OnEnable()
	{
		Debug.Log("Singleton OnEnable");
	}

	void OnDisable()
	{
		Debug.Log("Singleton OnDisable");
	}

	void OnDestroy()
	{
		Debug.Log("Singleton OnDestroy");
	}
}
