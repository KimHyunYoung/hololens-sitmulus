using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_size2 : MonoBehaviour
{
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
            process.SendMessage("Per_trial");
            nottwice = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        counter = 0;
        nottwice = true;
    }
}
