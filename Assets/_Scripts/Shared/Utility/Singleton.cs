using UnityEngine;

namespace CastOuts.Utility {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Class variables
        private static bool _isShuttingDown = false;    // Check to see if the instance is about to be destroyed.
        private static object _lock = new object();     // Set a lock on the instance when being initialized.
        private static T _instance;                     // Store singleton instance.
        #endregion

        /// <summary>
        /// Access singleton instance through this property.
        /// </summary>
        /// <returns></returns>
        public static T Instance {
            get {
                if(_isShuttingDown) {
                    Debug.LogWarning($"[Singleton] Instance of {typeof(T)} already destroyed. Returning null.");
                    return null;
                }

                lock(_lock) {
                    // Check if instance has already been instantiated.
                    if(_instance != null) return _instance;

                    // Search for existing instance.
                    _instance = FindObjectOfType<T>();
                    if(_instance != null) return _instance;

                    // Create new instance if one doesn't already exist.
                    var singletonObject = new GameObject {
                        name = $"{typeof(T).ToString()} (Singleton)"
                    };

                    // Set instance to new object.
                    _instance = singletonObject.AddComponent<T>();

                    // Make instance persistent.
                    DontDestroyOnLoad(singletonObject);

                    // Return new singleton instance.
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Is called when application is shutting down.
        /// </summary>
        private void OnApplicationQuit() {
            _isShuttingDown = true;
        }

        /// <summary>
        /// Is called when game object is being destroyed.
        /// </summary>
        private void OnDestroy() {
            _isShuttingDown = true;
        }
    }
}
