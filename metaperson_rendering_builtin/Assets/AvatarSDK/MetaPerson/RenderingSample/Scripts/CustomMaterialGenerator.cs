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
using GLTFast;
using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarSDK.MetaPerson.RenderingSample
{
	public class CustomMaterialGenerator : MetaPersonMaterialGenerator
	{
		protected override UnityEngine.Material GenerateOutfitMaterial(UnityEngine.Material templateMaterial, MaterialBase gltfMaterial, IGltfReadable gltf, bool useMetallicRoughness = true)
		{
			var material = base.GenerateOutfitMaterial(templateMaterial, gltfMaterial, gltf, useMetallicRoughness);
			material.SetTexture("_EmissionMap", material.mainTexture);
			return material;
		}
	}
}
