using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariousButton : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject rankingBoard;

    //재시작 버튼
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    //랭킹 보드 버튼
    public void GoToRaningBoard()
    {
        endPanel.SetActive(false);
        rankingBoard.SetActive(true);
    }

    //원래대로 돌아가기
    public void ReturnEndPanel()
    {
        rankingBoard.SetActive(false);
        endPanel.SetActive(true);
    }
}
