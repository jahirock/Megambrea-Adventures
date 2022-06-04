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
    
    public float speed = 4.0F;
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    private Animator animator;
    private Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;

        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5F)
        {
            /*this.transform.Translate(
                new Vector3(
                    Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 
                    0, 0
                )
            );*/
            playerRigidBody.velocity = new Vector2(
                Input.GetAxisRaw(horizontal) * speed, 
                playerRigidBody.velocity.y
            );
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(
                0,
                playerRigidBody.velocity.y
            );
        }

        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5F)
        {
            /*this.transform.Translate(
                new Vector3(
                    0,
                    Input.GetAxisRaw(vertical) * speed * Time.deltaTime,
                    0
                )
            );*/
            playerRigidBody.velocity = new Vector2(
                playerRigidBody.velocity.x,
                Input.GetAxisRaw(vertical) * speed
            );
            walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
        }
        else
        {
            playerRigidBody.velocity = new Vector2(
                playerRigidBody.velocity.x,
                0
            );
        }

        if(!walking)
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
