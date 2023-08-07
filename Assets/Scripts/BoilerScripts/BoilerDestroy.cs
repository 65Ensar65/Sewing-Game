using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerDestroy : MonoBehaviour
{
    public GameObject Boiler;
    void Start()
    {
        Boiler = GameManager.Instance.Boiiler;
        Boiler.GetComponent<BoxCollider>().enabled = true;
        Boiler.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
    }
}
