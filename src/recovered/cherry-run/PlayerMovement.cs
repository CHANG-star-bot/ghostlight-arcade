// Recovered C# from the distributed game's Assembly-CSharp.dll.
// Decompiled with ILSpy 9.1.0.7988; this is not the original project source.

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private enum MovementState
	{
		idle,
		running,
		jumping,
		falling
	}

	private Rigidbody2D rb;

	private BoxCollider2D coll;

	private SpriteRenderer sprite;

	private Animator anim;

	[SerializeField]
	private LayerMask jumpableGround;

	private float dirX;

	[SerializeField]
	private float moveSpeed = 7f;

	[SerializeField]
	private float jumpForce = 7f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		coll = GetComponent<BoxCollider2D>();
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		dirX = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
		UpdateAnimationState();
	}

	private void UpdateAnimationState()
	{
		MovementState value;
		if (dirX > 0f)
		{
			value = MovementState.running;
			sprite.flipX = false;
		}
		else if (dirX < 0f)
		{
			value = MovementState.running;
			sprite.flipX = true;
		}
		else
		{
			value = MovementState.idle;
		}
		if (rb.velocity.y > 0.1f)
		{
			value = MovementState.jumping;
		}
		else if (rb.velocity.y < -0.1f)
		{
			value = MovementState.falling;
		}
		anim.SetInteger("State", (int)value);
	}

	private bool IsGrounded()
	{
		return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
	}
}
