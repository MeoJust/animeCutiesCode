using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnDie;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
