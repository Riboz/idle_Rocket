using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_choser : MonoBehaviour
{
    // Start is called before the first frame update
    current_rocket Current_rocket;
    void Awake()
    {
       Current_rocket=GameObject.FindGameObjectWithTag("Rocket").GetComponent<current_rocket>();
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
