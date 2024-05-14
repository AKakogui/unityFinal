using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    public TMP_Text timerText; 

    private float startTime;
    private float pausedDuration = 0;
    private bool isPaused = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this GameObject persists across scenes
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startTime = Time.time;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TMP_Text foundTimerText = GameObject.Find("Timer Text")?.GetComponent<TMP_Text>();
        if (foundTimerText != null)
        {
            timerText = foundTimerText;
        }
        else
        {
            Debug.LogError("No object named 'Timer Text' with a TMP_Text component found in the scene.");
            
        }
    }

    void Update()
    {
        if (timerText != null && !isPaused)
        {
            float elapsedTime = Time.time - startTime - pausedDuration;
            string formattedTime = FormatTime(elapsedTime);
            timerText.text = formattedTime;
        }
    }

    public void ResumeTimer()
    {
        if (isPaused)
        {
            isPaused = false;
            startTime = Time.time;
        }
    }

    public void ResetTimer()
    {
        startTime = Time.time;
        pausedDuration = 0;
        isPaused = false; // Ensure the timer isn't paused when resetting
    }

    // Helper function to format the time string
    private string FormatTime(float elapsedTime)
    {
        int minutes = (int)elapsedTime / 60;
        int seconds = (int)elapsedTime % 60;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe 
    }

    public void StopTimer()
    {
        if (!isPaused)
        {
            isPaused = true;
            pausedDuration += Time.time - startTime;
        }
    }

    public float GetElapsedTime()
    {
        if (!isPaused)
        {
            return Time.time - startTime - pausedDuration;
        }
        return pausedDuration; // Return the last recorded paused duration if the timer is already paused
    }

}
