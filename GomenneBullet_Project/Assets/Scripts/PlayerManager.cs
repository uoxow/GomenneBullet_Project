using UnityEngine;
using System;
using System.Threading.Tasks;

public class PlayerManager : MonoBehaviour
{
    // プレイヤーの移動速度
    private int moveSpeed = 5;
    
    void Update()
    {
        //プレイヤーの動き
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float y = Input.GetAxis("Vertical") * moveSpeed;
        transform.position += new Vector3(x, y, 0) * Time.deltaTime;
    }

}