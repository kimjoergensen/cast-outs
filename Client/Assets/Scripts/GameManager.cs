namespace CastOuts
{
  using CastOuts.Shared;
  using System;
  using UnityEngine;

  /// <summary>
  /// Manages the state of the game.
  /// </summary>
  public class GameManager : Singleton<GameManager>
  {
    [Serializable]
    protected class Essentials
    {

    }

    [Serializable]
    protected class Settings
    {

    }

    [SerializeField]
    private Essentials essentials;
    [SerializeField]
    private Settings settings;

    /// <summary>
    /// Prevents a default instance of this class from being created.
    /// </summary>
    private GameManager() { }

    private void Awake() {
      InitGame();
    }

    /// <summary>Initializes the game.</summary>
    private void InitGame() {

    }
  }
}
