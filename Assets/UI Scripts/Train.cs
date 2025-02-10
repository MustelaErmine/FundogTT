using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Train",menuName ="Object/Train")]
public class Train : ScriptableObject
{
    public int[] pullUps = new int[5];
    public bool isTest = false;
    public int rest;
}
