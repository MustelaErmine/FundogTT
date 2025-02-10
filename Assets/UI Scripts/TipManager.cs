using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TipManager : MonoBehaviour
{
    [SerializeField] Tip[] tips;
    [SerializeField] TextMeshProUGUI textMesh;
    public void OnClick()
    {
        textMesh.text = tips[Random.Range(0, tips.Length)].tip;
    }
}
