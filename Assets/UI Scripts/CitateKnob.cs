using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CitateKnob : MonoBehaviour
{
    [SerializeField] Citates citate;
    [SerializeField] TextMeshProUGUI title, text;
    [SerializeField] Image image;
    static List<CitateKnob> buttons = new List<CitateKnob>();

    private void Start()
    {
        buttons.Add(this);
    }
    public void OnClick()
    {
        foreach (var knob in buttons)
        {
            knob.Activate(knob == this);
        }
    }
    void Activate(bool active)
    {
        image.color = active ? new Color(0xD2 / 255f, 0x10 / 255f, 0x11 / 255f) : Color.white;
        if (active)
        {
            title.text = citate.title;
            text.text = citate.text;
        }
    }
}
