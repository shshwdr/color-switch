using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class PreloadSigningAlias
{

    static PreloadSigningAlias()
    {
        PlayerSettings.Android.keystorePass = "0901096";
        PlayerSettings.Android.keyaliasName = "test";
        PlayerSettings.Android.keyaliasPass = "0901096";
    }

}