using AssetKits.ParticleImage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MobManager : MonoBehaviour {
    public static MobManager instance;

    Animator anim;
    [SerializeField] ParticleImage pi;

    [SerializeField] private List<Mobs> mobs;
    [SerializeField] private double mobDropGold;
    public double mobMaxHP;
    public double mobHP;

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
        UIManager.instance.UpdateHpBar();
    }

    private bool TryCri() {
        if(gm.criChance >= UnityEngine.Random.value) return true;
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
        double dropGold = (mobDropGold * gm.getMoneyMul) * (1 + (UnityEngine.Random.Range(-1, 1) / 10f));
        for (int i = 0; i < 20; i++){
            yield return new WaitForSeconds(0.05f);
            AddMoney(dropGold / 20f);
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
        UIManager.instance.UpdateHpBar();
        int index = UnityEngine.Random.Range(0, mobs.Count);
        gameObject.GetComponent<Animator>().runtimeAnimatorController = mobs[index].mobAnim;
        UIManager.instance.SetName(mobs[index].name);
    }

    private void AddMoney(double money){
        gm.money += money;
        UIManager.instance.UpdateMoney();
    }
}
