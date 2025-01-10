using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSeed = 5f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private Animator animator;
    private bool isGrounded;
    private Rigidbody2D rb;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoveMent();
        HanldeJump();
        UpdateAmimation();
    }
    private void HandleMoveMent() //di chuyển 
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity=new Vector2 (moveInput*moveSeed, rb.velocity.y);
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

    }
  private void HanldeJump() //check nhảy
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);

        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
   private void UpdateAmimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsJumping", isJumping);
    }
}
