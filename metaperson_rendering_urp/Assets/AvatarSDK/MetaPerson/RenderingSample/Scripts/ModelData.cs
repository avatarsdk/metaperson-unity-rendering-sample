/* Copyright (C) Itseez3D, Inc. - All Rights Reserved
* You may not use this file except in compliance with an authorized license
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* UNLESS REQUIRED BY APPLICABLE LAW OR AGREED BY ITSEEZ3D, INC. IN WRITING, SOFTWARE DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR
* CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED
* See the License for the specific language governing permissions and limitations under the License.
* Written by Itseez3D, Inc. <support@avatarsdk.com>, May 2024
*/

using AvatarSDK.MetaPerson.Loader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarSDK.MetaPerson.RenderingSample
{
	public class ModelData : MonoBehaviour
	{
		public PipelineType pipelineType;

		public Text progressText = null;

		public CameraController cameraController;

		public bool loadByUri = false;

		public string modelUri = string.Empty;

		private bool isModelLoadingStarted = false;

		private bool isModelLoaded = false;

		public void OnModelSelectionChanged(bool isOn)
		{
			gameObject.SetActive(isOn);
		}

		private async void OnEnable()
		{
			cameraController.Configure(pipelineType);

			if (loadByUri)
			{
				if (isModelLoaded)
					return;

				if (!string.IsNullOrEmpty(modelUri))
				{
					if (!isModelLoadingStarted)
					{
						MetaPersonLoader metaPersonLoader = GetComponent<MetaPersonLoader>();
						if (metaPersonLoader != null)
						{
							isModelLoadingStarted = true;
							isModelLoaded = await metaPersonLoader.LoadModelAsync(modelUri, OnDownloadingProgressChanged);
							if (gameObject.activeSelf)
							{
								if (isModelLoaded)
								{
									progressText.text = string.Empty;
								}
								else
									progressText.text = "Unable to load the model";
							}
						}
					}
				}
			}
		}

		private void OnDisable()
		{
			progressText.text = string.Empty;
		}

		private void OnDownloadingProgressChanged(float p)
		{
			if (gameObject.activeSelf)
			{
				if (p < 1.0f)
					progressText.text = string.Format("Downloading: {0} %", (int)(p * 100.0f));
				else
					progressText.text = "Loading model...";
			}
		}
	}
}
