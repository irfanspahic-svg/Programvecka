using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class test : MonoBehaviour
{

    private string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      StartCoroutine(GetDataFromApi());  
    }
IEnumerator GetDataFromApi()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            request.SetrequestuestHeader("Content-Type", "application/json");
            request.SetrequestuestHeader("X-goog-api-key", "AIzaSyDlIQD3d_sCSVCw6X5v2FYAp4f1_5N4_r0");

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
    // Update is called once per frame
    void Update()
    {
        
    }
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