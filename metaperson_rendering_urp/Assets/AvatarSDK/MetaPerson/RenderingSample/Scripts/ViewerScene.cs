/* Copyright (C) Itseez3D, Inc. - All Rights Reserved
* You may not use this file except in compliance with an authorized license
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* UNLESS REQUIRED BY APPLICABLE LAW OR AGREED BY ITSEEZ3D, INC. IN WRITING, SOFTWARE DISTRIBUTED UNDER THE LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR
* CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED
* See the License for the specific language governing permissions and limitations under the License.
* Written by Itseez3D, Inc. <support@avatarsdk.com>, May 2024
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AvatarSDK.MetaPerson.RenderingSample
{
	public class ViewerScene : MonoBehaviour
	{
		public CameraMover cameraMover;

		private void Update()
		{
			Vector2 scrollDelta = Input.mouseScrollDelta;
			if (scrollDelta != Vector2.zero && IsMouseOverGameWindow() && !IsPointerOverUIObject())
			{
				if (scrollDelta.y < 0)
					cameraMover.MoveBackward();
				else if (scrollDelta.y > 0)
					cameraMover.MoveForward();
			}
		}

		private bool IsMouseOverGameWindow()
		{
			return !(0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y);
		}

		protected bool IsPointerOverUIObject()
		{
			PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
			{
				position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
			};
			List<RaycastResult> results = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
			return results != null && results.Count > 0; 
		}
	}
}
