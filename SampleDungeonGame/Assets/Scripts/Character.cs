using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
    public readonly GameObject charModel;
    readonly Rigidbody physics;

    public Character (GameObject model) {
        charModel = model;
        physics = model.GetComponent<Rigidbody>();
        physics.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    public void Update (Vector3 direction, Vector3 hit) {
        Vector3 velocity = 10 * direction;
        physics.velocity = new Vector3(velocity.x, physics.velocity.y, velocity.z);

        Vector3 normal = new Vector3(0, 1, 0);
        Vector3 look = hit - physics.position;
        physics.rotation = Quaternion.LookRotation(Vector3.Cross(Vector3.Cross(look, normal), normal), normal);
    }
}
