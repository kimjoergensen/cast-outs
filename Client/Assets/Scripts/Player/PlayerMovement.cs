namespace Assets.Scripts.Player
{
  using Assets.Scripts.Shared.Extensions;
  using System.Collections;
  using UnityEngine;
  using UnityEngine.AI;

  [RequireComponent(typeof(NavMeshAgent))]
  public class PlayerMovement : MonoBehaviour
  {
    [Tooltip("Set the rotational speed of the player.")]
    [Range(0, 5)]
    public float RotationDamping;

    private NavMeshAgent _agent;
    private Vector3 _desiredMovement;
    private Quaternion _desiredRotation;
    private bool _isMoving;
    private bool _isRotating;

    public bool IsStoppingAction { get; private set; }

    private void Start() {
      _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() {
      if (_isMoving
      && !_isRotating)
        Move();
    }

    /// <summary>
    /// Move the player towards a point in world space.
    /// </summary>
    /// <param name="point">Vector3 holding the X, Y, Z coordinates of the point in world space.</param>
    public void MoveTowards(Vector3 point) {
      _desiredMovement = point;
      _isMoving = true;
    }

    private void Move() {
      Debug.DrawLine(transform.position, _desiredMovement, Color.red);

      _agent.isStopped = false;
      _agent.SetDestination(_desiredMovement);

      if (transform.position == _desiredMovement)
        _isMoving = false;
    }

    /// <summary>
    /// Stop all current player actions.
    /// </summary>
    public void StopAction() {
      IsStoppingAction = true;
    }

    /// <summary>
    /// Rotate the player towards a point in world space.
    /// </summary>
    /// <param name="point">Vector3 holding the X, Y, Z coordinates of the point in world space.</param>
    public IEnumerator LookAt(Vector3 point) {
      var direction = point - transform.position;
      _desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
      _isRotating = true;
      yield return Rotate();
    }

    private IEnumerator Rotate() {
      _agent.isStopped = true;
      while (_isRotating) {
        yield return transform.rotation = Quaternion.RotateTowards(transform.rotation, _desiredRotation, Time.deltaTime * (_agent.angularSpeed / RotationDamping));

        // Stop rotating when the rotation is approximately within the desired rotation.
        if (transform.rotation.Approximately(_desiredRotation, 5f))
          _isRotating = false;
      }
    }
  }
}
