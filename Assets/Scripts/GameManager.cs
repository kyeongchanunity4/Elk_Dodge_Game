using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject BlueCar;
    public GameObject Bulldozer;
    public GameObject DumpTruck;
    public GameObject motorbikeblack;
    public GameObject MotorBikeRed;
    public GameObject PurpleCar;
    public GameObject YellowCar;

    public GameObject endPanel;
    public GameObject gameOverScene;

    private float[] bestTime = new float[5];
    private float[] rankScore = new float[5];
    public string[] bestName = new string[5];
    public float recordTime;

    public Text[] RankScoreText;
    public Text playerScore;
    public Text timeTxt;
    public Text NowScore;
    public Text BestScore;

    bool isPlay = true;

    float gameTime = 0f;
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

        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        endPanel.SetActive(false);
        gameOverScene.SetActive(false);

        gameTime += Time.deltaTime;

        InvokeRepeating("MakeCar", 0.0f, 2.0f); //자동차가 랜덤으로 나온다.
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
        float p = Random.Range(0, 10);  //주기적으로 차가 등장함
        if (p < 3) Instantiate(BlueCar);
        else if (p >= 3 && p < 7) Instantiate(PurpleCar);
        else if (p >= 7) Instantiate(YellowCar);

        if(time >= 20) // 가끔씩 오토바이가 등장함
        {
            float r = Random.Range(0, 30);
            if (r < 10) Instantiate(motorbikeblack);
            if (r > 20) Instantiate(MotorBikeRed);
        }
        if(time >= 40) // 가끔씩 덤프트럭이나 불도저가 등장함
        {
            float t = Random.Range(0, 30);
            if (t < 5) Instantiate(Bulldozer);
            if (t > 20) Instantiate(DumpTruck);
        }

    }

    //게임 종료 됐을 시
    public void GameOver()
    {
        float overTime = 0;
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

    void ScoreSet(float currentTime, string currentName)
    {
        //일단 현재에 저장하고 시작
        PlayerPrefs.SetString("currentName", currentName = "chan");
        PlayerPrefs.SetFloat("CurrentPlayerTime", currentTime = recordTime);

        float tmpTime = 0f;
        string tmpName = "";

        for (int i = 0; i < 5; i++)
        {
            //저장된 최고 점수와 이름을 가져오기
            bestTime[i] = PlayerPrefs.GetFloat(i + "BestTime");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            //현재 점수가 랭킹에 오를 수 있을 때
            while (bestTime[i] < currentTime)
            {
                //자리 바꾸기
                tmpTime = bestTime[i];
                tmpName = bestName[i];
                bestTime[i] = currentTime;
                bestName[i] = currentName;

                //랭킹에 저장
                PlayerPrefs.SetFloat(i + "BestScore", currentTime);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                //다음 반복을 위한 준비
                currentTime = tmpTime;
                currentName = tmpName;
            }
        }

        //랭킹에 맞춰 점수와 이름 저장
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestTime[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
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
