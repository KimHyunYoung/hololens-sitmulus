using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stimuluscontrol : MonoBehaviour {
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    // Use this for initialization
    void Start () {
        one = GameObject.Find("one");
        two = GameObject.Find("two");
        three = GameObject.Find("three");
        four = GameObject.Find("four");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void SettingSize(float size)
    {
        one.transform.localScale = new Vector3(size, 1F, size);
        two.transform.localScale = new Vector3(size, 1F, size);
        three.transform.localScale = new Vector3(size, 1F, size);
        four.transform.localScale = new Vector3(size, 1F, size);
    }
}

