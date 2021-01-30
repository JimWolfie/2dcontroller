using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GobalLocation", menuName = "orb")]
public class PositionOfPlayer : ScriptableObject
{
	public Vector2 Starting_World_Pos;
	public Vector2 Local_Pos;
}
