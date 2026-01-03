using UnityEngine;
using System;
using System.Threading.Tasks;

public class PlayerManager : MonoBehaviour
{
    // プレイヤーの移動速度
    private int moveSpeed = 5; //動く速さ
    public int maxHP = 7; //最大HP
    public int nowHP; //現在のHP
    private bool isInvincible;
    public float InvincibleTime = 1f ; //無敵時間(秒)
    private float timer = 0f ;

    void Start()
    {
        nowHP = maxHP;
        isInvincible = false;
    }
    
    void Update()
    {   
        //プレイヤーの動き
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;
        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
        
        if(isInvincible)
        {
　　　　　  //ここに無敵状態のときの処理を書く
            //Debug.Log("無敵状態");

            //毎フレームタイマー変数にTime.deltaTimeを足す
            timer += Time.deltaTime;
            //Debug.Log(InvincibleTime);

             //タイマーが無敵時間を超えたとき
            if(timer > InvincibleTime)
            {   
                timer = 0f;
                //Debug.Log("無敵状態終わり");

                //無敵状態フラグをFalseにする
                isInvincible = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        //ダメージ判定
        //Debug.Log("当たり判定発動相手の名前：" + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy_Bullet" && isInvincible == false){
            nowHP -= 1;
            Debug.Log("HP１減少 / 残り: " + nowHP);
            isInvincible = true;
        }
        //HPゼロになったらゲームオーバー処理
        if(nowHP == 0){
            Debug.Log("HP０ ゲームオーバー");
        }
    }
}