using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [SerializeField] private TextMeshProUGUI _judgeText;
    [SerializeField] private GameObject _judge;

    public enum Judge_TYPE
    {
        WIN,
        LOSE,
        DRAW,
    }
    public Judge_TYPE _type;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _judge.SetActive(false);
    }

    public void Judge(Judge_TYPE type)
    {
        switch(type)
        {
            case Judge_TYPE.WIN:
                _judgeText.text = ("WIN");
                _judge.SetActive(true);
                break;
            case Judge_TYPE.LOSE:
                _judgeText.text = ("LOSE");
                _judge.SetActive(true);
                break;
            case Judge_TYPE.DRAW:
                _judgeText.text = ("DRAW");
                _judge.SetActive(true);
                break;
        }
        
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("kamisumou");
    }
    
}
