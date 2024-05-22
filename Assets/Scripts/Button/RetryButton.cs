using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    //재시작 버튼
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
