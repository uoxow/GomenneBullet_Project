using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public GameObject QuizCanvas;      // クイズ画面全体
    public GameObject ChoicesButton;      // ボタン全体
    public GameObject Panel;            //panel
    public TextMeshProUGUI questionText;        // 問題文
    public TextMeshProUGUI trueText;         // 正解の文字
    public TextMeshProUGUI falseText;         // 不正解の文字

    [SerializeField]
    public PlayerManager playerManager;
    [SerializeField]
    public EnemyManager enemyManager;

    private bool isPlayerQuiz;       // 現在どちらのクイズか判定

    void Start()
    {
        QuizCanvas.SetActive(false);  // 最初は隠しておく
    }

    // クイズ開始（外部から呼ぶ）
    public void StartQuiz(bool forPlayer)
    {
        isPlayerQuiz = forPlayer;
        GameManager.Instance.IsGameActive = false; // ゲームを一時停止
        QuizCanvas.SetActive(true);
        ChoicesButton.SetActive(true);
        Panel.SetActive(true);

        if (isPlayerQuiz) {
            questionText.text = "どうせわたしのことなんてどうでもいいんだ！";
            trueText.text = "違う！大切だよ";
            falseText.text = "えー？そんなことないよ笑";
        } else {
            questionText.text = "わたしのこと、すき？";
            trueText.text = "一生愛してるよ";
            falseText.text = "嫌いだったら一緒に映画館とか行かないよ笑";
        }
    }

    public void OnClickTRUE()
    {
        ChoicesButton.SetActive(false);

        if (isPlayerQuiz) {
            // プレイヤー正解：復活
            questionText.text = "本当…？";
            playerManager.nowHP += 3 ;
            StartCoroutine(WaitAndResume(2.0f));
        } else {
            // 敵への正解：ゲームクリア
            questionText.text = "だいすき。\nきょうはごめんね。";
            Panel.SetActive(false);
            GameManager.Instance.SetGameClear();
        }
    }

    public void OnClickFALSE()
    {
        ChoicesButton.SetActive(false);

        if (isPlayerQuiz) {
            // プレイヤー不正解：ゲームオーバー
            questionText.text = "そっか。そんな感じなんだ…。もういい…";
            Panel.SetActive(false);
            GameManager.Instance.SetGameOver();
        } else {
            // 敵への不正解：継続
            questionText.text = "なんでまたそうやって不安にさせるの？";
            enemyManager.nowGauge -= 3; 
            StartCoroutine(WaitAndResume(2.0f));;
        }
    }

    private IEnumerator WaitAndResume(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResumeGame();
    }

    void ResumeGame()
    {
        QuizCanvas.SetActive(false);
        GameManager.Instance.IsGameActive = true; // ゲーム再開
    }
}