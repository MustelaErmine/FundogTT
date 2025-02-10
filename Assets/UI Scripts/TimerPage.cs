using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerPage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh, title;
    float timeStarted;
    bool paused = false;
    void Start()
    {
        timeStarted = Time.realtimeSinceStartup;
    }
    void SetSeconds(float seconds)
    {
        textMesh.text = $"{(int)(seconds / 60)}:{(int)(seconds % 60)}";
    }
    void Update()
    {
        if (!paused)
        {
            SetSeconds(Time.realtimeSinceStartup - timeStarted);
        }
    }
    public void Stop()
    {
        paused = true;
        title.text = textMesh.text;
    }
}
