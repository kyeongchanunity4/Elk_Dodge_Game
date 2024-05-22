using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUi : MonoBehaviour
{
    public TextMeshProUGUI itemDescription;
    private int selectItemNum = 0;

    public GameObject item1SelectPanel;
    public GameObject item2SelectPanel;
    public GameObject item3SelectPanel;

    private void Awake()
    {
        if (itemDescription == null)
        {
            itemDescription = GetComponentInChildren<TextMeshProUGUI>();
        }

    }


    public void SelectItem1Btn()
    {
        selectItemNum = 1;
        itemDescription.text = "Becomes stronger than a car for 2 seconds.";
        item1SelectPanel.SetActive(true);
        item2SelectPanel.SetActive(false);
        item3SelectPanel.SetActive(false);
    }

    public void SelectItem2Btn()
    {
        selectItemNum = 2;
        itemDescription.text = "Time around you slows down for 5 seconds.";
        item1SelectPanel.SetActive(false);
        item2SelectPanel.SetActive(true);
        item3SelectPanel.SetActive(false);
    }

    public void SelectItem3Btn()
    {
        selectItemNum = 3;
        itemDescription.text = "Prevents being hit once.";
        item1SelectPanel.SetActive(false);
        item2SelectPanel.SetActive(false);
        item3SelectPanel.SetActive(true);
    }

    public void GoBtn()
    {
        if (selectItemNum == 1)
        {
            GameManager.Instance.item1Hav += 1;
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else if(selectItemNum == 2)
        {
            GameManager.Instance.item2Hav += 1;
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else if(selectItemNum == 3)
        {
            GameManager.Instance.item3Hav += 1;
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            return;
        }
    }
}
