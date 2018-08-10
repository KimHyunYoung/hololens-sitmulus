using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_total : MonoBehaviour {

    bool nottwice = true;
    int counter = 0;
    public GameObject process;
    public void OnTriggerStay(Collider other)
    {
        if (nottwice)
        {
            counter++;
        }
        if (counter > StaticClass.second)
        {
            counter = 0;
            process.SendMessage("Rp_total");
            nottwice = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        counter = 0;
        nottwice = true;
    }
}
