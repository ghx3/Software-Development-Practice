using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

        public Vector3 Velocity;
        public Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            Quaternion rotation = Quaternion.Euler(Velocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotation);
        }
    }