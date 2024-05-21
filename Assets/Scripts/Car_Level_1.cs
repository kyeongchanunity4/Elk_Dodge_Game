using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Level_1 : MonoBehaviour
{
    float downSpeed = 0.05f;
    float upSpeed = 0.02f;

    SpriteRenderer spriteRenderer;

    // �ڵ����� ������ ��ġ
    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = 5.5f;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (x < -1.35f && x >= -2.0f)
        {
            x = -1.95f;
            transform.position = new Vector2(x, y);
        }
        else if (x < 0.0f && x >= -1.35f)
        {
            x = -0.75f;
            transform.position = new Vector2(x, y);
        }
        else if (x < 1.35f && x >= 0.0f)
        {
            x = 0.75f;
            transform.position = new Vector2(x, -y);
            //�ڵ����� ���������� �ö� �ڵ����� ���� ��ȯ+����� �׸��� ���� ���� ��
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
            spriteRenderer.flipX = true;

        }
        else if (x <= 2.0f && x >= 1.35f)
        {
            x = 1.95f;
            transform.position = new Vector2(x, -y);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
            spriteRenderer.flipX = true;
        }
    }

    // ���� ���� ������ ���� ��
    void Update()
    {
        //���� ������ ��ġ�� ���� ������
        if (transform.position.x < 0.0f && transform.position.x >= -2.0f)
        {
            transform.position += Vector3.down * downSpeed;
        }
        else if (transform.position.x >= 0.0f && transform.position.x <= 2.0f)
        {
            transform.position += Vector3.up * upSpeed;
        }

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
