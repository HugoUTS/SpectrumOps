using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Inventory : MonoBehaviour
{
   [SerializeField]private Weapon[] weapons;
   
   private void Start()
   {
      InitVariables();
   }
   
   public void AddItem(Weapon newItem)
   {
      int newItemIndex = (int)newItem.weaponStyle;
      
      if (weapons[newItemIndex] != null)
      {
         RemoveItem(newItemIndex);
      }
      weapons[newItemIndex] = newItem;
   }

   public void RemoveItem(int index)
   {
      weapons[index] = null;
   }

   public Weapon GetItem(int index)
   {
      return weapons[index];
   }

   private void InitVariables()
   {
      weapons = new Weapon[2];
   }
}
