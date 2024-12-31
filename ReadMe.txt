COVID
-----
The COVID app displays information provided by the COVID Tracking Project's API.  

Overview
--------
Since the data is provided, there are only two tiers in this application's stack

	COVID.ApiClient - this contains the wrapper services that handle the API requests and responses.  

	COVID.Web       - this contains a server-side Blazor website that displays information retrieved from the API

Other projects in the solution include the following

	COVID.Tests     - this contains tests for both projects.  



-------------------
Developer's Journal
-------------------

12/31/2024 - Initial Setup
--------------------------

- started by creating a new solution using the class library template.  This allows me to name the solution COVID and have the other projects use COVID as a prefix.  
  I normally keep the class library to contain shared objects such as interfaces and exceptions, but I don't think that's needed for this project so I deleted it.

- I then created another project using the class library template and named it COVID.ApiClient.  This is where I will be putting the details for the COVID api including
  the services that will interact with the API and the classes that will represent the data that is returned.  I added the following folders to this project

  * Exceptions - contains custom exceptions
  * Interfaces - defines the contracts api client services
  * Models     - these are the classes that correspond to the data returned by the API. 
  * Services   - implements the coding logic to interact with the API are return data from it

  Note that I am of the opinion that the API producer should create this project.  Front-end developer should not be concerned with API details.

- Next step is to create a project using the server-side Blazor template.  I think you guys are using the WebAssembly flavor but I'm more familiar with server-side.  
  I deleted the Data folder since that will be retrieved by services in the API client project.  I also removed the counter and weather objects that are included in the
  template.  Then added the following folders

  * Interfaces - contains contracts for component services
  * Models     - defines classes for data produced by the componenent services.  This is the data that actually gets rendered in the application.
  * Services   - implements the coding logic to produce component services.  

- Next was to create a Blazor component named CasesPage.razor.  This will contain the grid component that was requested in the requirements.  The c# objects that are needed
  to support this component are listed below

  * CasesPageVM.cs               - view model that contains the data needed to render CasePages.razor.  For now, this is a bool indicating that the vm has been loaded.                                
  * CasesPageComponentService.cs - hydrates the CasesPageVM object.  Derived from IComponentService.

  I had to register the service in program.cs - weather service reference was removed.

  At this point, the application compiles and the Blazor website renders.  I can navigate to the Cases page and the view model gets hydrated with dummy data.

