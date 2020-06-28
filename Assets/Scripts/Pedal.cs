using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    [SerializeField]
    private float pedalBounding = 1.65f;

    private float touchBoundx1 = -2.6f;
    private float touchBoundx2 = 2.6f;
    private float touchBoundy1 = -1;
    private float touchBoundy2 = -4;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // if (Input.GetMouseButtonDown(0))
        // {
        //     var temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     if(temp.x >= touchBoundx1 && temp.x <= touchBoundx2 
        //     && temp.y >= touchBoundy2 && temp.y <= touchBoundy1)
        //     {
        //         touchStart = temp;
        //         InboundClick = true;
        //     }
        //     else InboundClick = false;
        // }
        // if (Input.GetMouseButton(0) && InboundClick)
        // {
        //     Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     rb.MovePosition(new Vector2(-(direction.x), transform.position.y));
        // }

        if (Input.GetMouseButton(0))
        {
            var temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (temp.x >= touchBoundx1 && temp.x <= touchBoundx2
            && temp.y >= touchBoundy2 && temp.y <= touchBoundy1)
            {
                rb.MovePosition(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y));
            }
        }

        var pos = transform.position;
        if (pos.x > pedalBounding) pos.x = pedalBounding;
        else if (pos.x < -pedalBounding) pos.x = -pedalBounding;
        transform.position = pos;
    }
}
