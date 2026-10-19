using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public static HPManager instance;
    [SerializeField] private Slider _playerSlider;
    [SerializeField] private Slider _enemySlider;
    private float _playerMaxHP = 500f;
    private float _enemyMaxHP = 10000f;
    private float _playerCrrentHP;
    private float _enemyCrrentHP;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerCrrentHP = _playerMaxHP;
        _enemyCrrentHP = _enemyMaxHP;
        _playerSlider.value = _playerCrrentHP;
        _enemySlider.value = _enemyCrrentHP;
    }
    public void PlayerHPDamage()
    {
        _playerCrrentHP -= 10f;
        _playerSlider.value = _playerCrrentHP/_playerMaxHP;
        if(_playerCrrentHP <= 0)
        {
            SceneManager.LoadScene("ResultLose");
        }
    }
    public void EnemyHPDamage()
    {
        _enemyCrrentHP -= 10f;
        _enemySlider.value = _enemyCrrentHP/_enemyMaxHP;
        if(_enemyCrrentHP <= 0)
        {
            SceneManager.LoadScene("ResultWin");
        }
    }
}
