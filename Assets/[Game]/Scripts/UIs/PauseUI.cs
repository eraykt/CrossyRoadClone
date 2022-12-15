using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private int timer = 3;

    [Header("References")]
    [SerializeField] private Button btnUnpause;
    [SerializeField] private TextMeshProUGUI txtTimer;


    public void OnUnpause()
    {
        // Reset timer text
        UpdateTimerTxt();
        // Change active of btn and txt
        SetUIPause(false);
        // Start timer
        StartCoroutine(UnpauseTimer());
    }

    IEnumerator UnpauseTimer()
    {
        // Store timer
        var temp = timer;

        while(timer != 0)
        {
            yield return new WaitForSecondsRealtime(1);
            timer--;
            UpdateTimerTxt();
        }

        // Reset timer
        timer = temp;
        OnTimerEnd();
    }

    private void OnTimerEnd()
    {
        // Close pause panel
        gameObject.SetActive(false);
        // Reset active of btn and txt to later use
        SetUIPause(true);

        // TO DO :: GameManager.Instance.OnGameUnpaused();
    }

    # region Update UI

    private void UpdateTimerTxt()
    {
        txtTimer.text = timer.ToString();
    }
    private void SetUIPause(bool paused)
    {
        btnUnpause.gameObject.SetActive(paused);
        txtTimer.gameObject.SetActive(!paused);
    }

    # endregion


}
