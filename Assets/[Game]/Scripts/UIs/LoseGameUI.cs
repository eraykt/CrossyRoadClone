using UnityEngine;
using UnityEngine.UI;

public class LoseGameUI : MonoBehaviour
{
    #region ad panel

    [Header("Ad Panel")] public Image adPanel;
    public Button adButton;
    public Button noAdButton;

    public void ShowAd()
    {
        //TODO: show ad
        GameManager.Instance.Resume();
    }

    public void NoAd(bool closeAdPanel) // 2. ölümden sonra ad panelini tekrar açıyor
    {
        adPanel.gameObject.SetActive(!closeAdPanel);
        losePanel.gameObject.SetActive(closeAdPanel);
    }

    #endregion


    #region lose panel

    [Space] [Header("Lose Panel")] public Image losePanel;
    public Button restartButton;


    public void Restart()
    {
        GameManager.Instance.RestartGame();
        NoAd(false);
    }

    #endregion
}