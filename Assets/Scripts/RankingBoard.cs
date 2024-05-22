using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingBoard : MonoBehaviour
{
    private float[] bestTime;
    public string[] bestName;
    private float[] rankScore = new float[5];
    

    public Text RankNameCurrent;
    public Text RankScoreCurrent;
    

    public void Ranking()
    {
        RankNameCurrent.text = PlayerPrefs.GetString("CurrentPlayerName");
        RankScoreCurrent.text = string.Format( "{0.N3}cm", PlayerPrefs.GetFloat("CurrentPlayerScore"));
       
        for(int i = 0; i<5; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            
        }

    }
}
