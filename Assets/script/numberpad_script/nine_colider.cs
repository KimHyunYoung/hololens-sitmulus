using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nine_colider : MonoBehaviour {
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
            process.SendMessage("Ninepush");
            nottwice = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        counter = 0;
        nottwice = true;
    }
}
