using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameManager instance;

    // Initialize the script.
	private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if (instance != this) {
            // Enforces the singleton pattern.
            Destroy(gameObject);
        }

        // Keep instance alive when switching scene.
        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    /// <summary>
    /// Inialize a game.
    /// </summary>
    private void InitGame() {
        
    }
}
