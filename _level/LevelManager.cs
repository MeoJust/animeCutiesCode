using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LevelManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI _bonusTXT;
    [SerializeField] TextMeshProUGUI _pointsTXT;
    [SerializeField] TextMeshProUGUI _endGamePointsTXT;

    [Header("GO")]
    [SerializeField] GameObject _blockSpawner;
    [SerializeField] GameObject _inGameCNV;
    [SerializeField] GameObject _endGameCNV;

    [Header("BTNs")]
    [SerializeField] Button _backBTN;
    [SerializeField] Button _okBTN;
    [SerializeField] Button _adBTN;

    float _levelPoints = 0;
    int _currentPoints = 0;
    int _bonusMultiplier = 1;

    bool _isPlayerDead;

    Player _player;


    void OnEnable() => YandexGame.RewardVideoEvent += GetReward;
    void OnDisable() => YandexGame.RewardVideoEvent -= GetReward;

    void Start()
    {
        InvokeRepeating("AddBonus", 10f, 10f);

        _player = FindObjectOfType<Player>();
        _player.OnDie += OnPlayerDead;

        _backBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(0));
        _okBTN.onClick.AddListener(NoReward);
        _adBTN.onClick.AddListener(ShowAdd);

        _endGameCNV.SetActive(false);
    }

    void Update()
    {
        if (_isPlayerDead) return;

        _levelPoints += Time.deltaTime;
        _currentPoints = (int)(_levelPoints * _bonusMultiplier);

        _pointsTXT.text = _currentPoints.ToString();
        _bonusTXT.text = "x" + _bonusMultiplier.ToString();
    }

    void AddBonus()
    {
        if (_bonusMultiplier < 3 && _player)
        {
            _bonusMultiplier++;
            Instantiate(_blockSpawner, transform.position, Quaternion.identity);
        }
    }

    void OnPlayerDead()
    {
        //PointsManager.Instance.Points += _currentPoints;
        _isPlayerDead = true;

        _inGameCNV.SetActive(false);
        _endGameCNV.SetActive(true);
        _endGamePointsTXT.text = _currentPoints.ToString();
    }

    void NoReward()
    {
        PointsManager.Instance.Points += _currentPoints;
        SaveManager.Instance.Save();
        SceneSwitcher.Instance.SwitchScene(0);
    }

    void GetReward(int id)
    {
        id = 0;
        _currentPoints *= 3;
        PointsManager.Instance.Points += _currentPoints;
        SaveManager.Instance.Save();
        SceneSwitcher.Instance.SwitchScene(0);
    }

    void ShowAdd(){
        YandexGame.RewVideoShow(0);
    }
}
