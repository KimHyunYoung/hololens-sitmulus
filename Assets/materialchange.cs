using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class materialchange : MonoBehaviour {
    public Material[] material;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Changetowhite()
    {
        rend.sharedMaterial = material[0];
    }
    void Changetored()
    {
        rend.sharedMaterial = material[1];
    }
}
