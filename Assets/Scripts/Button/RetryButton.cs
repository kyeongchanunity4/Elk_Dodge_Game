using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    //����� ��ư
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
