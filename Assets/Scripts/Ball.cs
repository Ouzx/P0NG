using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector2 force = new Vector2(15f, 20f);

    [SerializeField]
    private Vector2 maxSpeed = new Vector2(40, 50);
    [SerializeField]
    private Vector2 minSpeed = new Vector2(15, 20);

    private GameManager gm;

    private Rigidbody2D rb;
    private void Start()
    {
        gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 v;
            v.y = rb.velocity.y;
            v.x = (rb.velocity.x / 2) + (collision.collider.attachedRigidbody.velocity.x / 3);
            rb.velocity = v;
            FindObjectOfType<AudioManager>().Play("PedalBounce");

        }
        else if (collision.collider.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("WallBounce");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            collision.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("PointTaken");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fall"))
        {
            FindObjectOfType<AudioManager>().Play("Fell");
            
            gm.GetComponent<LifeController>().DecreaseLife(); // <!-- Canı bir azaltır --!>
            gm.GetComponent<LifeController>().ResetBall(true); // <!-- Topu resetler --!>
        }
    }

    public void StartBall()
    {
        ResetBall();
        Invoke("ThrowBall", 1f);
    }


    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void ThrowBall()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0) rb.AddForce(force);
        else rb.AddForce(new Vector2(-force.x, force.y));
    }

}
