Technologies Used:
.Net Framework - 4.7.1
ASP .NET MVC 5.2.7.0
HTML
CSS
UNITY CONTAINER FOR DEPENDENCY INJECTION: Unity.Mvc5

Execution instructions:
Run the application in Visual Studio or publish the solution to IIS and setup a domain in local IIS server and browse the URL.

Implementation approach:
Implemented CarouselContent ActionResult method to mock the Page data like Carousle title, Description and Images.When we submit the form with correct API URL then API will returns the mock data as a JSON format.

Run the application in Visual studio and browse the links as the below,
URLS:
1. When we ran the application in Visual Studio debug mode URL will be http://localhost:58168
2. Add API URL http://localhost:58168/api/carouselcontent
3. Hit Submit button to see the results in the page

Note*: Site can be hosted in IIS as well. Based on IIS binding replace the host name URL.
