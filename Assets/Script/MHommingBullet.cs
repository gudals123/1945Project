using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
            //A - B -> A�� �ٶ󺸴� ���� ���´�.
            dir = target.transform.position - transform.position;

            //���⺤�͸� ���ϱ� �ݵں��� 1�� ũ��� �����.
            dirNo = dir.normalized;
        }
        else
        {
            int num = Random.Range(0,2);
            if (num == 0)
            {
                dirNo = new Vector2(1, -1);
            }
            else
            {
                dirNo = new Vector2(-1, -1);
            }
        }

        bulletVector = dirNo;
        damage = 1;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void BulletVector(Vector2 vec)
    {
        base.BulletVector(vec);
    }



    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }


}
