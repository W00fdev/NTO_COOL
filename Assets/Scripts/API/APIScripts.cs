using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIScripts : MonoBehaviour
{
    const string gameUUID = "b101081f-24ed-4bb5-9c70-c17d73ef0213";
    public UnityWebRequest.Result requestResult;
    public string requestError;
    public string requestText;

    public IEnumerator CreatePlayer(string username, Dictionary<string, object> resources)
    {
        Dictionary<string, object> dict = new Dictionary<string, object>()
        {
            {"name", username},
            {"resources", resources},
        };
        yield return PostRequest($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/", dict);
    }

    public IEnumerator GetAllPlayers()
    {
        yield return GetRequest($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/");
    }

    public IEnumerator GetPlayer(string username)
    {
        yield return GetRequest($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/{username}/");
    }

    public IEnumerator DeletePlayer(string username)
    {
        yield return DeleteRequest($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/{username}/");
    }

    public IEnumerator UpdatePlayerResources(string username, Dictionary<string, object> resources)
    {
        yield return PutRequest($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/{username}/", resources);
    }

    public IEnumerator CreateLog(string comment, string player_name, Dictionary<string, object> resources_changed)
    {
        Dictionary<string, object> dict = new Dictionary<string, object>()
        {
            {"comment", comment},
            {"player_name", player_name},
            {"resources_changed", resources_changed},
        };
        yield return PostRequest($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/logs/", dict);
    }

    public IEnumerator GetPlayerLogs(string username)
    {
        yield return GetRequest($"https://2025.nti-gamedev.ru/api/games/{gameUUID}/players/{username}/logs/");
    }


    IEnumerator PostRequest(string url, Dictionary<string, object> body)
    {
        string bodyJSON = JsonConvert.SerializeObject(body, Formatting.Indented);
        using (UnityWebRequest uwr = UnityWebRequest.PostWwwForm(url, bodyJSON))
        {
            uwr.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
            uwr.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(bodyJSON));
            yield return uwr.SendWebRequest();

            requestResult = uwr.result;
            if (uwr.result != UnityWebRequest.Result.Success) requestError = uwr.error;
            else requestError = null;
            requestText = uwr.downloadHandler.text;
        }
    }

    IEnumerator PutRequest(string url, Dictionary<string, object> body)
    {
        Dictionary<string, object> formattedBody = new Dictionary<string, object>() { { "resources", body } };
        string bodyJSON = JsonConvert.SerializeObject(formattedBody, Formatting.Indented);
        using (UnityWebRequest uwr = UnityWebRequest.Put(url, bodyJSON))
        {
            uwr.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
            uwr.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(bodyJSON));
            yield return uwr.SendWebRequest();

            requestResult = uwr.result;
            if (uwr.result != UnityWebRequest.Result.Success) requestError = uwr.error;
            else requestError = null;
            requestText = uwr.downloadHandler.text;
        }
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(url))
        {
            yield return uwr.SendWebRequest();

            requestResult = uwr.result;
            if (uwr.result != UnityWebRequest.Result.Success) requestError = uwr.error;
            else requestError = null;
            requestText = uwr.downloadHandler.text;
        }
    }

    IEnumerator DeleteRequest(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Delete(url))
        {
            yield return uwr.SendWebRequest();
        }
    }
}
