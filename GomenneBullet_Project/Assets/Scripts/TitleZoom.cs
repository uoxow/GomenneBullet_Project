using UnityEngine;
using System.Collections; 
using UnityEngine.SceneManagement;


public class TitleZoom : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject textObject;
    [SerializeField] private GameObject lookObject;
    [SerializeField] private GameObject instructionObject;
    [SerializeField] private GameObject logoObject;

    public float animationDuration = 2.0f; // 2秒間動かす
    public float positionSpeed = 0.7f;    // 1秒間に動く距離
    public float zoomSpeed = 1f;        // 1秒間に大きくなる量
    private int progressManager = 0;  //0→スタート画面　１→操作説明画面　２→プレイシーンへ

    void Update()
    {
        if(progressManager == 1){
            if(Input.GetMouseButtonDown(0)){
                instruction();
                progressManager = 2 ;
            }
        }else if(progressManager == 2 ){
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
                StartGame();
            }
        }
    }

    public void ZoomAnimation() 
    {
        Debug.Log("AnimationEvent発生");
        // コルーチンを開始
        StartCoroutine(DoZoom());
    }

    private IEnumerator DoZoom()
    {
        float elapsedTime = 0f; 

        while (elapsedTime < animationDuration)
        {
            // 毎フレームの移動量を計算
            float stepPos = positionSpeed * Time.deltaTime;
            float stepZoom = zoomSpeed * Time.deltaTime;

            transform.position += new Vector3(-stepPos, stepPos, 0);
            transform.localScale += Vector3.one * stepZoom;
            logoObject.transform.position += new Vector3(0, -stepZoom , 0);

            // 経過時間を加算
            elapsedTime += Time.deltaTime;

            yield return null; 
        }
        if (textObject != null)
        {
            textObject.SetActive(true);
            lookObject.SetActive(true);
            progressManager = 1;
        }
    }

    private void instruction(){
        Destroy(logoObject);
        Destroy(textObject);
        instructionObject.SetActive(true);
    }

    private void StartGame()
    {
        Debug.Log("ゲーム本編へ");
        SceneManager.LoadScene("MainScene"); 
    }
}