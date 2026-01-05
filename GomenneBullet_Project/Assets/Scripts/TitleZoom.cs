using UnityEngine;
using System.Collections; 

public class TitleZoom : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject textObject;

    public float animationDuration = 2.0f; // 2秒間動かす
    public float positionSpeed = 0.7f;    // 1秒間に動く距離
    public float zoomSpeed = 1f;        // 1秒間に大きくなる量

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
            // 毎フレームの移動量を計算します
            float stepPos = positionSpeed * Time.deltaTime;
            float stepZoom = zoomSpeed * Time.deltaTime;

            transform.position += new Vector3(-stepPos, stepPos, 0);
            transform.localScale += Vector3.one * stepZoom;

            // 経過時間を足していきます
            elapsedTime += Time.deltaTime;

            yield return null; 
        }
        if (textObject != null)
        {
            textObject.SetActive(true);
        }
    }
}