Enhancements:
	1. Replaced '?' with enter to get instructions.
	2. Added quit option to terminate application -> there was option to exit the app, added this as part of instructions list.
	3. Enhanced existing console input and output by adding new console logs-> the inputs were vague and also proper spacing and new line characters were missin.
	4. Fixed getCategories to return list of categories, it was failing before -> it required update to URL which fetched the required values.
	5. Added default case in switch(to handle various console input scenarios)-> in case of y and n, only y was supported and handling of scenarios other than y and n is also provided.
	6. Added logic to enter number of jokes with in range-> if the number was not in range,trigger a prompt to provide propeer numbers.
	7. Returning jokes based on the number entered.-> previosly was returning only one entry irrespective of number.
	8. List of categories to selct a category, if entered category not present prompt to enter again-> display the valid categories to chose from.
	9. Fixed existing and potential bugs.

Future Maintenance & Extension :
	1. Added new methods and decoupled code for future enhancements.
	2. Methods like ProcessNumberOfJokesandCategory(), ProcessNumberOfJokesWithOutCategory() etc are added as seperation of concerns.

 Reliability & Quality
	1. Added exception handling mechanisms required at places like FormatException, HttpRequestException.
	2. Failures are handled efficiently.

*More enhancements can be performed which will be specific to requirements