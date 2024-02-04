using System;
using System.Diagnostics.CodeAnalysis;
using GameNetcodeStuff;
using UnityEngine;


namespace xtendhack
{
  partial class hack : MonoBehaviour
  {
    public void Update()
    {
      EntityUpdate();
    }

    public void OnGUI()
    {
            

        GUI.Box(new Rect(30, 30, 250, 200), "XtendHack - Lethal Company v49");
            GUI.Button(new Rect(32, 52, 248, 40), "ESP");
 



      foreach (var go in grabbable_objects)
      {
        esp(go.transform.position, Color.green);
      }

      foreach (var enemy in enemies)
      {
        esp(enemy.transform.position, Color.red);
      }

      foreach (var gift in giftBoxItems)
      {
        esp(gift.transform.position, Color.green);
      }

    }


    private EnemyAI[] enemies;
    private PlayerControllerB local_player;
    private GrabbableObject[] grabbable_objects;
    private Camera camera;
    private GiftBoxItem[] giftBoxItems;
    }
}