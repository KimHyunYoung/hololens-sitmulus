using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWindow : MonoBehaviour
{
    public TextMesh textMesh; // debug.log 띄울 텍스트 unity 에서 세팅

    void OnEnable()
    {
        Application.logMessageReceived += LogMessage;
    }

    public void LogMessage(string message, string stackTrace, LogType type)
    {
        if(textMesh.text.Length < 200)// 200글자 이하일경우 추가
        {
            textMesh.text += message + "\n"; 
        }
        else
        {
            textMesh.text = message + "\n"; // 아니면 추가
        }
        
    }
}