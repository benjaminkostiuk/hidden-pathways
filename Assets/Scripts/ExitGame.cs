using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit(0);
        }
    }
}
