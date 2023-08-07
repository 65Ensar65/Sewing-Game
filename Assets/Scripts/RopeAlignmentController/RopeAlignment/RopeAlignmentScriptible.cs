using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RopeAlignment", menuName = "RopeAlignment")]
public class RopeAlignmentScriptible : ScriptableObject
{
    public List<Transform> RopeList = new List<Transform>();
    public int ListIndex;
    public GameObject RopePos;
}