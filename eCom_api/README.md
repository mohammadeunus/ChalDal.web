## ERRORS
- Fetch error response status is 500 https://localhost:7225/swagger/v1/swagger.json
	- solution: added [HttpGet] before a action in controller
	- the error is related to swagger so this can be resolved if we change the url.