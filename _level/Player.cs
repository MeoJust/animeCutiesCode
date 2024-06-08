using UnityEngine;

public class Player : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            //TODO: add points
            Destroy(gameObject);
        }
    }
}
