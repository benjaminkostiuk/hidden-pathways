using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShotMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Vector3 movementVector;

    // Update is called once per frame
    void Update()
    {
        if(movementVector != null)
        {
            transform.Translate(movementVector * Time.deltaTime * speed);
        }
    }

    public void SetMovementVector(Vector3 movementVector)
    {
        this.movementVector = movementVector;
    }
}
