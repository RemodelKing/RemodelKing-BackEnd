Feature: CreateProjectBusiness
	As a Client
	I want to rate a company
	To publicize my level of satisfaction with your services

@mytag
Scenario: Create a project for the company.
	Given the user is in the tab - Your Profile -
	When click on - Add Project - and fill in the information
	| Style   | Description            | Location        | BusinessId |
	| Rustico | Hecho a base de madera | Miraflores-Lima | 1          |
	Then the project will be added to the company.