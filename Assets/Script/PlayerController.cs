using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSeed = 5f;
    [SerializeField] private float JumpForce = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private Rigidbody2D rb;
    private void Awake()
    {
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
    }
    private void HandleMoveMent()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity=new Vector2 (moveInput*moveSeed, rb.velocity.y);
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

    }
  private void HanldeJump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);

        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
