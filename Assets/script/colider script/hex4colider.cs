using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hex4colider : MonoBehaviour {
    public GameObject ui;
    public Renderer rend;
    public Material []mat;
    public GameObject[] obj;
    int frame = 0;
    public void OnTriggerStay(Collider other)
    {
        frame++;
        rend.sharedMaterial = mat[1];
        if (frame > 70)
        {
            frame = 0;
            rend.sharedMaterial = mat[0];
            ui.SendMessage("changescene");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        rend.sharedMaterial = mat[0];
        frame = 0;
    }
}
