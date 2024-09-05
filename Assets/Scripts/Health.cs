using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] bool isPlayer;
   [SerializeField] int score=50;
  [SerializeField] int health=50;//amount of health that the obyject have, which this script attached to
[SerializeField] ParticleSystem hitEffect;
[SerializeField] bool applyCameraShake;

CameraShake cameraShake;
AudioPlayer audioPlayer;

ScoreKeeper scoreKeeper;
LevelManager levelManager;
void Awake() {
   cameraShake=Camera.main.GetComponent<CameraShake>();
   audioPlayer= FindObjectOfType<AudioPlayer>();
   scoreKeeper = FindObjectOfType<ScoreKeeper>();
   levelManager=FindObjectOfType<LevelManager>();
}
 void OnTriggerEnter2D(Collider2D other) {
    //check that the other object collide has a Damagedeler scripy/component
     DamageDealer damageDealer=other.GetComponent<DamageDealer>();

    //if there is a damage dealer component
     if(damageDealer !=null){
        //take damage
        takeDamage(damageDealer.getDamage());
        playHitEffect();
        shakeCamera();
        audioPlayer.playDamagingClip();
        //tell Damagedeler destroy his own object(enemy)
        damageDealer.hit();
     }
  }

   void takeDamage(int damageAmount){

   health=health-damageAmount;
   if(health <=0){
      die();
   }
    
  }

  void die(){
   if(!isPlayer){
      scoreKeeper.modifyScore(score);
   }else{
      levelManager.loadGameOver();
   }
   Destroy(gameObject);
  }

  void playHitEffect(){
   if(hitEffect != null){
      ParticleSystem instance= Instantiate(hitEffect,transform.position,Quaternion.identity);
      Destroy(instance.gameObject,instance.main.duration+instance.main.startLifetime.constantMax);
   }
  }

  void shakeCamera(){
   if(cameraShake != null && applyCameraShake){
      cameraShake.play();
   }
  }

  public int getHealth(){
   return health;
  }
}
