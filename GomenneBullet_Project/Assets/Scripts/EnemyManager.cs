using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public int moveSpeed = 5; // 敵の移動速度

    //★ゲージが最大値になるとゲームクリア★

    public int maxGauge = 9; //最大値
    private int gaugeCountMax = 7;//一つのゲージをためるのに必要なハートのカウント
    public int gaugeCount;
    public int nowGauge;
    void Start()
    {
        nowGauge = 0;
        gaugeCount = 0;
    }

    void Update()
    {   
      /*  // 敵を下方向に移動させる
        transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;

        if (this.transform.position.y < -6) // 画面の外に出たら削除
        {
            Destroy(this.gameObject);
        }*/
    }

    void OnTriggerEnter2D(Collider2D collision){
        //ダメージ判定
        //Debug.Log("当たり判定発動相手の名前：" + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player_Bullet" /*&& isInvincible == false*/){
            gaugeCount += 1;
            //Debug.Log("カウント１増加 / 合計 " + gaugeCount);
            if(gaugeCount >= gaugeCountMax){
                nowGauge += 1;
                gaugeCount = 0;
                Debug.Log("ゲージ１増加 / 合計 " + nowGauge);
            }
        }
        //HPゼロになったらゲームオーバー処理
        if(nowGauge == maxGauge){
            Debug.Log("ゲームクリア");
        }
    }

}