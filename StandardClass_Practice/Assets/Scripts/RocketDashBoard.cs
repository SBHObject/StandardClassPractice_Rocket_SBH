using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketDashBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject rocket;

    //점수 표기 텍스트
    [SerializeField]
    private TextMeshProUGUI currentScoreTxt;
    [SerializeField]
    private TextMeshProUGUI highScoreTxt;

    //실제 점수
    private int highScore;
    private int nowScore = 0;

    //점수 저장용 키 값
    private string highScoreKeyName = "HighScore";

    //저장용 플래그 변수
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

    //점수 확인 함수
    private void ScoreChecker()
    {
        //현재 위치 표기
        nowScore = (int)rocket.transform.position.y;
        currentScoreTxt.text = $"{nowScore} M";

        //현재 점수가 최고점수보다 높을때 작동
        if (nowScore >= highScore)
        {
            highScoreFlag = true;
            //최고점수를 현재점수로 변경
            highScore = nowScore;
            highScoreTxt.text = $"{highScore} M";
        }

        //최고점수를 달성하고, 떨어지기 시작하면 저장
        if (highScoreFlag && highScore > nowScore)
        {
            highScoreFlag = false;
            PlayerPrefs.SetInt(highScoreKeyName, highScore);
        }
    }

    public void ResetButton()
    {
        //리셋을 누르면 현재 최고점수 저장
        PlayerPrefs.SetInt(highScoreKeyName, highScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
