using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text clickText;
    public Text coinText;

    public void SetClick(int score)
    {
        clickText.text = score.ToString();
    }

    public void SetCoin(int score)
    {
        coinText.text = score.ToString();
    }
}