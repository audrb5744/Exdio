using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour{

    public static UIManager instance;

    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Slider hpBar;

    GameManager gm;
    MobManager mm;

    private void Awake(){
        gm = GameManager.instance;
        mm = MobManager.instance;
        instance = this;
    }

    public void SetName(string name){
        nameText.text = name;
    }

    public void UpdateMoney(){
        moneyText.text = "" + (int)gm.money;
    }

    public void UpdateHpBar(){
        hpBar.value = (float)(mm.mobHP / mm.mobMaxHP);
    }
}
