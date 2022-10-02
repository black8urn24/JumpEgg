using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test.Sharath
{
    public class TestScriptSharath : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform = null;
        [SerializeField] private List<Transform> targetTransformList = new List<Transform>();

        private Vector3 initialPosition;
        private Vector3 finalPosition;
        private bool isCameraMoving = false;
        private int currentTargetTransformIndex = -1;

        // Start is called before the first frame update
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(isCameraMoving == false)
                {
                    isCameraMoving = true;
                    MoveCameraToTargetPosition();
                }
            }
        }

        private void SetInitialReferences()
        {
            currentTargetTransformIndex = 0;
            initialPosition = transform.position;
            finalPosition = targetTransformList[currentTargetTransformIndex].position;
        }

        private void MoveCameraToTargetPosition()
        {
            StartCoroutine(MoveCameraToTargetPositionRoutine(cameraTransform, initialPosition, finalPosition));
        }

        private IEnumerator MoveCameraToTargetPositionRoutine(Transform targetTransform, Vector3 fromPosition, Vector3 toPosition, float animationDuration = 1f)
        {
            float animationTime = 0f;
            while(animationTime < animationDuration)
            {
                animationTime += Time.deltaTime;
                float lerpTime = animationTime / animationDuration;
                targetTransform.position = Vector3.Lerp(fromPosition, toPosition, lerpTime);
                yield return new WaitForEndOfFrame();
            }
            currentTargetTransformIndex++;
            if(currentTargetTransformIndex >= targetTransformList.Count - 1)
            {
                currentTargetTransformIndex = 0;
            }
            initialPosition = toPosition;
            finalPosition = targetTransformList[currentTargetTransformIndex].position;
            isCameraMoving = false;
        }
    }
}