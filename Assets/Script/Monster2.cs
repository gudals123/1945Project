using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : Monster
{
    private float moveSpeed = 3.0f;
    private float StartTime = 0.5f; //Ω√¿€
    private float StopTime = 2f;
    private bool isStart = true;
    private float shootDelay = 2.5f;
    private Vector2 monsterVector;

    protected override void Start()
    {
        hp = 800;
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
            StartCoroutine("StopMove");
            StartCoroutine("SpeedControl");
            isStart = false;
        }
        transform.Translate(monsterVector * moveSpeed * Time.deltaTime);
    }

    IEnumerator SpeedControl()
    {
        yield return new WaitForSeconds(StartTime);
        moveSpeed = 0.5f;
    }
    IEnumerator StopMove()
    {
        yield return new WaitForSeconds(StopTime);
        moveSpeed = 0f;
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
            for(int i = 0; i < 3;++i)
            {
                Instantiate(bullet, pos[0].position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }


    public void MonsterVector(Vector2 vec)
    {
        monsterVector = vec;
    }


    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }

}
