using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public Material flashMaterial;
    public float flashDuration;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashCoroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = flashMaterial; // flaş materyaline geç

        yield return new WaitForSeconds(flashDuration); // flaş süresi kadar bekle

        spriteRenderer.material = originalMaterial; // flaşı bitir

        flashCoroutine = null;
    }
}
