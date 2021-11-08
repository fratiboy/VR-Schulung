﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracheostomaLoch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        RotationCollisionEvent collisionEvent = new RotationCollisionEvent(this.gameObject, collision.gameObject, collision.gameObject.transform.rotation.eulerAngles);
        collisionEvent.ReportCollision();
    }
}
