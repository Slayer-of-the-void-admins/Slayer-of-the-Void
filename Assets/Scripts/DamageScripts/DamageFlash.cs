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

        // flaş metaryelini kopyası ile değiştir
        if (flashMaterial != null)
        {
            flashMaterial = new Material(flashMaterial);
        }
        else
        {
            Debug.LogError("flashMaterial is not assigned!", this);
        }
    }

    public void Flash(Color color)
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashCoroutine(color));
    }

    private IEnumerator FlashCoroutine(Color color)
    {
        spriteRenderer.material = flashMaterial; // flaş materyaline geç

        flashMaterial.color = color;

        yield return new WaitForSeconds(flashDuration); // flaş süresi kadar bekle

        spriteRenderer.material = originalMaterial; // flaşı bitir

        flashCoroutine = null;
    }
}
