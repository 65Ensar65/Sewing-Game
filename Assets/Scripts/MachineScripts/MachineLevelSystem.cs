using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineLevelSystem : Base
{
    public List<GameObject> Machine = new List<GameObject>();
    public int Index;

    public void GetMachine()
    {
        if (Index == 0 && Machine.Count >= 2)  
        {
            Machine[0].GetComponent<BoxCollider>().enabled = true;
            Machine[0].GetComponent<MachineController>().enabled = true;
            Machine[0].transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
            Machine[0].transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
            Index++;
        }
        else if (Index == 1 && Machine.Count >= 2)  
        {
            Machine[1].GetComponent<BoxCollider>().enabled = true;
            Machine[1].GetComponent<MachineController>().enabled = true;
            Machine[1].transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
            Machine[1].transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
            Index++;
        }
        else if (Index == 2)
        {
            GetComponent<MachineLevelSystem>().enabled = false;
        }
    }

}
