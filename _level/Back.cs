using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _offset = 0f;

    void Start()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<Player>().gameObject;
        }
    }

    void Update()
    {
        if(_player == null) return;

        transform.position = new Vector3(transform.position.x, _player.transform.position.y + _offset, transform.position.z);
    }
}
