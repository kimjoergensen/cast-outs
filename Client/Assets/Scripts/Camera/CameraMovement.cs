namespace Assets.Scripts.Camera
{
  using Assets.Scripts.Shared.KeyBinding;
  using UnityEngine;

  /// <summary>
  /// Controls the camera's movement
  /// </summary>
  public class CameraMovement : MonoBehaviour
  {
    [Tooltip("The movement speed of the camera.")]
    public float speed;
    [Tooltip("The amount of pixels from the screen edge the mouse needs to enter before moving the camera.")]
    public float boundary;
    [Tooltip("Limits the cameras movemen on the X and Z axis by the amount specified.")]
    public Vector2 limits;

    private Vector3 _desiredCameraPosition;
    private int _screenWidth;
    private int _screenHeight;

    private void Start() {
      _desiredCameraPosition = transform.position;
      _screenWidth = Screen.width;
      _screenHeight = Screen.height;
    }

    private void Update() {
      // Get updates made to the desired movement of the camera.
      SetDesiredCameraPosition();
    }

    private void FixedUpdate() {
      // Check if the current camera position is not at the desired camera position.
      if (Vector3.Distance(transform.position, _desiredCameraPosition) > 0.1f) {
        // Move the camera towards the desired camera position.
        MoveCamera();
      }
    }

    private void SetDesiredCameraPosition() {
      // Get the current desired camera position.
      var position = _desiredCameraPosition;

      // Check if the mouse is within the boundary of the screen's right edge
      if ((Input.mousePosition.x > _screenWidth - boundary && Input.mousePosition.x < _screenWidth + 1) || InputManager.Instance.GetKey(KeyBinding.CameraMoveRight))
        position.x += speed * Time.deltaTime;

      // Check if the mouse is within the boundary of the screen's left edge
      if ((Input.mousePosition.x < boundary && Input.mousePosition.x > -1) || InputManager.Instance.GetKey(KeyBinding.CameraMoveLeft))
        position.x -= speed * Time.deltaTime;

      // Check if the mouse is within the boundary of the screen's top edge
      if ((Input.mousePosition.y > _screenHeight - boundary && Input.mousePosition.y < _screenHeight + 1) || InputManager.Instance.GetKey(KeyBinding.CameraMoveUp))
        position.z += speed * Time.deltaTime;

      // Check if the mouse is within the boundary of the screen's bottom edge
      if ((Input.mousePosition.y < boundary && Input.mousePosition.y > -1) || InputManager.Instance.GetKey(KeyBinding.CameraMoveDown))
        position.z -= speed * Time.deltaTime;

      // TODO: Limit camera movement.
      // Keep the desired camera position within the directional limits.
      //position = position.LimitCoordinates(settings.limits, essentials.offset.position);

      _desiredCameraPosition = position;
    }

    private void MoveCamera() {
      transform.position = _desiredCameraPosition;
    }
  }
}
