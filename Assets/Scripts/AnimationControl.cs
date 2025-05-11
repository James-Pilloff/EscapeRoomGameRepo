using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public int direction = 2;

    private bool isMoving;
    private float xMove;
    private float yMove;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("direction", 2);
        animator.SetBool("isIdle", true);
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
            transform.localScale = new Vector3(-1, 1, 1);
            direction = 3;
        } else if (xMove > 0)
        {
            animator.SetInteger("direction", 1);
            transform.localScale = new Vector3(1, 1, 1);
            direction = 1;
        } else if (yMove < 0)
        {
            animator.SetInteger("direction", 2);
            transform.localScale = new Vector3(1, 1, 1);
            direction = 2;
        } else if (yMove > 0)
        {
            animator.SetInteger("direction", 0);
            transform.localScale = new Vector3(1, 1, 1);
            direction = 0;
        }
        
        animator.SetBool("isIdle", xMove == 0 && yMove == 0);
    }
}
