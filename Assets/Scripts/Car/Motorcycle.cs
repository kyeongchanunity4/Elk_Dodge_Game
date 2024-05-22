using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcycle : MonoBehaviour
{
    float downSpeed = 0.13f;
    float upSpeed = 0.09f;

    SpriteRenderer spriteRenderer;

    // �ڵ����� ������ ��ġ
    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = 5.5f;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (x < 0.0f && x >= -2.0f)
        {
            x = -1.4f;
            transform.position = new Vector2(x, y);
        }
        else if (x < 2.0f && x >= 0.0f)
        {
            x = 1.3f;
            transform.position = new Vector2(x, -y);
            //������̰� ���������� �ö� �ڵ����� ���� ��ȯ+����� �׸��� ���� ���� ��
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
        if (transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 8.0f)
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
