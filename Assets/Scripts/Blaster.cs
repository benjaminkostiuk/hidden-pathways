using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blaster : MonoBehaviour
{
    [SerializeField] private GameObject paintBlast;
    [SerializeField] private Text ammoText;
    [SerializeField] private int ammo = 20;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammo > 0)
        {
            ammo--;
            GameObject blast = Instantiate(paintBlast, transform.position + transform.forward, Quaternion.identity);
            blast.GetComponent<BlasterShotMove>().SetMovementVector(transform.forward);
            Destroy(blast, 3f);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ammo = 20;
        }

        ammoText.text = ammo + "/20";
    }
}
