using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI _bonusTXT;
    [SerializeField] TextMeshProUGUI _pointsTXT;

    [Header("GO")]
    [SerializeField] GameObject _blockSpawner;

    [Header("BTNs")]
    [SerializeField] Button _backBTN;

    float _levelPoints = 0;
    int _currentPoints = 0;
    int _bonusMultiplier = 1;

    bool _isPlayerDead;

    Player _player;

    void Start()
    {
        InvokeRepeating("AddBonus", 10f, 10f);

        _player = FindObjectOfType<Player>();
        _player.OnDie += OnPlayerDead;

        _backBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(0));
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
        PointsManager.Instance.Points += _currentPoints;
        print(PointsManager.Instance.Points);
        _isPlayerDead = true;
    }
}
