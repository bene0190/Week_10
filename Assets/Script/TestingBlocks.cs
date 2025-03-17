using System.Collections;
using UnityEngine;

public class TestingBlocks : MonoBehaviour
{
    public int health;
    public Material hitMaterial,orginalMaterial;
    public Renderer objectRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        orginalMaterial = objectRenderer.material; // Store the original material
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health-=damage;
        ChangeMaterialTemporarily();
    }

    public void ChangeMaterialTemporarily()
    {
        StartCoroutine(ChangeMaterialCoroutine());
    }
    IEnumerator ChangeMaterialCoroutine()
    {
        objectRenderer.material = hitMaterial; // Change material
        yield return new WaitForSeconds(2f);   // Wait for 2 seconds
        objectRenderer.material = orginalMaterial; // Revert back
    }
}
