using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class PlayerInputController : ElkController
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
}