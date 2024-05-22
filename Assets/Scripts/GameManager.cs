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

    public int item1Hav;
    public int item2Hav;
    public int item3Hav;

    public bool isItem1Active = false;
    public bool isItem2Active = false;

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

    //�ڵ��� ȣ���ϴ� �޼���
    void MakeCar()
    {
        Instantiate(car1);
    }

    //���� ���� ���� ��
    public void GameOver()
    {
        isPlay = false;
        Time.timeScale = 0.0f; //���� ���� ó��
        NowScore.text = time.ToString("N2"); //��ƾ �ð� ��ŭ ���� ��Ͽ� ǥ��

        //�ְ� ������ �ִٸ�
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if (best < time) //���� ������ �ְ� �������� ���� ���
            {
                PlayerPrefs.SetFloat(key, time); //���� ������ �ְ� ������ ����
                BestScore.text = time.ToString("N2"); //���� ������ �ְ� ������ �����ش�.
            }
            else //���� ������ �ְ� �������� ���� ��� (���� ����)
            {
                BestScore.text = best.ToString("N2"); //����� �ְ� ������ �����ش�.
            }
        }
        //�ְ� ������ ���ٸ�
        else
        {
            PlayerPrefs.SetFloat(key, time); //���� ������ �ְ� ������ ����
            BestScore.text = time.ToString("N2"); //���� ������ �ְ� ������ �����ش�.
        }

        //�÷��̾��� �ð��� ����
        PlayerPrefs.SetFloat("recordTime", time);

        //������ ����Ǹ� ���� �ǳ� Ȱ��ȭ
        endPanel.SetActive(true); 
    }

    public void ScoreSet()
    {
        float currentTime = PlayerPrefs.GetFloat("recordTime");
        //�ϴ� ���翡 �����ϰ� ����
        PlayerPrefs.SetFloat("CurrentPlayerTime", currentTime);

        float tmpTime = 0f;

        for (int i = 0; i < 5; i++)
        {
            //����� �ְ� ������ �̸��� ��������
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");

            //���� ������ ��ŷ�� ���� �� ���� ��
            while (bestScore[i] < currentTime)
            {
                //�ڸ� �ٲٱ�
                tmpTime = bestScore[i];
                bestScore[i] = currentTime;

                //��ŷ�� ����
                PlayerPrefs.SetFloat(i + "BestScore", currentTime);

                //���� �ݺ��� ���� �غ�
                currentTime = tmpTime;
            }
        }

        //��ŷ�� ���� ������ �̸� ����
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
        }
    }

    //��ŷ ����
    public void Board()
    {
        //�÷��̾��� ���� �ؽ�Ʈ�� ���� '��'�� ������ ǥ��
        playerScore.text = PlayerPrefs.GetString("CurrentPlayerScore");

        //��ŷ�� ���� �ҷ��� ���� ǥ��
        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            RankScoreText[i].text = string.Format("{0:N3}cm", rankScore[i]);

            //��ŷ ���� ǥ��
            if (playerScore.text == RankScoreText[i].text)
            {
                Color Rank = new Color(255, 255, 0);
                playerScore.color = Rank;
                RankScoreText[i].color = Rank;
            }
        }
    }
}
