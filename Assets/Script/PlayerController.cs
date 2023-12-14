using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float jumpSpeed = 8f;

    private Rigidbody2D player;
    private Animator animator;

    private bool isFacingRight = true;

    private enum PlayerState
    {
        idle,
        running,
        jump,
        slide
    }

    private PlayerState currentState = PlayerState.idle;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(horizontalInput * speed, player.velocity.y);

        UpdateAnimationState(horizontalInput);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {
            Slide();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            ResetSlide();
        }
    }

  void UpdateAnimationState(float horizontalInput)
{
    PlayerState state;

    if (player.velocity.y > 0.1f)
    {
        state = PlayerState.jump;
    }
    else if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
    {
        state = PlayerState.slide;
    }
    else if (horizontalInput > 0f)
    {
        state = PlayerState.running;
        isFacingRight = true;
    }
    else if (horizontalInput < 0f)
    {
        state = PlayerState.running;
        isFacingRight = false;
    }
    else
    {
        state = PlayerState.idle;
    }

    SetPlayerState(state);
    FlipCharacter();
}

    void Jump()
    {
        if (IsGrounded())
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            SetPlayerState(PlayerState.jump);
        }
    }

    void Slide()
    {
        SetPlayerState(PlayerState.slide);
    }

    void ResetSlide()
    {
        SetPlayerState(PlayerState.idle);
    }

    bool IsGrounded()
    {
        // Implement your grounded check logic here
        // This is a basic placeholder that always returns true, modify it according to your game's needs
        return true;
    }

    void SetPlayerState(PlayerState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            animator.SetInteger("state", (int)currentState);
        }
    }

    void FlipCharacter()
    {
        // Flip the character based on the direction it's moving
        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 1 : -1;
        transform.localScale = scale;
    }
}
