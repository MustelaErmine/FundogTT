using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalsManager : MonoBehaviour
{
    int[] Goals { get => new int[] {10, 100}; } // may be easyly set by level or anything
    [SerializeField] TextMeshProUGUI[] goalsTexts;
    [SerializeField] Image[] goalsSliders;
    void OnEnable()
    {
        for (int i = 0; i < Goals.Length; i++)
        {
            float val = Mathf.Clamp01(PlayerPrefs.GetInt("maxPullups", 0)/(float)Goals[i]);
            goalsTexts[i].text = $"{(int)(val*100)}%";
            goalsSliders[i].fillAmount = val;
        }
    }
}
