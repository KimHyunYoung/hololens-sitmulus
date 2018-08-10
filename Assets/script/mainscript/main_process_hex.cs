using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_process_hex : MonoBehaviour
{
    //variable
    int[] repeatindex; //깜빡임 배열
    int repeatnumber = 10; // 매 트라이얼 반복횟수
    int count = 0;//깜빡임 카운터
    int totalnumber = 0; // 현재 
    float DarkTime = 0.2F;//깜빡이는 시간
    int answer = 0;//제시된 정답
    bool training = true;
    /// <summary>
    /// 회전및 재지정을 위한 vector3(3차원 벡터)
    /// </summary>
    Vector3 temp1;
    Vector3 temp2;
    Vector3 temp3;
    Vector3 temp4;
    Vector3 temp5;
    Vector3 temp6;
    Vector3 temp11;
    Vector3 temp21;
    Vector3 temp31;
    Vector3 temp41;
    Vector3 temp51;
    Vector3 temp61;

    Vector3 y1_1 = new Vector3(0.0F, 51.0F,0.0F);
    Vector3 y1_2 = new Vector3(0.0F, 102.0F, 0.0F);
    Vector3 y1_3 = new Vector3(0.0F, 154.0F, 0.0F);
    Vector3 y1_4 = new Vector3(0.0F, 205.0F, 0.0F);
    Vector3 y1_5 = new Vector3(0.0F, 256.0F, 0.0F);
    Vector3 y1_6 = new Vector3(0.0F, 307.0F, 0.0F);
    Vector3 y1_7 = new Vector3(0.0F, 0.0F, 0.0F);

    Vector3 y2_1 = new Vector3(0.0F, -51.0F, 0.0F);
    Vector3 y2_2 = new Vector3(0.0F, -102.0F, 0.0F);
    Vector3 y2_3 = new Vector3(0.0F, -154.0F, 0.0F);
    Vector3 y2_4 = new Vector3(0.0F, -205.0F, 0.0F);
    Vector3 y2_5 = new Vector3(0.0F, -256.0F, 0.0F);
    Vector3 y2_6 = new Vector3(0.0F, -307.0F, 0.0F);
    Vector3 y2_7 = new Vector3(0.0F, 0.0F, 0.0F);

    Vector3 x1_1 = new Vector3(51.0F, 0.0F, 0.0F);
    Vector3 x1_2 = new Vector3(102.0F, 0.0F, 0.0F);
    Vector3 x1_3 = new Vector3(154.0F, 0.0F, 0.0F);
    Vector3 x1_4 = new Vector3(205.0F, 0.0F, 0.0F);
    Vector3 x1_5 = new Vector3(256.0F, 0.0F, 0.0F);
    Vector3 x1_6 = new Vector3(307.0F, 0.0F, 0.0F);
    Vector3 x1_7 = new Vector3(0.0F, 0.0F, 0.0F);

    Vector3 x2_1 = new Vector3(-51.0F, 0.0F, 0.0F);
    Vector3 x2_2 = new Vector3(-102.0F, 0.0F, 0.0F);
    Vector3 x2_3 = new Vector3(-154.0F, 0.0F, 0.0F);
    Vector3 x2_4 = new Vector3(-205.0F, 0.0F, 0.0F);
    Vector3 x2_5 = new Vector3(-256.0F, 0.0F, 0.0F);
    Vector3 x2_6 = new Vector3(-307.0F, 0.0F, 0.0F);
    Vector3 x2_7 = new Vector3(0.0F, 0.0F, 0.0F);
    Vector3 tm1 = new Vector3(0, 0, 0);
    Vector3 tm2 = new Vector3(0, 100, 0);
    /// <summary>
    /// 벡터 종료
    /// </summary>
    long before = 0;
    long now = 0;
    long prints = 0;
    public GameObject[] obj;
    public Renderer[] rend;
    public GameObject network;
    public GameObject setting;
    public Material[] materials;
    public GameObject startbutton;
    bool end = false;
    float widepos = 0.483F; // 기본 지정 위치 3개
    float height1 = 0.55F; // 가장 높은 0번 3번 y좌표
    float height2 = 0.265F; // 나머지 4개 y좌표
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); // 시간재는 스탑워치
    // Use this for initialization
    float max(float a, float b) // .net사용불가로 직접 만든 max함수
    {
        if(a >= b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    void Start() // 시작 세팅
    {
        startbutton.transform.localPosition = tm2; // 시작버튼 올리기
        DarkTime = StaticClass.blinktime - 0.01F;// 실제로 하면 프레임 1개가 올라서 30ms가 추가됨
        repeatnumber = StaticClass.repeat_per_trial;//전역변수에서 값 불러오기
        temp2 = new Vector3(widepos * StaticClass.wide, height2, 0);
        temp3 = new Vector3(widepos * StaticClass.wide, -height2, 0);
        temp5 = new Vector3(-widepos * StaticClass.wide, -height2, 0);
        temp6 = new Vector3(-widepos * StaticClass.wide, height2, 0); // 좌우 자극 늘리기용 벡터 4개
        obj[1].transform.localPosition = temp2;
        obj[2].transform.localPosition = temp3;
        obj[4].transform.localPosition = temp5;
        obj[5].transform.localPosition = temp6; // 위치 재지정
        temp1 = new Vector3(0, height1, 0);
        temp4 = new Vector3(0, -height1, 0);  // 재조정
        temp11 = new Vector3(widepos * StaticClass.wide, 100, 0);
        temp21 = new Vector3(widepos * StaticClass.wide, 100, 0);
        temp31 = new Vector3(widepos * StaticClass.wide, 100, 0);
        temp41 = new Vector3(widepos * StaticClass.wide, 100, 0);
        temp51 = new Vector3(-widepos * StaticClass.wide, 100, 0);
        temp61 = new Vector3(-widepos * StaticClass.wide, 100, 0); // 자극 가릴때 자극이 갈 위치
        switch(StaticClass.screennumber){
            case 1:
            if (training) network.SendMessage("Send", "#*a#"); // 현재 세탁기임
            break;
            case 2:
            if (training) network.SendMessage("Send", "#*b#"); // 현재 전등임
            break;
            case 3:
            if (training) network.SendMessage("Send", "#*c#"); // 현재 로봇청소기임
            break;
        }
        StartCoroutine (StartBlink()); // 깜빡임 시작
    }

    // Update is called once per frame
    void Update()
    {
        
        if (end) // 1 트라이얼 깜빡임이 끝나면 end켜짐, 다음프레임에 실행
        {
            end = false; // 리셋
            if (totalnumber < StaticClass.repeat_total + StaticClass.repeat_test) // 아직 트레이닝 + 테스트 전체가 안끝낫을때.
            {
                if (totalnumber == StaticClass.repeat_total) // 트레이닝이 다 끝났을때
                {
                    training = false; // 트레이닝 제거
                }
                StartCoroutine(StartBlink()); // 시작
            }
            else // 다 끝낫을때
            {
                StaticClass.received5 = false;
                StaticClass.received = false; // 대기 해제
                count = 0;
                totalnumber = 0;
                answer = 0;// 초기화
                SceneManager.LoadScene("textpic"); // 사진 찍어 인식하는 곳으로 되돌아감
            }
            totalnumber++;
        }
    }
    void continues() // 대기 함수. 외부에서 수신하는 통로
    {
        if (!StaticClass.received5)
        {
            StaticClass.received5 = true; // 수신 완료
        }
    }

    // control instances
    IEnumerator StartBlink()
    {
        repeatindex = new int[(repeatnumber + 1) * 6]; // 총 자극 갯수만큼 생성
        repeatindex[0] = Random.Range(1, 7);// 1~6까지 랜덤
        repeatindex[1] = Random.Range(1, 6);// 1~5까지 랜덤
        repeatindex[2] = Random.Range(1, 5);// 1~4까지 랜덤
        repeatindex[3] = Random.Range(1, 4);// 1~3까지 랜덤
        repeatindex[4] = Random.Range(1, 3);// 1~2까지 랜덤
        repeatindex[5] = 1; // 마지막은 1 확정
        for (int j = 1; j < 6; j++) // 이중 중복되는 숫자가 나올경우 + 시켜서 뒤로 밀음. ex)223412-> 233412-> 234412-> 234512-> 234516 으로 겹치지 않음.
        {
            for (int k = 0; k < j; k++)
            {
                if (repeatindex[k] == repeatindex[j])
                {
                    repeatindex[j]++; // 겹칠경우 뒤로 밀음
                    k = -1; // 처음부터 스캔
                }
            }
        }
        for (int i = 1; i <= repeatnumber; i++) // 첫 부분에는 전 값이 없어서 처음에 하나만 따로 처리, 나머지는 for 문으로 반복해서 실행
        {
            repeatindex[i * 6] = Random.Range(1, 7); //1~6
            repeatindex[i * 6 + 1] = Random.Range(1, 6); //1~5
            repeatindex[i * 6 + 2] = Random.Range(1, 5); //1~4
            repeatindex[i * 6 + 3] = Random.Range(1, 4); // 1~3
            repeatindex[i * 6 + 4] = Random.Range(1, 3); // 1~2
            repeatindex[i * 6 + 5] = 1; //1만
            for (int j = 1; j < 6; j++) // 123456만 포함되게,  523211 -> 523416 으로 겹치지 않는 고유의 순서 생성
            {
                for (int k = 0; k < j; k++)
                {
                    if (repeatindex[i * 6 + k] == repeatindex[i * 6 + j])
                    {
                        repeatindex[i * 6 + j]++;
                        k = -1;
                    }
                }
            }
            if (repeatindex[i * 6] == repeatindex[i * 6 - 1]) // 전 자극값과 겹칠경우 교대
            {
                int temp;
                temp = repeatindex[i * 6];
                repeatindex[i * 6] = repeatindex[i * 6 + 1];
                repeatindex[i * 6 + 1] = temp;
            }
        }

        if (training)
        {
            yield return StartCoroutine(total()); // 트레이닝용 자극
        }
        else
        {
            yield return StartCoroutine(wait5()); // 테스트용 자극
        }

    }
    IEnumerator wait5() // 테스트용 자극 대기 + 2 + 0.5 + 0.5 + 0.5 + 3 = 6.5초. 트레이닝 대비 버튼 누르는 시간이 있기때문에 1.5초 지연
    {
        startbutton.transform.localPosition = tm1; // 시작 버튼 내려옴
        obj[0].transform.localPosition = temp11;
        obj[1].transform.localPosition = temp21;
        obj[2].transform.localPosition = temp31;
        obj[3].transform.localPosition = temp41;
        obj[4].transform.localPosition = temp51;
        obj[5].transform.localPosition = temp61;  // 자극물 치우기
        while (true) // 시작 버튼 누를때까지 대기
        {
            if (StaticClass.received5)
            {
                StaticClass.received5 = false;
                break;
            }
            yield return new WaitForSeconds(0.5F); // 렉을 줄이기 위해 0.5초마다 체크
        }
        startbutton.transform.localPosition = tm2; // 시작 버튼 올라감
        obj[0].transform.localPosition = temp1;
        obj[1].transform.localPosition = temp2;
        obj[2].transform.localPosition = temp3;
        obj[3].transform.localPosition = temp4;
        obj[4].transform.localPosition = temp5;
        obj[5].transform.localPosition = temp6; // 자극물 재등장
        yield return new WaitForSeconds(2F);
        sw.Start(); // 시작지점
        now = sw.ElapsedMilliseconds;
        prints = now - before;// 시간 계산
        before = now;
        network.SendMessage("Send", prints + "#x#"); // 트리거 11
        answer = Random.Range(1, 7); // 정답 설정 1~6 랜덤
        rend[answer - 1].sharedMaterial = materials[1];
        yield return new WaitForSeconds(0.5F);
        switch (answer) // 정답 전송
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
            case 5:
                if (training) network.SendMessage("Send", prints + "#e#");
                break;
            case 6:
                if (training) network.SendMessage("Send", prints + "#f#");
                break;
        }
        // abcdef = 트리거 123456
        // 각 신호는 #으로 구별
        //prints = 홀로렌즈에서 각 프레임별 지속 시간. 이걸 기반으로 시간을 재조립
        yield return new WaitForSeconds(0.5F);
        network.SendMessage("Send", prints + "#y#"); // 트리거 12
        rend[answer - 1].sharedMaterial = materials[1];
        yield return new WaitForSeconds(0.5F);
        count = 0;
        for (int i = 0; i < repeatnumber * 6; i++)
        {
            count++;
            if (StaticClass.type == 1)
            {
                yield return StartCoroutine(on()); // 깜빡일경우
            }
            else
            {
                yield return StartCoroutine(spinon()); // 회전일경우
            }
        }
        yield return new WaitForSeconds(3F);
        network.SendMessage("Send", prints + "#z#"); // 트리거 13
        end = true;
    }
    IEnumerator total() //트레이닝용 자극 0.5 + 0.5 + 0.5 + 0.5 + 3 = 5초
    {
        yield return new WaitForSeconds(0.5F);
        sw.Start();
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 지연시간 측정
        before = now;
        Debug.Log("start :" + prints);
        network.SendMessage("Send", prints + "#x#");
        rend[repeatindex[count] - 1].sharedMaterial = materials[1]; //정답 표시
        answer = Random.Range(1, 7);
        yield return new WaitForSeconds(0.5F);
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
            case 5:
                if (training) network.SendMessage("Send", prints + "#e#");
                break;
            case 6:
                if (training) network.SendMessage("Send", prints + "#f#");
                break;
        }
        // abcdef = 트리거 123456
        // 각 신호는 #으로 구별
        //prints = 홀로렌즈에서 각 프레임별 지속 시간. 이걸 기반으로 시간을 재조립
        yield return new WaitForSeconds(0.5F);
        network.SendMessage("Send", prints + "#y#"); // 트리거 12
        now = sw.ElapsedMilliseconds;
        prints = now - before;
        before = now;
        Debug.Log("ready :" + prints);
        rend[repeatindex[count] - 1].sharedMaterial = materials[0]; // 되돌리기
        yield return new WaitForSeconds(0.5F);
        count = 0;
        for (int i = 0; i < repeatnumber * 6; i++)
        {
            count++;
            if (StaticClass.type == 1)
            {
                yield return StartCoroutine(on()); // 깜빡임
            }
            else
            {
                yield return StartCoroutine(spinon()); // 회전
            }
        }
        yield return new WaitForSeconds(3F);
        now = sw.ElapsedMilliseconds;
        prints = now - before; // 시간 측정
        before = now;
        Debug.Log("end :" + prints);
        network.SendMessage("Send", prints + "#z#"); // 트리거 13
        end = true;
        sw.Stop();//스톱워치 정지
        sw.Reset();//스톱워치 리셋
        now = 0;
        prints = 0;
        before = 0;
    }
    IEnumerator on() // 일반 자극
    {
        rend[repeatindex[count] - 1].sharedMaterial = materials[1];
        now = sw.ElapsedMilliseconds;
        prints = now - before;
        before = now;
        Debug.Log("blink :" + prints);
        switch (repeatindex[count])
        {
            case 1:
                network.SendMessage("Send", prints + "#a#");
                break;
            case 2:
                network.SendMessage("Send", prints + "#b#");
                break;
            case 3:
                network.SendMessage("Send", prints + "#c#");
                break;
            case 4:
                network.SendMessage("Send", prints + "#d#");
                break;
            case 5:
                network.SendMessage("Send", prints + "#e#");
                break;
            case 6:
                network.SendMessage("Send", prints + "#f#");
                break;

        }
        // abcdef = 트리거 123456
        // 각 신호는 #으로 구별
        //prints = 홀로렌즈에서 각 프레임별 지속 시간. 이걸 기반으로 시간을 재조립
        yield return new WaitForSeconds(DarkTime);
        rend[repeatindex[count] - 1].sharedMaterial = materials[0];
        yield return new WaitForSeconds(DarkTime);
    }
    IEnumerator spinon() // 회전 자극
    {
        now = sw.ElapsedMilliseconds;
        prints = now - before;
        before = now;
        Debug.Log("spin :" + prints);
        switch (repeatindex[count]) {
            case 1:
                network.SendMessage("Send", prints + "#a#");
                break;
            case 2:
                network.SendMessage("Send", prints + "#b#");
                break;
            case 3:
                network.SendMessage("Send", prints + "#c#");
                break;
            case 4:
                network.SendMessage("Send", prints + "#d#");
                break;
            case 5:
                network.SendMessage("Send", prints + "#e#");
                break;
            case 6:
                network.SendMessage("Send", prints + "#f#");
                break;

        }
        // abcdef = 트리거 123456
        // 각 신호는 #으로 구별
        //prints = 홀로렌즈에서 각 프레임별 지속 시간. 이걸 기반으로 시간을 재조립
        int random = Random.Range(1, 5);
        switch (random)
        {
            case 1: // 회전 1
                obj[repeatindex[count] - 1].transform.eulerAngles = y1_1;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y1_2;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y1_3;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y1_4;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y1_5;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y1_6;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y1_7;
                yield return new WaitForSeconds(max(0, DarkTime - 0.1F));// 회전
                break;
            case 2: // 회전 2
                obj[repeatindex[count] - 1].transform.eulerAngles = y2_1;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y2_2;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y2_3;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y2_4;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y2_5;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y2_6;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = y2_7;
                yield return new WaitForSeconds(max(0, DarkTime - 0.1F));// 회전
                break;
            case 3: // 회전 3
                obj[repeatindex[count] - 1].transform.eulerAngles = x1_1;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x1_2;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x1_3;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x1_4;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x1_5;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x1_6;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x1_7;
                yield return new WaitForSeconds(max(0, DarkTime - 0.1F));// 회전
                break;
            case 4: // 회전 4
                obj[repeatindex[count] - 1].transform.eulerAngles = x2_1;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x2_2;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x2_3;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x2_4;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x2_5;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x2_6;
                yield return new WaitForEndOfFrame();
                obj[repeatindex[count] - 1].transform.eulerAngles = x2_7;
                yield return new WaitForSeconds(max(0, DarkTime - 0.1F)); // 회전
                break;
           

        }
        yield return new WaitForSeconds(DarkTime); // 정지
    }
}