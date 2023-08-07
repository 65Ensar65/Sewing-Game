using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishListNullController : MonoBehaviour
{
    public WishListScriptible WishListScriptibles;
    public Transform List;

    private void Start()
    {
        WishListScriptibles.WishList.Clear();
        for (int i = 0; i < List.childCount; i++)
        {
            WishListScriptibles.WishList.Add(List.GetChild(i).gameObject);
        }
    }
    private void Update()
    {
        if (WishListScriptibles.WishList.Count == 0)
        {
            GameManager.Instance.GetActiveWinPanel();
            gameObject.SetActive(false);
        }
    }
}
