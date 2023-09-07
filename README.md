![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/0951e7ba-5ebb-4a5f-817e-938dae9adcaf)![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/0a727e6a-2b34-4426-a379-bc960334ce6e)# Hololens2Gallery
Overview:
Simple application to browse images from flickr on Hololens2. Written in Unity + C#.

Project assumptions:
Communicate with flickr by api
Download images from service
Display images as list
Display single image
Save and load feature
Run on Hololens2
https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/app-quality-criteria-overview
Splash screen

External tools/libs/sources:
https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-overview/
https://github.com/vrtx-labs/Unity-SOAP

![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/cffc9eb8-b11e-46ab-b03e-71269bae9681)

App flow:

Browse images:
After app load and splash screen user is presented with menu. 
![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/4e462c43-69bc-48c0-8b77-5c74afdcaa56)
First button(from left) opens search menu. Next is save and load. 
On refresh button 3D space GUI is presented. 
![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/14ec72bd-524e-418f-bc29-761d67e2eec1)
Here user can select count of downloaded images and type text query to search.
![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/3ea44d1d-7e4e-417f-a435-9405c6d6d1f2)
Query can be changed by using keyboard button.
On pressing search button querty is sent to server, spinner is shown and after response app shows list and starts downloading thumbnails. 
![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/519fefa7-bec8-4ed3-9d03-ce6eb0e17db4)
User can click on image to display it on higher resolution. On image click app downloads bigger version of image and shows it in separate window.
![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/d8a160ec-3db9-48fd-9f23-b3e33803c487)

Save functionality:
On save click images that are displayed in list are saved. Button is blocked on click and shows spinner. After save operation its result is presented on modal window.
![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/a42999be-bf0e-4fde-85d2-1b48f47641c9)


Load functionality
User can load previosly saved images by clicking load button. Images are displayed as search result list.
![image](https://github.com/Jahazz/Hololens2Gallery/assets/15159025/c91642ea-558e-47b3-9f5c-e4651fba83ee)





Code formating, comments etc
Project is written in self explaining, encapsulated code which modules try to follow KISS and SOLID principles but due to low development time few rules had to be broken.

Files
File orientation in project is feature driven with exception to Codebase. Author drags those classes with him to all his projects and due its nature it whould be hard to update them when he had to sort them otherways. Main directory in project is named Gallery. 

App is divided to multiple modules(namespaces):
GUI - MVC's responsible for data processing/displaying and user input
Data - Data of photos containing its id, title, thumbnail and proper image. Thumbnail and proper image contain sprite and url to that image.
Networking - Communication with flickr api https://www.flickr.com/services/api/ by soap https://en.wikipedia.org/wiki/SOAP protocol.
Saving - Module contains save/load functionality with its own dataset classes
Singletons - Management of single instance objects, communication between mvcs, displaying of modals etc.
Codebase - Highly reusable and extendable classes, utils, etc.

Data


Networking 
Module communicating with internet. Communication with flickr api is done by Unity-SOAP framework(Tbh any framework can be used here.). Images are downloaded by use of UnityWebRequestTexture. Config file is SoapConfig.cs and requests are stored in RequestFactory.cs. Calls are made from NetworkingMediator.cs and it should be only exposed class(beside of data classes) here. When api calls are executed in realtime, image requests utilize FIFO queue.
