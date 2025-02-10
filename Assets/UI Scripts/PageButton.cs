using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageButton : MonoBehaviour
{
    [SerializeField] PagesPanels controller;
    [SerializeField] Image image;
    [SerializeField] GameObject panel;
    [SerializeField] Sprite activeSprite, inactiveSprite;
    [SerializeField] bool isPressed = false;

    private void Start()
    {
        Activate(isPressed);
        controller.InitButton(this);
    }
    public void OnClick()
    {
        controller.Activate(this);
    }
    public void Activate(bool active)
    {
        image.sprite = active ? activeSprite : inactiveSprite;
        if (panel)
            panel.SetActive(active);
    }
}
