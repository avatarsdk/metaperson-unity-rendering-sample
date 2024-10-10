/* Copyright (C) Itseez3D, Inc. - All Rights Reserved
* You may not use this file except in compliance with an authorized license
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* UNLESS REQUIRED BY APPLICABLE LAW OR AGREED BY ITSEEZ3D, INC. IN WRITING, SOFTWARE DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR
* CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED
* See the License for the specific language governing permissions and limitations under the License.
* Written by Itseez3D, Inc. <support@avatarsdk.com>, June 2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace AvatarSDK.MetaPerson.RenderingSample
{
	public class LightController : MonoBehaviour
	{
		public Transform jewelleryReflectionProbesTransform;

		public void ConfigureLighting(GameObject avatarObject, PipelineType pipelineType)
		{
			GameObject earringsObjects = FindSubobjectByName(avatarObject, "earring");
			if (earringsObjects != null)
			{
				SkinnedMeshRenderer earringsMeshRenderer = earringsObjects.GetComponentInChildren<SkinnedMeshRenderer>();
				if (earringsMeshRenderer != null)
					earringsMeshRenderer.probeAnchor = jewelleryReflectionProbesTransform;
			}

			GameObject necklaceObject = FindSubobjectByName(avatarObject, "necklace");
			if (necklaceObject != null)
			{
				SkinnedMeshRenderer necklaceMeshRenderer = necklaceObject.GetComponentInChildren<SkinnedMeshRenderer>();
				if (necklaceMeshRenderer != null)
					necklaceMeshRenderer.probeAnchor = jewelleryReflectionProbesTransform;
			}
		}

		private GameObject FindSubobjectByName(GameObject obj, string name, bool includeInactive = true)
		{
			foreach (var trans in obj.GetComponentsInChildren<Transform>(includeInactive))
				if (trans.name == name)
					return trans.gameObject;

			return null;
		}
	}
}
