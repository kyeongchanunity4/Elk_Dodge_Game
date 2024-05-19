using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElkMovement : MonoBehaviour
{
    private ElkController movementController;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        movementController = GetComponent<ElkController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movementController.OnMoveEvent += Move;
    }

    // 고라니가 화면 밖으로 안나가도록 범위 조정
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (x > 2.0f)
        {
            x = 2.0f;
        }
        else if (x < -2)
        {
            x = -2.0f;
        }

        if (y > 4.0f)
        {
            y = 4.0f;
        }
        else if (y < -4.0f)
        {
            y = -4.0f;
        }
        transform.position = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 3;
        movementRigidbody.velocity = direction;
    }
}
