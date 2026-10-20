using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Data
{
    public float ShotSpeed;
    public float BulletSpeed;
    public float HP;
}
[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public List<Data> DataLists;
}
