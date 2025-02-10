using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Citate", menuName = "Object/Citate")]
public class Citates : ScriptableObject
{
    public string title;
    [TextArea] public string text;
}
