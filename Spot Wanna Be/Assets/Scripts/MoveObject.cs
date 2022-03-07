﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public static MoveObject moveObject;
    RaycastHit hit;
    BoxCollider boxCollider;
    public bool isMoving;

    private void Awake() {
        if (moveObject != null) {
            Destroy(gameObject);
        } else {
            moveObject = this;
        }
    }

    private void Start() {
        boxCollider = GetComponent<BoxCollider>();
        isMoving = false;
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 40000, (1 << 8))) {
            if (isMoving) {
                transform.position = hit.point;
                transform.position = new Vector3 (transform.position.x, 20f, transform.position.z);
                boxCollider.isTrigger = true;

                if (Input.GetKeyDown(KeyCode.Space)) {
                    isMoving = false;
                    boxCollider.isTrigger = false;
                }
            }
        }
    }

    public void Move() {
        isMoving = true;
    }
}