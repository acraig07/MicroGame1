using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public bool _leftPaddle;
    public float _speed;
    int _leftUp, _rightUp;
    Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_leftPaddle)
        {
            if (Input.GetKey(KeyCode.W))
                _leftUp = 1;
            if (Input.GetKey(KeyCode.S))
                _leftUp = -1;
            _rigidbody.AddForce(Vector2.up * _leftUp * _speed * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                _rightUp = 1;
            if (Input.GetKey(KeyCode.DownArrow))
                _rightUp = -1;
            _rigidbody.AddForce(Vector2.up * _rightUp * _speed * Time.deltaTime);
        }
    }
}
