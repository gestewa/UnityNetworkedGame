using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : MonoBehaviour {

    private Transform _playerTransform;

    // public event System.EventHandler PlayerTransformChanged;
    // protected virtual void OnPlayerTransformChanged()
    // { 
    //     if (PlayerTransformChanged != null) 
    //         PlayerTransformChanged(this,EventArgs.Empty);
    // }
    // public Transform playerTransform
    // {
    //     get
    //     {
    //         return _playerTransform;
    //     }

    //     set
    //     {
    //         _playerTransform = value;
    //         OnPlayerTransformChanged();
    //     }
    // }

    public Transform playerTransform
    {
        get { return _playerTransform; }
        set
        {
            transform.position = origCamPos;
            _playerTransform = value;
            offset = transform.position - _playerTransform.position;
        }
    }

    private Vector3 offset;
    private Vector3 origCamPos;
    

    void Start ()
    {
        origCamPos = transform.position;
    }

    void LateUpdate ()
    {
        if (playerTransform == null){return;}
        transform.position = playerTransform.position + offset;
    }
}