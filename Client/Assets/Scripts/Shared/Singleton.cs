namespace CastOuts.Shared
{
  using UnityEngine;

  /// <summary>
  /// Applies the singleton pattern to the inheritance class.
  /// </summary>
  public class Singleton<T> : MonoBehaviour where T : Singleton<T>
  {
    private static bool _isShuttingDown = false; // Check to see if the instance is about to be destroyed.
    private static readonly object _lock = new object(); // Set a lock on the instance when being initialized.
    private static T _instance; // Store singleton instance.

    protected Singleton() { }

    /// <summary>
    /// Gets the instance.
    /// </summary>
    public static T Instance {
      get {
        if (_isShuttingDown) {
          Debug.LogWarning($"Singleton instance of {typeof(T)} already destroyed. Returning null.");
          return null;
        }

        lock (_lock) {
          // Check if instance has already been instantiated.
          if (!(_instance is null) && !_isShuttingDown) return _instance;

          // Search for existing instance.
          _instance = FindObjectOfType<T>();
          if (!(_instance is null)) return _instance;

          // Create new instance if one doesn't already exist.
          var singletonObject = new GameObject {
            name = $"{nameof(T)} (Singleton)"
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

    private void OnApplicationQuit() {
      _isShuttingDown = true;
    }

    private void OnDestroy() {
      _isShuttingDown = true;
    }
  }
}
