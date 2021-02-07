using System.Text;
using UnityEngine;
using UnityEngine.UI;

#if WINDOWS_UWP
using System;
using Windows.Storage;
using System.Collections.Generic;
#endif

public class Accessor : MonoBehaviour
{
    [SerializeField]
    private Text uiText;

    private async void Start()
    {
        uiText.text = "test";
        StringBuilder outputText = new StringBuilder();
        outputText.AppendLine("KnownFolders.PicturesLibrary");
#if WINDOWS_UWP
        try
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
            
            IReadOnlyList<StorageFile> fileList = await picturesFolder.GetFilesAsync();
            
            outputText.AppendLine("Files:");
            foreach (StorageFile file in fileList)
            {
                outputText.Append(file.Name + "\n");
            }
        }
        catch (Exception e)
        {
            outputText.AppendLine(e.Message);
        }
#endif
        uiText.text = outputText.ToString();
    }
}
