using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage=10;//amount of Damage can be done by the obeject which this acript attached to

    public int getDamage(){
        return damage;
    }  

    public void hit(){
        
        Destroy(gameObject);
    }
}
