using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;
    [SerializeField]
    private Image[] heartIcons;
    
    private Color lostColor = new Color(0.34f, 0.26f, 0.26f);
    private Color activeColor = new Color(1f, 0.2862f, 0.2784f);
    int i;


    void Update()
    {
        
        /*if(playerManager.maxHP - playerManager.nowHP == 0){
                heartIcons[i].color = activeColor;
        }*/
        for( i=0 ; i<playerManager.maxHP ; i++){ 
            
            if(playerManager.maxHP - playerManager.nowHP <= i){ //受けたダメージ0+1のときHpicon[0]←が暗い色　合計2受けているとHpIcon1とHpIcon2がlostColorになる
                heartIcons[i].color = activeColor;
            }else {
                heartIcons[i].color = lostColor;
            }
        }
    }
}