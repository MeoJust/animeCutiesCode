using System.Drawing;
using UnityEngine;
using YG;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    public bool IsFirstTime = true;

    void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GetLoad();
    }

    void GetLoad()
    {
        PointsManager.Instance.Points = YandexGame.savesData.money;
    }

    public void Save()
    {
        YandexGame.savesData.money = PointsManager.Instance.Points;
        YandexGame.SaveProgress();
    }
}
