using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MHommingBullet : Bullet
{
    private GameObject target;

    private Vector2 dir;
    private Vector2 dirNo;

    protected override void Start()
    {
        base.Start();

        if (target = GameObject.FindGameObjectWithTag("Player"))
        {
            //A - B -> A를 바라보는 벡터 나온다.
            dir = target.transform.position - transform.position;

            //방향벡터만 구하기 반뒤벡터 1의 크기로 만든다.
            dirNo = dir.normalized;
        }
        else
        {
            
            //A - B -> A를 바라보는 벡터 나온다.
            dir = deadPosition - transform.position;

            //방향벡터만 구하기 반뒤벡터 1의 크기로 만든다.
            dirNo = dir.normalized;
        }

        bulletVector = dirNo;
        damage = 1;
    }

    protected override void FixedUpdate()
    {
        base .FixedUpdate();
    }




}
