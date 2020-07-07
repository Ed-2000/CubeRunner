using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 newPos = transform.position;
        newPos.z = _player.transform.position.z + 30;
        transform.position = newPos;
    }
}
