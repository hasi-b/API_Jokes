using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class PlayerNetwork : NetworkBehaviour
{
    float x;
    float y;
    [SerializeField]
    float moveSpeed = 3f;

    [SerializeField]
    TMP_Text variableText;


    NetworkVariable<int> randomNumber = new NetworkVariable<int>(1,NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);



    // Start is called before the first frame update
    void Start()
    {
        variableText = GameObject.Find("Vb").GetComponent<TMP_Text>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(!IsOwner) this.enabled = false;
    }

    //public override void OnNetworkSpawn()
    //{
    //    base.OnNetworkSpawn();
    //    randomNumber.OnValueChanged += (int prev,int newV) =>
    //    {

    //    };
    //}

    // Update is called once per frame
    void Update()
    {
       
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T)){
            randomNumber.Value = Random.Range(0,100);
            variableText.text = OwnerClientId + " : " + randomNumber.Value.ToString();
        }

            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            transform.position += new Vector3(x, 0, y) * moveSpeed * Time.deltaTime;
        

    }
}
