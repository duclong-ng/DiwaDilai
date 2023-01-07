using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 8f, jumpForce = 15f, maxVelocity = 4f, maxVelocityJump = 3.5f;
	public bool isFalling = false;
	public bool isJumping = false;

	//[SerializeField] //To visible Private function in Inspector Panel 
	private Rigidbody2D myBody;//Physic
	private Animator anim;//Animation

	void Awake()
	{
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	void Start()
	{

	}
	void FixedUpdate()
	{
		PlayerMoveKeyboard();
	}

	//Create function to move player
	void PlayerMoveKeyboard()
	{
		float forceX = 0f;
		float jumpForceUp = 0f;
		//Returns the absolute value of f and return x velecity in Rigidbody
		float vel = Mathf.Abs(myBody.velocity.x);
		float velJ = Mathf.Abs(myBody.velocity.y);
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		if (h > 0)
		{

			if (vel < maxVelocity)//it still move
				forceX = speed;
			Vector3 temp = transform.localScale;
			temp.x = 1.0f;

			transform.localScale = temp;
			anim.SetBool("Walk", true);
		}
		else if (h < 0)
		{
			if (vel < maxVelocity)
				forceX = -speed;//left side is negative
			Vector3 temp = transform.localScale;
			temp.x = -1.0f;//b/c he facing the left side
			transform.localScale = temp;

			anim.SetBool("Walk", true);
		}
		else
		{
			anim.SetBool("Walk", false);
		}
		// Iumping
		if (velJ == 0) //in ground
        {
			anim.SetBool("Jump", false);
			isFalling = false;
			isJumping = false;
		}
		if (v > 0)
		{
			if (!isFalling && velJ < maxVelocityJump)
            {
				isJumping = true;
				jumpForceUp = jumpForce;
				anim.SetBool("Jump", true);
            }
		}
		else if(isJumping)
		{
			jumpForceUp = 0f;
			isFalling = true;
		}

		if (velJ >= maxVelocityJump)
        {
			isFalling = true;
        }

		//Apply a force to the rigidbody, 
		myBody.AddForce(new Vector2(forceX, jumpForceUp));
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
			
		}
    }
}
