using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("BTNs")]
    [SerializeField] Button _playBTN;
    [SerializeField] Button _galleryBTN;
    [SerializeField] Button _optionsBTN;
    [SerializeField] Button _rusBTN;
    [SerializeField] Button _engBTN;

    [Header("TXTs")]
    [SerializeField] TextMeshProUGUI _pointsTXT;

    void Start()
    {
        _playBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(1));
        _galleryBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(2));
        _optionsBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(3));

        _rusBTN.onClick.AddListener(SetRusLang);
        _engBTN.onClick.AddListener(SetEngLang);

        _pointsTXT.text = PointsManager.Instance.Points.ToString();
    }

    void SetRusLang()
    {
        PlayerPrefs.SetString("language", "rus");
        LangChanger[] txts = FindObjectsOfType<LangChanger>();
        foreach (LangChanger txt in txts)
        {
            txt.SetRusLang();
        }
    }

    void SetEngLang()
    {
        PlayerPrefs.SetString("language", "eng");
        LangChanger[] txts = FindObjectsOfType<LangChanger>();
        foreach (LangChanger txt in txts)
        {
            txt.SetEngLang();
        }
    }
}
