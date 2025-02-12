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
    [SerializeField] Scrollbar scrollbar;

    float myNum;
    [SerializeField] bool myElephant = false;

    private void Start()
    {
        myNum = ((float)num) / outof - (0.5f / outof);
    }
    public void OnChange()
    {
        myElephant = (Mathf.Abs(content.anchoredPosition.x / xConst + 1 - num) < .5f);
        image.color = myElephant ? new Color(0xD2 / 255f, 0x10 / 255f, 0x11 / 255f) : Color.white;
    }
    public void EndDrag()
    {
        if (myElephant)
        {
            StartCoroutine(SlideRoutine());
        }
    }
    IEnumerator SlideRoutine()
    {
        float startTime = Time.time;
        float startValue = scrollbar.value;
        float endValue = 1f / (outof - 1) * (num - 1);
        float secsForFinish = .3f * Mathf.Abs(startValue - endValue) / (1f / (outof - 1));
        while (startTime + secsForFinish > Time.time)
        {
            scrollbar.value = Mathf.Lerp(startValue, endValue, Mathf.Sin((Time.time - startTime) / secsForFinish));
            //print(scrollbar.value);
            yield return new WaitForEndOfFrame();
        }
        scrollbar.value = endValue;
    }
}
