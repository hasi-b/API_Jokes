using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class TestRelay : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
       await UnityServices.InitializeAsync();



        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed In"+ AuthenticationService.Instance.PlayerId);
        };

      await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
