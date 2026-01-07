using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    void Update () {
        // 現在のシーンが始まってからの時間
        float time = Time.timeSinceLevelLoad - 3f; 
        Debug.Log ("経過時間(秒)" + time);
    }
}