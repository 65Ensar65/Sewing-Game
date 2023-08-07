using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullCheck : Base
{
    public BoxCollider MachineCollider;

    void Update()
    {
        if (transform.childCount == 0)
        {
            MachineCollider.enabled = true;
        }

        else if(transform.childCount >= 1)
        {
            MachineCollider.enabled = false;
        }
    }
}
