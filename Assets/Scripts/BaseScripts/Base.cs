using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [HideInInspector] public Rigidbody e_rigidbody;
    [HideInInspector] public Collider e_collider;
    [HideInInspector] public Animator e_animator;
    [HideInInspector] public MeshRenderer e_meshRenderer;
    [HideInInspector] public ObjectPool e_objectPool;
    [HideInInspector] public RopeController e_ropeController;
    [HideInInspector] public MachineController e_machineController;
    [HideInInspector] public FilledImageController e_filledController;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        e_rigidbody = (GetComponent<Rigidbody>()) ? GetComponent<Rigidbody>() : null;
        e_collider = (GetComponent<Collider>()) ? GetComponent<Collider>() : null;
        e_animator = (GetComponent<Animator>()) ? GetComponent<Animator>() : null;
        e_meshRenderer = GetComponent<MeshRenderer>() ? GetComponent<MeshRenderer>() : null;
        e_objectPool = (FindObjectOfType<ObjectPool>()) ? FindObjectOfType<ObjectPool>() : null;
        e_ropeController = (FindObjectOfType<RopeController>()) ? FindObjectOfType<RopeController>() : null;
        e_machineController = (FindObjectOfType<MachineController>()) ? FindObjectOfType<MachineController>() : null;
        e_filledController = (FindObjectOfType<FilledImageController>()) ? FindObjectOfType<FilledImageController>() : null;
    }
}
