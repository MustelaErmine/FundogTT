using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TrainAtlas", menuName="Object/TrainAtlas")]
public class TrainAtlas : ScriptableObject
{
    public Train[] trains;
}
