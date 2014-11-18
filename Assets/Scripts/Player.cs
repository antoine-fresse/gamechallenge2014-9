using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    void Start()
    {
        if (Network.peerType == NetworkPeerType.Client && networkView.isMine)
            this.changeColor();
    }

    void Update()
    {
        if (networkView.isMine/*Network.peerType == NetworkPeerType.Client*/)
        {
            transform.Translate(Input.acceleration.x / 10.0f, 0, -Input.acceleration.z / 10.0f);
        }
        else
        {
            this.SyncedMovement();
        }
    }

    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;
        if (syncStartPosition != Vector3.zero && syncEndPosition != Vector3.zero) // Valeur exacte de la position
            rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }


    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        Vector3 syncVelocity = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = rigidbody.position;
            stream.Serialize(ref syncPosition);

            syncVelocity = rigidbody.velocity;
            stream.Serialize(ref syncVelocity);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            stream.Serialize(ref syncVelocity);

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncStartPosition = rigidbody.position;
        }
    }

    [RPC]
    private void changeColor()
    {
        renderer.material.color = new Color(0.0f, 1.0f, 0.0f);
        if (networkView.isMine)
            networkView.RPC("changeColor", RPCMode.OthersBuffered);
    }
}
