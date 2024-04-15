using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    int flag = 1;
    int speed = 2;

    bool BoundaryCheck = false;


    void Start()
    {
        Invoke("Hide", 1);
        //�ڷ�ƾ ����
        StartCoroutine(CicleFire());

    }

    void Hide()
    {
        //GameObject.Find("TextBossWarning").SetActive(false);
    }


    public void colliderControll()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    //�� �������� �̻��� �߻�
    IEnumerator CicleFire()
    {
        //���� �ֱ�
        float attackRate = 3;
        //�߻�ü ��������
        int count = 30;
        //�߻�ü ������ ����
        float intervalAngle = 360 / count;
        //���ߵǴ� ����(�׻� ���� ��ġ�� �߻����� �ʵ��� ����
        float weightAngle = 0f;

        //�� ���·� ����ϴ� �߻�ü ����(count ���� ��ŭ)
        while (true)
        {
            for (int i = 0; i< count; ++i)
            {
                //�߻�ü ����
                GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);

                //�߻�ü �̵� ����(����)
                float angle = weightAngle + intervalAngle * i;
                //�߻�ü �̵� ����(����)
                //Cos(����)���� ������ ���� ǥ���� ����  pi/ 180 �� ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //sin(����)���� ������ ���� ǥ���� ���� PI/100�� ����
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //�߻�ü �̵� ���� ����
                clone.GetComponent<BossBullet>().BulletVector(new Vector2(x, y));
            }

            //�߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;

            //3�ʸ��� �̻��� �߻�
            yield return new WaitForSeconds(attackRate);
        }
    }

    public override void Damage(int attack)
    {
        base.Damage(attack);
    }

    void Update()
    {
        if(transform.position.x > 1 && BoundaryCheck == true)
        {
            flag *= -1;
            BoundaryCheck = false;
        }
        if(transform.position.x < -1 && BoundaryCheck == true)
        {
            flag *= -1;
            BoundaryCheck = false;
        }
        else if(transform.position.x < 1 && transform.position.x > -1)
        {
            BoundaryCheck = true;
        }

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);

            StartCoroutine("Hit");
            //GameObject.FindGameObjectWithTag("BossHead").GetComponent<BossHead>().BeHit();

        }
/*        if (collision.CompareTag("Lazer"))
        {

            StartCoroutine("Hit");
        }*/
    }

    IEnumerator Hit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(200/255, 200/255, 200/255, 255/255);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
