using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageInfoController : MonoBehaviour
{
    private StorageService storageService = StorageService.GetInstance();
    private Text storageInfoText;
    // Start is called before the first frame update
    void Start()
    {
        storageInfoText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        String tempText = "Storage Resources:\n";
        foreach (KeyValuePair<ResourceType, int> resource in storageService.resources)
        {
            tempText += resource.Key + ": "+ resource.Value + "\n";
        }
        storageInfoText.text = tempText;
    }

}
