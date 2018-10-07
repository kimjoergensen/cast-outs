using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using WarlockBrawl.Utility;

namespace WarlockBrawl.Camera {
    [Serializable]
    public class CameraControllerEssentials {
        public UnityEngine.Camera camera;
    }

    [Serializable]
    public class CameraControllerSettings {
        public float boundary = 50f;
        public float speed = 5f;
    }

    public class CameraController : MonoBehaviour {
        #region Inspector menues
        public CameraControllerEssentials essentials;
        public CameraControllerSettings settings;
        #endregion

        #region Class variables
        private bool _isScrollingRight = false;
        private bool _isScrollingLeft = false;
        private bool _isScrollingUp = false;
        private bool _isScrollingDown = false;
        private int _screenWidth;
        private int _screenHeight;
        #endregion

        /// <summary>
        /// Gets called when CameraController is initialized.
        /// </summary>
        private void Awake() {
            essentials = new CameraControllerEssentials();
            settings = new CameraControllerSettings();
        }

        /// <summary>
        /// Gets called after Awake for later instantiation.
        /// </summary>
        private void Start() {
            // Get the user's screen width and height in pixels.
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
        }

        /// <summary>
        /// Editor validation
        /// </summary>
        private void OnValidate() {
            Validate();
        }

        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        private void Update() {
            CheckForMousePosition();
        }

        /// <summary>
        /// FixedUpdate counts the time from last frame update to keep
        /// every update within the same interval for all users.
        /// </summary>
        private void FixedUpdate() {
            if(_isScrollingRight) {

            }
        }

        /// <summary>
        /// Checks if the mouse position is within the boundary limit of the screen edge.
        /// </summary>
        /// <returns></returns>
        private void CheckForMousePosition() {
            // Check if the mouse is within the boundary of the screen's right edge.
            if (Input.mousePosition.x > _screenWidth - settings.boundary) {
                _isScrollingRight = true;
            }


            // Check if the mouse is within the boundary of the screen's left edge.
            if(Input.mousePosition.x < settings.boundary) {
                _isScrollingLeft = true;
            }


            // Check if the mouse is within the boundary of the screen's top edge.
            if(Input.mousePosition.y > _screenHeight - settings.boundary) {
                _isScrollingUp = true;
            }


            // Check if the mouse is within the boundary of the screen's bottom edge.
            if(Input.mousePosition.y < settings.boundary) {
                _isScrollingDown = true;
            }
        }

        /// <summary>
        /// Validate the code in the editor at compile time.
        /// </summary>
        private void Validate() {
            Assert.IsNotNull(transform, AssertUtility.ComponentNullErrorMessage(gameObject.transform, gameObject));
            Assert.AreEqual(essentials.camera.GetType(), typeof(UnityEngine.Camera), AssertUtility.PropertyWrongTypeOrNullErrorMessage("Camera", essentials.camera, gameObject));
        }
    }
}
