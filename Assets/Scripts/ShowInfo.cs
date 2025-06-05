using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowInfo : MonoBehaviour
{
    public Material InactiveMaterial;

    public Material GazedAtMaterial;

    private Renderer _myRenderer;

    public GameObject parent;
    public TextMeshProUGUI hoverText;

    public string msg = "Papua adalah sebuah provinsi di Indonesia yang terletak di pulau Nugini bagian barat atau west New Guinea";

    public float hoverTimeRequired = 3f;

    private float hoverTimer = 0f;
    private bool isHovering = false;

    public void Start()
    {
        hoverText.text = msg;
        parent.SetActive(false);
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    public void OnPointerEnter()
    {
        isHovering = true;
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        isHovering = false;
        hoverTimer = 0f;
        // HideText();
        SetMaterial(false);
    }

    public void OnPointerClick()
    {
        
    }

    void Update()
    {
        if (isHovering)
        {
            hoverTimer += Time.deltaTime;

            if (hoverTimer >= hoverTimeRequired)
            {
                ShowText();
                isHovering = false; // prevent it from triggering again
            }
        }
    }

    void ShowText()
    {
        if (hoverText != null)
            parent.SetActive(true);
    }

    void HideText()
    {
        if (hoverText != null)
            parent.SetActive(false);
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
