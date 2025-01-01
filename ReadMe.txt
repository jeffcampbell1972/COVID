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

- Final step in the setup process was to create a GIT repository for the solution and push it to GitHub.  


12/31/2024 - Build the API Client
---------------------------------

- First thing was to identify the data being returned by the API.  I navigated to the various JSON files that are served up by the API and found that it supports two
  data structures.  So I created two classes to correspond to each.  I copied the JSON values into the class and proceeded to turn it into the class so I would have the names
  right.  The resulting classes were named the following

  * StateSummary
  * UnitedStatesSummary

  I don't see any instructions regarding the United States-level data, but decided to include it in the API Client anyway.  

- Next was to create the interface(s).  In this case, I went ahead and created a generic interface namef IApiClientService - this is probably the wrong choice, but I wanted to
  demonstrate usage of a generic interface.  I think this is pretty useful for RESTful APIs as each data point would have the same methods supported.  However, in this case,
  the two data points are handled differently by the API so it might have made more sense to have two custom interfaces. Anywho, the following methods are required to implement 
  services that are derived from IApiClientService

  * GetAsync         - retrieves a single record for the specifield identifier
  * GetByDateAsync   - retrieves a single record for the specified identifier on the specified date
  * GetHistoricAsync - retrieves a list of records for the specified identifier
  * GetAllAsync      - retrieves a list of all records

- Next I created the two API client services. Note that I have utilzied RestSharp to handle the API calls.  

  * StatesApiClientService       - implements all four methods in the interface.  state abbreviation is expected to be provided as the identifier
  * UnitedStatesApiClientService - implements two of the fourns methods in the interface.  "us" is expected to be provided as the identifier.  note that this parameter is not
                                   needed - however, since we are demonstrating usage of a generic interface, it must be provided.

- Finally, I created the tests.  For both of the test classes, I have utilized the dependency injection framework.  This is probably not necessary since there are not dependent
  services.  But in the real world, there will be so I always utilize it in testing.

  * StatesApiClientServiceTests       - each of the four methods implemented in StatesApiClientService are executed and the results are verified.
  * UnitedStatesApiClientServiceTests - the two methods that are implemented in UnitedStatesApiClientService are executed and the results are verified.  The other two
	                                    methods are called and verified to raise a NotImplementedException.

Note that I had to include the Base URL for one of the service methods but not for the others.  Weird.

1/1/2025 - Install Telerik for Blazor
-------------------------------------

- I had left things off with the API client project largely complete.  In the process of the getting the grid to render, I discovered a bug in one of the API client methods.   
  Specifically, the GetAllAsync() method for states was pulling from the current.json file instead of the daily.json file.  That got fixed and I went ahead and added another
  method to the interface for 