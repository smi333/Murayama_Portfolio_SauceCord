using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class characterManager : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    public static characterManager Instance;
    private void Awake()
    {
        Instance = this;
        _animator = GetComponent<Animator>();
    }
    public void PlayerAnimPlay(string animName, float oneBeat)
    {
        //AnimatorStateInfoからステートの長さを取得
        AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
        float animLength = info.length;
        float targetSpeed = animLength / oneBeat;
        _animator.speed = targetSpeed;
        _animator.SetBool(animName, true);
    }
    public async Task Catch(string animName, float duration)
    {
        Debug.Log("発動");
        BGMManager.Instance.PlaySe(0);
        _animator.SetBool(animName,true);
        await UniTask.Delay(TimeSpan.FromSeconds(duration));
        _animator.SetBool(animName, false);
    }
}
