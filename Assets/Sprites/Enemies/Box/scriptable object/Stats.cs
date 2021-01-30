using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "enemyBox stats",menuName = "stats1", order =1)]
public class Stats : ScriptableObject
{
	public string _name;
	public float speed;
	public string drop;
	public Color color;
	public int enemyHealth;
	public Vector2 TargetPos;
 
  
}
