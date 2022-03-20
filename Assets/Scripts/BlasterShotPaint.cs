using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShotPaint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Level"))
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
