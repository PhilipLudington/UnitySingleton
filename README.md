# Unity Singleton
This is an example of a Singleton in Unity.
It's creation was inspired by Richard Fine's talk:
 	"Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution" https://www.youtube.com/watch?v=6vmRwLYWNRo
Rules:
 - Only one instance should exist at anytime
 - It will survive reloading, recompiling, starting and stopping
 - It can exists outside of the game playing (in editor)
 - There are only three callbacks that it receives: OnEnable, OnDisable and OnDestroy
 - You could also load/create from a saved json file if it doesn't exist already
     <see cref="JsonUtility.FromJsonOverwrite(string, object)"/>
 - The <see cref="SingletonAttribute"/> (can also be just [Singleton]) tags the class,
     automatically adding it to the Windows->Singletons menu list
     which allows you to select it in the Inspector.