using UnityEngine;

public class LoopingBackGround : MonoBehaviour
{
    private float _scrollSpeed = 2f;
    private float _spriteWidth;
    private Vector3 _startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPos = transform.position;
        //SpriteRendererの幅を取得
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(sr != null)
        {
            _spriteWidth = sr.bounds.size.x;
        }
        else
        {
            Debug.LogError("SpriteRenderが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _scrollSpeed * Time.deltaTime);
        //一定距離移動したら位置をリセット
        if(transform.position.x <= _startPos.x - _spriteWidth)
        {
            transform.position = _startPos;
        }
    }
}
