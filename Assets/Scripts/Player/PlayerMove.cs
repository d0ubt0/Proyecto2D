using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Move
    Rigidbody2D rb;
    public float _speedPlayer;
    private float xInputPlayer;
    private bool isRunning;
    public float _runSpeedPlayer;
    private float actualSpeed;
    private Vector2 movementVector;
    //IsGrounded
    private bool isGrounded;
    public LayerMask layerMaskGrounded;
    GameObject foot;
    //IsWalled
    private bool isWalledL;
    private bool isWalledR;
    private bool isSliding;
    //Jump
    public float forceJump;
    public float jumpTime;
    private float jumpTimer;
    private bool isJumping;
    private Vector2 jumpVector;
    //Animator
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    private AudioSource jumpSoundEffect;


    void Start()
    {
        Init();
    }

    void Update() 
    {
        PlayerMoveInputs();

        CheckGround();

        CheckWall();

        PlayerXMovement();

        NormalJump();

        BasicAnimations();



    }

    private void FixedUpdate() 
    {
        Movement();

        WallSlide();
        
    }

    void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        foot = GameObject.Find("Foot");
    }

    void PlayerMoveInputs()
    {
        xInputPlayer = Input.GetAxis("Horizontal");
        if(isWalledL && xInputPlayer<0)
        {
            xInputPlayer = 0;
        }
        if(isWalledR && xInputPlayer>0)
        {
            xInputPlayer = 0;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

    }
    
    void PlayerXMovement()
    {
        //Movimiento lateral
        if(isRunning)
        {
            actualSpeed = _runSpeedPlayer;
        }
        else
        {
            actualSpeed =_speedPlayer;
        }
        movementVector = new Vector2(actualSpeed*xInputPlayer,0f);
    }

    void CheckGround()
    {
        //Booleana para comprobar si esta en el suelo
        bool checkMaskGrounded;
        checkMaskGrounded = Physics2D.OverlapCircle(foot.transform.position,0.05f,layerMaskGrounded);
        if (Mathf.Abs(rb.velocity.y)>0.1f & checkMaskGrounded==false)
        {
            isGrounded = false;
        }
        else if(checkMaskGrounded & Mathf.Abs(rb.velocity.y)<0.1f)
        {
            isGrounded = true;
        }
    }

    void CheckWall()
    {
        //Checkea la pared izquierda y derecha
        isWalledL = Physics2D.Raycast(rb.position,Vector2.left,0.12f,layerMaskGrounded);
        isWalledR = Physics2D.Raycast(rb.position,Vector2.right,0.12f,layerMaskGrounded);
    }

    void Jump()
    {
                  
    }

    void NormalJump()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpSoundEffect.Play();
            
            if(isGrounded)
            {
                isJumping = true;
            }
            else if(isWalledL)
            {
                jumpVector = new Vector2 (forceJump*0.7f,forceJump);
                isJumping = true;
            }
            else if(isWalledR)
            {
                jumpVector = new Vector2 (forceJump*-0.7f,forceJump);
                isJumping = true;
            }
            
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true && jumpTimer<jumpTime)
        {
            
            jumpVector.y = forceJump;
            jumpTimer = jumpTimer + Time.deltaTime;

        }

        if(Input.GetKeyUp(KeyCode.Space) || jumpTimer>jumpTime)
        {
            jumpTimer = 0f;
            isJumping = false;
            jumpVector =Vector2.zero;
        }
    }

    void Movement()
    {
        
        if(isJumping)
        {
            rb.velocity = new Vector2(movementVector.x+jumpVector.x,jumpVector.y);
        }
        else if(isGrounded)
        {
            rb.velocity = new Vector2(movementVector.x,rb.velocity.y);
        }
        else 
        {
            rb.velocity = new Vector2(Mathf.Clamp(movementVector.x+rb.velocity.x,-1f*actualSpeed,actualSpeed),rb.velocity.y);
        }
    }

    void WallSlide()
    {

        if(!isGrounded && isWalledL && !isJumping)
        {
            isSliding = true;
        }
        else if(!isGrounded && isWalledR && !isJumping)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
        if(isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x,Mathf.Clamp(rb.velocity.y-0.05f,-0.7f,rb.velocity.y));
        }
    }

    void BasicAnimations()
    {
        //Voltear segun el input 
        if(xInputPlayer<0)
        {
            spriteRenderer.flipX = true;
        }   
        else if(xInputPlayer>0)
        {
            spriteRenderer.flipX = false;                     
        }
        if(xInputPlayer!=0)
        {
            anim.SetBool("Walk",true);
        }
        else
        {
            anim.SetBool("Walk",false);
        }
        anim.SetBool("IsGrounded",isGrounded);
        anim.SetBool("Run",isRunning); 
        anim.SetBool("Jump",isJumping);
        

    }   
}