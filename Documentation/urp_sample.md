# MetaPerson - URP Rendering Sample

The **URP Rendering Sample** can be found in the [`metaperson_rendering_urp`](./../../main/metaperson_rendering_urp) directory.

The critical configuration points that impact the models' appearance are described below.

## Materials

### Preconfigured Materials for FBX Models

Materials for **FBX** models are already preconfigured. You can select the sample model on the scene and see material values for a particular avatar's mesh.

### Template Materials for GLB Models

For **GLB** models, the use of template materials provides a flexible approach. These templates are dynamically applied to loaded models. 
The `MetaPersonMaterialGenerator` script takes a corresponding template material for each loaded mesh, instantiates this material, and sets the required textures.
You can find the template materials in the following directory: `Assets/AvatarSDK/MetaPerson/RenderingSample/Materials`. 

![Template Materials](./Images/urp/template_materials.JPG "Template Materials")

## Camera

The Field of View (FOV) depends on the camera's position. When the camera is pointed at the avatar's head, the FOV is set to 40. When viewing the full-body model, the FOV is set to 27.

Other camera settings are shown below:

![Camera Settings](./Images/urp/camera_settings.JPG "Camera Settings")

## Light Sources

There are two light sources configured to enhance the visual quality of the avatars:

1. Front directional light.
   
![Front Light](./Images/urp/front_light.png "Front Light")

2. Back directional light.
   
![Back Light](./Images/urp/back_light.png "Back Light")

## Environment Lighting

A special **skybox** is used as an environment with the following settings:

![Environment Light](./Images/urp/environment_light_settings.JPG "Environment Light")

![Skybox](./Images/urp/skybox.JPG "Skybox")

## Post-Processing

1. **Post Procesing** is enabled for the **Main Camera**. 

![Enable Post Processing](./Images/urp/enable_post_processing.png "Enable Post Processing")

2. Global volume is configured as follows:

![Global Volume](./Images/urp/global_volume.JPG "Global Volume")

## Rendering and Quality Settings

The project works in **Linear** color space.

![Rendering Settings](./Images/urp/rendering_settings.png "Rendering Settings")

Quality settings have the following parameters: 

![Quality Settings](./Images/urp/quality_settings_1.JPG "Quality Settings")

![Quality Settings](./Images/urp/quality_settings_2.JPG "Quality Settings")

## Support

If you have any questions or issues with this project, please contact us at <support@avatarsdk.com>.
