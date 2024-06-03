/* Copyright (C) Itseez3D, Inc. - All Rights Reserved
* You may not use this file except in compliance with an authorized license
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* UNLESS REQUIRED BY APPLICABLE LAW OR AGREED BY ITSEEZ3D, INC. IN WRITING, SOFTWARE DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR
* CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED
* See the License for the specific language governing permissions and limitations under the License.
* Written by Itseez3D, Inc. <support@avatarsdk.com>, June 2024
*/

using AvatarSDK.MetaPerson.Loader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarSDK.MetaPerson.RenderingSample
{
	public class ModelLoadingHandler : MonoBehaviour
	{
		public string modelUri = string.Empty;

		public MetaPersonLoader metaPersonLoader = null;

		public Text progressText = null;

		private async void Start()
		{
			if (!string.IsNullOrEmpty(modelUri))
			{
				bool isModelLoaded = await metaPersonLoader.LoadModelAsync(modelUri, OnDownloadingProgressChanged);
				if (gameObject.activeSelf)
				{
					if (isModelLoaded)
						progressText.text = string.Empty;
					else
						progressText.text = "Unable to load the model";
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
