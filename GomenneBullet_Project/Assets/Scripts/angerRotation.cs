using UnityEngine;

public class angerRotation : MonoBehaviour
{
    public int r_speed = 4;
    void Update()
    {
        //回転
        transform.Rotate(0,0,-r_speed);
    }
}
