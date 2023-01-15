using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="new assets",menuName ="rocket")]
public class Rocket_Scriptable_object : ScriptableObject
{
   
   public float Fuel;
   public float speed;
   
   public Sprite rocket_sprite;
   public int Money_earing_constant;
  
   public Vector3[] fire_positions;
}
