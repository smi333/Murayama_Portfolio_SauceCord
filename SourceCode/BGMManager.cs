using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _BGMs = new List<AudioSource>();
    [SerializeField] private List<AudioSource> _SEs = new List<AudioSource>();
    public static BGMManager Instance { get; private set; }

    private void Awake()
    {
        // すでにインスタンスが存在している場合は自分を破棄する
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // インスタンスを登録
        Instance = this;

        // シーンを跨いで破棄されないようにする
        DontDestroyOnLoad(gameObject);
    }
    public void PlayBGM(int BGMNum)
    {
        if(BGMNum == 0)
        {
            _BGMs[BGMNum].Play();
        }
    }
    public void PlaySe(int SENum)
    {
            _SEs[SENum].Play();
    }
}
