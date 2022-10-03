using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform visual;
    public Transform Visual => visual;
}
