using UnityEngine;
using UnityEngine.UI;

public class IMG : MonoBehaviour
{
    [SerializeField] int _cost;

    void OnEnable()
    {
        if (_cost <= PointsManager.Instance.Points)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = Color.black;
        }
    }
}
