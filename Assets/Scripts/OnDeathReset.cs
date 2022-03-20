using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player Entered Death Zone");

            CharacterController charController = other.GetComponent<CharacterController>();
            charController.enabled = false;
            charController.transform.position = new Vector3(0f, 2.5f, -2.5f);
            charController.enabled = true;
        }
    }
}
