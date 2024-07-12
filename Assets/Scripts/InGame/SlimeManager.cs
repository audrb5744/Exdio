using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SlimeManager : MonoBehaviour{
    public static SlimeManager instance;

    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Slider hpBar;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private double mobDropGold;
    [SerializeField] private double mobMaxHP;
    [SerializeField] private double mobHP;

    Animator anim;

    GameManager gm;

    private void Awake() {
        instance = this;
        gm = GameManager.instance;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(double damage) {
        mobHP -= damage;
        if (mobHP <= 0){
            anim.SetBool("isDeath", true);
            AddMoney(gm.getMoney);
            Respawn();
        }else{
            anim.SetTrigger("isHit");
            hpBar.value = (float)(mobHP / mobMaxHP);
        }
    }

    private void Respawn() {
        anim.SetBool("isDeath", false);
        mobMaxHP = 10;
        mobHP = mobMaxHP;
        hpBar.value = (float)(mobHP / mobMaxHP);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
    }

    private void AddMoney(double money){
        gm.money += money;
        moneyText.text = "Money | " + gm.money;
    }
}
