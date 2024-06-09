using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button _playBTN;
    [SerializeField] Button _galleryBTN;

    [SerializeField] TextMeshProUGUI _pointsTXT;

    void Start()
    {
        _playBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(1));
        _galleryBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(2));

        _pointsTXT.text = "total scores: " + PointsManager.Instance.Points.ToString();
    }
}
