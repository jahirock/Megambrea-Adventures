using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";

    public float speed = 4.0F;
    private float currentSpeed;
    private bool walking = false;
    private bool attacking = false;
    public Vector2 lastMovement = Vector2.zero;

    public float attackingTime;
    private float attackingTimeCounter; 

    private Animator animator;
    private Rigidbody2D playerRigidBody;

    public static bool playerCreated;
    public string nextPlaceName;

    private SFXManager sfxManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        sfxManager = FindObjectOfType<SFXManager>();

        if(!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;

        if(Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackingTimeCounter = attackingTime;
            playerRigidBody.velocity = Vector2.zero;
            animator.SetBool(attackingState, attacking);

            sfxManager.playerAttack.Play();
        }

        if(attacking)
        {
            attackingTimeCounter -= Time.deltaTime;
            if(attackingTimeCounter < 0)
            {
                attacking = false;
                animator.SetBool(attackingState, attacking);
            }
        }
        else
        {
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5F || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5F)
            {
                walking = true;
                lastMovement = new Vector2(
                    Input.GetAxisRaw(horizontal),
                    Input.GetAxisRaw(vertical)
                );
                playerRigidBody.velocity = lastMovement.normalized * speed; //* Time.deltaTime;

            }
        }

        if(!walking || attacking)
        {
            playerRigidBody.velocity = Vector2.zero;
        }

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
