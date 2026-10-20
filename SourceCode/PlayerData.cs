using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int HP;
    public float Damage;
    public float BulletSpeed;//弾速
    public float ShotSpeed;//射出速度
    public float Speed;//移動速度
    public int Score;
}
