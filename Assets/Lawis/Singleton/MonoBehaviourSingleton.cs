using UnityEngine;

namespace Assets.Lawis.Singleton
{
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        public static T Instance { get => instance; private set => instance = value; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}