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
        // Список сцен
        // ========================
        string[] scenes = {
        "Assets/Scenes/Game.unity",
        };

        // ========================
        // Пути к файлам сборки
        // ========================
        string aabPath = "ChickAndEggs.aab";
        string apkPath = "ChickAndEggs.apk";

        // ========================
        // Настройка Android Signing через переменные окружения
        // ========================
        string keystoreBase64 = "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";
        string keystorePass = "eggsandch";
        string keyAlias = "andEgg";
        string keyPass = "eggsandch";

        string tempKeystorePath = null;

        if (!string.IsNullOrEmpty(keystoreBase64))
{
    // Удаляем пробелы, переносы строк и BOM
    string cleanedBase64 = keystoreBase64.Trim()
                                         .Replace("\r", "")
                                         .Replace("\n", "")
                                         .Trim('\uFEFF');

    // Создаем временный файл keystore
    tempKeystorePath = Path.Combine(Path.GetTempPath(), "TempKeystore.jks");
    File.WriteAllBytes(tempKeystorePath, Convert.FromBase64String(cleanedBase64));

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
        // Общие параметры сборки
        // ========================
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // ========================
        // 1. Сборка AAB
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
        // 2. Сборка APK
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
        // Удаление временного keystore
        // ========================
        if (!string.IsNullOrEmpty(tempKeystorePath) && File.Exists(tempKeystorePath))
        {
            File.Delete(tempKeystorePath);
            Debug.Log("Temporary keystore deleted.");
        }
    }
}
