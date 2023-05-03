using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] Rigidbody2D rb;

    public float jumpSpeed = 10;

    [SerializeField] private bool yerdeMi = true;
    [SerializeField] private bool doubleJump = false;
  

    private void Update()
    {
        if (!Player.isStart)
        {
            return;
        }

        RaycastHit2D carpiyorMu = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, groundLayer);

        if (carpiyorMu.collider != null)
        {
            yerdeMi = true;
        }
        else
        {
            yerdeMi = false;
        }


        if (yerdeMi && Input.GetKeyDown(KeyCode.Space))
        {
        
            JupmActive();


        }



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (doubleJump)
        //    {
        //        DoubleJupmActive();
        //    }
        //    if (yerdeMi)
        //    {
        //        JupmActive();
        //    }

        //}



    }

    private void JupmActive()
    {
        doubleJump = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
    private void DoubleJupmActive()
    {
        doubleJump = false;
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
}
