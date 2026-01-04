using UnityEngine;
using UnityEngine.UI;

public class EnemyGauge : MonoBehaviour
{
    [SerializeField]
    private EnemyManager EnemyManager;
    [SerializeField]
    private Image[] heartIcons;
    
    private Color lostColor = new Color(1f, 0.9710f, 1f);
    private Color activeColor = new Color(0.3019f, 0.2862f, 0.6627f);
    int i;


    void Update()
    {
        for( i=0 ; i<EnemyManager.maxGauge ; i++){ 
            if(EnemyManager.nowGauge < i || EnemyManager.nowGauge == i){
                //Debug.Log("ゲージの色変わった");
                heartIcons[i].color = activeColor;
            }else{
                heartIcons[i].color = lostColor;
            }
        }
    }
}