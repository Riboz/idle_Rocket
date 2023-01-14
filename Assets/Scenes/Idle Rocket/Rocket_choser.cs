using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_choser : MonoBehaviour
{
    // Start is called before the first frame update
    current_rocket Current_rocket;
    public Rocket_Scriptable_object rocket_Scriptable;
    void Awake()
    {
       Current_rocket=GameObject.FindGameObjectWithTag("Rocket").GetComponent<current_rocket>();
    }
    
    public void clicked()
    {
        Current_rocket.chosed(rocket_Scriptable);
    }
    
}
