using UnityEngine;

public class PetAnimatorController : MonoBehaviour
{
    private Animator animator;
    bool facingRight = true;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isSlide",true);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isSlide",false);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("penguin_atack");
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;  // 翻轉 X 軸
        transform.localScale = scale;
    }
}
