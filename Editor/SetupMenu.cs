using UnityEngine;
using UnityEditor;
using static FoldersManager;
using static PackagesManager;

public static class SetupMenu
{
    [MenuItem("Tools/Project Setup/Run Full URP Setup", priority = 0)]
    private static void RunFull_URP_ProjectSetup()
    {
        CreateTypeFolders();
        InstallUnityPackage("render-pipelines.universal");
        InstallGeneralPackages();
        Install2DPackages();
    }

    [MenuItem("Tools/Project Setup/Install General Unity Packages")]
    private static void InstallGeneralPackages()
    {
        InstallUnityPackage("textmeshpro");
        InstallUnityPackage("addressables");
        InstallUnityPackage("visualeffectgraph");
        InstallUnityPackage("ui.builder");
        InstallUnityPackage("cinemachine");
        InstallUnityPackage("inputsystem");
    }

    [MenuItem("Tools/Project Setup/Install 2D Unity Packages")]
    private static void Install2DPackages()
    {
        InstallUnityPackage("2d.animation");
        InstallUnityPackage("2d.pixel-perfect");
        InstallUnityPackage("2d.psdimporter");
        InstallUnityPackage("2d.sprite");
        InstallUnityPackage("2d.spriteshape");
        InstallUnityPackage("2d.tilemap");
    }
}
