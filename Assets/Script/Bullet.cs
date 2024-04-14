using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private string attacker;

    private Rigidbody2D rigidBody;

    protected Vector2 bulletVector;
    protected int damage;

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
                collision.gameObject.GetComponent<Monster>().Damage(damage);
                Destroy(collision.gameObject);
            }
        }
        else if (attacker == "Monster")
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

    }
    protected virtual void BulletVector(Vector2 vec)
    {
        bulletVector = vec;
    }

}
