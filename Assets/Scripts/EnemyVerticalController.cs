﻿using System.Collections;
using System.Collections.Generic;
//using System.Random;
using UnityEngine;


public class EnemyVerticalController : MonoBehaviour
{

    private float floatingTimer = 0f;
    public float floatingMax = 1f;
    public float floatingDir = 5f;

    private void FixedUpdate()
    {
        if (floatingTimer < floatingMax)
        {
            this.transform.position = new Vector2(transform.position.x,
                transform.position.y + (Time.fixedDeltaTime * floatingDir));

            floatingTimer += Time.fixedDeltaTime;
        }
        else
        {
            floatingDir *= -1;
            floatingTimer = 0f;
        }
    }


    //public float speed;
    //private Rigidbody2D rb;
    public GameObject bullet;
    private float timerBullet;
    private float maxTimerBullet;
    


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(speed, 0);

        timerBullet = 0;
        maxTimerBullet = Random.Range(5f, 15f);

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("FireBullet");

        if (Camera.main.WorldToViewportPoint(transform.position).x < 0)
            Destroy(this.gameObject);
    }

    void SpawnBullet()
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.x -= (bullet.GetComponent<Renderer>().bounds.size.x / 2) + (GetComponent<Renderer>().bounds.size.x / 2);
        GameObject.Instantiate(bullet, spawnPoint, transform.rotation);
    }


    IEnumerator FireBullet()
    {
        if (timerBullet >= maxTimerBullet)
        {
            SpawnBullet();
            timerBullet = 0;
            maxTimerBullet = Random.Range(5f, 25f);
        }

        timerBullet += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }
}