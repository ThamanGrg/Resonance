using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 8f;
    public float jumpForce = 11f;

    [Header("Ground Check")]
    public ContactFilter2D contactFilter;

    [Header("screenBound")]
    private float minX;
    private float maxX;
    private float playerHalfWidthX;

    [Header("Movement")]
    private InputAction move;
    private InputAction jump;
    private Rigidbody2D rb;



    void Start()
    {
        Camera cam = Camera.main;

        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;
        playerHalfWidthX = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        minX = cam.transform.position.x - camWidth + playerHalfWidthX;
        maxX = cam.transform.position.x + camWidth - playerHalfWidthX;

        
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
        Move();
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        if (jump.IsPressed() && IsGrounded())
        {
            print("grounded");
            Jump();
        }

        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rb.position = pos;
    }


    [System.Obsolete]
    void Move()
    {
        float x = move.ReadValue<Vector2>().x;
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
