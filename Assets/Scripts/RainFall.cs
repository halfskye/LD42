﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFall : MonoBehaviour {

    [SerializeField]
    private float RainSpeed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.down * RainSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RainCollider")
        {
            gameObject.SetActive(false);
        }
    }
}
