using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : Bullet
{

    protected override void Start()
    {
        base.Start();
        bulletVector = Vector2.down;
        damage = 1;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}