using TMPro;
using UnityEngine;

public class LangChanger : MonoBehaviour
{
    [Header("TXTs")]
    [SerializeField] string _rusTXT;
    [SerializeField] string _engTXT;

    [Header("Fonts")]
    [SerializeField] TMP_FontAsset _rusFont;
    [SerializeField] TMP_FontAsset _engFont;

    TextMeshProUGUI _textComponent;

    void Start()
    {
        _textComponent = gameObject.GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.GetString("language", "rus") == "rus")
        {
            SetRusLang();
        }
        else
        {
            SetEngLang();
        }
    }

    public void SetRusLang()
    {
        if (!_textComponent) return;

        _textComponent.text = _rusTXT;
        _textComponent.font = _rusFont;
    }

    public void SetEngLang()
    {
        if (!_textComponent) return;

        _textComponent.text = _engTXT;
        _textComponent.font = _engFont;
    }
}
