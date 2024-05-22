using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed; //������ ������ �ӵ��� ������ ����
    public float Item2ScrollSpeed = 0.8f;
    public Transform[] backgrounds; //������ ����� ����

    float upPosY = 0f; // ����� �� y��ǥ�� ����� ����
    float downPosY = 0f; // ����� ���� y��ǥ�� ����� ����
    float xScreenHalfSize; //���� ȭ���� x��ǥ ������ ����� ����
    float yScreenHalfSize; //���� ȭ���� y��ǥ ������ ����� ����

    //��׶��� ��ũ�Ѹ��� ���Ǵ� ȭ�� ��ǥ���� ���� �ʱ�ȭ
    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        downPosY = -(yScreenHalfSize * 2);
        upPosY = yScreenHalfSize * 2 * backgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isItem2Active)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].position += new Vector3(0, -scrollSpeed, 0) * Time.deltaTime;

                if (backgrounds[i].position.y < downPosY)
                {
                    Vector3 nextPos = backgrounds[i].position;
                    nextPos = new Vector3(nextPos.x, nextPos.y + upPosY, nextPos.z);
                    backgrounds[i].position = nextPos;
                }
            }
        }

        else
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].position += new Vector3(0, -Item2ScrollSpeed, 0) * Time.deltaTime;

                if (backgrounds[i].position.y < downPosY)
                {
                    Vector3 nextPos = backgrounds[i].position;
                    nextPos = new Vector3(nextPos.x, nextPos.y + upPosY, nextPos.z);
                    backgrounds[i].position = nextPos;
                }
            }
        }
    }
}
