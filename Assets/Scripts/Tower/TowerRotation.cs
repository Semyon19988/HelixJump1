using System;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField] [Min(0.0f)] private float _rotationSpeed;

    private Quaternion _newRotationAngle;

    private void Update() => transform.rotation = CalculateRotation(_rotationSpeed * Time.deltaTime);

    private Quaternion CalculateRotation(float rotationSpeed) =>
        Quaternion.Slerp(transform.rotation, _newRotationAngle, rotationSpeed);

    public void AddRotation(float xAxis)
    {
        Vector3 newEulerRotationAngle = transform.eulerAngles + Vector3.down * xAxis;
        _newRotationAngle = Quaternion.Euler(newEulerRotationAngle);
    }
}
