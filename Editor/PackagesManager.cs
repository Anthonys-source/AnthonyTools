using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;

public static class PackagesManager
{
    private static List<string> m_PackagesToInstall = new List<string>();
    private static AddRequest m_Request; // Current Request

    public static void InstallUnityPackage(string packageName)
    {
        m_PackagesToInstall.Add(packageName);

        // If the instalation process is not currently running then start it
        if (m_Request == null || (m_Request.IsCompleted && m_PackagesToInstall.Count == 1))
        {
            Debug.Log($"[Project Setup Tool] Installation STARTED");
            m_Request = Client.Add($"com.unity.{m_PackagesToInstall[0]}");
            EditorApplication.update += InstalationProcess;
        }
    }

    public static void InstalationProcess()
    {
        if (m_Request.IsCompleted)
        {
            if (m_Request.Status == StatusCode.Success)
                Debug.Log($"[Project Setup Tool] Succesfully installed/updated {m_Request.Result.displayName} ({m_Request.Result.name})");
            else if (m_Request.Status == StatusCode.Failure)
                Debug.Log($"[Project Setup Tool] Error: {m_Request.Error.message}");

            m_PackagesToInstall.RemoveAt(0);

            if (m_PackagesToInstall.Count > 0)
            {
                // Queue next install
                m_Request = Client.Add($"com.unity.{m_PackagesToInstall[0]}");
            }
            else
            {
                // Finish the instalation process
                EditorApplication.update -= InstalationProcess;
                Debug.Log($"[Project Setup Tool] Installation FINISHED");
            }
        }
    }
}
