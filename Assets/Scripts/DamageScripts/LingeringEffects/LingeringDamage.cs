using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringDamage : MonoBehaviour
{
    public LingeringEffectData lingeringEffectData;

    void Start()
    {
        // havuz kendini yok etsin
        StartCoroutine(DestroySelf(lingeringEffectData.GetDuration()));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthScript health = other.GetComponent<HealthScript>();
            if (health != null)
            {
                Poisoned poisoned = other.GetComponent<Poisoned>();
                if (poisoned == null)
                {
                    // Debug.Log("poisoned status added to enemy");
                    poisoned = other.gameObject.AddComponent<Poisoned>();
                    poisoned.Initialize(health, lingeringEffectData);
                }
                // else if (lingeringEffectData.effectName == "BlackHoleLinger")
                // {

                // }
            }
        }
    }

    private IEnumerator DestroySelf(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
