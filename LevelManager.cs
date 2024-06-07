using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI _bonusTXT;
    [SerializeField] TextMeshProUGUI _pointsTXT;

    [Header("GO")]
    [SerializeField] GameObject _blockSpawner;

    float levelPoints = 0;
    int currentPoints = 0;
    int bonusMultiplier = 1;

    void Start()
    {
        InvokeRepeating("AddBonus", 10f, 10f);
    }

    void Update()
    {
        levelPoints += Time.deltaTime;
        currentPoints = (int)(levelPoints * bonusMultiplier);

        _pointsTXT.text = currentPoints.ToString();
        _bonusTXT.text = "x" + bonusMultiplier.ToString();
    }

    void AddBonus(){
        if(bonusMultiplier < 3){
            bonusMultiplier++;
            Instantiate(_blockSpawner, transform.position, Quaternion.identity);
        }
    }
}
