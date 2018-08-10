using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiprocess : MonoBehaviour {
    int next_process = 0;//0 is default, 1 = blink, 2 = color
    public void changescene()
    {        
        switch (next_process)
        {
            case 1:
                Debug.Log("changescene stimulus");
                SceneManager.LoadScene("stimuls");
                break;
            case 2:
                Debug.Log("changescene colorstimuls");
                SceneManager.LoadScene("colorstimuls");
                break;
            case 3:
                Debug.Log("changescene hexagon");
                SceneManager.LoadScene("hexagon");
                break;
            default:
                break;
        }
    }
    public void reset()
    {
        next_process = 0;
        Debug.Log("reseted");
    }
    public void setblink()
    {
        next_process = 1;
        Debug.Log("setblink");
    }
    public void setcolor()
    {
        next_process = 2;
        Debug.Log("setcolor");
    }
    public void sethex()
    {
        next_process = 3;
        Debug.Log("sethex");
    }
}
