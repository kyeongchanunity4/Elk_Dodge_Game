using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    //아이템 지속시간
    private float item2Duration = 5.0f;
    private float timer2 = 0f;
    private float item2LeftTime = 5.0f;

    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI leftTimeText;

    void Awake()
    {
        if (textMesh == null)
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
        }

        if (leftTimeText == null)
            leftTimeText = GetComponent<TextMeshProUGUI>();

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isItem2Active)
        {
            timer2 += Time.deltaTime;
            item2LeftTime -= Time.deltaTime;
            leftTimeText.text = item2LeftTime.ToString("N2");
            if (timer2 >= item2Duration)
            {
                GameManager.Instance.isItem2Active = false;
                timer2 -= Time.deltaTime;
                timer2 = 0f;
                item2LeftTime = 5.0f;
                leftTimeText.text = "";
            }
        }
        textMesh.text = $"x{GameManager.Instance.item2Hav}";
    }

    public void ITem2Activate()
    {
        if (GameManager.Instance.item2Hav >= 1 && !GameManager.Instance.isItem2Active)
        {
            GameManager.Instance.item2Hav -= 1;
            GameManager.Instance.isItem2Active = true;
        }
    }
}
