using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int speed = 5;
    public int lives = 5;
    public int damage = 2;
    public int speedRotation = 25;
    public float playerDistance = 25f;
}
