using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed; //배경들이 움직일 속도를 정의한 변수
    public Transform[] backgrounds; //배경들을 담아줄 변수

    float upPosY = 0f; // 배경의 끝 y좌표를 담아줄 변수
    float downPosY = 0f; // 배경의 시작 y좌표를 담아줄 변수
    float xScreenHalfSize; //게임 화면의 x좌표 절반을 담아줄 변수
    float yScreenHalfSize; //게임 화면의 y좌표 절반을 담아줄 변수

    //백그라운드 스크롤링에 사용되는 화면 좌표들의 값을 초기화
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
        for(int i = 0; i<backgrounds.Length; i++)
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
}
