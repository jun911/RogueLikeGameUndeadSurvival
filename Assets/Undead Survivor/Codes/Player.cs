using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public bool isDead = false;
    
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec); // move position
    }

    private void LateUpdate()
    {
        if (inputVec.x != 0)
        {
            spriteRenderer.flipX = inputVec.x < 0;
        }

        if (isDead)
        {
            animator.SetTrigger("Dead");
        }

        animator.SetFloat("Speed", inputVec.magnitude); // magnitude : 1 or 0
    }
}