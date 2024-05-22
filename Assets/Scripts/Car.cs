using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float forceGravity = 3.0f;
    float item2ForceGravity = 0.5f;
    public bool isItem1Active;
    Rigidbody2D rb;

    private bool isRotation = false;
    private float RotateSpeed = 360f;

    // �ڵ����� ������ ��ġ
    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = 5.5f;
        rb = GetComponent<Rigidbody2D>();

        if ( x < -0.45f && x >= -2.0f)
        {
            transform.position = new Vector2(x, y);
        }
        else if( x>=0.45f && x <= 2.0f)
        {
            transform.position = new Vector2(x, -y);
        }
    }

    // ���� ����� ������ ���� ��
    void Update()
    {
        isItem1Active = GameManager.Instance.isItem1Active;
        //���� ȭ�� ������ ������ ����
        if (transform.position.y < -5.6f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 5.6f)
        {
            Destroy(gameObject);
        }

        if(isRotation == true)
        {
            transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
        }
    }


    private void FixedUpdate()
    {
        if (transform.position.x < 0.0f && transform.position.x >= -2.0f)
        {
            if (!GameManager.Instance.isItem2Active)
            {
                rb.AddForce(Vector3.down * forceGravity);
            }
            else
            {
                rb.AddForce(Vector3.down * item2ForceGravity);
            }

        }
        else if (transform.position.x >= 0.0f && transform.position.x <= 2.0f)
        {
            if (!GameManager.Instance.isItem2Active)
            {
                rb.AddForce(Vector3.up * forceGravity);
            }
            else
            {
                rb.AddForce(Vector3.up * item2ForceGravity);
            }
        }
    }


    //���� �����(�÷��̾�)�� ���� ���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isItem1Active)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (GameManager.Instance.item3Hav >= 1)
                {
                    GameManager.Instance.item3Hav -= 1;
                    DestroyCar();
                }

                else
                {
                    GameManager.Instance.GameOver();
                }
            }
        }

        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                DestroyCar();
            }
        }
    }

    private void DestroyCar()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Collider2D collider = GetComponent<Collider2D>();
        
        Destroy(collider);

        rb.gravityScale = 2.0f;

        Vector2 initialVelocity = new Vector2(Random.Range(-2.0f,2.0f),Random.Range(6.0f,10.0f));
        rb.AddForce(initialVelocity, ForceMode2D.Impulse);

        isRotation = true;
    }
}
