Feature: AddActivityClient
	As a Company 
	I want to add activities 
	for each client

	Scenario: Add an activity
		Given the user is in the “Client Portfolio" section
		When he fill in the activity information and click - + Add -
		| title          | Description    | StartDate | FinishDate | PorfolioId |
		| Pint the house | Pint the walls | Monday    | Sunday     | 1          |
		Then the created activity will be added.