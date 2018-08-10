using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class main_process : MonoBehaviour
{
    //variable
    int[] repeatindex;
    int repeatnumber = 10;
    int count = 0;  
    int totalnumber = 0;
    bool SwitchColor = false;
    float DarkTime = 0.2F;
    float LightTime = 0.2F;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public Renderer rend1;
    public Renderer rend2;
    public Renderer rend3;
    public Renderer rend4;
    public GameObject network;
    public GameObject setting;
    public Material[] materials;
    public GameObject[] hexobjects;
    bool end = false;
    // Use this for initialization
    void Start()
    {
        DarkTime = StaticClass.second;
        LightTime = StaticClass.second;
       StartBlink();   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (end)
        {
            totalnumber++;
            end = false;
            if (totalnumber < 40)
            {
                StartCoroutine(total());
            }
            else
            {
                totalnumber = 0;
                SceneManager.LoadScene("holo");
            }
        }
    }


    // control instances
    void setblink()
    {
        SwitchColor = false;
    }
    void setcolor()
    {
        SwitchColor = true;
    }
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
        rend1 = one.GetComponent<Renderer>();
        rend2 = two.GetComponent<Renderer>();
        rend3 = three.GetComponent<Renderer>();
        rend4 = four.GetComponent<Renderer>();
        setting = GameObject.Find("stimulscontroller");
        blink();
    }
    void blink()
    {
        StartCoroutine(total());
    }
    IEnumerator total()
    {
        yield return new WaitForSeconds(2F);
        network.SendMessage("Send", "11");

        yield return new WaitForSeconds(1.5F);
        int answer = repeatindex[count];
        switch (answer)
        {
            case 1:
                rend1.sharedMaterial = materials[2];
                break;
            case 2:
                rend2.sharedMaterial = materials[2];
                break;
            case 3:
                rend3.sharedMaterial = materials[2];
                break;
            case 4:
                rend4.sharedMaterial = materials[2];
                break;
        }
        network.SendMessage("Send", answer.ToString());
        yield return new WaitForSeconds(1F);
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        switch (answer)
        {
            case 1:
                rend1.sharedMaterial = materials[0];
                break;
            case 2:
                rend2.sharedMaterial = materials[0];
                break;
            case 3:
                rend3.sharedMaterial = materials[0];
                break;
            case 4:
                rend4.sharedMaterial = materials[0];
                break;
        }
        network.SendMessage("Send", "12");
        yield return new WaitForSeconds(DarkTime);
        for (int i = 0; i < repeatnumber * 40; i++)
        {
            yield return StartCoroutine(on());
        }
        yield return new WaitForSeconds(5F);
        network.SendMessage("Send", "13");
        end = true;
    }
    IEnumerator on()
    {
        
        switch (repeatindex[count])
        {
            case 1:
                if (SwitchColor)
                {
                    rend1.sharedMaterial = materials[1];
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
                    rend2.sharedMaterial = materials[1];
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
                    rend3.sharedMaterial = materials[1];
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
                    rend4.sharedMaterial = materials[1];
                }
                else
                {
                    four.SetActive(true);
                }
                network.SendMessage("Send", "4");
                break;
        }
        yield return new WaitForSeconds(LightTime);
        
        switch (repeatindex[count])
        {
            case 1:
                if (SwitchColor)
                {
                    rend1.sharedMaterial = materials[0];
                }
                else
                {
                    one.SetActive(false);
                }
                break;
            case 2:
                if (SwitchColor)
                {
                    rend2.sharedMaterial = materials[0];
                }
                else
                {
                    two.SetActive(false);
                }
                break;
            case 3:
                if (SwitchColor)
                {
                    rend3.sharedMaterial = materials[0];
                }
                else
                {
                    three.SetActive(false);
                }
                break;
            case 4:
                if (SwitchColor)
                {
                    rend4.sharedMaterial = materials[0];
                }
                else
                {
                    four.SetActive(false);
                }
                break;
        }
        yield return new WaitForSeconds(DarkTime);
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