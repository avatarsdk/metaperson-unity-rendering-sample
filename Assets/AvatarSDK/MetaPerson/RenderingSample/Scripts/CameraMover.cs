/* Copyright (C) Itseez3D, Inc. - All Rights Reserved
* You may not use this file except in compliance with an authorized license
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* UNLESS REQUIRED BY APPLICABLE LAW OR AGREED BY ITSEEZ3D, INC. IN WRITING, SOFTWARE DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR
* CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED
* See the License for the specific language governing permissions and limitations under the License.
* Written by Itseez3D, Inc. <support@avatarsdk.com>, May 2024
*/

using UnityEngine;

namespace AvatarSDK.MetaPerson.RenderingSample
{
	public enum CameraMovingDirection
	{
		Forward,
		Backward
	}

	public class CameraMover : MonoBehaviour
	{
		public Camera targetCamera;

		public CameraSettings farCameraPosition;
		public CameraSettings closeCameraPosition;

		public float movingDurationInSec;

		private bool isMoving;
		private float clampedTime = 0.0f;
		private CameraMovingDirection direction;

		private Quaternion farCameraRotation;
		private Quaternion closeCameraRotation;

		public void MoveForward()
		{
			StartMoving(CameraMovingDirection.Forward);
		}

		public void MoveBackward()
		{
			StartMoving(CameraMovingDirection.Backward);
		}

		public void StartMoving(CameraMovingDirection direction)
		{
			this.direction = direction;
			isMoving = true;

			farCameraRotation = Quaternion.Euler(farCameraPosition.cameraPosition.rotationEulers);
			closeCameraRotation = Quaternion.Euler(closeCameraPosition.cameraPosition.rotationEulers);

			UpdateTargetCameraPosition();
		}

		public void UpdateCameraPositions(CameraSettings farCameraPosition, CameraSettings closeCameraPosition)
		{
			this.farCameraPosition = farCameraPosition;
			this.closeCameraPosition = closeCameraPosition;

			farCameraRotation = Quaternion.Euler(farCameraPosition.cameraPosition.rotationEulers);
			closeCameraRotation = Quaternion.Euler(closeCameraPosition.cameraPosition.rotationEulers);

			UpdateTargetCameraPosition();
		}

		private void Update()
		{
			if (isMoving)
			{
				if (direction == CameraMovingDirection.Forward)
				{
					clampedTime += Time.deltaTime / movingDurationInSec;
					if (clampedTime >= 1.0f)
					{
						clampedTime = 1.0f;
						isMoving = false;
					}
				}
				else
				{
					clampedTime -= Time.deltaTime / movingDurationInSec;
					if (clampedTime <= 0.0f)
					{
						clampedTime = 0.0f;
						isMoving = false;
					}
				}

				UpdateTargetCameraPosition();
			}
		}

		private void UpdateTargetCameraPosition()
		{
			targetCamera.transform.position = Vector3.Lerp(farCameraPosition.cameraPosition.position, closeCameraPosition.cameraPosition.position, clampedTime);
			targetCamera.transform.rotation = Quaternion.Lerp(farCameraRotation, closeCameraRotation, clampedTime);
			targetCamera.fieldOfView = Mathf.Lerp(farCameraPosition.fov, closeCameraPosition.fov, clampedTime);
		}
	}
}
