using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class main_process2 : MonoBehaviour
{
    //variable
    int[] repeatindex;
    int repeatnumber = 10;
    int count = 0;
    int totalnumber = 0;
    int[] result = new int[4];
    
    float DarkTime = 0.2F;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject cross1;
    public GameObject cross2;
    public GameObject cursor;
    public Renderer rend1;
    public Renderer rend2;
    public Renderer rend3;
    public Renderer rend4;
    public GameObject network;
    public Material[] materials;
    public Material[] materials_on;
    public Material[] materials_off;
    public GameObject startbutton;
    Vector3 temp1 = new Vector3(0, 100, 5);
    Vector3 temp2 = new Vector3(0, 0, 5);
    long before = 0;
    long now = 0;
    long prints = 0;
    long debugtest = 0;
    bool end = false;
    bool training = false;
    int answer;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); //시간 재는 용 스톱워치, 단위 = ms
    // Use this for initialization

    void Start()
    {
        
        cross1.SetActive(false);
        cross2.SetActive(false);
        Random.seed = (int)System.DateTime.Now.Ticks; // 현재 시간으로 랜덤씨드 저장
        one = GameObject.Find("one");
        two = GameObject.Find("two");
        three = GameObject.Find("three");
        four = GameObject.Find("four");//오브젝트 찾기
        rend1 = one.GetComponent<Renderer>();
        rend2 = two.GetComponent<Renderer>();
        rend3 = three.GetComponent<Renderer>();
        rend4 = four.GetComponent<Renderer>();//오브젝트의 렌더러 찾기
        if(StaticClass.totalnumber == 0) setanswersheet(); // 정답 표 생성. 1~24 + 1~ 얼마 만큼을 더 추가해 랜덤으로 섞음. 처음에만 실행.
        setcase(StaticClass.blinksheet[0]); // 0번 정답 세팅
        rend1.sharedMaterial = materials_off[0];
        rend2.sharedMaterial = materials_off[1];
        rend3.sharedMaterial = materials_off[2];
        rend4.sharedMaterial = materials_off[3]; // 모든 자극물 색깔 리셋.
        network.SendMessage("Send", "#M#"); // M = testing
        //startbutton.transform.localPosition = temp1; // 시작버튼 치우기
        DarkTime = StaticClass.blinktime- 0.010F; // 0.01F는 일부러 뺌, 살짝 오버할경우 다음프레임이 되어 100ms가 130ms로 바뀜. 엔진문제
        repeatnumber = StaticClass.repeat_per_trial; // 전역변수에서 값 불러오기
        StartBlink(); // 자극 시작
    }

    // Update is called once per frame
    void Update()
    {

        if (end)
        {
            StaticClass.totalnumber++;
            end = false;
            if (StaticClass.totalnumber >= StaticClass.repeat_testfor2)
            {
                StaticClass.totalnumber = 0;
            }
            if (StaticClass.totalnumber >= StaticClass.repeat_test) // 트레이닝 종료 시
            {
                Debug.Log("END");
                SceneManager.LoadScene("textpic"); // 사진 찍는 부분으로 되돌아가기
            }
            else
            {
                setcase(StaticClass.blinksheet[StaticClass.totalnumber]); // 다음 자극 세트로 실행
                rend1.sharedMaterial = materials_off[0];
                rend2.sharedMaterial = materials_off[1];
                rend3.sharedMaterial = materials_off[2];
                rend4.sharedMaterial = materials_off[3]; // 자극물 리셋
                waitfortraining();
            }
        }
    }

    void waitfortraining()
    {
        StartCoroutine(waiting()); // 테스트 시작 버튼 누르기 기다리기
    }
    IEnumerator waiting() // 기다리기 함수.
    {
        startbutton.transform.localPosition = temp2; // 버튼 등장
        while (true)
        {

            yield return new WaitForSeconds(0.5F);
            if (StaticClass.received)
            { 
                //Debug.Log("check");
                StaticClass.received = false;
                break;
            }
        }
        startbutton.transform.localPosition = temp1; // 버튼 치우기
        blink(); // 자극 시작
    }
    void continues()
    {
       // Debug.Log("received");
        StaticClass.received = true;
    }
    // control instances
    void StartBlink()
    {
        
        int beforeindex = 0; // 직전 자극의 마지막값, 바로 연속으로 같은 자극이 나타나지 않게 하기 위해서 필요
        int nextindex; // 시작 값을 결정하는 변수
        int randomend; // 끝 값 랜덤으로 결정하는 변수
        int pick = 1; // 처음과 끝이 정해질 경우 2가지 케이스를 골라내기 위한 변수
        int switchprocess;
        repeatindex = new int[repeatnumber * 4];// 생성
        for (int i = 0; i < repeatnumber; i++)
        {
            pick = Random.Range(1, 3); //1~2 랜덤
            nextindex = Random.Range(1, 4); // 1~3 랜덤
            randomend = Random.Range(1, 4); // 1~3 랜덤
            if (beforeindex <= nextindex) nextindex++; // nextindex가 beforeindex와 같거나 클경우 변경
            if (nextindex <= randomend) randomend++; // randomend가 
            switchprocess = nextindex * 100 + randomend * 10 + pick; // 3가지 변수를 이용한 진리표
            beforeindex = randomend; // 마지막 값을 beforeindex에 넣어서
            nextindex = 0; //초기화
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
        waitfortraining();// 다음 테스트 기다리기 함수
    }
    void blink()
    {
        StartCoroutine(total()); // 깜빡임 시작
    }
    IEnumerator total()
    {
        cross1.SetActive(true);
        cross2.SetActive(true);// 집중용 십자가 등장
        cursor.SetActive(false); // 커서 없애기
        yield return new WaitForSeconds(1F);
        cross1.SetActive(false);
        cross2.SetActive(false);//십자가 제거
        sw.Start();//스탑워치 시작시점
        now = sw.ElapsedMilliseconds;
        prints = now - before;// 지연시간 측정
        before = now;
        debugtest += prints; 
        //Debug.Log("start :" + prints + " real : " + sw.ElapsedMilliseconds); 
        network.SendMessage("Send", prints + "#x#"); // 11번 트리거
        answer = StaticClass.answersheet[StaticClass.totalnumber]; // 정답 불러오기
        switch (answer) // 정답 화면 세팅
        {
            case 0:
                rend1.sharedMaterial = materials_on[0];
                break;
            case 1:
                rend2.sharedMaterial = materials_on[1];
                break;
            case 2:
                rend3.sharedMaterial = materials_on[2];
                break;
            case 3:
                rend4.sharedMaterial = materials_on[3];
                break;
        }
        yield return new WaitForSeconds(1F);
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 지연시간 측정
        before = now;
        debugtest += prints;

        //Debug.Log("answer :" + prints + " real : " + sw.ElapsedMilliseconds); 
        //Debug.Log(answer);
        //Debug.Log(result[answer]);
        switch (answer) // 정답 미리 보내기
        {
            case 0:
                network.SendMessage("Send", prints + "#a#");
                break;
            case 1:
                network.SendMessage("Send", prints + "#b#");
                break;
            case 2:
                network.SendMessage("Send", prints + "#c#");
                break;
            case 3:
                network.SendMessage("Send", prints + "#d#");
                break;
        }
        network.SendMessage("Send", result[0] + "#&1#" + result[1]+ "#&2#" +result[2]+ "#&3#" + result[3] + "#&4#"); // result[a] 번 문양이 b번째 자리에 위치했다. 원래 기본 1234 기준으로..
        yield return new WaitForSeconds(1F);
        switch (answer) // 정답 화면 초기화
        {
            case 0:
                rend1.sharedMaterial = materials_off[0];
                break;
            case 1:
                rend2.sharedMaterial = materials_off[1];
                break;
            case 2:
                rend3.sharedMaterial = materials_off[2];
                break;
            case 3:
                rend4.sharedMaterial = materials_off[3];
                break;
        }
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 지연시간 측정
        before = now;
        debugtest += prints;
        //Debug.Log("ready :" + prints + " real : " + sw.ElapsedMilliseconds);
        network.SendMessage("Send", prints +"#y#"); // 12번 트리거
        yield return new WaitForSeconds(0.5F); 
        for (int i = 0; i < repeatnumber * 4; i++)//총 반복횟수 * 4만큼 반복(각 자극 마다 반복횟수만큼 해야하기 때문에)
        {
            yield return StartCoroutine(on());// 깜빡임
        }
        yield return new WaitForSeconds(0.5F);
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 지연시간 측정
        before = now;
        debugtest += prints;
        yield return new WaitForSeconds(0.5F);
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 지연시간 측정
        before = now;
        debugtest += prints;
        //Debug.Log("end :" + prints + " real : " + sw.ElapsedMilliseconds + " testing : " + debugtest); //테스트용 디버그 코드
        network.SendMessage("Send", prints + "#z#"); //13번 트리거
        yield return new WaitForSeconds(1F);
        cursor.SetActive(true); // 커서 다시 등장
        end = true;
        now = 0;
        prints = 0;
        before = 0;
        debugtest = 0; // 리셋
        sw.Stop();//스탑워치 중지
        sw.Reset(); // 스탑워치 리셋
    }
    IEnumerator on()
    {
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 시간지연 측정
        before = now;
        debugtest += prints;
       // Debug.Log("start :" + prints + " real : " + sw.ElapsedMilliseconds);
        switch (repeatindex[count]) // 현재 자극 녹색으로 전환
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
        switch (repeatindex[count]) //현재 자극 파랑으로 리셋
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
        count++; // 자극 진행 횟수 기록
        if (count >= repeatnumber * 4) // 다 끝났을경우 리셋
        {
            count = 0;
        }
    }
    void setcase(int a) // 자극의 위치 지정 함수. 총 24가지 케이스 4P4 = 24. 0~23이 인풋
    {
        ////////////////////////////////////
        ///0: 1234 6: 2134
        ///1: 1243 7: 2143
        ///2: 1324 8: 2314
        ///3: 1342 ...
        ///4: 1423
        ///5: 1432
        /////////////////////////////////////
        int casea = (a / 6) + 1; // 1~23까지 숫자를 6으로 나눈 몫 + 1을 1번 자리로 이동(1,2,3,4)
        int caseb = ((a % 6) / 2) + 1; //1~23까지 숫자를 6으로 나눈 나머지를 2로 나눠서  1을 더해 2번째 자리로 놓는다.
        int casec = a % 2; // 홀수인지 짝수인지 구별
        bool[] abcd = new bool[4]; //1234 자리 있는지 확인하기 위한 변수
        for (int i = 0; i < 4; i++) // 초기화
        {
            abcd[i] = true;
        }
        //result 함수는 0123 순서대로 왼쪽 위 오른쪽 위 왼쪽 아래 오른쪽 아래의 자극 번호를 의미한다, 들어가야하는값은 1234
        result[0] = casea; // casea 변수 그대로 대입 
        result[1] = caseb; // caseb 변수 그대로 대입
        if (result[0] == result[1]) result[1]++; // 같을경우 b를 하나 더 늘린다. b를 늘리는 이유는 a = 1~4, b= 1~3 이 되서 b 가 한칸 여유가 있기때문
        abcd[result[0] - 1] = false; // result 0값을 abcd bool 0번 변수에 저장
        abcd[result[1] - 1] = false;// result 1값을 abcd bool 1번 변수에 저장
        for (int i = 0; i < 4; i++)// 1234가 true(존재하지 않을 때)만 실행
        {
            if (abcd[i])// i가 존재하지 않을경우
            {
                if (casec == 1)// 홀수이면
                {
                    result[2] = i + 1; // 2번에 저장
                    casec = 2; // 짝수로 변경
                    abcd[i] = false;
                }
                else
                {
                    result[3] = i + 1; // 3번에 저장
                    casec = 1; // 홀수로 변경
                    abcd[i] = false;
                }
            }
        }
        for(int i =0; i < 4; i++) // 순서에 맞춰서 material 세팅
        {
            materials_off[i] = materials[2 * result[i] -2];
            materials_on[i] = materials[2 * result[i] - 1];
        }
    }
    void setanswersheet()// 정답 및 자극 위치 세팅
    {
        
        int a;
        int b;
        int temp;
        for(int i = 0; i < StaticClass.repeat_testfor2; i++) //초기화, 
        {
            StaticClass.blinksheet[i] = i % 24; // 0~23
            StaticClass.answersheet[i] =i % 4; // 0~3
        }
        for(int i = 0; i < 1000; i++) // 1000번 랜덤한 위치 골라 섞기, 같은위치면 섞이지 않음
        {
            a = Random.Range(0, StaticClass.repeat_testfor2);
            b = Random.Range(0, StaticClass.repeat_testfor2); // 선택
            temp = StaticClass.blinksheet[a];
            StaticClass.blinksheet[a] = StaticClass.blinksheet[b];
            StaticClass.blinksheet[b] = temp;// 교체
            a = Random.Range(0, StaticClass.repeat_testfor2);
            b = Random.Range(0, StaticClass.repeat_testfor2); // 선택
            temp = StaticClass.answersheet[a];
            StaticClass.answersheet[a] = StaticClass.answersheet[b];
            StaticClass.answersheet[b] = temp;// 교체
        }
       
    }

}