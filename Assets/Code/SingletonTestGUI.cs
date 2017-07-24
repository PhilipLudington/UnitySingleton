using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonTestGUI : MonoBehaviour
{
	public void AssetDatabaseRefresh()
	{
		AssetDatabase.Refresh();
	}

	public void Access()
	{
		UnitySingleton.Instance.Access();
	}

	public void Create()
	{
		ScriptableObject.CreateInstance<UnitySingleton>();
	}

	public void Count()
	{
		UnitySingleton[] found = FindObjectsOfType<UnitySingleton>();
		Debug.LogFormat("FindObjectsOfType<UnitySingleton>() found {0} UnitySingleton object(s)...", found.Length);

		found = Resources.FindObjectsOfTypeAll<UnitySingleton>();
		Debug.LogFormat("... but Resources.FindObjectsOfTypeAll<UnitySingleton>() found {0} UnitySingleton object(s).", found.Length);
	}

	public void UnloadUnusedAssets()
	{
		Resources.UnloadUnusedAssets();
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene("Empty");
		SceneManager.LoadScene("SingletonTest");
	}
}
