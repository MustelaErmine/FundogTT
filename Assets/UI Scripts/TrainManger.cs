using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainManger : MonoBehaviour
{
    [SerializeField] TrainAtlas atlas;
    [SerializeField] GameObject[] panels;
    public static TrainManger instance;
    private void Start()
    {
        instance = this;
        UpdateTrains();
    }
    public void UpdateTrains()
    {
        int lastday = PlayerPrefs.GetInt("day", 0);
        if (lastday >= atlas.trains.Length)
        {
            foreach (var panel in panels)
            {
                if (panel!= null)
                {
                    Destroy(panel);
                }
            }
        }
        int week = lastday / 4 * 4;
        for (int i = 0; i < 4; i++)
        {
            SetTrain(panels[i], atlas.trains[week + i], week + i);
        }
    }
    public void SetTrain(GameObject gameObject, Train train, int number)
    {
        bool interactable = number == PlayerPrefs.GetInt("day", 0);
        Transform panelTransfrom = gameObject.transform;
        if (!train.isTest)
        {
            panelTransfrom.GetChild(0).GetComponent<TextMeshProUGUI>().text = (number + 1).ToString();
            panelTransfrom.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"REST TIME - {train.rest} SEC";
            panelTransfrom.GetChild(4).GetComponent<Button>().interactable = interactable;

            Transform frame = panelTransfrom.GetChild(2);
            for (int i = 0; i < 5; i++)
            {
                frame.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = train.pullUps[i].ToString();
            }
        } 
        else
        {
            panelTransfrom.GetChild(0).GetComponent<TextMeshProUGUI>().text = (number + 1).ToString();
            panelTransfrom.GetChild(3).GetComponent<Button>().interactable = interactable;
        }
        panelTransfrom.GetComponent<Button>().interactable = interactable;
    }
    public void Increase()
    {
        PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day", 0) + 1);
        UpdateTrains();
    }
}
