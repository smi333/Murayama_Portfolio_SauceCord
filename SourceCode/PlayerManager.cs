using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private int _hp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hp = _playerData.HP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Exp"))
        {
            Destroy(collision.gameObject);
            //経験値
        }
        else if (collision.gameObject.CompareTag("BulletItem"))
        {
            //_playerData.BulletSpeed *= 1.1f;
            if (_hp >= 3)
            {
                _playerData.Score += 50;
                GameManager.instance.AddScore();
                Destroy(collision.gameObject);
                return;
            }
            _hp++;
            LifeManageer.instance.OnLife(_hp - 1);
            Debug.Log(_hp);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("EnemyBullet"))
        {

            if (_hp <= 1)
            {
                //ゲームオーバー処理
                Debug.Log("ゲームオーバー");
                SceneManager.LoadScene("Result");
            }
            else
            {
                Destroy(collision.gameObject);
                _hp -= 1;
                LifeManageer.instance.OffLife(_hp);
            }
        }
    }
}
