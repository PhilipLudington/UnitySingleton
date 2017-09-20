using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUITestSingleton : MonoBehaviour
{
	public void AssetDatabaseRefresh()
	{
		AssetDatabase.Refresh();
	}

	public void Access()
	{
		SingletonTest.Instance.Access();
	}

	public void Create()
	{
		SingletonTest test = ScriptableObject.CreateInstance<SingletonTest>();
		test.Access();
	}

	public void Count()
	{
		SingletonTest[] found = FindObjectsOfType<SingletonTest>();
		Debug.LogFormat("Found {0} SingletonTest object(s).", found.Length);
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
