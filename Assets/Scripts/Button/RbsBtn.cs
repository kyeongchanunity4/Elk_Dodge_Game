using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RbsBtn : MonoBehaviour
{
    public void GotoRankingBoard()
    {
        SceneManager.LoadScene("RankingBoardScene");
    }
}
