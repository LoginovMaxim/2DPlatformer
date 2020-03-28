using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool _isRightView;
    private bool _isGround;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _isRightView = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);

            if (_isGround)
                _animator.SetBool("isRunning", true);
            else
                _animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);

            if (_isGround)
                _animator.SetBool("isRunning", true);
            else
                _animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            _animator.SetBool("isRunning", false);

        if (Input.GetKeyDown(KeyCode.D) && !_isRightView)
            Flip();

        if (Input.GetKeyDown(KeyCode.A) && _isRightView)
            Flip();

        if(_isGround)
            _animator.SetBool("isGround", true);
        else
            _animator.SetBool("isGround", false);

    }

    private void Flip()
    {
        Vector2 direction;

        if(_isRightView)
            direction = new Vector2(-1, 1);
        else
            direction = new Vector2(1, 1);

        transform.localScale = direction;
        _isRightView = !_isRightView;
    }

    public void GameOver()
    {
        _speed = 0;
        _jumpForce = 0;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void SetGround(bool value)
    {
        _isGround = value;
    }
}
