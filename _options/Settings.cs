using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Button _backBTN;
    void Start()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);

        _volumeSlider.onValueChanged.AddListener(VolumeSet);

        _backBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(0));
    }

    void VolumeSet(float volume)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.VolumeSet(volume);
        }
    }
}
