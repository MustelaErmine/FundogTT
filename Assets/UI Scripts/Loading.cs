using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] float loadingSeconds;
    [SerializeField] Slider slider;
    [SerializeField] string nextScene = "InGame";
    void Start()
    {
        StartCoroutine(LoadingRoutine());
    }
    IEnumerator LoadingRoutine()
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - loadingSeconds < startTime)
        {
            yield return null;
            slider.value = (Time.realtimeSinceStartup - startTime) / loadingSeconds;
        }
        SceneManager.LoadSceneAsync(nextScene);
    }
}
