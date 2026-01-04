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
     
 
     private void Awake()
     {
         if(Instance == null)
         {
             Instance = this;
             DontDestroyOnLoad(this.gameObject); 
         }
         else
         {
             Destroy(this.gameObject);
         }
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
        Debug.Log("ゲームクリア");

        OnGameClear?.Invoke();
    }

    
 }