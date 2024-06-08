using UnityEngine;
using UnityEngine.UI;

public class ChooseCuttie : MonoBehaviour
{
    [SerializeField] GameObject[] _cutties;

    [SerializeField] Button _leftBTN;
    [SerializeField] Button _rightBTN;
    [SerializeField] Button _backBTN;

    int _indexToShow = 0;

    void Start()
    {
        ShowDatCuttie(0);

        _leftBTN.onClick.AddListener(() => ShowDatCuttie(-1));
        _rightBTN.onClick.AddListener(() => ShowDatCuttie(1));

        _backBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(0));
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
    }
}
