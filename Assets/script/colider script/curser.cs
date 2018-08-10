using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curser : MonoBehaviour {
    public GameObject ui;
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("colide");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "hexagon")
        {
            ui.SendMessage("reset");
        }
        else if (other.gameObject.name == "hexagon2")
        {
            ui.SendMessage("reset");
        }
        else if (other.gameObject.name == "hexagon2")
        {
            ui.SendMessage("setblink");
        }
        else if (other.gameObject.name == "hexagon2")
        {
            ui.SendMessage("changescene");
        }
        else if (other.gameObject.name == "hexagon2")
        {
            ui.SendMessage("reset");
        }
        else if (other.gameObject.name == "hexagon2")
        {
            ui.SendMessage("setcolor");
        }
    }
}
