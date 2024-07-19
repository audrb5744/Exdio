using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public enum mobType { normal, boss };
[CreateAssetMenu(fileName = "mobSO", menuName = "Scriptable Object/Mobs", order = int.MaxValue)]
public class Mobs : ScriptableObject{
    public string mobName;
    public AnimatorController mobAnim;
    public mobType mobType;
}
