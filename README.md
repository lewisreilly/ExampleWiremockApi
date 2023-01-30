# ExampleWiremockApi

Example of using [Wiremock.NET](https://github.com/WireMock-Net/WireMock.Net/wiki) to create a simple, local API for returning stubbed responses.

Supported requests
- GET /echo - echos back the URL path
- GET /healthcheck - responds with the current date and time
- GET /slow_response - same behaviour as /healthcheck after an initial delay