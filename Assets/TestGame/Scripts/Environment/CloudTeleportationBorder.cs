using UnityEngine;

public class CloudTeleportationBorder : MonoBehaviour
{
    [SerializeField] private float _leftBorderX;
    [SerializeField] private float _rightBorderX;

    public float GetLeft { get => _leftBorderX; }
    public float GetRigt { get => _rightBorderX; }
}
