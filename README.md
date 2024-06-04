# MetaPerson - Unity Rendering Sample

This repository contains a unity project with the exact rendering settings used in the Desktop version of the [MetaPerson Creator](https://metaperson.avatarsdk.com/). It also incorporates a sample scene to showcase avatars.

The project includes several models in **FBX** with preconfigured materials. dditionally, some models are dynamically loaded at runtime in **GLB** format.

![Sample Scene](./Documentation/Images/sample_scene.JPG "Sample Scene")

The sections below describe the key configuration points that impact how the models appear.

## Materials

The project works with **Built-In** rendering pipeline.

### Preconfigured Materials for FBX Models

Materials for **FBX** models are already preconfigured. You can select the sample model on the scene and see material values for a particular avatar's mesh.

### Template Materials for GLB Models

For **GLB** models, template materials are used. These templates are dynamically applied to loaded models. 
The `MetaPersonMaterialGenerator` script takes a corresponding template material for each loaded mesh, instantiates this material and sets the required textures.
You can find the template materials in the following directory: `Assets/AvatarSDK/MetaPerson/RenderingSample/Materials`. 

![Template Materials](./Documentation/Images/template_materials.JPG "Template Materials")

## Light Sources

In this project, there are three light sources configured to enhance the visual quality of the avatars:

1. Front directional light.
![Front Light](./Documentation/Images/front_light.png "Front Light")

2. Back directional light.
![Back Light](./Documentation/Images/back_light.png "Back Light")

3. Spot light that is configured with constraints to always point towards the avatar's head, ensuring that the face is well-lit and highlighted.
![Spot Light](./Documentation/Images/spot_light.png "Spot Light")

## Environment Lighting

A special **skybox** is used as an environment with the following settings:

![Environment Light](./Documentation/Images/environment_light_settings.JPG "Environment Light")

![Skybox](./Documentation/Images/skybox.JPG "Skybox")

## Post-Processing

The **Post-process Layer** is added for the main camera.

![Post-process Layer](./Documentation/Images/skybox.JPG "Post-process Layer")

Also there is the global **Post-process Volume**:

![Post-process Volume](./Documentation/Images/post_process_volume.JPG "Post-process Volume")

## Rendering and Quality Settings

The project works in **Linear** color space.

![Rendering Settings](./Documentation/Images/rendering_settings.png "Rendeing Settings")

We recommend you to set **8x Anti Aliasing** and maximum **shadows** resolution. Also, we disabled **Shadow Cascades** for this sample.

![Quality Settings](./Documentation/Images/quality_settings.png "Quality Settings")