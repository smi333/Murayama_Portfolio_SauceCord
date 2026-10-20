using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _xPos = 11f;
    private int _minYPos = -4;
    private int _maxYPos = 4;
    private float _spawnSpan = 2f;
    private float _time = 0;
    private int _maxCount;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private PlayerData _playerData;
    enum Spawner_TYPE
    {
        single,
        twin,
        single_Bc,
        triangle,
        twin_Bc,
        single_Mc,
        twin_Mc,
        triangle_Bc,
        triangle_Mc,
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Spawner_TYPEの要素数を取得する
        _maxCount = Enum.GetNames(typeof(Spawner_TYPE)).Length;

    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time >= _spawnSpan)
        {
            _time = 0;
            Spawner_TYPE type;//召喚するエネミーの種類
            int rand;//ランダムのEnumの数値を格納する
            //現在のスコア数によって出現するエネミーの種類を変える（増やす）
            if(_playerData.Score <= 100)
            {
                type = (Spawner_TYPE)Enum.ToObject(typeof(Spawner_TYPE), 0);
                Spawn(type);
            }
            else
            {
                rand = UnityEngine.Random.Range(0, 2);//0～1のランダム数値
                type = (Spawner_TYPE)Enum.ToObject(typeof(Spawner_TYPE), rand);//randの数値をEnumに反映
                Spawn(type);//ランダムに出した数値のエネミーを召喚
            }
                
            
        }
    }

    private void Spawn(Spawner_TYPE spawnerNum)
    {
        switch(spawnerNum)
        {
            case Spawner_TYPE.single://1体普通弾
                Instantiate(_enemy, new Vector3(_xPos, UnityEngine.Random.Range(_minYPos, _maxYPos), 0), Quaternion.Euler(0, 0, 90));
                break;
            case Spawner_TYPE.twin://2体普通弾
                int firstRand = RandomSpawn(100,100);
                int secondRand = RandomSpawn(firstRand,100);
                Instantiate(_enemy, new Vector3(_xPos, firstRand, 0), Quaternion.Euler(0, 0, 90));
                Instantiate(_enemy, new Vector3(_xPos, secondRand, 0), Quaternion.Euler(0, 0, 90));
                break;
            case Spawner_TYPE.single_Bc:
                break;
            case Spawner_TYPE.triangle://3体普通弾
                firstRand = RandomSpawn(100, 100);
                secondRand = RandomSpawn(firstRand, 100);
                int thirdRand = RandomSpawn(firstRand, secondRand);
                Instantiate(_enemy, new Vector3(_xPos, firstRand, 0), Quaternion.Euler(0, 0, 90));
                Instantiate(_enemy, new Vector3(_xPos, secondRand, 0), Quaternion.Euler(0, 0, 90));
                Instantiate(_enemy, new Vector3(_xPos, thirdRand, 0), Quaternion.Euler(0, 0, 90));
                break;
            case Spawner_TYPE.twin_Bc:
                break;
            case Spawner_TYPE.single_Mc:
                break;
            case Spawner_TYPE.twin_Mc:
                break;
            case Spawner_TYPE.triangle_Bc:
                break;
            case Spawner_TYPE.triangle_Mc:
                break;
        }
    }
    /// <summary>
    /// ランダムにスポーンさせる位置の値を返す。除外しなくていいときは4より上の数字を入れる
    /// </summary>
    /// <param name="exclusion">除外用</param>
    /// <param name="exclusion2">除外用</param>
    /// <returns></returns>
    private int RandomSpawn(int exclusion, int exclusion2)
    {
        var rand = UnityEngine.Random.Range(_minYPos, _maxYPos);
        if(rand == exclusion || rand == exclusion2)
        {
            RandomSpawn(exclusion, exclusion2);
        }
        return rand;
    }
}
