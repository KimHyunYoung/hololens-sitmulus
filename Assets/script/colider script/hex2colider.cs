using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hex2colider : MonoBehaviour
{
    public GameObject ui;
    public Renderer rend;
    public Material[] mat;
    public GameObject[] obj;
    public void resetcolor()
    {
        rend.sharedMaterial = mat[0]; // 자신 색 리셋
    }
    public void OnTriggerEnter(Collider other)
    {
        obj[0].SendMessage("resetcolor");//다른 색 변경
        obj[1].SendMessage("resetcolor");
        obj[2].SendMessage("resetcolor");
        rend.sharedMaterial = mat[1]; // 자신을 다른색으로
        ui.SendMessage("sethex");
    }
}
