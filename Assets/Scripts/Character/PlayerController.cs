using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[Serializable]
public class PlayerControllerSettings {
    public float MovementSpeed = 20f;
    public float TurnRate = 20f;
}

public class PlayerController : MonoBehaviour {
    #region Inspector menues
    [Tooltip("Set player game settings.")]
    public PlayerControllerSettings playerControllerSettings;
    [Tooltip("Set user input for player controls.")]
    public InputManager.PlayerInputs playerInputs;
    #endregion

    #region Inspector properties
    public NavMeshAgent agent;
    #endregion

    #region Private variables
    // Input variables
    private bool _moveInputPressed = false;
    private bool _fireInputPressed = false;
    private bool _stopInputPressed = false;

    // Player state variables
    private bool _walking = false;
    #endregion

    /// <summary>
    /// Constructor for initializing class variables
    /// </summary>
    public PlayerController() {
        playerInputs = new InputManager.PlayerInputs();
        playerControllerSettings = new PlayerControllerSettings();
    }

    /// <summary>
    /// Editor validation
    /// </summary>
    private void OnValidate() {
        Assert.IsNotNull(agent);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update() {
        // Check for user inputs.
        if(Input.anyKeyDown) {
            CheckForInput();
        }
	}

    /// <summary>
    /// FixedUpdate counts the time from last frame update to keep
    /// every update within the same interval for all users.
    /// </summary>
    private void FixedUpdate() {
        // Execute player actions
        if(_moveInputPressed) {
            PlayerActionMove();
            _moveInputPressed = false;
        }

        if(_fireInputPressed) {
            PlayerActionFire();
            _fireInputPressed = false;
        }

        if(_stopInputPressed) {
            PlayerActionStop();
            _stopInputPressed = false;
        }
    }

    #region Helper functions
    /// <summary>
    /// Set player actions based on inputs from the user.
    /// </summary>
    private void CheckForInput() {
        // Check if the MOVE key has been pressed.
        if(Input.GetKeyDown(playerInputs.Move)) {
            _moveInputPressed = true;
        }

        // Check if the FIRE key has been pressed.
        if(Input.GetKeyDown(playerInputs.Fire)) {
            _fireInputPressed = true;
        }

        // Check if the STOP key has been pressed.
        if(Input.GetKeyDown(playerInputs.Stop)) {
            _stopInputPressed = true;
        }
    }

    /// <summary>
    /// Start player movement towards current mouse position.
    /// </summary>
    private void PlayerActionMove() {
        var camera = FindCamera();

        // Fire a ray from the camera towards the current mouse position;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        // Stores the world's X and Y coordinates where the raycast hit.
        RaycastHit hit;
        // Check if the raycast didn't hit any game objects.
        if(!Physics.Raycast(ray, out hit, 1000f)) {
            // Escape function.
            return;
        }

        // Check if the game object hit doesn't have collider on it.
        if(!hit.transform) {
            // Escape function.
            return;
        }


    }

    /// <summary>
    /// Fire currently selected spell.
    /// </summary>
    private void PlayerActionFire() {
        
    }

    /// <summary>
    /// Stop all player actions.
    /// </summary>
    private void PlayerActionStop() {
        
    }

    private Camera FindCamera() {
        var camera = GetComponent<Camera>();
        if(camera) {
            return camera;
        }
        else {
            return Camera.main;
        }
    }
    #endregion
}
