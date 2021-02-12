using System;
using CastOuts.Shared.DataTransferObjects;
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
    [Tooltip("Determines how fast the player moves.")]
    public float movementSpeed;
    [Tooltip("Set the rotational speed of the player, when they are moving or casting a spell.")]
    public float rotationSpeed;
  }

  [RequireComponent(typeof(NavMeshAgent))]
  public class PlayerMovement : MonoBehaviour
  {
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
      _agent.speed = settings.movementSpeed;
    }

    private void FixedUpdate()
    {
      if (_isMoving)
        Move();

      if (_isRotating)
        Rotate();
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

      _agent.SetDestination(_desiredMovement);

      if (transform.position == _desiredMovement)
        _isMoving = false;
    }

    /// <summary>
    /// Rotate the player towards a point in world space.
    /// </summary>
    /// <param name="point">Vector3 holding the X, Y, Z coordinates of the point in world space.</param>
    public void LookAt(Vector3 point)
    {
      var direction = point - transform.position;
      _desiredRotation = Quaternion.Euler(0, direction.y, 0);
      _isRotating = true;
    }

    private void Rotate()
    {
      transform.rotation = Quaternion.RotateTowards(transform.rotation, _desiredRotation, Time.deltaTime * settings.rotationSpeed);

      if (transform.rotation == _desiredRotation)
        _isRotating = false;
    }

    private void OnValidate() => Validate();
    private void Validate()
    {
      Assert.IsTrue(settings.movementSpeed.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(settings.movementSpeed), default, gameObject));
      Assert.IsTrue(settings.rotationSpeed.GreaterThan(default), AssertErrorMessage.GreaterThan(nameof(settings.rotationSpeed), default, gameObject));
      Assert.AreNotEqual(essentials.mask, 0, AssertErrorMessage.NotNull<LayerMask>(nameof(essentials.mask), gameObject));
    }
  }
}
