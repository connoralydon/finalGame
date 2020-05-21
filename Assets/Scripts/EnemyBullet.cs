﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1*speed, 0);
    }

    // Update is called once per frame

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).x > 1)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameObject.Destroy(this.gameObject);
        }


        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
            SceneManager.LoadScene("menu");

        }
    }
}