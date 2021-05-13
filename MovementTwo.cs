using UnityEngine;
using UnityEngine.Events;

public class MovementTwo : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	
	[SerializeField] private bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;							
	[SerializeField] private Transform m_CeilingCheck;							
	[SerializeField] private Collider2D m_CrouchDisableCollider;				

	const float k_GroundedRadius = .2f;
	public bool m_Grounded;            
	const float k_CeilingRadius = .2f; 
	private Rigidbody2D m_Rigidbody2D;
	public bool m_FacingRight = true;  
	private Vector3 m_Velocity = Vector3.zero;
	public float jumpingRate = 1;
	float nextJump;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	private void Awake()
	{
		nextJump = Time.time;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		if (move > 0 && !m_FacingRight)
		{
			Flip();
		}
		else if (move < 0 && m_FacingRight)
		{
			Flip();
		}
		if (m_Grounded && jump){
			if(Time.time >= nextJump){
				m_Grounded = false;
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
				nextJump = Time.time + jumpingRate;
			}
		}
	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public bool IsFacingRight(){
		if(transform.localScale.x > 0f){
			return true;
		}
		else{
			return false;
		}
	}
	public void Knockback(){
        m_Rigidbody2D.AddForce(new Vector3(-700,0));
	}
}