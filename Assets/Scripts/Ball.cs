using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector2 force = new Vector2(12, 16); //velocity = 20 unit

    public float maxSpeed = 11f;
    public float minSpeed = 9f;

    public static int ballCount = 1;
    private GameManager gm;

    private Rigidbody2D rb;
    private void Start()
    {
        gm = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        CheckBallSpeed();
    }

    private void CheckBallSpeed()
    {
        if (rb)
        {
            if (rb.velocity.magnitude > maxSpeed)
            {
                float ratio = rb.velocity.magnitude / maxSpeed;
                if (ratio != 0) rb.velocity = (rb.velocity / ratio);
            }
            else if (rb.velocity.magnitude < minSpeed)
            {
                float ratio = rb.velocity.magnitude / maxSpeed;
                if (ratio != 0) rb.velocity = (rb.velocity / ratio);
            }
        }
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
            gm.GetComponent<ScoreBoard>().AddBouncePoint();
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("WallBounce");
        }
    }

    private bool isInTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
        if (collision.CompareTag("Point"))
        {
            collision.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("PointTaken");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;
        if (collision.CompareTag("Fall"))
        {
            FindObjectOfType<AudioManager>().Play("Fell");
            if (ballCount <= 1)
            {
                gm.GetComponent<LifeController>().DecreaseLife();
            }
        }
    }

    public void StartBall()
    {
        if (!isInTrigger)
        {
            ResetBall();
            Invoke("ThrowBall", 1f);
        }
    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void ThrowBall()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0) rb.AddForce(force);
        else rb.AddForce(new Vector2(-force.x, force.y));
    }

    public void AddBall(Vector3 pos)
    {
        ballCount++;
        GameObject ball = Instantiate(gameObject, pos, Quaternion.identity);
        Ball temp = ball.GetComponent<Ball>();
        temp.Invoke("StartBall", 0.5f);
    }

}
