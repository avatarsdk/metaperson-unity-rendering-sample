/* Copyright (C) Itseez3D, Inc. - All Rights Reserved
* You may not use this file except in compliance with an authorized license
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* UNLESS REQUIRED BY APPLICABLE LAW OR AGREED BY ITSEEZ3D, INC. IN WRITING, SOFTWARE DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR
* CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED
* See the License for the specific language governing permissions and limitations under the License.
* Written by Itseez3D, Inc. <support@avatarsdk.com>, May 2024
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AvatarSDK.MetaPerson.RenderingSample
{
	public enum PipelineType
	{
		META_PERSON_2_MALE,
		META_PERSON_2_FEMALE
	}

	[Serializable]
	public class CameraPosition
	{
		public Vector3 position;
		public Vector3 rotationEulers;
	}

	[Serializable]
	public class CameraSettings
	{
		public CameraPosition cameraPosition;
		public float fov = 60;

		public CameraSettings() { }

		public CameraSettings(CameraSettings cameraSettings)
		{
			cameraPosition = new CameraPosition();
			cameraPosition.position = cameraSettings.cameraPosition.position;
			cameraPosition.rotationEulers = cameraSettings.cameraPosition.rotationEulers;
			fov = cameraSettings.fov;
		}
	}

	[Serializable]
	public class PipelineCameras
	{
		public PipelineType pipeline;

		public CameraSettings farCamera;

		public CameraSettings closeCamera;
	}

	public class CameraController : MonoBehaviour
	{
		public int baseScreenWidth;

		public int baseScreenHeight;

		public Camera mainCamera;

		public List<PipelineCameras> pipelineCamerasList = new List<PipelineCameras>();

		public CameraMover cameraMover;

		private PipelineCameras currentPipelineCameras = null;

		private int screenWidth = Screen.width;
		private int screenHeight = Screen.height;

		public void Configure(PipelineType pipeline)
		{
			currentPipelineCameras = pipelineCamerasList.FirstOrDefault(c => c.pipeline == pipeline);
			UpdateMainCameraPositions();
		}

		public void MoveCamera(CameraMovingDirection movingDirection)
		{
			cameraMover.StartMoving(movingDirection);
		}

		public void AlignTargetCameraToMainCameraPosition(Camera targetCamera, int targetScreenWidth, int targetScreenHeight)
		{
			targetCamera.transform.position = ComputeCameraPositionForResolution(mainCamera.transform.position, mainCamera.transform.rotation.eulerAngles.x,
				screenWidth, screenHeight, targetScreenWidth, targetScreenHeight);
			targetCamera.transform.rotation = mainCamera.transform.rotation;
		}


		private void Start()
		{
			if (pipelineCamerasList.Count > 0)
			{
				currentPipelineCameras = pipelineCamerasList[0];
				UpdateMainCameraPositions();
			}
		}

		private void Update()
		{
			if (screenWidth != Screen.width || screenHeight != Screen.height)
			{
				Debug.LogFormat("Screen resolution changed: {0}x{1}", Screen.width, Screen.height);
				screenWidth = Screen.width;
				screenHeight = Screen.height;

				UpdateMainCameraPositions();
			}
		}

		private void UpdateMainCameraPositions()
		{
			if (currentPipelineCameras != null)
			{
				CameraSettings farCameraSettings = new CameraSettings(currentPipelineCameras.farCamera);
				farCameraSettings.cameraPosition.position = ComputeCameraPositionForResolution(farCameraSettings.cameraPosition.position, farCameraSettings.cameraPosition.rotationEulers.x,
					baseScreenWidth, baseScreenHeight, screenWidth, screenHeight);

				CameraSettings closeCameraSettings = new CameraSettings(currentPipelineCameras.closeCamera);
				closeCameraSettings.cameraPosition.position = ComputeCameraPositionForResolution(closeCameraSettings.cameraPosition.position, closeCameraSettings.cameraPosition.rotationEulers.x,
					baseScreenWidth, baseScreenHeight, screenWidth, screenHeight);

				cameraMover.UpdateCameraPositions(farCameraSettings, closeCameraSettings);
			}
		}

		private Vector3 ComputeCameraPositionForResolution(Vector3 basePosition, float xRotationEuler, int baseScreenWidth, int baseScreenHeight, int targetScreenWidth, int targetScreenHeight)
		{
			float aspect = ((float)baseScreenHeight / baseScreenWidth) * ((float)targetScreenWidth / targetScreenHeight);
			float z = basePosition.z * aspect;
			float deltaZ = (z - basePosition.z);
			float deltaY = deltaZ * (float)Math.Tan(xRotationEuler * Math.PI / 180.0f);
			return new Vector3(basePosition.x, (basePosition.y + deltaY), z);
		}
	}
}
