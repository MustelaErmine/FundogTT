using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainController : MonoBehaviour
{
    [SerializeField] TrainAtlas atlas;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] GameObject[] panels;
    Train current;
    int currentStep = 0;
    int maxPulls = 0;
    void OnEnable()
    {
        currentStep = 0;
        int day = PlayerPrefs.GetInt("day", 0);
        current = atlas.trains[day];
        maxPulls = atlas.trains[day].pullUps.Max();
        for (int i = 0; i < 5; i ++)
        {
            SetPanelNumber(panels[i], atlas.trains[day].pullUps[i]);
            SetPanelActive(panels[i], false);
        }
        SetPanelActive(panels[0], true);
        textMesh.text = current.pullUps[0].ToString();
    }
    void SetPanelActive(GameObject panel, bool active)
    {
        Image image = panel.GetComponent<Image>();
        TextMeshProUGUI textMesh = panel.GetComponentInChildren<TextMeshProUGUI>();
        if (active)
        {
            image.color = Color.white;
            textMesh.color = Color.white;
        } else
        {
            image.color = new Color(0,0,0,0);
            textMesh.color = new Color(0x51/255f,0x51/255f,0x51/255f, 1f);
        }
    }
    void SetPanelNumber(GameObject panel, int number)
    {
        panel.GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
    }
    public void ClickDone()
    {
        currentStep++;
        if (currentStep > 4)
        {
            TrainManger.instance.Increase();
            PlayerPrefs.SetInt("maxPullups", maxPulls);
            gameObject.SetActive(false);
        } 
        else
        {
            SetPanelActive(panels[currentStep - 1], false);
            SetPanelActive(panels[currentStep], true);
            textMesh.text = current.pullUps[currentStep].ToString();
        }
    }
}
