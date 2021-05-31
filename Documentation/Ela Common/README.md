# ELA Common Objects
This part describe the **ELA Common Objects** developped by ELA Innovation. We use gRPC and we love it! gRPC is a modern open source high performance Remote Procedure Call (RPC) framework that can run in any environment. All the desciprion here is based on proto files and describe the different function declared in the interface, and the associated object used as parameters.

To find all the information about gRPC, you can go directly to the official website [here][here_grpc]. The are lots of documentation, but we will provide here some description for the different public API, and at least how to generate the client side to plug directly to our application. But if you are familiar with the technologie, this is the place to be to have a good overview for the different fonctions and object.

## Objects
You will find the description here for the following objects
- [ElaInputBaseRequest](#elainputbaserequest)
- [ElaError](#elaerror)

### ElaInputBaseRequest
```proto
message ElaInputBaseRequest {

	string client_id = 1;
	string session_id = 2;
	string request_id = 3;
	string client_ip_address = 4;
}
````

| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| client_id | string | Identifiant defined by user to specify to which client is associated the request | Mandatory |
| session_id | string | Authentication token provided by session Id | Mandatory |
| request_id | string | Absolute request counter defined by user to identify the request | Mandatory |
| client_ip_address | string | Reseved | Optionnal present |


### ElaError
```proto
message ElaError {

	uint32 error = 1;
	string lastErrorMessage = 2;
	string lastExceptionMessage = 3;
	string clientId = 4;
	string requestId = 5;
}
````

| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| error | uint32 | Returned error code associated to the service (no Error is 0). For the other errors, you can report to the specific description | Always present |
| lastErrorMessage | string | Last error message associated to the reported error | Always present |
| lastExceptionMessage | string | Exception message as additionnal information if this one is reported by the microservice | Optionnal |
| clientId | string | Target client ID, this one is associatd by your client id passed with [ElaInputBaseRequest](#elainputbaserequest) | Always present |
| requestId | string | Target request ID, this one is associatd by your request id passed with [ElaInputBaseRequest](#elainputbaserequest)  | Always present |

[here_grpc]: https://grpc.io
