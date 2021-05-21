Feature: RestAPI


Scenario: Check API response 
	Given I'm requesting latest currency list  
	When I make a request 
	Then The response should include list of currencies            