﻿using UnityEngine;
using System.Collections;

public class Apply_Shader : MonoBehaviour {
    //used from http://www.gamasutra.com/blogs/SvyatoslavCherkasov/20140531/218753/Shader_tutorial_CRT_emulation.php

    public Shader shader;
    private Material _material;

    [Range(0, 1)]
    public float verts_force = 0.0f;

    [Range(0, 1)]
    public float verts_force_2 = 0.0f;

    protected Material material
    {
        get
        {
            if (_material == null)
                _material.hideFlags = HideFlags.HideAndDontSave;     // Creates a material that is explicitly created & destroyed by the component.
            return _material;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (shader == null) return;

        Material mat = material;
        mat.SetFloat("_VertsColor", 1 - verts_force);
        mat.SetFloat("_VertsColor2", 1 - verts_force_2);
        Graphics.Blit(source, destination, mat); //Source texture,The destination RenderTexture,Material to use.

    }

    void OnDisable()
    {
        if (_material)  DestroyImmediate(_material);
    }
}
