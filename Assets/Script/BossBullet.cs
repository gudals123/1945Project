using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bullet
{
    protected override void Start()
    {
        base.Start();
        damage = 1;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void BulletVector(Vector2 vec)
    {
        base.BulletVector(vec);
    }
}
