Feature: F1-Login_Scenarios
		As a user, 
		I want to login to the Cuviva Control Tower System 
	When I provide valid username and password

Background:
	Given That I have launch the "Chrome" browser
	And Navigates to the "Sign in to your account" Login page

@Login
@Regression
Scenario: F1-TC01_Login_to_the_Application_with_valid_credentials
	Given I have entered correct value for username and password
		| Username       | Password       |
		| Valid Username | Valid Password |
	When I click on the signin button
	Then I should be able to login to the system successfully
	And I verify the profile name "LoginUserProfile"

@Login
@Regression
Scenario: F1-TC02_Logout_from_the_Application_using_valid_credentialsm
	Given I have entered correct value for username and password
		| Username       | Password       |
		| Valid Username | Valid Password |
	When I click on the signin button
	Then I should be able to login to the system successfully
	And I verify the profile name "LoginUserProfile"
	When  I click on the logout button
    Then I verify the login page header "You signed out of your account"

@Login
@Regression
Scenario: F1-TC03_Login_to_the_Application_with_invalid_credentials
	Given I have entered invalid value for username and password
		| Username       | Password         |
		| Valid Username | Invalid Password |
	When I click on the signin button
	Then I should NOT be able to login successfully
	And I verify the error message "Your account or password is incorrect. If you don't remember your password, reset it now."
