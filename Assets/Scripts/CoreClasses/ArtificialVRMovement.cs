﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialVRMovement : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public string horizontalAxisName = "Horizontal";
    public string verticalAxisName = "Vertical";
    public bool threeDMovement = false;

    [Header("Required Scene/Child References")]
    public Transform offhandMovementHand;

    // Update is called once per frame
    void Update()
    {
        if (!offhandMovementHand)
        {
            return;
        }

        Vector3 verticalMovementVector = offhandMovementHand.forward;

        if (!threeDMovement)
        {
            // Project offhandMovementHand forward axis onto floor plane (so that lifting controller up and down does not affect magnitude)
            verticalMovementVector = Vector3.ProjectOnPlane(verticalMovementVector, Vector3.up).normalized;
        }

        Vector3 horizontalMovementVector = Vector3.Cross(verticalMovementVector,-Vector3.up);

        transform.position += verticalMovementVector * Input.GetAxis(verticalAxisName) * Time.deltaTime;
        transform.position += horizontalMovementVector * Input.GetAxis(horizontalAxisName) * Time.deltaTime;
    }
}
