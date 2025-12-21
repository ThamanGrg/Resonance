using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;
    public float jumpForce = 11f;
    public Animator anim;

    [Header("Ground Check")]
    public ContactFilter2D contactFilter;


    [Header("Movement")]
    private InputAction move;
    private InputAction jump;
    private Rigidbody2D rb;



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");

        move.Enable();
        jump.Enable();
    }

    [System.Obsolete]
    void Update()
    {
        if (move.ReadValue<Vector2>().x != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        Move();
        if (jump.IsPressed() && IsGrounded())
        {
            Jump();
        }

        // Vector2 pos = rb.position;
        // pos.x = Mathf.Clamp(pos.x, minX, maxX);
        // rb.position = pos;
    }


    [System.Obsolete]
    void Move()
    {
        float x = move.ReadValue<Vector2>().x;

        if (x < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
            cameraFollow.xoffset = -4f;
        }
        if (x > 0)
        {
            transform.eulerAngles = Vector3.zero;
            cameraFollow.xoffset = 4f;
        }


        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    [System.Obsolete]
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    { 
        return rb.IsTouching(contactFilter);
    }
}
