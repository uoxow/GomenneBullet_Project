using UnityEngine;
using TMPro; 

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    void Start()
    {
        countdownText.text = "";
    }

    public void UpdateCountdownText(string message)
    {
        countdownText.text = message;
    }

    public void HideCountdown()
    {
        countdownText.gameObject.SetActive(false);
    }
}