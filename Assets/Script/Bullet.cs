using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private string attacker;
    [SerializeField]
    private GameObject hit;


    private Rigidbody2D rigidBody;

    protected Vector2 bulletVector;
    protected int damage;
    protected Vector3 deadPosition;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //rigidBody.MovePosition(rigidBody.position + bulletVector * bulletSpeed * Time.deltaTime);

    }
    protected virtual void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + bulletVector * bulletSpeed * Time.deltaTime);
    }


    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if(attacker =="Player")
        {
            if (collision.CompareTag("Monster"))
            {
                GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
                Destroy(go, 0.1f);
                collision.gameObject.GetComponent<Monster>().Damage(damage);
                Destroy(gameObject);
            }
            if (collision.CompareTag("Boss"))
            {
                GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
                Destroy(go, 0.1f);
                collision.gameObject.GetComponent<Boss>().Damage(damage);
            }
            if (collision.CompareTag("BossLeft"))
            {
                GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
                Destroy(go, 0.1f);
                collision.gameObject.GetComponent<BossSide>().DamageL(damage);
            }
            if (collision.CompareTag("BossRight"))
            {
                GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
                Destroy(go, 0.1f);
                collision.gameObject.GetComponent<BossSide>().DamageR(damage);
            }
            if (collision.CompareTag("BossHead"))
            {
                GameObject go = Instantiate(hit, transform.position, Quaternion.identity);
                Destroy(go, 0.1f);
                collision.gameObject.GetComponent<BossHead>().Damage(damage);
            }
        }
        else if (attacker == "Monster")
        {
            if (collision.CompareTag("Player"))
            {
                deadPosition = collision.gameObject.transform.position;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

    }
    public virtual void BulletVector(Vector2 vec)
    {
        bulletVector = vec;
    }

}
