using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ButtonHome : MonoBehaviour
{

    private Button thisBtn;

    public int SceneBuildIndexToLoad;

    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(0.7f);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(SceneBuildIndexToLoad);
    }

    // Start is called before the first frame update
    void Start()
    {
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => {
            StartCoroutine("loadScene");
            thisBtn.enabled = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
