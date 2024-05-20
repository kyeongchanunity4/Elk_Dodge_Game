using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float forceGravity = 3.0f;

    Rigidbody2D rb;

    // �ڵ����� ������ ��ġ
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

    // ���� ���� ������ ���� ��
    void Update()
    {
        //���� ȭ�� ������ ������ ����
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


    //���� ����(�÷��̾�)�� ���� ���
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            //���� ���� �޼��� ����
            GameManager.Instance.GameOver();
        }
    }
}
