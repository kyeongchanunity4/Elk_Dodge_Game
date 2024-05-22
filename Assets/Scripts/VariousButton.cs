using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariousButton : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject rankingBoard;

    //��ŷ ���� ��ư
    public void GoToRaningBoard()
    {
        endPanel.SetActive(false);
        rankingBoard.SetActive(true);
    }

    //������� ���ư���
    public void ReturnEndPanel()
    {
        rankingBoard.SetActive(false);
        endPanel.SetActive(true);
    }
}
