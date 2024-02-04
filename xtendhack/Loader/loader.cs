using UnityEngine;

namespace xtendhack
{
    public class loader
    {
        private static readonly GameObject MGameObject = new GameObject();
        
        public static void load() 
        {
            MGameObject.AddComponent<hack>();
            Object.DontDestroyOnLoad(MGameObject);
        }
        public static void unload() 
        {
            Object.Destroy(MGameObject);
        }
    }
}