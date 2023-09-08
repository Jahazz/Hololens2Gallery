# Hololens2Gallery

## Overview:

Simple application to browse images from flickr on Hololens2. Written in Unity + C#.

## Project assumptions:

- Communicate with flickr by api
  
- Download images from service
  
- Display images as list
  
- Display single image
  
- Save and load feature
  
- Run on Hololens2
  
- [Microsoft app quality criteria](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/app-quality-criteria-overview)
  
- Splash screen
  

## External tools/libs/sources:

- [Mixed Reality Toolkit 3 Developer Documentation - MRTK3 | Microsoft Learn](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-overview/)
  
- [Unity SOAP](https://github.com/vrtx-labs/Unity-SOAP)
  

## App flow and class relations

![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/cffc9eb8-b11e-46ab-b03e-71269bae9681)

## App flow:

### Browse images:

After app load and splash screen user is presented with menu. 
<p align="center">
  <img src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/4e462c43-69bc-48c0-8b77-5c74afdcaa56" />
</p>
First button (from left) opens search menu. Next is save and load. 
On refresh button 3D space GUI is presented. 
<p align="center">
  <img src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/14ec72bd-524e-418f-bc29-761d67e2eec1" />
</p>
Here user can select count of downloaded images and type text query to search. Query can be changed using keyboard button.
<p align="center">
  <img src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/3ea44d1d-7e4e-417f-a435-9405c6d6d1f2" />
</p>
On pressing search button query is sent to server, spinner is shown and after response app shows list and starts downloading thumbnails.
<p align="center">
  <img src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/519fefa7-bec8-4ed3-9d03-ce6eb0e17db4" />
</p>
User can click on image to display it in higher resolution. On image click app downloads bigger version of image and shows it in separate window.
<p align="center">
  <img src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/d8a160ec-3db9-48fd-9f23-b3e33803c487" />
</p>

### Save functionality

On save click images that are displayed in list are saved. Button is blocked on click and shows spinner. After save operation its result is presented on modal window.
<p align="center">
  <img src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/a42999be-bf0e-4fde-85d2-1b48f47641c9" />
</p>

### Load functionality

User can load previosly saved images by clicking load button. Images are displayed as search result list.
<p align="center">
  <img src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/c91642ea-558e-47b3-9f5c-e4651fba83ee" />
</p>

## Code formating, comments etc

Project is written in self explaining (thus no comments), encapsulated code which modules try to follow KISS and SOLID principles but due to low development time few rules had to be broken. Most of parameters are adjustable in editor or have separate class with config.

## Files

File orientation in project is feature driven with exception to Codebase. Author drags those classes with him to all his projects and due its nature it whould be hard to update them when he had to sort them otherways. Main directory in project is named Gallery.

## Modules

App is divided to multiple modules (namespaces):
GUI - MVC's responsible for data processing/displaying and user input
Data - Data of photos containing its id, title, thumbnail and proper image. Thumbnail and proper image contain sprite and url to that image.
Networking - Communication with flickr api https://www.flickr.com/services/api/ by soap https://en.wikipedia.org/wiki/SOAP protocol.
Saving - Module contains save/load functionality with its own dataset classes.
Singletons - Management of single instance objects, communication between mvcs, displaying of modals etc.
Codebase - Highly reusable and extendable classes, utils, etc.

### Data (`Gallery.Data`)

Data format in app. Separated from networking and saving format to ensure expendability.

### Networking (`Gallery.FlickrAPIIntegration`)

Module for communicating with internet. Communication with flickr api is done by Unity-SOAP framework (Tbh any framework can be used here.). Images are downloaded by use of UnityWebRequestTexture and returned as sprites. Photo lists are parsed from xml to `Gallery.FlickrAPIIntegration.Endpoints.Photo` objects. 
Config file is SoapConfig.cs and requests are stored in RequestFactory.cs. 
Calls are made from `NetworkingMediator.cs` and it should be the only exposed class (beside of data classes) here. 
When api calls are executed in realtime, image requests utilize FIFO queue.
To expand, simply add output format as for example in `PhotosSearchEndpoint.cs` and specify request in `RequestFactory.cs`. Example calls are in `NetworkingMediator.cs`.

### Saving (`Gallery.Saving`)

Module for read/write operations. Uses its own data format to store path for images (in exception of sprites from `Gallery.Data`). 
Both urls for thumbnails and proper image are stored and if bigger image is downloaded it is stored too.
Images are stored in .png format.
Calls should be made from `SaveUtils` static class.

### Singletons (`Gallery.Singletons`)

Classes made only for handling calls that should be availabe in all app scope such as Save/Load calls, references to MVC's or dialog display.

### GUI(`Gallery.GUI`)

Core of application. Here are classes that could be responsible for single gui element calls, data processing and its display.

####  MVCs

Most of those elements are divided for Model View and Controller to ensure expendability. 
Currenly there are:

#####  GridImageDisplay

Responsible for query result display and presentation of data. Calls `SingleImageDisplay` for displaying image.

#####  SearchMenu

Responsible for input of search query and calling `GridImageDisplay` on its response.

#####  SingleImageDisplay

Responsible for single high quality image display. When this window is opened higher quality image downloads from server.

### Codebase(`Codebase`)

Namespace containing MVC implementation and many utilities. Highly reusable. 
MVC setup is:
Inherit those three scripts, add them to game object and fill its references. On Start it will initialize and proper object can be called (Controller can call model and view, model can call view).
Also contains list MVC implementation (adding, removing, storage of elements), setup is same as mvc but additionaly object container and prefab must be specified. Also implements rearanging vertical list functionality, but its not used in this project.
Event passer is class to propagate drag events through raycast blocking IDraggable elements. Useful when dealing with problem of non scrolling button list in MRTK for example.

- `InputOutput` is simple read/write class.
  
- `SingletonMonobehaviour` allows to make monobehaviour to be singleton (sic!). It just contains static reference that is asigned on awake.
  
- `Utils` contains few misc functions. I didn't include full utils here, only necessary ones.
  
- `XMLUtils` is serialization and deserialization of urls.
  

## Afterthought:

Project was made in week and still needs some work. Due to lack of time, i couldn't add interfaces to all modules, window spawning positions are not best and there is almost no exception handling. Due to lack of physical Hololens app had to be tested on emulator that doesn't represent it very good.

Splash art by vexels. I had to change it but already pushed commits and built app.

## License

```
Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation
the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

You also agree to give me your first born child to immolate it to the devil when
the summer solstice has a full moon.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
```

𝐼 𝑤𝑎𝑛𝑡 𝑡𝑜 𝑡ℎ𝑎𝑛𝑘 𝑚𝑦 𝑐𝑎𝑡𝑠 𝐵𝑜𝑏 𝑎𝑛𝑑 𝑃𝑎𝑠 𝑤ℎ𝑜𝑚 𝑑𝑖𝑠𝑡𝑢𝑟𝑏𝑒𝑑 𝑚𝑦 𝑑𝑒𝑣𝑒𝑙𝑜𝑝𝑙𝑒𝑛𝑡 𝑜𝑛 𝑑𝑎𝑖𝑙𝑦 𝑏𝑎𝑠𝑖𝑠 𝑎𝑛𝑑 𝑤ℎ𝑜 𝑏𝑟𝑖𝑛𝑔 𝑚𝑒 𝑗𝑜𝑦 𝑎𝑙𝑙 𝑡ℎ𝑒 𝑡𝑖𝑚𝑒. 𝐼 𝑙𝑜𝑣𝑒 𝑦𝑜𝑢 𝑏𝑜𝑡ℎ.
