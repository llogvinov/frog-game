using UnityEngine;

namespace Core
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null) 
                    InitInstance();

                return _instance;
            }
        }

        public static bool HasInstance => _instance != null;

        private static void InitInstance()
        {
            if (_instance != null)
                return;

            _instance = FindObjectOfType<T>();

            if (_instance == null) 
                InstantiateDefault();
        }

        private static void InstantiateDefault()
        {
            var singleton = new GameObject();
            _instance = singleton.AddComponent<T>();
            singleton.name = "(singleton) " + typeof(T).ToString();
        }
    }
}