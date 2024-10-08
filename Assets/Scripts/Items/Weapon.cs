using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapons")]
public class Weapon : Item
{
    public GameObject prefab;
    public int ammoCount;
    public float range;
    public WeaponType WeaponType;
}

public enum WeaponType { Melee, Pistol, AR, Shotgun, Sniper}

