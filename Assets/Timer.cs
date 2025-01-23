using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; // Arrastra aquí el Text desde la UI.
    public float startTime = 300f; // Tiempo inicial en segundos (5 minutos por defecto).

    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        currentTime = startTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}s", minutes, seconds);
    }
}
