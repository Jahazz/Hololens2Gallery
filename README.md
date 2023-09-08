<h1 class="atx" id="hololens2gallery">Hololens2Gallery</h1>
<h2 class="atx" id="overview">Overview:</h2>
<p>Simple application to browse images from flickr on Hololens2. Written in Unity + C#.</p>
<h2 class="atx" id="project-assumptions">Project assumptions:</h2>
<ul>
<li><p>Communicate with flickr by api</p>
</li>
<li><p>Download images from service</p>
</li>
<li><p>Display images as list</p>
</li>
<li><p>Display single image</p>
</li>
<li><p>Save and load feature</p>
</li>
<li><p>Run on Hololens2</p>
</li>
<li><p><a href="https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/app-quality-criteria-overview">Microsoft app quality criteria</a></p>
</li>
<li><p>Splash screen</p>
</li>
</ul>
<h2 class="atx" id="external-toolslibssources">External tools/libs/sources:</h2>
<ul>
<li><p><a href="https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-overview/">Mixed Reality Toolkit 3 Developer Documentation - MRTK3 | Microsoft Learn</a></p>
</li>
<li><p><a href="https://github.com/vrtx-labs/Unity-SOAP">Unity SOAP</a></p>
</li>
</ul>
<h2 class="atx" id="app-flow-and-class-relations">App flow and class relations</h2>
<p><img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/cffc9eb8-b11e-46ab-b03e-71269bae9681"></p>
<h2 class="atx" id="app-flow">App flow:</h2>
<h3 class="atx" id="browse-images">Browse images:</h3>
<p>After app load and splash screen user is presented with menu. 
<img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/4e462c43-69bc-48c0-8b77-5c74afdcaa56">
First button(from left) opens search menu. Next is save and load. 
On refresh button 3D space GUI is presented. 
<img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/14ec72bd-524e-418f-bc29-761d67e2eec1"> </p>
<p>Here user can select count of downloaded images and type text query to search. Query can be changed by using keyboard button.
<img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/3ea44d1d-7e4e-417f-a435-9405c6d6d1f2">
On pressing search button querty is sent to server, spinner is shown and after response app shows list and starts downloading thumbnails.</p>
<p><img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/519fefa7-bec8-4ed3-9d03-ce6eb0e17db4">
User can click on image to display it on higher resolution. On image click app downloads bigger version of image and shows it in separate window.
<img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/d8a160ec-3db9-48fd-9f23-b3e33803c487"></p>
<h3 class="atx" id="save-functionality">Save functionality</h3>
<p>On save click images that are displayed in list are saved. Button is blocked on click and shows spinner. After save operation its result is presented on modal window.
<img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/a42999be-bf0e-4fde-85d2-1b48f47641c9"></p>
<h2 class="atx" id="load-functionality">Load functionality</h2>
<p>User can load previosly saved images by clicking load button. Images are displayed as search result list.
<img alt="image" src="https://github.com/Jahazz/Hololens2Gallery/assets/15159025/c91642ea-558e-47b3-9f5c-e4651fba83ee"></p>
<h2 class="atx" id="code-formating-comments-etc">Code formating, comments etc</h2>
<p>Project is written in self explaining(thus no comments), encapsulated code which modules try to follow KISS and SOLID principles but due to low development time few rules had to be broken. Most of parameters are adjustable in editor or have separate class with config.</p>
<h2 class="atx" id="files">Files</h2>
<p>File orientation in project is feature driven with exception to Codebase. Author drags those classes with him to all his projects and due its nature it whould be hard to update them when he had to sort them otherways. Main directory in project is named Gallery.</p>
<h2 class="atx" id="modules">Modules</h2>
<p>App is divided to multiple modules(namespaces):
GUI - MVC's responsible for data processing/displaying and user input
Data - Data of photos containing its id, title, thumbnail and proper image. Thumbnail and proper image contain sprite and url to that image.
Networking - Communication with flickr api <a href="https://www.flickr.com/services/api/">https://www.flickr.com/services/api/</a> by soap <a href="https://en.wikipedia.org/wiki/SOAP">https://en.wikipedia.org/wiki/SOAP</a> protocol.
Saving - Module contains save/load functionality with its own dataset classes
Singletons - Management of single instance objects, communication between mvcs, displaying of modals etc.
Codebase - Highly reusable and extendable classes, utils, etc.</p>
<h3 class="atx" id="data-gallerydata">Data (<code>Gallery.Data</code>)</h3>
<p>Data format in app. Separated from networking and saving format to ensure expendability.</p>
<h3 class="atx" id="networking-galleryflickrapiintegration">Networking (<code>Gallery.FlickrAPIIntegration</code>)</h3>
<p>Module for communicating with internet. Communication with flickr api is done by Unity-SOAP framework(Tbh any framework can be used here.). Images are downloaded by use of UnityWebRequestTexture and returned as sprites. Photo lists are parsed from xml to <code>Gallery.FlickrAPIIntegration.Endpoints.Photo</code> objects. 
Config file is SoapConfig.cs and requests are stored in RequestFactory.cs. 
Calls are made from <code>NetworkingMediator.cs</code> and it should be only exposed class(beside of data classes) here. 
When api calls are executed in realtime, image requests utilize FIFO queue.
To expand, simply add output format as for example in <code>PhotosSearchEndpoint.cs</code> and specify request in <code>RequestFactory.cs</code>. Example calls are in <code>NetworkingMediator.cs</code>.</p>
<h3 class="atx" id="saving-gallerysaving">Saving (<code>Gallery.Saving</code>)</h3>
<p>Module for read/write operations. Uses its own data format to store path for images(in exception of sprites from <code>Gallery.Data</code>). 
Both urls for thumbnails and proper image are stored and if bigger image is downloaded is stored too.
Images are stored in .png format.
Calls should be made from <code>SaveUtils</code> static class.</p>
<h3 class="atx" id="singletons-gallerysingletons">Singletons (<code>Gallery.Singletons</code>)</h3>
<p>Classes made only for handling calls that should be availabe in all app scope such as Save/Load calls, references to MVC's or dialog display.</p>
<h3 class="atx" id="guigallerygui">GUI(<code>Gallery.GUI</code>)</h3>
<p>Core of application. Here are classes that could be responsible for single gui element calls, data processing and its display.</p>
<h4 class="atx" id="mvcs">MVCs</h4>
<p>Most of those elements are divided for Model View and Controller to ensure expendability. 
Currenly there are:</p>
<h5 class="atx" id="gridimagedisplay">GridImageDisplay</h5>
<p>Responsible for query result display and presentation of data. Calls <code>SingleImageDisplay</code> for displaying image.</p>
<h5 class="atx" id="searchmenu">SearchMenu</h5>
<p>Responsible for input of search query and calling <code>GridImageDisplay</code> on its response.</p>
<h5 class="atx" id="singleimagedisplay">SingleImageDisplay</h5>
<p>Responsible for single high quality image display. When this window is opened higher quality image downloads from server</p>
<h3 class="atx" id="codebasecodebase">Codebase(<code>Codebase</code>)</h3>
<p>Namespace containing MVC implementation and many utilities. Highly reusable. 
MVC setup is:
Inherit those three scripts add them to game object, and fill its references. On Start it will initialize and proper object can be called(Controller can call model and view, model can call view)
Also contains list MVC implementation(adding, removing, storage of elements), setup is same as mvc but additionaly object container and prefab must be specified. Also implements rearanging vertical list functionality, but its not used in this project.
Event passer is class to propagate drag events through raycast blocking IDraggable elements. Useful when dealing with problem of non scrolling button list in MRTK for example.</p>
<ul>
<li><p><code>InputOutput</code> is simple read/write class.</p>
</li>
<li><p><code>SingletonMonobehaviour</code> allows to make monobehaviour to be singleton(sic!). It just contains static reference that is asigned on awake.</p>
</li>
<li><p><code>Utils</code> contains few misc functions. I didnt include full utils here, only necessary ones.</p>
</li>
<li><p><code>XMLUtils</code> is serialization and deserialization of urls.</p>
</li>
</ul>
<h2 class="atx" id="afterthought">Afterthought:</h2>
<p>Project was made in week and still needs some work. Due to lack of time, i couldnt add interfaces to all modules, window spawning positions are not best and there is almost no exception handling. Due to lack of physical Hololens app had to be tested on emulator that dont represent it very good.</p>
<p>Splash art by vexels. I had to change it but already pushed commits and build app.</p>
<h2 class="atx" id="license">License</h2>
<pre><code class="fenced-code-block">Permission is hereby granted, free of charge, to any person obtaining a
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
DEALINGS IN THE SOFTWARE.</code></pre>
<p>*I want to thank my cats Bob and Pas whom disturbed my developlent on daily basis and who bring me joy all the time. I love you both. *</p>
