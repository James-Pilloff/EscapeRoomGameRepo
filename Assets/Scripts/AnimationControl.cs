using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    private bool isMoving;
    private float xMove;
    private float yMove;

    // Start is called before the first frame update
    void Start()
    {
        animator.direction = 2;
        animator.idle = true;
        // 0, 1, 2, 3 correspond to N, E, S, W respectively
    }

    // Update is called once per frame
    void Update()
    {
        xMove = player.GetComponent<PlayerMoving>().movement.x;
        yMove = player.GetComponent<PlayerMoving>().movement.y;

        if (xMove < 0)
        {
            animator.SetInteger("direction", 3);
        } else if (xMove > 0)
        {
            animator.SetInteger("direction", 1);
        } else if (yMove < 0)
        {
            animator.SetInteger("direction", 2);
        } else if (yMove > 0)
        {
            animator.SetInteger("direction", 0);
        }
        
        animator.SetBool("isIdle", xMove == 0 && yMove == 0);

    }
}
