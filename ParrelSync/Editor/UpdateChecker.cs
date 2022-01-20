using System;
using UnityEditor;
using UnityEngine;

namespace ParrelSync.Update
{
    /// <summary>
    /// A simple update checker
    /// </summary>
    public class UpdateChecker
    {
        const string PackageName = "com.brentatpeoplefun.ParrelSync";
        

        class Manifest
        {
            public string name;
            public string version;
            
        }
        
        [MenuItem("ParrelSync/Check for update", priority = 20)]
        static void CheckForUpdate()
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string localPackageFilePath = $"Packages/{PackageName}/package.json";
                    var tmp = new Manifest() { version = "0.1" };
                    EditorJsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(localPackageFilePath), tmp);
                    string localVersionText = tmp.version;
                    string latesteVersionText = client.DownloadString(ExternalLinks.RemoteVersionURL);
                    string messageBody = "Current Version: " + localVersionText +"\n"
                                         +"Latest Version: " + latesteVersionText + "\n";
                    
                    var latestVersion = new Version(latesteVersionText);
                    var localVersion = new Version(localVersionText);

                    if (latestVersion > localVersion)
                    {
                        messageBody += "There's a newer version available";
                        if(EditorUtility.DisplayDialog("Check for update.", messageBody, "Get latest release", "Close"))
                        {
                            var manifestPath = System.IO.Path.Combine(Application.dataPath, "..", "Packages", "manifest.json");
                            var manifest = System.IO.File.ReadAllText(manifestPath);
                            System.IO.File.WriteAllText(manifestPath, manifest.Replace(
                                $"https://github.com/brentatpeoplefun/ParrelSync.git?path=/ParrelSync#{localVersionText}",
                                $"https://github.com/brentatpeoplefun/ParrelSync.git?path=/ParrelSync#{latesteVersionText}"));
                            
                            Application.OpenURL(ExternalLinks.Releases);
                        }
                    }
                    else
                    {
                        messageBody += "Current version is up-to-date.";
                        EditorUtility.DisplayDialog("Check for update.", messageBody,"OK");
                    }
                    
                }
                catch (Exception exp)
                {
                    Debug.LogError("Error with checking update. Exception: " + exp);
                    EditorUtility.DisplayDialog("Update Error","Error with checking update. \nSee console for more details.",
                     "OK"
                    );
                }
            }
        }
    }
}
