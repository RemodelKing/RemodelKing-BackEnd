Feature: Create an account as a customer
	As a customer 
	I want to create an account on RemodelKing
	to be able to navigate in the multiple options that it offers

	Scenario: The client does not have an account.
		Given he is in the Login section
		When you scroll to the “Sign up” section
		And enter the information requested
		| Name | LastName | Phone     | Address         | Img       | Email               | Id |
		| Pepe | Gomez    | 923512540 | Chorrillos-Lima | PepeImage | PepeGomez@gmail.com | 2  |
		And select the “Customer” checkbox
		And click the “Sign up” button
		Then account will then be created for the customer.