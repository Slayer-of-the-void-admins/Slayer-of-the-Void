using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Poisoned : MonoBehaviour
{
    private float damageAmount;
    private float damageInterval;
    private float duration;
    private float timer = 0f;
    private HealthScript health;
    private Color flashColour;
    private LingeringEffectData lingeringEffectData;

    public void Initialize(HealthScript health, LingeringEffectData lingeringEffectData)
    {
        this.health = health;
        this.lingeringEffectData = lingeringEffectData;
        this.damageAmount = lingeringEffectData.GetDamage();
        // oyuncu hasar multipler ını çarp
        this.damageInterval = lingeringEffectData.damageInterval;
        this.duration = lingeringEffectData.GetDuration();
        this.flashColour = lingeringEffectData.flashColor;
        timer = damageInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            health.TakeDamage(damageAmount, lingeringEffectData);

            timer = damageInterval;
        }

        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(this);
        }
    }
}
