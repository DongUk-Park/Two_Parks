using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_blink : MonoBehaviour
{
    public Material Left_lamp;
    public Material Right_lamp;

    float timer;
    float waitingtime;
    bool lamp_onoff = false; // ���-�����-���-����� �ٲ�� �����ִ� ����
    bool Right_lamp_on = false; // �����̰� ���Դ��� �Ǵ�
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
        if (Input.GetKeyDown(KeyCode.Q)) // ���� �����̸� ������
        {
            Left_lamp_on = !Left_lamp_on;// lamp_on: �����̸� ���� Ƚ��, Ȧ�� -> ������ ����, ¦�� -> ������ ����
            if (!Left_lamp_on) // ���� �����̰� �ȵ�������
                Left_lamp.color = Color.white; // �����̸� ����

            // Debug.Log(Left_lamp_on);
        }
        if (Left_lamp_on) //���� �����̰� ����������
            Left_lamp_Blinker(); // �����Ÿ��� ����� �Ѷ�


        if (Input.GetKeyDown(KeyCode.E)) //������ ����
        {
            Right_lamp_on = !Right_lamp_on;
            if (!Right_lamp_on)
                Right_lamp.color = Color.white;

            //  Debug.Log(Right_lamp_on);

        }
        if (Right_lamp_on)
            Right_lamp_Blinker();




        if (Input.GetKeyDown(KeyCode.R)) // ����
        {
            emer_lamp_on = !emer_lamp_on;

            Debug.Log(emer_lamp_on);

            if (emer_lamp_on)
            {
                if (!Left_lamp_on) //���� ���������̰� �����ִٸ� �Ѷ�
                    Left_lamp_on = !Left_lamp_on;
                if (!Right_lamp_on)
                    Right_lamp_on = !Right_lamp_on;
            }
            else
            {
                if (Left_lamp_on) //���� ���������̰� �����ִٸ�
                    Left_lamp_on = !Left_lamp_on; // �����Ÿ��� ����� ����
                if (Right_lamp_on)
                    Right_lamp_on = !Right_lamp_on;
                Right_lamp.color = Color.white; // ������ �ٲ۴�
                Left_lamp.color = Color.white;
            }

        }

    }


}
