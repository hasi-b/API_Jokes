using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{

    [SerializeField] Button serverBtn;
    [SerializeField] Button hostBtn;
    [SerializeField] Button clientBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        serverBtn.onClick.AddListener(() => {
   
            NetworkManager.Singleton.StartServer();
       
        });
        hostBtn.onClick.AddListener(() => {

            NetworkManager.Singleton.StartHost();

        });
        clientBtn.onClick.AddListener(() => {

            NetworkManager.Singleton.StartClient();

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
