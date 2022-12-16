using kechigames.Singleton;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool IsGameStarted { get; private set; }
    public bool IsGameEnded { get; private set; }

    #region Level

    public int LevelIndex { get; set; }

    #endregion


    #region Player

    public PlayerController player;

    #endregion

    private void Update()
    {
        OnGameStarting();
    }

    private void OnGameStarting()
    {
        if (!PlayerInputs.LeftClick) return;
        if (IsGameStarted) return;
        if (IsGameEnded) return;

        IsGameStarted = true;

        UiActions.Instance.HandleHomeUi?.Invoke(false);
        UiActions.Instance.HandleInGameUi?.Invoke(true);
    }

    public void OnLevelEnded(bool hasWon)
    {
        // IsGameStarted = false;
        IsGameEnded = true;

        UiActions.Instance.HandleInGameUi?.Invoke(false);

        if (hasWon)
        {
        }

        else
        {
            UiActions.Instance.HandleLoseGameUi?.Invoke(true);
        }
    }

    private void ResetGame()
    {
        IsGameEnded = false;
        IsGameStarted = false;

        // player.ResetPlayer();

        // LevelCreator.Instance.ResetAllCubes();

        UiActions.Instance.HandleHomeUi?.Invoke(true);
        UiActions.Instance.HandleInGameUi?.Invoke(false);
        UiActions.Instance.HandleLoseGameUi?.Invoke(false);
    }

    public void RestartGame()
    {
        ResetGame();
        // LevelCreator.Instance.CreateLevel(LevelIndex);
        ScoreManager.Instance.ResetCurrentScore();
    }

    public void Resume()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        // player.transform.position = new Vector3(player.LastCube.position.x, PlayerController.PlayerPositionY,
        //     player.LastCube.position.z);

        IsGameEnded = false;
        IsGameStarted = true;

        UiActions.Instance.HandleLoseGameUi?.Invoke(false);
        UiActions.Instance.HandleInGameUi?.Invoke(true);
    }

    public void NextLevel()
    {
        ResetGame();
        LevelIndex++;
    }
}