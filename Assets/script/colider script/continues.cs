using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continues : MonoBehaviour
{

    bool nottwice = true; // 중복 버튼 눌리기 제거
    int counter = 0; // 프레임 카운터
    public GameObject process; // 버튼 결과를 보낼 프로세스. 유니티에서 등록
    public void OnTriggerStay(Collider other) // 충돌시 매 프레임마다 호출
    {
        if (nottwice) // 아직 눌리지 않았을때
        {
            counter++; // 프레임 체크
        }
        if (counter > 50) // 50프레임 이상 충돌중일시
        {
            counter = 0; // 리셋
            process.SendMessage("continues");//재시작 함수 호출
            nottwice = false; // 탈출 전까진 다시 버튼이 눌리지 않음
        }
    }
    public void OnTriggerExit(Collider other) // 탈출시
    {
        counter = 0; // 리셋
        nottwice = true; // 리셋
    }
}
