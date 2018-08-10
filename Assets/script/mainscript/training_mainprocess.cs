using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class training_mainprocess : MonoBehaviour
{
   
    //variable
    int[] repeatindex;
    int repeatnumber = 10;
    int count = 0;
    int totalnumber = 0;
    int[] result = new int[4];
    int[] blinksheet = new int[StaticClass.repeat_total];
    int[] answersheet = new int[StaticClass.repeat_total];
    float DarkTime = 0.2F;
    public Renderer rend1;
    public Renderer rend2;
    public Renderer rend3;
    public Renderer rend4;
    public GameObject network;
    public GameObject cross1;
    public GameObject cross2;
    public Material[] materials;
    public Material[] materials_on;
    public Material[] materials_off;
    long before = 0;
    long now = 0;
    long prints = 0;
    long debugtest = 0;
    bool end = false;
    bool training = true;
    int answer;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); //시간 재는 용 스톱워치, 단위 = ms
    // Use this for initialization

    void Start()
    {
        cross1.SetActive(false);
        cross2.SetActive(false); // 십자가 제거
        Random.seed = (int)System.DateTime.Now.Ticks; //랜덤 시드 정하기
        setanswersheet(); // 정답, 자극위치 미리 표 만들기
        setcase(blinksheet[0]); // 첫 표의 이미지 세팅
        network.SendMessage("Send", "#K#"); // K = training
        DarkTime = StaticClass.blinktime - 0.010F; // 0.01F는 일부러 뺌, 살짝 오버할경우 다음프레임이 되어 100ms가 130ms로 바뀜
        repeatnumber = StaticClass.repeat_per_trial; // 전역변수에서 값 불러오기
        StartCoroutine(beforestart()); // 자극 시작
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            totalnumber++;
            end = false;
            if (totalnumber >= StaticClass.repeat_total) // 트레이닝 종료 시
            {
                totalnumber = 0; // 숫자 0부터
                training = false;//테스트로 세팅
                Debug.Log("END");
                Application.Quit(); // 끝날경우 앱 종료
            }
            else
            {
                setcase(blinksheet[totalnumber]);
                StartBlink(); // 트레이닝
            }
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
            } // 겹치지 않게 테이터 세팅하는 표
        }
        blink();
    }
    void blink()
    {
        StartCoroutine(total()); // 깜빡임 시작
    }
    IEnumerator beforestart()
    {
        yield return new WaitForSeconds(5F);
        StartBlink();
    }
    IEnumerator total()
    {
        Debug.Log("now play" + totalnumber + "th time");
        cross1.SetActive(true);
        cross2.SetActive(true);
        yield return new WaitForSeconds(1F);
        cross1.SetActive(false);
        cross2.SetActive(false);
        sw.Start();
        now = sw.ElapsedMilliseconds;
        prints = now - before;
        before = now;
        debugtest += prints;
        //Debug.Log("start :" + prints + " real : " + sw.ElapsedMilliseconds);
        network.SendMessage("Send", prints + "#x#");
        answer = answersheet[totalnumber];
        switch (answer)
        {
            case 1:
                rend1.sharedMaterial = materials_on[0];
                break;
            case 2:
                rend2.sharedMaterial = materials_on[1];
                break;
            case 3:
                rend3.sharedMaterial = materials_on[2];
                break;
            case 4:
                rend4.sharedMaterial = materials_on[3];
                break;
        }
        yield return new WaitForSeconds(0.5F);
        now = sw.ElapsedMilliseconds;
        prints = now - before;
        before = now;
        debugtest += prints;
        //Debug.Log("answer :" + prints + " real : " + sw.ElapsedMilliseconds);
        Debug.Log("answer = " + answer);
        switch (answer)
        {
            case 1:
                if (training) network.SendMessage("Send", prints + "#a#");
                break;
            case 2:
                if (training) network.SendMessage("Send", prints + "#b#");
                break;
            case 3:
                if (training) network.SendMessage("Send", prints + "#c#");
                break;
            case 4:
                if (training) network.SendMessage("Send", prints + "#d#");
                break;
        }
        yield return new WaitForSeconds(0.5F);
        network.SendMessage("Send", "1#&1#2#&2#3#&2#4#&2#");
        yield return new WaitForSeconds(1F);
        switch (answer)
        {
            case 1:
                rend1.sharedMaterial = materials_off[0];
                break;
            case 2:
                rend2.sharedMaterial = materials_off[1];
                break;
            case 3:
                rend3.sharedMaterial = materials_off[2];
                break;
            case 4:
                rend4.sharedMaterial = materials_off[3];
                break;
        }
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 지연시간 측정
        before = now;
        debugtest += prints;
        //Debug.Log("ready :" + prints + " real : " + sw.ElapsedMilliseconds);
        network.SendMessage("Send", prints + "#y#");
        yield return new WaitForSeconds(0.5F);
        for (int i = 0; i < repeatnumber * 4; i++) // 깜빡임
        {
            yield return StartCoroutine(on());
        }
        yield return new WaitForSeconds(1F);
        now = sw.ElapsedMilliseconds;
        prints = now - before;
        before = now;
        debugtest += prints;
        //Debug.Log("end :" + prints + " real : " + sw.ElapsedMilliseconds + " testing : " + debugtest); //테스트용 디버그 코드
        network.SendMessage("Send", prints + "#z#");
        yield return new WaitForSeconds(1F);
        end = true;
        now = 0;
        prints = 0;
        before = 0;
        debugtest = 0;
        sw.Stop();
        sw.Reset();
    }
    IEnumerator on()
    {
        now = sw.ElapsedMilliseconds;
        prints = now - before;
        before = now;
        debugtest += prints;
        //Debug.Log("start :" + prints + " real : " + sw.ElapsedMilliseconds);
        switch (repeatindex[count])
        {
            case 1:
                rend1.sharedMaterial = materials_on[0];
                network.SendMessage("Send", prints + "#a#");
                break;
            case 2:
                rend2.sharedMaterial = materials_on[1];
                network.SendMessage("Send", prints + "#b#");
                break;
            case 3:
                rend3.sharedMaterial = materials_on[2];
                network.SendMessage("Send", prints + "#c#");
                break;
            case 4:
                rend4.sharedMaterial = materials_on[3];
                network.SendMessage("Send", prints + "#d#");
                break;
        }
        yield return new WaitForSeconds(DarkTime);
        switch (repeatindex[count])
        {
            case 1:
                rend1.sharedMaterial = materials_off[0];
                break;
            case 2:
                rend2.sharedMaterial = materials_off[1];
                break;
            case 3:
                rend3.sharedMaterial = materials_off[2];
                break;
            case 4:
                rend4.sharedMaterial = materials_off[3];
                break;
        }
        yield return new WaitForSeconds(DarkTime);
        count++;
        if (count >= repeatnumber * 4)
        {
            count = 0;
        }
    }
    void setcase(int a)
    {
        Debug.Log("setcase" + a);
        int casea = (a / 6) + 1;
        int caseb = ((a % 6) / 2) + 1;
        int casec = a % 2;
        bool[] abcd = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            abcd[i] = true;
        }
        result[0] = casea;
        result[1] = caseb;
        if (result[0] == result[1]) result[1]++;
        abcd[result[0] - 1] = false;
        abcd[result[1] - 1] = false;
        for (int i = 0; i < 4; i++)
        {
            if (abcd[i])
            {
                if (casec == 1)
                {
                    result[2] = i + 1;
                    casec = 2;
                    abcd[i] = false;
                }
                else
                {
                    result[3] = i + 1;
                    casec = 1;
                    abcd[i] = false;
                }
            }
        }
        for (int i = 0; i < 4; i++)
        {
            materials_off[i] = materials[2 * result[i] - 2];
            materials_on[i] = materials[2 * result[i] - 1];
        }

        rend1.sharedMaterial = materials_off[0];
        rend2.sharedMaterial = materials_off[1];
        rend3.sharedMaterial = materials_off[2];
        rend4.sharedMaterial = materials_off[3];
    }
    void setanswersheet()
    {
        
        int a;
        int b;
        int temp;
        for (int i = 0; i < StaticClass.repeat_total; i++)
        {
            blinksheet[i] = i % 24;
            answersheet[i] = (i % 4) + 1;
        }
        for (int i = 0; i < 1000; i++)
        {
            a = Random.Range(0, StaticClass.repeat_total);
            b = Random.Range(0, StaticClass.repeat_total);
            temp = blinksheet[a];
            blinksheet[a] = blinksheet[b];
            blinksheet[b] = temp;
            a = Random.Range(0, StaticClass.repeat_total);
            b = Random.Range(0, StaticClass.repeat_total);
            temp = answersheet[a];
            answersheet[a] = answersheet[b];
            answersheet[b] = temp;
        }

    }
}