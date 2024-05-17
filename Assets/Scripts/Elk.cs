using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elk : MonoBehaviour
{
    float direction = 0.05f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() //고라니 컨트롤러
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;

        if (x > 2.0f)  //고라니가 차선 안에서만 움직일 수 있다
        {
            x = 2.0f;
        }
        else if (x < -2.0f)
        {
            x = -2.0f;
        }
        transform.position = new Vector2(x, transform.position.y);
    }


}
