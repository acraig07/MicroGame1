using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float _speed;
    public float _randomUp;

    Rigidbody2D _ballRigidbody;

    GameController _cont;
    // Start is called before the first frame update
    void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody2D>();
        _cont = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        Invoke("PushBall", 1f);
    }
    private void PushBall()
    {
        int dir = Random.RandomRange(0,2);
        float x, y;
        if (dir == 0)
            x = _speed;
        else 
            x = -_speed;
        y = Random.Range(-_randomUp, _randomUp);

        _ballRigidbody.AddForce(new Vector2(x, y));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisonEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = _ballRigidbody.velocity.x;
            vel.y = (_ballRigidbody.velocity.y / 2) +(collision.collider.attachedRigidbody.velocity.y / 2);

            _ballRigidbody.velocity = vel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (_ballRigidbody.velocity.x > 0)
            {
                _cont.Score(true);
            }
            else if (_ballRigidbody.velocity.x < 0)
            {
                _cont.Score(false);
            }

            _ballRigidbody.velocity = Vector2.zero;
            transform.position = Vector3.zero;
            Invoke("PushBall", 2f);
        }
    }
}
