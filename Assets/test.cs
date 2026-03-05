using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Collections.Generic;

public class test : MonoBehaviour
{

    private string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetDataFromApi());
       // StartCoroutine(PostDataFromApi());
    }
    IEnumerator GetDataFromApi()
    {
        using (UnityWebRequest request = new UnityWebRequest(apiUrl))
        {

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("X-goog-api-key", "AIzaSyDlIQD3d_sCSVCw6X5v2FYAp4f1_5N4_r0");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string responseText = request.downloadHandler.text;
                Debug.Log("Response: " + responseText);
            }
            else
            {
                Debug.LogError("Error: " + request.error);

            }

        }
    }

    /*IEnumerator PostDataFromApi()
    {
        DataModel newData = new DataModel { name = "john doe", age = 33 };
        string jsonData = JsonUtility.ToJson(newData);
        byte[] jsonToSend = Encoding.UTF8.GetBytes(jsonData);
        using (UnityWebRequest request = new UploadHandlerRaw(url, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                string responseText = request.downloadHandler.text;
                Debug.Log("POST request successful Response: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("POST request failed: " + request.error);

            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {

    }
}
public class DataModel
{

}

public class Content
{
    public List<Part> parts { get; set; }
}

public class Part
{
    public string text { get; set; }
}

public class Root
{
    public List<Content> contents { get; set; }
}