using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    void Start()
    {
        Debug.Log("びっくり");
        animator.Play("astonish");
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
