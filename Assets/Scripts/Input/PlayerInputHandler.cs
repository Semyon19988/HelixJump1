
using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
   [Header("Input")] 
   [SerializeField] private InputSwipePanel _swipePanel;

   [Header("Tower")] 
   [SerializeField] private TowerRotation _towerRotation;

   private void OnEnable() =>
	   _swipePanel.Swiping += RotateTower;

   private void OnDisable() =>
	   _swipePanel.Swiping -= RotateTower;

   private void RotateTower(Swipe swipe)
   {
	   float xAxis = swipe.Delta.x;
	   _towerRotation.Rotate(xAxis);
   }
}
