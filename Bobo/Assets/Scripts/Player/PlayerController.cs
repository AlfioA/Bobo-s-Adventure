using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float runSpeed=10.0f;
    public float horizontalMove;
    Rigidbody2D rigid;
    float jumpVelocity = 8f;//1720.0f;
    BoxCollider2D boxCollider;
    //CircleCollider2D circle;
    LayerMask platformlayermask;
    public bool isGround = true;
    public bool shooting = false;
    private bool facingRight = true;
    Vector2 movement;
    public Chest chest;
    public bool m_Grounded;
  
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    private Vector3 m_Velocity = Vector3.zero;
    LayerMask coinLayer;

    private Vector3 respawnPoint; 
    public GameObject fallDetector;
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    [SerializeField] float translationMacEnemy=3.84f;

    private void Awake(){
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        StartingPosition();
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        platformlayermask = LayerMask.GetMask("Ground");
        coinLayer = LayerMask.GetMask("Coin");
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = IsGrounded();
        horizontalMove = Input.GetAxis("Horizontal");
        Jump();
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void FixedUpdate()
    {   
        m_Grounded = false;
        IsShooting();
 //       Flip();
      
    }

    void StartingPosition(){
        if(PlayerStats.checkpoint==1 && !PlayerStats.challengeMode){
            transform.position=new Vector3(91.3f,35.42f,0);
        }
        else if(PlayerStats.checkpoint==2 && !PlayerStats.challengeMode){
            transform.position=new Vector3(277.4932f,11.15392f,0);
        }
    }

    private void Move(float move)
    {
        if (!shooting)
        {
            if (m_Grounded){

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			    else if (move < 0 && m_FacingRight)
			    {
				// ... flip the player.
				Flip();
			    }
		    }
        }
    }

    private void Jump()
    {
        if (isGround && GameInputManager.GetKeyDown("Jump"))
        {
            rigid.AddForce(new Vector2(0f,jumpVelocity*100));
            //rigid.velocity += Vector2.up * jumpVelocity;
        }
    }

    public bool IsGrounded()
    {
       RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down,0.1f,platformlayermask);
        return ray.collider != null;
        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.13f, platformlayermask);
        for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				return true;
			}
		}
        return false;*/
    }

    public bool IsShooting()
    {
        if (GameInputManager.GetKey("Shoot") && isGround)
        {
            shooting=true;
            rigid.velocity=new Vector2(0,0);
        }
        else
        {
            shooting = false;
        }
        return shooting;
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;
		transform.localScale = flipped;

		transform.Rotate(0f, 180f, 0f);
	}

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "FallDetector"){ // Torna al punto di spawn;
            transform.position = respawnPoint;
            GetComponent<Health>().TakeDamage(1);
        }
        else if(other.tag == "Checkpoint"){
            respawnPoint = transform.position;
        }

        if (other.gameObject.CompareTag("Coin"))//piglia coin
        {   
            SoundManagerScript.Instance.PlaySound("coin");
            PlayerStats.money++;
            Destroy(other.gameObject);
            PlayerStats.score += 10;
            //coroutine col suono
        }
        else if (other.gameObject.CompareTag("Spikes"))//takeDamage
        {
            //Debug.Log("Ho preso danno");
            //vita.takeDamage(1);
            StartCoroutine(KnockBack(0.03f, 10, transform.position));
        }
        else if (other.gameObject.CompareTag("Key") && chest.open){
            PlayerStats.key++;
            Destroy(other.gameObject);
        }
    }

    public IEnumerator KnockBack(float knockDuration,float knockPower,Vector3 knockDirection)
    {
        float timer = 0;
        while (knockDuration > timer)
        {
            timer += Time.deltaTime;
            rigid.AddForce(new Vector3(knockDirection.x * -1, knockDirection.y * knockPower, transform.position.z));//knockDirection.y * knockPower
        }
        yield return 0;
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.tag=="Pedana"){
            transform.parent=other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag=="Pedana"){
            transform.parent=null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mac"))
        {
            transform.Translate(translationMacEnemy,0,0);
            //StartCoroutine(KnockBack(0.03f, 100, transform.position));
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }*/
}
