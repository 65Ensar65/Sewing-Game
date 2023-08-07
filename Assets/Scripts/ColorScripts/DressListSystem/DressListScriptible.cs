using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "DressList", menuName = "DressList")]
public class DressListScriptible : ScriptableObject
{
    public List<Transform> DressList;
    public float DressSpeed;
    public GameObject DressPos;
    public int DressIndex;
}
