using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
 public class GameManager : MonoBehaviour
 {
     public static GameManager Instance;
     public bool isGameOver = false;
     public bool isGameClear = false;
     public event Action OnGameOver;
     public event Action OnGameClear;
     public TimeManager timemanager;
     public ClearTimeText clearTimeText;

     public event System.Action OnGameStart; // 開始イベント
     public bool IsGameActive = false;

     [SerializeField] private Countdown countdown;
 
     private void Awake()
     {
         if(Instance == null)
         {
             Instance = this;
             //DontDestroyOnLoad(this.gameObject); 
         }
         else
         {
             //Destroy(this.gameObject);
         }
     }

     void Start()
    {
        // カウントダウン
        StartCoroutine(GameStartSequence());
        
    }

    public IEnumerator GameStartSequence()
    {
        countdown.DisplayCountdown();
        for(int i=3 ; i>0 ; i--){
            //UIでカウントダウン
            countdown.UpdateCountdownText(i.ToString());
            yield return new WaitForSeconds(1f);
        }

        countdown.UpdateCountdownText("START!");
        countdown.HideCountdown();//UIさよなら
        IsGameActive = true;
        OnGameStart?.Invoke(); 
    }

     public void SetGameOver()
    {
        if (isGameOver) return; // 既にゲームオーバーなら何もしない

        isGameOver = true;
        Debug.Log("ゲームオーバー");

        // 聞いている全員の関数が一斉に動く
        OnGameOver?.Invoke();
    }

    public void SetGameClear()
    {
        if (isGameClear) return; 

        isGameClear = true;
        Debug.Log("クリア！タイムは " + timemanager.clearTime.ToString("F2") + "秒でした！");
        clearTimeText.TimeText("time：" + timemanager.clearTime.ToString("F2"));

        OnGameClear?.Invoke();
    }

    
 }