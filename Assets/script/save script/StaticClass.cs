using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public static class StaticClass // 저장소
{
    public static float blinktime = 0.066F; // 자극의 점멸 시간
    public static float wide = 1.0F; // 가로 배율
    public static int type = 1;// 1 = 깜빡이기, 2 = 회전
    public static int second = 60;
    public static int repeat_per_trial = 10; // 매 회수 깜빡임
    public static int repeat_total = 50; // 트레이닝 총 실행횟수
    public static int repeat_test = 30; // 테스트 총 실행횟수
    public static int repeat_testfor2 = 24; // 총 테스트 반복횟수, 위에 변수와는 1번 반복 때문에 만듬
    public static int totalnumber; // 여태까지 총 실행한 테스트 수
    public static int[] answersheet = new int[30]; // 정답 시트 
    public static int[] blinksheet = new int[30];// 자극 위치 시트
    public static bool received = false;
    public static bool received5 = false; // 테스트시 재실행을 위한 실행
    public static int screennumber = 0; // variable for screen light, laundry, robot cleaner. 1 = laundry, 2 = light, 3 = robot
}