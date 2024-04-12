using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : Monster
{
    private float moveSpeed = 3.5f;
    private float StartTime = 0.5f; //시작
    private bool isStart = true;
    private float shootDelay = 2.5f;


    protected override void Start()
    {
        hp = 10;
        Shoot();
    }

    protected override void Update()
    {
        Move();
    }

    protected override void Move()
    {
        if (isStart)
        {
            StartCoroutine("SpeedControl");
            isStart = false;    
        }
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    IEnumerator SpeedControl()
    {
        yield return new WaitForSeconds(StartTime);
        moveSpeed = 1.5f;
    }


    protected override void Shoot()
    {
        StartCoroutine("CreateBullet");
    }

    IEnumerator CreateBullet()
    {
        while (true)
        {
            if (isStart)
                yield return new WaitForSeconds(StartTime);
            else
                yield return new WaitForSeconds(shootDelay);
            Instantiate(bullet, pos[0].position, Quaternion.identity);
        }
    }



    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }



}