using UnityEngine;
using UnityEditor;
using System.IO;

public static class FoldersManager
{
    [MenuItem("Tools/Project Setup/Folder Structure/Create By Type + Feature Folders")]
    public static void CreateTypeAndFeatureFolders()
    {
        CreateFolders("_Project",
                     "Code",
                     "Content");
        CreateFolders("_Project\\Global_Content",
                      "_Scripts",
                      "_Prefabs",
                      "ScenesUnity",
                      "Rendering_Settings",
                      "Materials",
                      "Shaders",
                      "PostProcess",
                      "Models");
        CreateFolders("_Project\\Global_Content\\_Audio",
                      "SoundFX",
                      "Soundtracks",
                      "Sound_Settings");
        AssetDatabase.Refresh();
    }

    [MenuItem("Tools/Project Setup/Folder Structure/Create By Type Folders")]
    public static void CreateTypeFolders()
    {
        CreateFolders("_Project",
                      "_Scripts",
                      "_Prefabs",
                      "Scenes",
                      "Rendering_Settings",
                      "Materials",
                      "Shaders",
                      "PostProcess",
                      "Models");
        CreateFolders("_Project\\_Audio",
                      "SoundFX",
                      "Soundtracks");
        AssetDatabase.Refresh();
    }

    public static void CreateFolders(string root, params string[] folderDirectories)
    {
        foreach (var folderDir in folderDirectories)
            Directory.CreateDirectory(Path.Combine(Application.dataPath, root, folderDir));
    }
}