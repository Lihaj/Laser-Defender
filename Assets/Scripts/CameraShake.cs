using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
 [SerializeField] float shakeDuration=1f;
 [SerializeField] float shakeMagnitude=0.5f;

 Vector3 intialCameraPosition;   
    void Start()
    {
        intialCameraPosition=transform.position;
    }

    public void play(){
        StartCoroutine(shake());
    }

    IEnumerator shake(){
        float elapsedTime=0;
        while(elapsedTime<shakeDuration){
            transform.position=intialCameraPosition + (Vector3)Random.insideUnitCircle* shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position=intialCameraPosition;    
    }
}
