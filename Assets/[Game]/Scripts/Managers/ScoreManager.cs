using kechigames.Singleton;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int CurrentClickPoint { get; private set; }
    public int CurrentCoin { get; private set; }

    public int TotalClickPoint { get; private set; }
    public int TotalCoin { get; private set; }


    public void SetScore(string scoreType, int score)
    {
        switch (scoreType)
        {
            case "click":
                CurrentClickPoint += score;
                UiActions.Instance.SetScoreHandler(scoreType, CurrentClickPoint);
                break;

            case "coin":
                CurrentCoin += score;
                UiActions.Instance.SetScoreHandler(scoreType, CurrentCoin);
                break;

            default:
                Debug.Log("Score type is not defined");
                return;
        }
    }

    public void ResetCurrentScore()
    {
        CurrentClickPoint = CurrentCoin = 0;
        UiActions.Instance.SetScoreHandler("click", CurrentClickPoint);
        UiActions.Instance.SetScoreHandler("coin", CurrentCoin);
    }
}