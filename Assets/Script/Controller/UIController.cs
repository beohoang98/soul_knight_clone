using UnityEngine;
using System.Collections;
using TMPro;

public class UIController : MonoBehaviour
{
    private static UIController _instance;
    public static UIController Instance
    {
        get { return _instance; }
    }

    public TextMeshProUGUI weaponOnHoverInfo;
    public TextMeshProUGUI weaponOnHoverDamage;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        } 
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateWeaponOnHover(string name, float damage, float damageDiff)
    {
        string prefix = damageDiff >= 0 ? "+" : "-";
        weaponOnHoverInfo.text = $"{name} (Q)";
        weaponOnHoverDamage.text = $"{damage} DMG ({prefix}{damageDiff})";
        showWeaponOnHover();
    }

    public void showWeaponOnHover(bool isShow = true)
    {
        weaponOnHoverInfo.gameObject.SetActive(isShow);
        weaponOnHoverDamage.gameObject.SetActive(isShow);
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
