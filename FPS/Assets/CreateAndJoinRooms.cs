using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;


public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    //To match the textmeshpro object inheritance (so i can drag and drop it in)
    public TMP_InputField joinInput;
    public TMP_InputField createInput;
    

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        //scene van game (hier kan je dus levels manage)
        PhotonNetwork.LoadLevel("Level0");
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
