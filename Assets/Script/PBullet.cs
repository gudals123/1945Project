using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : Bullet
{

    protected override void Start()
    {
        base.Start();
        bulletVector = Vector2.up;
        damage = 10;
    }

    protected override void Update()
    {
        base.Update();
    }



}
