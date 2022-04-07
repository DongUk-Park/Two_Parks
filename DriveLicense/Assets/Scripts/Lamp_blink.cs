using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_blink : MonoBehaviour
{
    public Material Left_lamp;
    public Material Right_lamp;

    float timer;
    float waitingtime;
    bool lamp_onoff = false; // 흰색-노란색-흰색-노란색 바뀌도록 도와주는 변수
    bool Right_lamp_on = false; // 깜빡이가 들어왔는지 판단
    bool Left_lamp_on = false;
    bool emer_lamp_on = false;


    private void Start()
    {
        Left_lamp.color = Color.white;
        Right_lamp.color = Color.white;
        timer = 0f;
        waitingtime = 0.5f;
    }

    private void Update()
    {
        Timer();
        lamp_Operation();   
        
    }

    void Left_lamp_Blinker()
    {
        if (lamp_onoff)
            Left_lamp.color = Color.yellow;
        else
            Left_lamp.color = Color.white;
    }
    void Right_lamp_Blinker()
    {
        if (lamp_onoff)
            Right_lamp.color = Color.yellow;
        else
            Right_lamp.color = Color.white;
    }


    void Timer()
    {
        timer += Time.deltaTime;
        if (timer > waitingtime)
        {
            timer = 0;
            lamp_onoff = !lamp_onoff;
        }
    }


    void lamp_Operation()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // 좌측 깜빡이를 넣으면
        {
            Left_lamp_on = !Left_lamp_on;// lamp_on: 깜빡이를 누른 횟수, 홀수 -> 깜빡이 켜짐, 짝수 -> 깜빡이 꺼짐
            if (!Left_lamp_on) // 좌측 깜빡이가 안들어왔으면
                Left_lamp.color = Color.white; // 깜빡이를 꺼라

            // Debug.Log(Left_lamp_on);
        }
        if (Left_lamp_on) //좌측 깜빡이가 켜져있으면
            Left_lamp_Blinker(); // 깜빡거리는 기능을 켜라


        if (Input.GetKeyDown(KeyCode.E)) //좌측과 동일
        {
            Right_lamp_on = !Right_lamp_on;
            if (!Right_lamp_on)
                Right_lamp.color = Color.white;

            //  Debug.Log(Right_lamp_on);

        }
        if (Right_lamp_on)
            Right_lamp_Blinker();




        if (Input.GetKeyDown(KeyCode.R)) // 비상등
        {
            emer_lamp_on = !emer_lamp_on;

            Debug.Log(emer_lamp_on);

            if (emer_lamp_on)
            {
                if (!Left_lamp_on) //만약 좌측깜빡이가 꺼져있다면 켜라
                    Left_lamp_on = !Left_lamp_on;
                if (!Right_lamp_on)
                    Right_lamp_on = !Right_lamp_on;
            }
            else
            {
                if (Left_lamp_on) //만약 좌측깜빡이가 켜져있다면
                    Left_lamp_on = !Left_lamp_on; // 깜빡거리는 기능을 끄고
                if (Right_lamp_on)
                    Right_lamp_on = !Right_lamp_on;
                Right_lamp.color = Color.white; // 색깔을 바꾼다
                Left_lamp.color = Color.white;
            }

        }

    }


}
