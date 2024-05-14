using UnityEngine;
using TMPro;

public class DisplayFinalTime : MonoBehaviour
{
    public TMP_Text timeDisplay;  // Assign this in the inspector

    void Start()
    {
        if (timeDisplay != null)
        {
            float finalTime = PlayerPrefs.GetFloat("FinalTime", 0);
            timeDisplay.text = FormatTime(finalTime);
        }
    }

    private string FormatTime(float elapsedTime)
    {
        int minutes = (int)elapsedTime / 60;
        int seconds = (int)elapsedTime % 60;
        return string.Format("Final Time : {0:00}:{1:00}", minutes, seconds);
    }
}
