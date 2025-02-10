using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesPanels : MonoBehaviour
{
    List<PageButton> buttons = new List<PageButton>();
    public void InitButton(PageButton button)
    {
        buttons.Add(button);
    }
    public void Activate(PageButton source)
    {
        foreach (var button in buttons)
        {
            button.Activate(button == source);
        }
    }
}
