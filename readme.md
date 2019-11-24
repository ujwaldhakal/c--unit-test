## Details
Just testing how c# really works and written a simple test with async test.

## Assumptions -: 
The tests from given abstract domains. So two tests has been written for that -: 

* `TestIfGetAccountAmountActuallyGetsCalledWhileRefreshingAmount` -:  This test is to make sure that RefreshAmount doesn't gets called twice in a single call.

* `TestIfRefreshAmountChangesAmount` -: This test is to make sure that amount variable gets refreshed after called it so we here start with 0 and change with given amount 20 to make sure its actually refreshing.

## Installation
* `git clone {$githubUrl}`
* Run  `dotnet test`

### Packages Used For Testing
* [XUNIT](https://xunit.net/) 
* [FakeItEasy](https://fakeiteasy.github.io/)

## Folder Structure
#### Domains -: 
All business domain logic resides here
#### Services -: 
Services that could be used by one or more domains / controller resides here.

#### Tests -: 
All Project Tests will reside here.

## Things left to do
* For some reason cake build has been failed for me whether its due to my linux distro or some setups i followed sample example from [Here](https://github.com/luisgoncalves/cake-sample)
* Retry async calls when it is failed due to network issues (When network is down there is not way to handle client so i think we could handle it with retry, or cached data or put it on queue when its ready and let client know )
* Limit api calls 
