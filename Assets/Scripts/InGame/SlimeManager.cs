using AssetKits.ParticleImage;
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
    [SerializeField] ParticleImage pi;

    GameManager gm;

    private void Awake() {
        instance = this;
        gm = GameManager.instance;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(double damage) {
        if (anim.GetBool("isDeath")) return;
        if (TryCri()) damage *= gm.criDamage;
        mobHP -= damage;
        if (mobHP <= 0) Death(); 
        else anim.Play("Hit", -1, 0f);
        hpBar.value = (float)(mobHP / mobMaxHP);
    }

    private bool TryCri() {
        if(gm.criChance >= Random.value){
            Debug.Log("Å©¸®");
            return true;
        }
        return false;
    }

    private void Death(){
        anim.SetBool("isDeath", true);
        StartCoroutine(MoneyEffect());
        StartCoroutine(RespawnDealay(1f));
    }

    IEnumerator MoneyEffect(){
        pi.Play();
        yield return  new WaitForSeconds(1.5f);
        for (int i = 0; i < 20; i++){
            yield return new WaitForSeconds(0.05f);
            AddMoney((mobDropGold * gm.getMoneyMul) / 20);
        }
    }

    IEnumerator RespawnDealay(float time){
        yield return new WaitForSeconds(time);
        Respawn();
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
        moneyText.text = "" + (int)gm.money;
    }
}
