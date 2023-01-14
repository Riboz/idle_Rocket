using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="new assets",menuName ="rocket")]
public class Rocket : ScriptableObject
{
   
   public float Fuel;
   public float speed;
   
   public Sprite rocket_sprite;
   public int Money_earing_constant;
   public int offline_money_earing_constant;
}
