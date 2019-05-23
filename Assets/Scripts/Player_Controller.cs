using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed;
    private float currentMoveSpeed;
    //public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigibody;
    private bool playerMoving;
    public Vector2 lastMove;
	private Vector2 moveInput;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    public bool canMove;
	
	private SFXManager sfxMan;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigibody = GetComponent<Rigidbody2D>();
		sfxMan = FindObjectOfType<SFXManager>();
		
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;
		
		lastMove = new Vector2(0, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if (!canMove)
        {
            myRigibody.velocity = Vector2.zero;
            return;
        }

        if (!attacking)
        {
           /* if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(
                //    new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                myRigibody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigibody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(
                //    new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigibody.velocity = new Vector2(myRigibody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigibody.velocity = new Vector2(0f, myRigibody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigibody.velocity = new Vector2(myRigibody.velocity.x, 0f);
            } */
			moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
			
			if(moveInput != Vector2.zero)
			{
				myRigibody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				lastMove = moveInput;
			} else {
					
					myRigibody.velocity = Vector2.zero;
					}
			
            if (Input.GetKeyDown(KeyCode.Z))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigibody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
				
				
				sfxMan.playerAttack.Play();
            }

            /*if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed / 1.4142f; 
            }
            else
            {
                currentMoveSpeed = moveSpeed;
            } */
        }



        if(attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }


        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);



    }
}
