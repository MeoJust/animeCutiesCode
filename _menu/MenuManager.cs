using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("BTNs")]
    [SerializeField] Button _playBTN;
    [SerializeField] Button _galleryBTN;
    [SerializeField] Button _optionsBTN;

    [Header("TXTs")]
    [SerializeField] TextMeshProUGUI _pointsTXT;

    void Start()
    {
        _playBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(1));
        _galleryBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(2));
        _optionsBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(3));

        _pointsTXT.text = "total scores: " + PointsManager.Instance.Points.ToString();
    }
}
