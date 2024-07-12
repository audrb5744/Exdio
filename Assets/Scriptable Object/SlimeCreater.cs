using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public enum Type { normal, boss }
public class SlimeCreater : MonoBehaviour{
    List<Slimes> itemInventory = new List<Slimes>();
    public Slimes[] slimeDB;
    /*public void SlimeCreate(Type type){
        int Index = (int)type;

        GameObject slimeGO = new GameObject(type.ToString());
        slimeGO.transform.parent = this.gameObject.transform;

        Slimes slime = slimeGO.AddComponent<Slimes>();

        slime.name = slimeDB[Index].slimeName;
        slime.slimeSprite = slimeDB[Index].slimeSprite;
        slime.type = slimeDB[Index].type;

        itemInventory.Add(slime);
    }

    void Start()
    {
        SlimeCreate(Type.normal);

        ShowInventoryItems();
    } */

    void ShowInventoryItems(){
    }
}
