using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1;
    //[SerializeField] 
    private Rigidbody2D enemyRigidBody;

    //[SerializeField] 
    private bool isMoving;

    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;

    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;

    private Animator enemyAnimator;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string moving = "IsMoving";

    public Vector2 lastMovement = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps * Random.Range(0.5F, 1.5F);
        timeToMakeStepCounter = timeToMakeStep * Random.Range(0.5F, 1.5F);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRigidBody.velocity = directionToMakeStep;

            if(timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRigidBody.velocity = Vector2.zero;
            }

            lastMovement = directionToMakeStep;
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if(timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMakeStep = new Vector2(Random.Range(-1,2), Random.Range(-1, 2)) * enemySpeed;
            }
        }

        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);
        enemyAnimator.SetBool(moving, isMoving);
        enemyAnimator.SetFloat(lastHorizontal, lastMovement.x);
        enemyAnimator.SetFloat(lastVertical, lastMovement.y);
    }
}
