using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCuttie : MonoBehaviour
{
    [Header("GOs")]
    [SerializeField] GameObject[] _cutties;
    [SerializeField] GameObject _infoPanel;

    [Header("BTNs")]
    [SerializeField] Button _leftBTN;
    [SerializeField] Button _rightBTN;
    [SerializeField] Button _backBTN;
    [SerializeField] Button _okBTN;
    
    [Header("TXTs")]
    [SerializeField] TextMeshProUGUI _countTXT;

    int _indexToShow = 0;

    void Start()
    {
        ShowDatCuttie(0);

        _leftBTN.onClick.AddListener(() => ShowDatCuttie(-1));
        _rightBTN.onClick.AddListener(() => ShowDatCuttie(1));

        _backBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(0));

        if (!SaveManager.Instance.IsFirstTime)
        {
            HideInfoPanel();
        }
        else
        {
            _okBTN.onClick.AddListener(HideInfoPanel);
        }
    }

    void HideThemAll()
    {
        foreach (var cuttie in _cutties)
        {
            cuttie.SetActive(false);
        }
    }

    void ShowDatCuttie(int index)
    {
        _indexToShow += index;
        if (_indexToShow > _cutties.Length - 1) _indexToShow = 0;
        if (_indexToShow < 0) _indexToShow = _cutties.Length - 1;
        HideThemAll();
        _cutties[_indexToShow].SetActive(true);
        _countTXT.text = (_indexToShow + 1).ToString() + "/" + _cutties.Length;
    }

    void HideInfoPanel()
    {
        _infoPanel.SetActive(false);
        SaveManager.Instance.IsFirstTime = false;
    }
}
