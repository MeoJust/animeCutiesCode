using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject[] _meshes;

    void Start()
    {
        foreach (var mesh in _meshes)
        {
            mesh.SetActive(false);
        }

        int index = Random.Range(0, _meshes.Length);
        _meshes[index].SetActive(true);
    }
}
