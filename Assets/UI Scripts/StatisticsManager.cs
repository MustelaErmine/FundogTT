using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField] GameObject parentDays;
    [SerializeField] Sprite activeCircle;
    void OnEnable()
    {
        for (int i = 0; i < 31; i++)
        {
            GameObject day = parentDays.transform.GetChild(7 + i).gameObject;
            if (i < PlayerPrefs.GetInt("day", 0))
                SetDayActive(day);
            day.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }
    void SetDayActive(GameObject gameObject)
    {
        gameObject.GetComponent<Image>().sprite = activeCircle;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
    }
}
