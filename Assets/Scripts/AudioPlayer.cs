using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f,1f)] float shootingVolume=1f;

    
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f,1f)] float damagingVolume=1f;

    static AudioPlayer instance;
    void Awake(){
        manageSingleton();
    }

    void manageSingleton(){

        // //finding how many AudioPlayers objects in the Scene

        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if(instanceCount > 1)

        if(instance != null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else{
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }



     void playClip(AudioClip clip,float volume){
        if(clip != null){
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,volume);
        }
    }
    
    public void playShootingClip(){
       playClip(shootingClip,shootingVolume);
    }
      public void playDamagingClip(){
       playClip(damageClip,damagingVolume);
    }

   
}
