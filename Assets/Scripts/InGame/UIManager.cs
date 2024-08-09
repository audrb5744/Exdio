using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DamageNumbersPro;


public class UIManager : MonoBehaviour{

    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Slider hpBar;
    [SerializeField] public DamageNumber numberPrefab;

    GameManager gm;
    MobManager mm;

    private void Start() {
        gm = GameManager.instance;
        mm = gm.mobManager;
    }

    public void SetName(string name){
        nameText.text = name;
    }

    public void UpdateMoney(){
        moneyText.text = "" + (int)gm.money;
    }

    public void UpdateHpBar(){
        hpBar.value = (float)mm.mobHP / (float)mm.mobMaxHP;
    }

    public void CreateDamageNumber(Vector3 point, int number, bool cri) {
        DamageNumber dn = numberPrefab.Spawn(point, number);
        if (cri) {
            dn.SetColor(Color.red);
            dn.enableShaking = true;
            dn.numberSettings.bold = true;
        }
    }
}
