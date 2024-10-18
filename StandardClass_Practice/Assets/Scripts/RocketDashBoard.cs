using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketDashBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject rocket;

    //���� ǥ�� �ؽ�Ʈ
    [SerializeField]
    private TextMeshProUGUI currentScoreTxt;
    [SerializeField]
    private TextMeshProUGUI highScoreTxt;

    //���� ����
    private int highScore;
    private int nowScore = 0;

    //���� ����� Ű ��
    private string highScoreKeyName = "HighScore";

    //����� �÷��� ����
    private bool highScoreFlag = false;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKeyName, 0);
        highScoreTxt.text = $"{highScore} M";
    }
    private void Update()
    {
        ScoreChecker();
    }

    //���� Ȯ�� �Լ�
    private void ScoreChecker()
    {
        //���� ��ġ ǥ��
        nowScore = (int)rocket.transform.position.y;
        currentScoreTxt.text = $"{nowScore} M";

        //���� ������ �ְ��������� ������ �۵�
        if (nowScore >= highScore)
        {
            highScoreFlag = true;
            //�ְ������� ���������� ����
            highScore = nowScore;
            highScoreTxt.text = $"{highScore} M";
        }

        //�ְ������� �޼��ϰ�, �������� �����ϸ� ����
        if (highScoreFlag && highScore > nowScore)
        {
            highScoreFlag = false;
            PlayerPrefs.SetInt(highScoreKeyName, highScore);
        }
    }

    public void ResetButton()
    {
        //������ ������ ���� �ְ����� ����
        PlayerPrefs.SetInt(highScoreKeyName, highScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
