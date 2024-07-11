using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlimeManager : MonoBehaviour{
    public static SlimeManager instance; 

    [SerializeField] private Slider hpBar;
    [SerializeField] private Sprite sprite;
    [SerializeField] private double mobDropGold;
    [SerializeField] private double mobMaxHP;
    [SerializeField] private double mobHP;

    GameManager gm;

    
    private void Awake() {
        instance = this;
        gm = GameManager.instance;
    }

    public void TakeDamage(double damage) {
        mobHP -= damage;
        hpBar.value = (float)(mobHP / mobMaxHP);
        Debug.Log("µ¥¹ÌÁö: " + damage);
        if (mobHP <= 0) {
            Debug.Log("»ç¸Á");
            Respawn();
        }
    }

    private void Respawn() {
        mobMaxHP = 10;
        mobHP = mobMaxHP;
        hpBar.value = (float)(mobHP / mobMaxHP);
    }
}
