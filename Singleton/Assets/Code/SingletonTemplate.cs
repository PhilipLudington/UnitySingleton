using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

/// <summary>
/// This is an example of a Singleton.
/// It's creation was impsidered by the talk by Richard Fine from Unity: https://www.youtube.com/watch?v=6vmRwLYWNRo
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
public class SingletonTemplate : ScriptableObject
{
    private static SingletonTemplate instance;

    public static SingletonTemplate Instance
    {
        get
        {
            // Find it if it exists
            if (!instance)
            {
                SingletonTemplate[] found = Resources.FindObjectsOfTypeAll<SingletonTemplate>();

                Assert.IsFalse(found.Length > 1, string.Format("There are {0} instances of SingletonExample!", 
                    found.Length));

                if (found.Length == 1)
                {
                    instance = found[0];
                }
            }
            // Create it if couldn't find it
            if (!instance)
            {                
                instance = ScriptableObject.CreateInstance<SingletonTemplate>();

                // https://docs.unity3d.com/ScriptReference/HideFlags.html
                // Will...
                // 1. Not show in the hierarchy (HideFlags.HideInHierarchy)
                // 2. Not be saved to the scene ( HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor)
                // 3. Not be unloaded by Resources.UnloadUnusedAssets (HideFlags.DontUnloadUnusedAsset)
                // instance.hideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor | HideFlags.DontUnloadUnusedAsset;                
				instance.hideFlags = HideFlags.HideAndDontSave;
            }

            return instance;
        }
    }
}
