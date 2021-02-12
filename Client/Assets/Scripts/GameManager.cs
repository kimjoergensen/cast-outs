using CastOuts.Shared.Utility;
using UnityEngine;

namespace CastOuts
{
  public class GameManagerEssentials
  {

  }

  public class GameManagerSettings
  {

  }

  /// <summary>
  /// Manages the state of the game.
  /// </summary>
  /// <remarks>Keeps track of rounds, score.</remarks>
  /// <seealso cref="Utility.Singleton{GameManager}"/>
  public class GameManager : Singleton<GameManager>
  {
    #region Inspector menues
    [Tooltip("Essential components for the GameManager script.")]
    public GameManagerEssentials essentials;
    [Tooltip("Settings for the GameManager behavior.")]
    public GameManagerSettings settings;
    #endregion

    #region Class variables

    #endregion

    /// <summary>
    /// Prevents a default instance of the <see cref="GameManager"/> class from being created.
    /// </summary>
    private GameManager() { }

    private void Awake()
    {
      InitGame();
    }

    /// <summary>Initializes the game.</summary>
    private void InitGame()
    {

    }

    #region Validation
    private void OnValidate() => Validate();

    /// <summary>Validates this instance.</summary>
    private void Validate()
    {

    }
    #endregion
  }
}
