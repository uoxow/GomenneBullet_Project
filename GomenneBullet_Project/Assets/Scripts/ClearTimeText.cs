using UnityEngine;
using TMPro; 


public class ClearTimeText : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI timeText;

    void Start()
    {
        timeText.text = "";
    }

    public void TimeText(string message)
    {
        timeText.text = message;
    }

    public void HideTime()
    {
        timeText.gameObject.SetActive(false);
    }
    public void DisplayTime()
    {
        timeText.gameObject.SetActive(true);
    }
}