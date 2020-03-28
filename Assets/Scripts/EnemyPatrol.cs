using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private Transform _target;

    private int _indexPoint;
    private bool _isRightView;

    void Start()
    {
        _points = _path.GetComponentsInChildren<Transform>();

        _indexPoint = 0;
        _target = _points[_indexPoint];

        _isRightView = false;

        for (int i = 0; i < _points.Length; i++)
        {
            Debug.Log(i + " point: " + _points[i].position + " " + _points[i].name);
        }
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) < 0.1f)
        {
            if (_indexPoint < _points.Length - 1)
            {
                _indexPoint++;
            }
            else
            {
                _indexPoint = 0;
            }

            _target = _points[_indexPoint];

            if (_indexPoint == 0)
            {
                Flip();
            }
            else if (_indexPoint == _points.Length - 1)
            {
                Flip();
            }
        }

        transform.Translate((_target.position - transform.position).normalized * Time.deltaTime * _speed);
    }

    private void Flip()
    {
        Vector2 direction;

        if (_isRightView)
            direction = new Vector2(-1, 1);
        else
            direction = new Vector2(1, 1);

        transform.localScale = direction;
        _isRightView = !_isRightView;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movement))
        {
            movement.GameOver();
        }
    }
}
