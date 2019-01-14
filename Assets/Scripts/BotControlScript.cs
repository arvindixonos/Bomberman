using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BotControlScript : MonoBehaviour
{
    private Animator anim;                          // a reference to the animator on the character

    private float turnSpeed = 0f;
    private float moveSpeed = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");              // setup h variable as our horizontal input axis
        float v = Input.GetAxis("Vertical");                // setup v variables as our vertical input axis

        turnSpeed = Mathf.Lerp(turnSpeed, h, 0.1f);
        moveSpeed = Mathf.Lerp(moveSpeed, v, 0.3f);

		moveSpeed = Mathf.Clamp(moveSpeed, 0f, 0.7f);

        anim.SetFloat("Speed", moveSpeed);                          // set our animator's float parameter 'Speed' equal to the vertical input axis				
        anim.SetFloat("Direction", turnSpeed);                      // set our animator's float parameter 'Direction' equal to the horizontal input axis		
    }
}
