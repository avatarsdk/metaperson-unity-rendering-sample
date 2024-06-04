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
		public GameObject bounceLight = null;

		public void ConfigureLighting(GameObject avatarObject)
		{
			GameObject hipsNode = FindSubobjectByName(avatarObject, "Hips");
			GameObject headTopNode = FindSubobjectByName(avatarObject, "HeadTop_End");
			ParentConstraint parentConstraint = bounceLight.GetComponent<ParentConstraint>();
			parentConstraint.SetSource(0, new ConstraintSource() { sourceTransform = hipsNode.transform, weight = 1.0f });
			LookAtConstraint lookAtConstraint = bounceLight.GetComponent<LookAtConstraint>();
			lookAtConstraint.SetSource(0, new ConstraintSource() { sourceTransform = headTopNode.transform, weight = 1.0f });
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
