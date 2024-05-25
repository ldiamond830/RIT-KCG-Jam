using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMoneyProjectile : Projectile
{
    protected override void Hit(Collider other, PlayerMovement move)
    {
        if(other.tag == "Player"){
           //stun player and have them drop money 
           var UI = other.GetComponent<PlayerUI>();
           UI.Coins = 0;

           move.Stun(stunDuration);
        }
    }
}
