using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.5f;
    private float shakeTimer = 1f;
    private Vector3 initialPosition;
    
    void Start() {
        initialPosition = transform.localPosition;
    }
    
    void Update() {
        
        if (shakeTimer > 0) {
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
            transform.localPosition = initialPosition + randomOffset;
            shakeTimer -= Time.deltaTime;
        }else {
            transform.localPosition = initialPosition;
        }
    }
    
    public void ShakeCamera() {
        shakeTimer = shakeDuration;
    }
}