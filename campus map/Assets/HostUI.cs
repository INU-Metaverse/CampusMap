using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HostUI : MonoBehaviour
{
    [SerializeField] private Button HostBtn;
    [SerializeField] private Button ClientBtn;

    private void Awake()
    {
        HostBtn.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });

        ClientBtn.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });
    }
}
