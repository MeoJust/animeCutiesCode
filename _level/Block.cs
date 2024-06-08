using UnityEngine;

public class Block : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 3f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
