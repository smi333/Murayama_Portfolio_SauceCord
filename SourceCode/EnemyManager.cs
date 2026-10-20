using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public static EnemyManager Instance;

    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
    }
    public void EnemyAnimPlay(string animName, float oneBeat)
    {
        //AnimatorStateInfoからステートの長さを取得
        AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
        float animLength = info.length;
        float targetSpeed = animLength / oneBeat;
        _animator.speed = targetSpeed;
        _animator.SetBool(animName, true);
    }
    public async Task Throw(float duration)
    {
        Debug.Log("発動");
        _animator.SetBool("Standby", true);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        _animator.SetBool("Standby", false);
        _animator.SetBool("Throw", true);
        BallSpawn.Instance.Ball(0);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        _animator.SetBool("Throw", false);
    }

    public async Task TwoThrow(float duration)
    {
        Debug.Log("発動");
        _animator.SetBool("TwoStandby", true);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        _animator.SetBool("TwoStandby", false);
        _animator.SetBool("Throw", true);
        BallSpawn.Instance.Ball(1);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        _animator.SetBool("Throw", false);
    }
}
