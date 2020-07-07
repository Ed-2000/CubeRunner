using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _deadAudioEvent;

    private static float    _speed;
    private static float    _maxSpeed;
    private GameObject      _body;
    private GameObject      _destroyedBody;
    private bool            _onGround;

    private void Start()
    {
        _speed = 7f;
        _maxSpeed = 20f;
        _onGround = true;

        _body = GameObject.Find("Body");
        _destroyedBody = GameObject.Find("DestroyedBody");

        _destroyedBody.SetActive(false);
    }

    private void FixedUpdate()
    {
        this.transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") Dead();
    }

    private void Dead()
    {
        _deadAudioEvent.Invoke();
        _speed = 0;
        _body.SetActive(false);
        _destroyedBody.SetActive(true);
        DeadMenu.ActiveDeadMenu();
    }

    public void Move(string direction)
    {
        Vector3 newPos = transform.position;

        switch (direction)
        {
            case "right":
                newPos.x += 1;
                break;
            case "left":
                newPos.x += -1;
                break;
            case "up":
                if (_onGround)
                {
                    newPos.y = 5f;
                    _onGround = !_onGround;
                }
                else
                {
                    newPos.y = 1f;
                    _onGround = !_onGround;
                }
                break;
        }

        if (newPos.x > 2)
            newPos.x = 2;
        else if (newPos.x < -2)
            newPos.x = -2;

        if (_speed <= _maxSpeed)
        {
            _speed += _speed * 0.01f;
        }
        transform.position = newPos;
    }

    public static float Speed { get { return _speed; } }
}