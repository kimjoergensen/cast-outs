namespace CastOuts
{
  using Assets.Scripts.Shared;

  /// <summary>
  /// Manages the state of the game.
  /// </summary>
  public class GameManager : Singleton<GameManager>
  {
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
