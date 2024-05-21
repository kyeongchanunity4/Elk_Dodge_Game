using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject car1;
    public GameObject BlueCar;
    public GameObject Bulldozer;
    public GameObject DumpTruck;
    public GameObject motorbikeblack;
    public GameObject MotorBikeRed;
    public GameObject PurpleCar;
    public GameObject YellowCar;

    public GameObject endPanel;
    public GameObject gameOverScene;

    private float[] bestScore = new float[5];
    public float[] rankScore = new float[5];
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
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60;
        endPanel.SetActive(false);
        gameOverScene.SetActive(false);

        gameTime += Time.deltaTime;
        InvokeRepeating("MakeCar", 0.0f, 1.0f); //�ڵ����� �������� ���´�.

        /*
        switch (gameTime / 30.0f) //�ð��� 30�� ���������� ���̵� ����
        {
            case 0: //���� 1�ܰ�
                InvokeRepeating("MakeCar", 0.0f, 1.0f); //�ڵ����� �������� ���´�.
                break;
            case 1: //30�ʰ� ������ ���� 2�ܰ�
                //�ڵ����� ������̰� �������� ���´�
                break;
            case 2: //60�ʰ� ������ ���� 3�ܰ�
                //�ڵ����� �������, ����Ʈ���� ���´�.
                break;
            default: //90�ʰ� ������ ���� 4�ܰ�
                //�ڵ����� �������, ����Ʈ��, �ҵ����� ���´�.
                break;
        }
        */
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
        Instantiate(BlueCar);
        Instantiate(Bulldozer);
        Instantiate(DumpTruck);
        Instantiate(motorbikeblack);
        Instantiate(MotorBikeRed);
        Instantiate(PurpleCar);
        Instantiate(YellowCar);

    }

    //������� ȣ���ϴ� �޼���
    void MakeMotorcycle()
    {

    }

    //����Ʈ�� ȣ���ϴ� �޼���
    void MakeDumpTruck()
    {

    }

    //�ҵ��� ȣ���ϴ� �޼���
    void bulldozer()
    {

    }

    //���� ���� ���� ��
    public void GameOver()
    {
        float overTime = 0;
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
