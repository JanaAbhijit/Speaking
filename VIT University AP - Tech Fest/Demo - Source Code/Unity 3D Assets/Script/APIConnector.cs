using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class APIConnector : Singleton<APIConnector>
{
    // Use this for initialization
    void Start()
    {

    }

    public IEnumerator SendMessageToAzure()
    {
        WWWForm form = new WWWForm();

        // Construct a sample message 
        form.AddField("BallMessage", "sample data from hololens");

        // update the service URL with your API URL

        using (UnityWebRequest www = UnityWebRequest.Post("http://holoapi.azurewebsites.net/Api/BallCounters", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Data Sent");
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
