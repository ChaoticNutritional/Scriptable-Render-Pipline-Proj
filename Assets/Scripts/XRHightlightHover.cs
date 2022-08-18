using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRHightlightHover : MonoBehaviour
{
    //Material we want the object to take on hover
    public Material hoverMaterial = null;

    XRBaseInteractable m_interactable = null;
    Renderer m_renderer = null;

    Material[] m_currentMaterials = null;

    private void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_interactable = GetComponent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        m_interactable.onHoverEntered.AddListener(giveMaterial);
        m_interactable.onHoverExited.AddListener(takeMaterial);
    }

    private void OnDisable()
    {
        m_interactable.onHoverEntered.RemoveListener(giveMaterial);
        m_interactable.onHoverExited.RemoveListener(takeMaterial);
    }

    void giveMaterial(XRBaseInteractor interactor)
    {
        //get the array of multiple materials and cache it in the m_currentMaterials Object
        m_currentMaterials = m_renderer.materials;
        Material[] hoverMats = new Material[m_currentMaterials.Length];
        for(int i = 0; i < m_currentMaterials.Length; i++)
        {
            hoverMats[i] = hoverMaterial; //
        }
        m_renderer.materials = hoverMats;
    }

    void takeMaterial(XRBaseInteractor interactor)
    {
        m_renderer.materials = m_currentMaterials;
        m_currentMaterials = null;
    }
}
