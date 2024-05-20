using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float forceGravity = 3.0f;

    Rigidbody2D rb;

    // 자동차가 나오는 위치
    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = 5.5f;
        rb = GetComponent<Rigidbody2D>();

        if ( x < -1.35f && x >= -2.0f)
        {
            x = -1.95f;
            transform.position = new Vector2(x, y);
        }
        else if (x < 0.0f && x>= -1.35f)
        {
            x = -0.75f;
            transform.position = new Vector2(x, y);
        }
        else if( x < 1.35f && x >= 0.0f)
        {
            x = 0.75f;
            transform.position = new Vector2(x, -y);
        }
        else if (x < 1.35f && x >= 2.0f)
        {
            x = 1.95f;
            transform.position = new Vector2(x, -y);
        }
    }

    // 차가 고라니 쪽으로 주행 중
    void Update()
    {
        //차가 화면 밖으로 나가면 삭제
        if (transform.position.y < -5.6f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 5.6f)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        if (transform.position.x < 0.0f && transform.position.x >= -2.0f)
        {
            rb.AddForce(Vector3.down * forceGravity);

        }
        else if (transform.position.x >= 0.0f && transform.position.x <= 2.0f)
        {
            rb.AddForce(Vector3.up * forceGravity);
        }
    }


    //차가 고라니(플레이어)를 쳤을 경우
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            //게임 종료 메서드 실행
            GameManager.Instance.GameOver();
        }
    }
}
