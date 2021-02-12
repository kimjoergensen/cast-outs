using System;
using System.Collections;
using CastOuts.Shared.Extensions;
using CastOuts.Shared.Utility;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace CastOuts.Player
{
  [Serializable]
  public class PlayerMovementEssentials
  {
    [Tooltip("Set which layer is walkable by player objects.")]
    public LayerMask mask;
  }

  [Serializable]
  public class PlayerMovementSettings
  {

  }

  [RequireComponent(typeof(NavMeshAgent))]
  public class PlayerMovement : MonoBehaviour
  {
    private const float ROTATION_DAMPING = 3.5f;

    [Tooltip("Essential components for the PlayerMovement script.")]
    public PlayerMovementEssentials essentials;
    [Tooltip("Settings for the PlayerMovement behavior.")]
    public PlayerMovementSettings settings;

    public bool StopAction { get; set; }
    private NavMeshAgent _agent;
    private Vector3 _desiredMovement;
    private Quaternion _desiredRotation;
    private bool _isMoving;
    private bool _isRotating;

    private void Start()
    {
      _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
      if (_isMoving
      && !_isRotating)
        Move();
    }

    /// <summary>
    /// Move the player towards a point in world space.
    /// </summary>
    /// <param name="point">Vector3 holding the X, Y, Z coordinates of the point in world space.</param>
    public void MoveTowards(Vector3 point)
    {
      _desiredMovement = point;
      _isMoving = true;
    }

    private void Move()
    {
      Debug.DrawLine(transform.position, _desiredMovement, Color.red);

      _agent.isStopped = false;
      _agent.SetDestination(_desiredMovement);

      if (transform.position == _desiredMovement)
        _isMoving = false;
    }

    /// <summary>
    /// Rotate the player towards a point in world space.
    /// </summary>
    /// <param name="point">Vector3 holding the X, Y, Z coordinates of the point in world space.</param>
    public IEnumerator LookAt(Vector3 point)
    {
      var direction = point - transform.position;
      _desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
      _isRotating = true;
      yield return Rotate();
    }

    private IEnumerator Rotate()
    {
      _agent.isStopped = true;
      while (_isRotating)
      {
        yield return transform.rotation = Quaternion.RotateTowards(transform.rotation, _desiredRotation, Time.deltaTime * (_agent.angularSpeed / ROTATION_DAMPING));

        // Stop rotating when the rotation is within 1 degree angle of the desired rotation.
        if (transform.rotation.Approximately(_desiredRotation, 1f))
          _isRotating = false;
      }
    }

    private void OnValidate() => Validate();
    private void Validate()
    {
      Assert.AreNotEqual(essentials.mask, 0, AssertErrorMessage.NotNull<LayerMask>(nameof(essentials.mask), gameObject));
    }
  }
}
