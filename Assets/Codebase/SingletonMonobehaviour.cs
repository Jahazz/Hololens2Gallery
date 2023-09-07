using UnityEngine;

namespace Codebase
{
    public class SingletonMonobehaviour<SingletonType> : MonoBehaviour
    {
        public static SingletonType Instance { get; private set; }

        protected virtual void Awake ()
        {
            if (Instance != null)
            {
                Debug.LogWarning("Singleton already exists, are you sure its single gameobject of that type?");
            }

            Instance = GetComponent<SingletonType>();
        }
    }

}
