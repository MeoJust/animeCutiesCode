using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button _playBTN;
    [SerializeField] Button _galleryBTN;

    //SceneSwitcher _sceneSwitcher;

    void Start()
    {
        _playBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(1));
        _galleryBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(2));
    }
}
