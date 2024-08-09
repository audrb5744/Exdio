using AssetKits.ParticleImage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { click, auto };

public class MobManager : MonoBehaviour {

    Animator anim;
    [SerializeField] ParticleImage pi;

    [SerializeField] private List<Mobs> mobs;
    [SerializeField] private uint mobDropGold;
    public int mobMaxHP;
    public int mobHP;

    GameManager gm;
    UIManager ui;

    private void Start() {
        gm = GameManager.instance;
        ui = gm.uiManager;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage, DamageType type) {
        if (anim.GetBool("isDeath")) return;

        bool critical = false;
        if (TryCri()) critical = true;
        if(critical) damage *= gm.criDamage;

        int totalDamage = (int)MathF.Floor(damage);
        if (type == DamageType.click) {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
               Input.mousePosition.y, -Camera.main.transform.position.z));
            ui.CreateDamageNumber(point, totalDamage, critical);    
        }
        mobHP -= totalDamage;
        if (mobHP <= 0) Death(); 
        else anim.Play("Hit", -1, 0f);
        ui.UpdateHpBar();
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
        float dropGold = (mobDropGold * gm.getMoneyMul) * (1 + (UnityEngine.Random.Range(-1, 1) / 10f));
        for (int i = 0; i < 20; i++){
            yield return new WaitForSeconds(0.05f);
            AddMoney((uint)Mathf.Floor(dropGold / 20f));
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
        ui.UpdateHpBar();
        int index = UnityEngine.Random.Range(0, mobs.Count);
        gameObject.GetComponent<Animator>().runtimeAnimatorController = mobs[index].mobAnim;
        ui.SetName(mobs[index].name);
    }

    private void AddMoney(uint money){
        gm.money += money;
        ui.UpdateMoney();
    }


}
