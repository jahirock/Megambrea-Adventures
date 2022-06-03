using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0F;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5F)
        {
            this.transform.Translate(
                new Vector3(
                    Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 
                    0, 0
                )
            );
        }

        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5F)
        {
            this.transform.Translate(
                new Vector3(
                    0,
                    Input.GetAxisRaw(vertical) * speed * Time.deltaTime,
                    0
                )
            );
        }

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
    }
}
