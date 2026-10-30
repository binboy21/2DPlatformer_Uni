using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public InputAction jump, dash;

    private Vector2 move;
    public bool isGrounded;

    private float speed = 5f;
    private float jumpHeight = 7f;

    private float dashTimer = 0f;
    private float maxDashTimer = 0.4f;
    public bool dashing;
    private int dashAmount = 1;

    public OrbBounce orbBounceMiniGame;
    public PlayerManager playerManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jump = GetComponent<PlayerInput>().actions["Jump"];
        dash = GetComponent<PlayerInput>().actions["Dash"];
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(move.x * speed, rb.linearVelocity.y);

        if (jump.triggered && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
            if (orbBounceMiniGame != null)
            {
                if (playerManager.player1Object == this.gameObject) orbBounceMiniGame.P1Count();
                else orbBounceMiniGame.P2Count();
            }
        }

        if (dash.triggered || dashing)
        {
            Dash();
        }
        else dashTimer -= Time.deltaTime;

        if (isGrounded) dashAmount = 1;
    }

    public void OnMove(InputValue moveValue)
    {
        move = moveValue.Get<Vector2>();
    }

    private void Dash()
    {
        if (dashing)
        {
            speed = 10f;

            if (dashTimer <= 0f)
            {
                dashTimer = maxDashTimer;
                dashing = false;
                speed = 5f;
            }
            else
            {
                rb.linearVelocity = new Vector2(move.x * speed, rb.linearVelocity.y);
                dashTimer -= Time.deltaTime;
            }
        }
        else
        {
            if (dashTimer <= 0f && dashAmount > 0)
            {
                dashing = true;
                dashTimer = 0.4f;
                if (!isGrounded) dashAmount--;
            }
        }
    }

    public void Bounce()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight/2);
        if (orbBounceMiniGame != null)
        {
            if (playerManager.player1Object == this.gameObject) orbBounceMiniGame.P1Count();
            else orbBounceMiniGame.P2Count();
        }
    }
}
