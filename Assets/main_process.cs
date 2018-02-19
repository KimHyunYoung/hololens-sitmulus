using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class main_process : MonoBehaviour
{
    //variable
    int[] repeatindex;
    int repeatnumber = 10;
    int count = 0;
    bool SwitchColor = true;
    float DarkTime = 0.15F;
    float LightTime = 0.15F;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject network;
    public GameObject setting;
    public Material[] materials;
    bool end = false;
    // Use this for initialization
    void Start()
    {
        StartBlink();
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            end = false;
           StartCoroutine(total());
        }
    }


    // control instances
    void StartBlink()
    {
        int beforeindex = 1;
        int nextindex;
        int randomend;
        int pick = 1;
        int switchprocess;
        repeatindex = new int[repeatnumber * 4];
        for (int i = 0; i < repeatnumber; i++)
        {
            pick = Random.Range(1, 3);
            nextindex = Random.Range(1, 4);
            randomend = Random.Range(1, 4);
            if (beforeindex <= nextindex) nextindex++;
            if (nextindex <= randomend) randomend++;
            switchprocess = nextindex * 100 + randomend * 10 + pick;
            beforeindex = randomend;
            nextindex = 0;
            switch (switchprocess)
            {
                case 121:
                    repeatindex[i * 4] = 1;
                    repeatindex[i * 4 + 1] = 3;
                    repeatindex[i * 4 + 2] = 4;
                    repeatindex[i * 4 + 3] = 2;
                    break;
                case 122:
                    repeatindex[i * 4] = 1;
                    repeatindex[i * 4 + 1] = 4;
                    repeatindex[i * 4 + 2] = 3;
                    repeatindex[i * 4 + 3] = 2;
                    break;
                case 131:
                    repeatindex[i * 4] = 1;
                    repeatindex[i * 4 + 1] = 2;
                    repeatindex[i * 4 + 2] = 4;
                    repeatindex[i * 4 + 3] = 3;
                    break;
                case 132:
                    repeatindex[i * 4] = 1;
                    repeatindex[i * 4 + 1] = 4;
                    repeatindex[i * 4 + 2] = 2;
                    repeatindex[i * 4 + 3] = 3;
                    break;
                case 141:
                    repeatindex[i * 4] = 1;
                    repeatindex[i * 4 + 1] = 2;
                    repeatindex[i * 4 + 2] = 3;
                    repeatindex[i * 4 + 3] = 4;
                    break;
                case 142:
                    repeatindex[i * 4] = 1;
                    repeatindex[i * 4 + 1] = 3;
                    repeatindex[i * 4 + 2] = 2;
                    repeatindex[i * 4 + 3] = 4;
                    break;

                case 231:
                    repeatindex[i * 4] = 2;
                    repeatindex[i * 4 + 1] = 1;
                    repeatindex[i * 4 + 2] = 4;
                    repeatindex[i * 4 + 3] = 3;
                    break;
                case 232:
                    repeatindex[i * 4] = 2;
                    repeatindex[i * 4 + 1] = 4;
                    repeatindex[i * 4 + 2] = 1;
                    repeatindex[i * 4 + 3] = 3;
                    break;
                case 241:
                    repeatindex[i * 4] = 2;
                    repeatindex[i * 4 + 1] = 3;
                    repeatindex[i * 4 + 2] = 1;
                    repeatindex[i * 4 + 3] = 4;
                    break;
                case 242:
                    repeatindex[i * 4] = 2;
                    repeatindex[i * 4 + 1] = 1;
                    repeatindex[i * 4 + 2] = 3;
                    repeatindex[i * 4 + 3] = 4;
                    break;
                case 211:
                    repeatindex[i * 4] = 2;
                    repeatindex[i * 4 + 1] = 3;
                    repeatindex[i * 4 + 2] = 4;
                    repeatindex[i * 4 + 3] = 1;
                    break;
                case 212:
                    repeatindex[i * 4] = 2;
                    repeatindex[i * 4 + 1] = 4;
                    repeatindex[i * 4 + 2] = 3;
                    repeatindex[i * 4 + 3] = 1;
                    break;

                case 321:
                    repeatindex[i * 4] = 3;
                    repeatindex[i * 4 + 1] = 1;
                    repeatindex[i * 4 + 2] = 4;
                    repeatindex[i * 4 + 3] = 2;
                    break;
                case 322:
                    repeatindex[i * 4] = 3;
                    repeatindex[i * 4 + 1] = 4;
                    repeatindex[i * 4 + 2] = 1;
                    repeatindex[i * 4 + 3] = 2;
                    break;
                case 341:
                    repeatindex[i * 4] = 3;
                    repeatindex[i * 4 + 1] = 1;
                    repeatindex[i * 4 + 2] = 2;
                    repeatindex[i * 4 + 3] = 4;
                    break;
                case 342:
                    repeatindex[i * 4] = 3;
                    repeatindex[i * 4 + 1] = 2;
                    repeatindex[i * 4 + 2] = 1;
                    repeatindex[i * 4 + 3] = 4;
                    break;
                case 311:
                    repeatindex[i * 4] = 3;
                    repeatindex[i * 4 + 1] = 2;
                    repeatindex[i * 4 + 2] = 4;
                    repeatindex[i * 4 + 3] = 1;
                    break;
                case 312:
                    repeatindex[i * 4] = 3;
                    repeatindex[i * 4 + 1] = 4;
                    repeatindex[i * 4 + 2] = 2;
                    repeatindex[i * 4 + 3] = 1;
                    break;

                case 421:
                    repeatindex[i * 4] = 4;
                    repeatindex[i * 4 + 1] = 1;
                    repeatindex[i * 4 + 2] = 3;
                    repeatindex[i * 4 + 3] = 2;
                    break;
                case 422:
                    repeatindex[i * 4] = 4;
                    repeatindex[i * 4 + 1] = 3;
                    repeatindex[i * 4 + 2] = 1;
                    repeatindex[i * 4 + 3] = 2;
                    break;
                case 431:
                    repeatindex[i * 4] = 4;
                    repeatindex[i * 4 + 1] = 1;
                    repeatindex[i * 4 + 2] = 2;
                    repeatindex[i * 4 + 3] = 3;
                    break;
                case 432:
                    repeatindex[i * 4] = 4;
                    repeatindex[i * 4 + 1] = 2;
                    repeatindex[i * 4 + 2] = 1;
                    repeatindex[i * 4 + 3] = 3;
                    break;
                case 411:
                    repeatindex[i * 4] = 4;
                    repeatindex[i * 4 + 1] = 2;
                    repeatindex[i * 4 + 2] = 3;
                    repeatindex[i * 4 + 3] = 1;
                    break;
                case 412:
                    repeatindex[i * 4] = 4;
                    repeatindex[i * 4 + 1] = 3;
                    repeatindex[i * 4 + 2] = 2;
                    repeatindex[i * 4 + 3] = 1;
                    break;
                default:
                    break;
            }
        }   

        one = GameObject.Find("one");
        two = GameObject.Find("two");
        three = GameObject.Find("three");
        four = GameObject.Find("four");
        network = GameObject.Find("networkprocess");
        setting = GameObject.Find("stimulscontroller");
        //one.SendMessage("Changetored");
        //one.SendMessage("Changetowhite");
        if (!SwitchColor)
        { 
           one.SetActive(false);
           two.SetActive(false);
           three.SetActive(false);
           four.SetActive(false);
        }
        StartCoroutine(total());
    }
    IEnumerator total()
    {
        //setting.SendMessage("SettingSize", 0.02F);
        for (int i = 0; i < repeatnumber * 4; i++)
        {
            yield return StartCoroutine(on());
        }
        yield return new WaitForSeconds(5F);
        Debug.Log("END");
        end = true;
    }
    IEnumerator on()
    {
        yield return new WaitForSeconds(LightTime);
        switch (repeatindex[count])
        {
            case 1:
                if (SwitchColor)
                {
                    one.SendMessage("Changetored");
                }
                else
                {
                    one.SetActive(true);
                }
                network.SendMessage("Send", "1");
                break;
            case 2:
                if (SwitchColor)
                {
                    two.SendMessage("Changetored");
                }
                else
                {
                    two.SetActive(true);
                }
                network.SendMessage("Send", "2");
                break;
            case 3:
                if (SwitchColor)
                {
                    three.SendMessage("Changetored");
                }
                else
                {
                    three.SetActive(true);
                }
                network.SendMessage("Send", "3");
                break;
            case 4:
                if (SwitchColor)
                {
                    four.SendMessage("Changetored");
                }
                else
                {
                    four.SetActive(true);
                }
                network.SendMessage("Send", "4");
                break;
        }
        yield return new WaitForSeconds(DarkTime);
        switch (repeatindex[count])
        {
            case 1:
                if (SwitchColor)
                {
                   one.SendMessage("Changetowhite");
                }
                else
                {
                    one.SetActive(false);
                }
                break;
            case 2:
                if (SwitchColor)
                {
                    two.SendMessage("Changetowhite");
                }
                else
                {
                    two.SetActive(false);
                }
                break;
            case 3:
                if (SwitchColor)
                {
                    three.SendMessage("Changetowhite");
                }
                else
                {
                    three.SetActive(false);
                }
                break;
            case 4:
                if (SwitchColor)
                {
                    four.SendMessage("Changetowhite");
                }
                else
                {
                    four.SetActive(false);
                }
                break;
        }
        
        count++;
        if (count >= repeatnumber * 4)
        {
            one.SetActive(true);
            two.SetActive(true);
            three.SetActive(true);
            four.SetActive(true);
            count = 0;
        }
    }
}