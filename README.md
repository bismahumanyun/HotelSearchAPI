#HotelSearchAPI

This Web API is created in the .NET Core 5 using Microsoft Visual Studio 2019 for an interview assessment assigned by the AHOY - a Dubai based organization.

#Instructions

For getting connected, you need to generate an environment key by running cmd as administrator. Use the following commmand to do so: setx KEY "xyzkey12345" /M
Change the DB credentials in the appsettings.JSON file.

Two new users needs be registered i.e. one with the role 'Administrator' and other with the role 'User' since authorization has been implemented.

Since JWT Authorization has also been implemented, a token will be generated when user will be login. While testing the API user can do the authorization  
to perform the action as per the assigned role. For example: Only Administrator role can delete the hotel, thus, Token Authorisation is mandatory. For  this purpose 
copy paste the generated token as per instructed by hitting the authoriszed button at the top right.

Error Log text file will be generated at the "C:\HotelSearchAPI\Logs". The error log has been logged using Serilog library.

Paging has also been implemented for the client's feasibility. 


#DatabaseBackup

A database backup "hotelDB.bak" has been attached also.

#SampleUsers
Sample users' credentials are in the "User deails.txt" file.


