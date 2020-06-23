using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    [SerializeField]
    private float bounding = 1.65f;

    private Vector3 touchStart;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.MovePosition(new Vector2(-(direction.x), transform.position.y));

            var pos = transform.position;
            if (pos.x > bounding) pos.x = bounding;
            else if (pos.x < -bounding) pos.x = -bounding;
            transform.position = pos;

        }
    }


}
