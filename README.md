# TheRefactoredShop
This is .Net web shop solution
<br/>
Refactored WebAPI Project is named WebApiV2
<br/>I haven't done any work on Vendor API project as I thought it is not a subject of code refactoring.


## Things done : 
- Project layered into multiple project's
- Used Command/ Request handler 
<br/>- Added UnitTest's and Perfomance test examples
<br/>- Added model mapping between layers
<br/>- Added Generic cache implementation
<br/>- Added DataAnotation request validation 


## Things that could be improved : 
- Generic way of getting the supplier data with DI binding ( HttpClient and mapper implementation ) 
<br/>- RestSharp http request implementation
<br/>- Cache invalidation in certain scenarious when the article is sold
<br/>- Probably the Repository project is unnecessary when we have Infrastructure project in place, same for Caching


