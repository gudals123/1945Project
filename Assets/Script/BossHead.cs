using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : Monster
{



    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bullet, transform.position,Quaternion.identity);
        go.GetComponent<BossBullet>().BulletVector(new Vector2(1, -1));
    }
    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().BulletVector(new Vector2(-1, -1));

    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().BulletVector(new Vector2(0, -1));

    }
    public override void Damage(int attack)
    {
        hp -= attack;
        if (hp < 0)
        {
            GameObject go = Instantiate(monsterDie, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);

            GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>().colliderControll();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);

            StartCoroutine("Hit");
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
