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
    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {

        float move_h = 0;
        float move_v = 0;
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

        targetSpeed = new Vector2(speed * move_h, speed * move_v);
        rigidBody2D.AddForce(speedFactor * (targetSpeed - rigidBody2D.velocity), ForceMode2D.Impulse);
    }
}
