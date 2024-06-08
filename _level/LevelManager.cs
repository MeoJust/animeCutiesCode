using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI _bonusTXT;
    [SerializeField] TextMeshProUGUI _pointsTXT;

    [Header("GO")]
    [SerializeField] GameObject _blockSpawner;

    [Header("BTNs")]
    [SerializeField] Button _backBTN;

    float levelPoints = 0;
    int currentPoints = 0;
    int bonusMultiplier = 1;

    void Start()
    {
        InvokeRepeating("AddBonus", 10f, 10f);

        _backBTN.onClick.AddListener(() => SceneSwitcher.Instance.SwitchScene(0));
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
