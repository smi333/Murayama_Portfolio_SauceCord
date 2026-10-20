using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.1f;
    [SerializeField]private Renderer _rend;
    private Vector2 _offset = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rend = GetComponent<Renderer>();
        if(_rend == null)
        {
            Debug.Log("Rendererが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_rend == null) return;
        //時間に応じてUVオフセットを更新
        _offset.x += _scrollSpeed * Time.deltaTime;
        _rend.material.mainTextureOffset = _offset;
    }
}
