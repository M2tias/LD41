// Date   : #CREATIONDATE#
// Project: #PROJECTNAME#
// Author : #AUTHOR#

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 5f)]
    private float speed = 1f;

    [SerializeField]
    [Range(0.2f, 2f)]
    private float speedFactor = 0.5f;

    private Vector2 targetSpeed;

    [SerializeField]
    private Rigidbody2D rigidBody2D;

    [SerializeField]
    private ToolManager toolManager;

    [SerializeField]
    private Animator animator;

    PlayerDirection dir = PlayerDirection.right;

    void Start()
    {
    }

    void Update()
    {
    }

    void FixedUpdate()
    {

        float move_h = 0;
        float move_v = 0;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("WALKLEFT");
            dir = PlayerDirection.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("WALKRIGHT");
            dir = PlayerDirection.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("WALKTOP");
            dir = PlayerDirection.top;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("WALKBOTTOM");
            dir = PlayerDirection.bottom;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move_h = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move_h = 1;
        }
        else
        {
            move_h = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move_v = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move_v = -1;
        }
        else
        {
            move_v = 0;
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            toolManager.TakeTool();
        }

        if(move_h == 0 && move_v == 0)
        {
            //TODO: TEMPORARY
            if (dir == PlayerDirection.left)
            {
                animator.SetTrigger("IDLELEFT");
                //Debug.Log("IDLELEFT");
            }
            else if(dir == PlayerDirection.top)
            {
                animator.SetTrigger("IDLETOP");
                //Debug.Log("IDLETOP");
            }
            else if(dir == PlayerDirection.bottom)
            {
                animator.SetTrigger("IDLEBOTTOM");
                //Debug.Log("IDLEBOTTOM");
            }
            else if(dir == PlayerDirection.right)
            {
                animator.SetTrigger("IDLE");
               // Debug.Log("IDLE");
            }
        }

        targetSpeed = new Vector2(speed * move_h, speed * move_v);
        rigidBody2D.AddForce(speedFactor * (targetSpeed - rigidBody2D.velocity), ForceMode2D.Impulse);
    }

    public PlayerDirection GetDir()
    {
        return dir;
    }
}

public enum PlayerDirection
{
    right, left, top, bottom
}
