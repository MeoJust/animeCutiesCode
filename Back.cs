using UnityEngine;

public class Back : MonoBehaviour
{
[SerializeField] GameObject _player;
[SerializeField] float _offset = 0f;

void Update(){
    transform.position = new Vector3(transform.position.x, _player.transform.position.y + _offset, transform.position.z);
}
}
