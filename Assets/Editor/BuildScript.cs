using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;
using System.IO;

public class BuildScript
{
    public static void PerformBuild()
    {
        // ========================
        // ������ ����
        // ========================
        string[] scenes = {
            "Assets/Scenes/menu.unity",
            "Assets/Scenes/gameplay.unity",
            "Assets/Scenes/Gameover.unity",
            "Assets/Scenes/Settings.unity",
            "Assets/Scenes/howtoplay.unity",
        };

        // ========================
        // ���� � ������ ������
        // ========================
        string aabPath = "RainbowUnicorn.aab";
        string apkPath = "RainbowUnicorn.apk";

        // ========================
        // ��������� Android Signing ����� ���������� ���������
        // ========================
        string keystoreBase64 = "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"
        string keystorePass = "unicorn"
        string keyAlias ="rainbow"
        string keyPass ="unicorn"

        string tempKeystorePath = null;

        if (!string.IsNullOrEmpty(keystoreBase64))
        {
            // ������� ��������� ���� keystore
            tempKeystorePath = Path.Combine(Path.GetTempPath(), "TempKeystore.jks");
            File.WriteAllBytes(tempKeystorePath, Convert.FromBase64String(keystoreBase64));

            PlayerSettings.Android.useCustomKeystore = true;
            PlayerSettings.Android.keystoreName = tempKeystorePath;
            PlayerSettings.Android.keystorePass = keystorePass;
            PlayerSettings.Android.keyaliasName = keyAlias;
            PlayerSettings.Android.keyaliasPass = keyPass;

            Debug.Log("Android signing configured from Base64 keystore.");
        }
        else
        {
            Debug.LogWarning("Keystore Base64 not set. APK/AAB will be unsigned.");
        }

        // ========================
        // ����� ��������� ������
        // ========================
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // ========================
        // 1. ������ AAB
        // ========================
        EditorUserBuildSettings.buildAppBundle = true;
        options.locationPathName = aabPath;

        Debug.Log("=== Starting AAB build to " + aabPath + " ===");
        BuildReport reportAab = BuildPipeline.BuildPlayer(options);
        if (reportAab.summary.result == BuildResult.Succeeded)
            Debug.Log("AAB build succeeded! File: " + aabPath);
        else
            Debug.LogError("AAB build failed!");

        // ========================
        // 2. ������ APK
        // ========================
        EditorUserBuildSettings.buildAppBundle = false;
        options.locationPathName = apkPath;

        Debug.Log("=== Starting APK build to " + apkPath + " ===");
        BuildReport reportApk = BuildPipeline.BuildPlayer(options);
        if (reportApk.summary.result == BuildResult.Succeeded)
            Debug.Log("APK build succeeded! File: " + apkPath);
        else
            Debug.LogError("APK build failed!");

        Debug.Log("=== Build script finished ===");

        // ========================
        // �������� ���������� keystore
        // ========================
        if (!string.IsNullOrEmpty(tempKeystorePath) && File.Exists(tempKeystorePath))
        {
            File.Delete(tempKeystorePath);
            Debug.Log("Temporary keystore deleted.");
        }
    }
}