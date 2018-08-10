using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hex3colider : MonoBehaviour {
    public GameObject ui;
    public Renderer rend;
    public Material[] mat;
    public GameObject[] obj;
    public void resetcolor()
    {
        rend.sharedMaterial = mat[1];
    }
    public void OnTriggerEnter(Collider other)
    {
        obj[0].SendMessage("resetcolor");
        obj[1].SendMessage("resetcolor");
        obj[2].SendMessage("resetcolor");
        rend.sharedMaterial = mat[0];
        ui.SendMessage("setblink");
    }
}
