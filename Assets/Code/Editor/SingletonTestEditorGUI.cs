using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SingletonTestEditorGUI : EditorWindow
{
	SingletonTestGUI testGUI;

	// Add menu named "My Window" to the Window menu
	[MenuItem("Window/Singletons/SingletonTestEditorGUI")]
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		SingletonTestEditorGUI window = (SingletonTestEditorGUI)EditorWindow.GetWindow(typeof(SingletonTestEditorGUI));
		window.Show();
	}

	void OnGUI()
	{
		if (GUILayout.Button("AssetDatabase.Refresh()"))
		{
			AssetDatabase.Refresh();
		}

		if (GUILayout.Button("Access"))
		{
			UnitySingleton.Instance.Access();
		}
		if (GUILayout.Button("Create"))
		{
			ScriptableObject.CreateInstance<UnitySingleton>();
		}

		if (GUILayout.Button("Count"))
		{
			UnitySingleton[] found = FindObjectsOfType<UnitySingleton>();
			Debug.LogFormat("FindObjectsOfType<UnitySingleton>() found {0} UnitySingleton object(s)...", found.Length);

			found = Resources.FindObjectsOfTypeAll<UnitySingleton>();
			Debug.LogFormat("... but Resources.FindObjectsOfTypeAll<UnitySingleton>() found {0} UnitySingleton object(s).", found.Length);
		}

		if (GUILayout.Button("UnloadUnusedAssets"))
		{
			Resources.UnloadUnusedAssets();
		}

		if (GUILayout.Button("ReloadScene"))
		{
			SceneManager.LoadScene("Empty");
			SceneManager.LoadScene("SingletonTest");
		}
	}
}
		                                           
