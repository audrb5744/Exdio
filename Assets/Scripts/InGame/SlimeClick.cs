using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClick : MonoBehaviour{

    public void OnClick() {
        SlimeManager.instance.TakeDamage(GameManager.instance.clickDamage);
    }

}
