using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item3 : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    void Awake()
    {
        if (textMesh == null)
        {
            textMesh = GetComponentInChildren<TextMeshProUGUI>();
        }

    }

    void Update()
    {
        textMesh.text = $"x{GameManager.Instance.item3Hav}";
    }
}
