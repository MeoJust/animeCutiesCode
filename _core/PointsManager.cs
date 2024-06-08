using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance { get; private set; }

    public int Points = 0;

    private void Awake()
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

}
