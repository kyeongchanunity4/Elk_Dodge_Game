using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item1 : MonoBehaviour
{
    //아이템 지속시간
    //item1Duration == item1LeftTime 이야 제대로 표기됨
    private float item1Duration = 2.0f;
    private float timer1 = 0f;
    private float item1LeftTime = 2.0f;

    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI leftTimeText;

    void Awake()
    {
        if(textMesh == null)
            textMesh = GetComponent<TextMeshProUGUI>();

        if(leftTimeText == null)
            leftTimeText = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isItem1Active)
        {
            timer1 += Time.deltaTime;
            item1LeftTime -= Time.deltaTime;
            leftTimeText.text = item1LeftTime.ToString("N2");

            if (timer1 >= item1Duration)
            {
                GameManager.Instance.isItem1Active = false;
                timer1 -= Time.deltaTime;
                timer1 = 0f;
                item1LeftTime = 2.0f;
                leftTimeText.text = "";
            }
        }

        textMesh.text = $"x{GameManager.Instance.item1Hav}";
    }

    public void ITem1Activate()
    {
        if (GameManager.Instance.item1Hav >= 1 && !GameManager.Instance.isItem1Active)
        {
            GameManager.Instance.item1Hav -= 1;
            GameManager.Instance.isItem1Active = true;
        }
    }
}
