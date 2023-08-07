using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WishList", menuName = "WishList")]
public class WishListScriptible : ScriptableObject
{
    public List<GameObject> WishList = new List<GameObject>();
}
