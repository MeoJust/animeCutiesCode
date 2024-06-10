using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] _audioClips;
    private AudioSource _audioSource;
    public static AudioManager Instance;

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
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
        _audioSource.Play();

        _audioSource.volume = PlayerPrefs.GetFloat("volume", 1f);
    }

    public void VolumeSet(float volume)
    {
        _audioSource.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }
}
