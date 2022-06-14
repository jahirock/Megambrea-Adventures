using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float npcSpeed = 1.5f;
    public bool isWalking;
    public float walkTime = 1.5f;
    public float waitTime = 3.0f;

    private float waitTimeCounter;
    private float walkCounter;
    private int currentDirection;

    private Vector2[] walkingDirections =
    {
        //Definimos las diferentes direcciones que tomará nuestro npc.
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0, -1)
    };

    private Rigidbody2D npcRigidbody;

    private Animator npcAnimator;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string moving = "IsMoving";

    public Vector2 lastMovement = Vector2.zero;

    public BoxCollider2D villagerZone;

    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody2D>();
        npcAnimator = GetComponent<Animator>();
        waitTimeCounter = waitTime;
        walkCounter = walkTime;
    }

    void Update()
    {
        if (isWalking)
        {
            npcRigidbody.velocity = walkingDirections[currentDirection] * npcSpeed;
            lastMovement = walkingDirections[currentDirection];
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
            
            if(villagerZone != null)
            {
                if(
                    gameObject.transform.position.x < villagerZone.bounds.min.x ||
                    gameObject.transform.position.x > villagerZone.bounds.max.x ||
                    gameObject.transform.position.y < villagerZone.bounds.min.y ||
                    gameObject.transform.position.y > villagerZone.bounds.max.y
                )
                {
                    transform.position = new Vector3(
                        Mathf.Clamp(this.transform.position.x, villagerZone.bounds.min.x, villagerZone.bounds.max.x),
                        Mathf.Clamp(this.transform.position.y, villagerZone.bounds.min.y, villagerZone.bounds.max.y),
                        this.transform.position.z
                    );
                    StopWalking();
                }
            }
        }
        else
        {
            //npcRigidbody.velocity = Vector2.zero;
            waitTimeCounter -= Time.deltaTime;

            if (waitTimeCounter < 0)
            {
                StartWalking();
            }
        }

        npcAnimator.SetFloat(horizontal, walkingDirections[currentDirection].x);
        npcAnimator.SetFloat(vertical, walkingDirections[currentDirection].y);
        npcAnimator.SetBool(moving, isWalking);
        npcAnimator.SetFloat(lastHorizontal, lastMovement.x);
        npcAnimator.SetFloat(lastVertical, lastMovement.y);
    }

    private void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkCounter = walkTime;
    }

    private void StopWalking()
    {
        isWalking = false;
        waitTimeCounter = waitTime;
        npcRigidbody.velocity = Vector2.zero;
    }

    private void ChangeDirection()
    {
        if (currentDirection == 0) currentDirection = 2;
        else if (currentDirection == 2) currentDirection = 0;
        else if (currentDirection == 1) currentDirection = 3;
        else if (currentDirection == 3) currentDirection = 1;
    }
}
