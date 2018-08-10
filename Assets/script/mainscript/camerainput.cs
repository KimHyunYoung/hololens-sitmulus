using UnityEngine; // 기본
using System.Collections; // 기본
using UnityEngine.SceneManagement; // 스크린 넘기는데 필요한 using

public class camerainput : MonoBehaviour {
    int Counterred = 0;
    int Countergreen = 0;
    int Counterblue = 0;  // 픽셀을 세어 이 칸이 무슨 색인지 알때 추가하는 변수

    int redprecess = 0;
    int blueprocess = 0;
    int greenprocess = 0; //사진 하나로 바로 인식되지 않고 두번 찍어야 인식되게 하기 위한 변수들, 빨녹파 순
    WebCamTexture webcam; //카메라
    public Texture2D m_MainTexture; //사진 넣을 텍스쳐, 유니티는 Texture2D로 인식해야함.
    int counter = 0; // 50프레임 세기 위한 카운터,
    void Start () {
        webcam = new WebCamTexture();
        webcam.Play();
        StartCoroutine(process());
        //Debug.LogFormat("webcam: {0}, {1} x {2}", webcam.deviceName, webcam.width, webcam.height);
    }
    IEnumerator process()
    {
        yield return new WaitForSeconds(1.2F);
        m_MainTexture = Takephoto(); // takephoto함수 실행
        switch (returncolor(m_MainTexture)) // returncolor함수로 사진의 중앙부에서 픽셀 36개를 떼어 색갈 분별하는 함수, 1 = 빨강 2 = 녹색, 3 = 파랑
        {
            case 0: // 아무것도 찍히지 않았을때. 혹은 인식이 안됬을때 리셋
                redprecess = 0;
                blueprocess = 0;
                greenprocess = 0;
                break;
            case 1: // 빨강일때
                blueprocess = 0;
                greenprocess = 0;
                redprecess++; // 레드프로세스 1 올림
                if (redprecess > 1) // 이미 올렸던 상태라 2가 됬을경우 스크린 변경
                {
                    StaticClass.screennumber = 1; // 빨강이라고 전역변수 기록
                    redprecess = 0; // 적색 초기화
                    webcam.Stop();// 카메라 정지
                    SceneManager.LoadScene("laundry"); // 빨강 = 세탁기
                }

                break;
            case 2: // 파랑일때
                blueprocess = 0;
                redprecess = 0;
                greenprocess++; // 그린프로세스 1 올림
                if (greenprocess > 1) // 이미 올렸던 상태라 2가 됬을경우 스크린 변경
                {
                    StaticClass.screennumber = 2; // 녹색이라고 전역변수 기록
                    greenprocess = 0; // 초기화
                    webcam.Stop();// 카메라 정지
                    SceneManager.LoadScene("light"); // 녹색 = 전등
                }
                break;
            case 3:
                redprecess = 0;
                blueprocess++;
                greenprocess = 0;
                if (blueprocess > 1) // 이미 올렸던 상태라 2가 됬을경우 스크린 변경
                {
                    StaticClass.screennumber = 3; // 파랑이라고 전역변수 기록
                    blueprocess = 0;// 초기화
                    webcam.Stop();// 카메라 정지
                    SceneManager.LoadScene("robot"); // 파랑 = 로봇청소기

                }
                break;
        }
        StartCoroutine(process());
        
    }
    private void Update() // 매 프레임 마다 실행
    {

    }


    Texture2D Takephoto() // 카메라에서 텍스쳐로 가져오는 함수
    {
        Texture2D WebcamImage = new Texture2D(webcam.width, webcam.height); // webcamimage라는 texture에 카메라 크기만한 백지를 넣는다
        WebcamImage.SetPixels(webcam.GetPixels()); // 카메라에서 사진을찍는다
        WebcamImage.Apply();// 적용한다

        return WebcamImage; // 적용된 이미지 리턴
    }
    int returncolor(Texture2D input) // 사진 판별 함수
    {
        Counterred = 0;
        Countergreen = 0;
        Counterblue = 0; // 초기화

        Color temp =  input.GetPixel(638, 358);//임시로 크기 맞추기 위해서
        for (int i = 0; i < 4; i++) // 가로
        {
            for (int j = 0; j < 4; j++) // 세로
            {
                temp = input.GetPixel(638 + i, 358 + j);//4 * 4만큼 각각 카운터
                if (temp.r > 0.5F) Counterred++;
                if (temp.g > 0.4F) Countergreen++; // 녹색은 인식률이 떨어져 민감도 높임
                if (temp.b > 0.5F) Counterblue++;
            }
        }
        Debug.LogFormat("color: red {0}, green {1}, blue {2}", Counterred, Countergreen, Counterblue); // 사진 처리 결과 표시 결과/16 이 결과물
        if (Counterred > 11 && Countergreen < 6 && Counterblue < 6) return 1; // 대략 70프로 이상일경우 그색으로 판별, 40프로 이하일경우 그색 이외의것이라고 판별. 빛색 섞기임.
        else if (Countergreen > 11 && Counterred < 6 && Counterblue < 6 ) return 2;
        else if (Counterblue > 11 && Countergreen < 6 && Counterred < 6) return 3;
        else return 0; // 아무것도 아닐때 0
    }
}   