using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CitateKnob : MonoBehaviour
{
    [SerializeField] RectTransform content;
    const float xConst = -820;
    [SerializeField] Image image;
    [SerializeField] int num, outof = 6;

    float myNum;

    private void Start()
    {
        myNum = ((float)num) / outof - (0.5f / outof);
    }
    public void OnChange()
    {
        image.color = (Mathf.Abs(content.anchoredPosition.x / xConst + 1 - num) < .5f) ? new Color(0xD2 / 255f, 0x10 / 255f, 0x11 / 255f) : Color.white;
    }
}
