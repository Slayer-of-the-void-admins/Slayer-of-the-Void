using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisoned : MonoBehaviour
{
    private float damageAmount;
    private float damageInterval;
    private float duration;
    private float timer = 0f;
    private HealthScript health;

    public void Initialize(HealthScript health, LingeringEffectData lingeringEffectData)
    {
        this.health = health;
        this.damageAmount = lingeringEffectData.GetDamage();
        this.damageInterval = lingeringEffectData.damageInterval;
        Debug.Log("duration on initialization: " + lingeringEffectData.GetDuration().ToString());
        this.duration = lingeringEffectData.GetDuration();
        timer = lingeringEffectData.damageInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("enemy takes damage from poisoned status: " + damageAmount);
            health.TakeDamage(damageAmount);
            timer = damageInterval;
        }

        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            // Debug.Log("duration of poisoned status has ended");
            Destroy(this);
        }
    }
}
