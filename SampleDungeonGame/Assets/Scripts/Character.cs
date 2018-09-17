using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public static Transform bullet;
    public static GameObject charModel;
    readonly Rigidbody physics;
    readonly float shootTime;
    readonly float shootDelay;

    public Character(GameObject model)
    {
        charModel = model;
        physics = model.GetComponent<Rigidbody>();
        physics.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        shootTime = 0;
        shootDelay = 0.5f;
    }

    public void Update(Vector3 direction, Vector3 hit)
    {
        Vector3 velocity = 10 * direction;
        physics.velocity = new Vector3(velocity.x, physics.velocity.y, velocity.z);

        Vector3 normal = new Vector3(0, 1, 0);
        Vector3 look = hit - physics.position;
        physics.rotation = Quaternion.LookRotation(Vector3.Cross(Vector3.Cross(look, normal), normal), normal);
    }

    public void Shoot()
    {
        if ((Time.time - shootTime) > shootDelay)
        {

            //Transform obj = GameObject.Instantiate(bullet, charModel.transform.position, new Quaternion());
        }
    }
}
