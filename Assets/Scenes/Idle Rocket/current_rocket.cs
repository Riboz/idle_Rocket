using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class current_rocket : MonoBehaviour
{
    // Start is called before the first frame update
    public Rocket rocket_sobj; 
    public float maxfuel;
    public float maxheat;
    void Awake()
    {
        maxfuel=rocket_sobj.Fuel;
        maxheat=rocket_sobj.heat;
        this.GetComponent<SpriteRenderer>().sprite=rocket_sobj.rocket_sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
