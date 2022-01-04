</h1>
<h3 align="center">
	MOVEit Transfer
</h3>

<p align="center">
	<img alt="Last Commit" src="https://img.shields.io/github/last-commit/ddxkalin/moveit-transfer.svg?style=flat-square">
	<img alt="Licence" src="https://img.shields.io/github/license/ddxkalin/moveit-transfer.svg?style=flat-square">
	<img alt="Star" src="https://img.shields.io/badge/you%20like%20%3F-STAR%20ME-blue.svg?style=flat-square">
</p>

## Project Requirements
- Create an interface that allows a user to upload a file to MOVEit Transfer using the REST API
- The app should allow for any username/password and upload the file into the user’s home folder
- Post the code to a Github repo
- Repo should have instructions on how to run the sample (including any machine or browser configuration required)
- You may choose any language, framework or interface pattern

## Resources
- Basics of using the MOVEit Transfer web UI: https://docs.ipswitch.com/MOVEit/Transfer2020/Help/Admin/en/index.htm#31238.htm
- API Documentation - https://docs.ipswitch.com/MOVEit/Transfer2020_1/Api/rest/
- Interactive Swagger documentation of REST APIs: https://mobile-1.moveitcloud.com/swagger/ui/index
- Authorization help
The API uses Access Tokens to validate the user. The first step is to get the token by providing the username and password to the server
After the token is received it is added to headers as “Authorization” = “Bearer ”
Auth-sample.txt attachment is a PowerShell example that should help you understand how to get the token and use i

## Prerequisites :
   1. Have a Google chrome browser installed
   2. Run it with CORS disabled :
      1. Disable CORS in Chrome oOSX: 
         1. 1.Quit Chrome
         2. 2.Go to Terminal
         3. 3.Execute the following command: 4.open /Applications/Google\Chrome.app --args --user-data-dir="/var/tmp/Chrome dev session" --disable-web-security
      2. Disable CORS in Chrome Windows: 
         1. Close all Chrome windows
         2. 2.Open "Run"
         3. 3.Execute the following command: 4.chrome.exe --user-data-dir="C://Chrome dev session" --disable-web-security
      3. Download the Allow CORS: Access-Control-Allow-Origin extension for the browser and enable it.


## Issues
- Uploading method is currently is under development!

## TODO:
- Implement Unit Testing for better perfomance
- Fix the Uploading method issue
- Logic, syntax & comments add & fix if necessary
