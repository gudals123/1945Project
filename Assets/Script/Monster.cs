using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    protected int hp;
    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected List<Transform> pos;
    [SerializeField]
    protected GameObject monsterDie;



    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void Move()
    {
    }

    protected virtual void Shoot()
    {
    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public virtual void Damage(int attack)
    {
        hp -= attack;

        if (hp <= 0)
        {
            GameObject go = Instantiate(monsterDie, transform.position, Quaternion.identity);
            Destroy(go, 1);
            Destroy(gameObject);
        }
    }
}
