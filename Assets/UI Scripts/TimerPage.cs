using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerPage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh, pauseText;
    [SerializeField] Image pausebtnImage;
    [SerializeField] Sprite pause, play; 
    float timeStarted;
    bool paused = false;
    bool started = false;
    float timeElapsed;
    void Start()
    {
        
    }
    void SetSeconds(float seconds)
    {
        seconds = seconds % 3600f;
        int minutes = (int)(seconds / 60);
        int secs = (int)(seconds % 60);
        string minutes10 = minutes < 10 ? "0" : "";
        string secs10 = secs < 10 ? "0" : "";
        textMesh.text = $"{minutes10}{minutes}:{secs10}{secs}";
    }
    void Update()
    {
        if (started && !paused)
        {
            SetSeconds(Time.realtimeSinceStartup - timeStarted + timeElapsed);
        }
    }
    public void PauseBtn()
    {
        if (!started)
        {
            timeElapsed = 0;
            timeStarted = Time.realtimeSinceStartup;
            started = true;
            paused = false;
            pausebtnImage.sprite= pause;
            pauseText.text = "Pause";
        }
        else
        {
            if (paused)
            {
                timeStarted = Time.realtimeSinceStartup;
                paused = false;
                pausebtnImage.sprite = pause;
                pauseText.text = "Pause";
            }
            else
            {
                timeElapsed += Time.realtimeSinceStartup - timeStarted;
                paused = true;
                pausebtnImage.sprite = play;
                pauseText.text = "Play";
            }
        }
    }
    public void Stop()
    {
        paused = false;
        started = false;
        textMesh.text = "00:00";
        pausebtnImage.sprite = play;
        pauseText.text = "Play";
    }
}
