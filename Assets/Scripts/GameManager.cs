using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject car1;
    public GameObject endPanel;
    public GameObject rankingBoard;
    
    private float[] bestScore = new float[5];
    public float[] rankScore = new float[5];
    public float recordTime;

    public Text[] RankScoreText;
    public Text playerScore;
    public Text timeTxt;
    public Text NowScore;
    public Text BestScore;

    bool isPlay = true;

    float time = 0f;
    string key = "BestScore";

    private void Awake()
    {
        if (Instance == null)
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60;
        InvokeRepeating("MakeCar", 0.0f, 1.0f);
        endPanel.SetActive(false);
        rankingBoard.SetActive(false);
    }

    void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    //자동차 호출하는 메서드
    void MakeCar()
    {
        Instantiate(car1);
    }

    //게임 종료 됐을 시
    public void GameOver()
    {
        isPlay = false;
        Time.timeScale = 0.0f; //게임 종료 처리
        NowScore.text = time.ToString("N2"); //버틴 시간 만큼 현재 기록에 표시

        //최고 점수가 있다면
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if (best < time) //현재 점수가 최고 점수보다 높을 경우
            {
                PlayerPrefs.SetFloat(key, time); //현재 점수를 최고 점수에 저장
                BestScore.text = time.ToString("N2"); //현재 점수를 최고 정수에 보여준다.
            }
            else //현재 점수가 최고 점수보다 낮을 경우 (저장 안함)
            {
                BestScore.text = best.ToString("N2"); //저장된 최고 점수를 보여준다.
            }
        }
        //최고 점수가 없다면
        else
        {
            PlayerPrefs.SetFloat(key, time); //현재 점수를 최고 점수에 저장
            BestScore.text = time.ToString("N2"); //현재 점수를 최고 정수에 보여준다.
        }

        //플레이어의 시간을 저장
        PlayerPrefs.SetFloat("recordTime", time);

        //게임이 종료되면 엔드 판넬 활성화
        endPanel.SetActive(true); 
    }

    public void ScoreSet()
    {
        float currentTime = PlayerPrefs.GetFloat("recordTime");
        //일단 현재에 저장하고 시작
        PlayerPrefs.SetFloat("CurrentPlayerTime", currentTime);

        float tmpTime = 0f;

        for (int i = 0; i < 5; i++)
        {
            //저장된 최고 점수와 이름을 가져오기
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");

            //현재 점수가 랭킹에 오를 수 있을 때
            while (bestScore[i] < currentTime)
            {
                //자리 바꾸기
                tmpTime = bestScore[i];
                bestScore[i] = currentTime;

                //랭킹에 저장
                PlayerPrefs.SetFloat(i + "BestScore", currentTime);

                //다음 반복을 위한 준비
                currentTime = tmpTime;
            }
        }

        //랭킹에 맞춰 점수와 이름 저장
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
        }
    }

    //랭킹 보드
    public void Board()
    {
        //플레이어의 점수 텍스트를 현재 '나'의 점수에 표시
        playerScore.text = PlayerPrefs.GetString("CurrentPlayerScore");

        //랭킹에 맞춰 불러온 점수 표시
        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            RankScoreText[i].text = string.Format("{0:N3}cm", rankScore[i]);

            //랭킹 강조 표시
            if (playerScore.text == RankScoreText[i].text)
            {
                Color Rank = new Color(255, 255, 0);
                playerScore.color = Rank;
                RankScoreText[i].color = Rank;
            }
        }
    }
}
