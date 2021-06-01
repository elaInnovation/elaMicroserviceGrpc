# Bluetooth Base API
This part describe the API associated to the **Bluetooth Base Module** developped by ELA Innovation. We use gRPC and we love it! gRPC is a modern open source high performance Remote Procedure Call (RPC) framework that can run in any environment. All the desciprion here is based on proto files and describe the different function declared in the interface, and the associated object used as parameters.

To find all the information about gRPC, you can go directly to the official website [here][here_grpc]. The are lots of documentation, but we will provide here some description for the different public API, and at least how to generate the client side to plug directly to our application. But if you are familiar with the technologie, this is the place to be to have a good overview for the different fonctions and object.

- [Functions](#functions)
    - [StartBluetoothListening](#startbluetoothlistening)
    - [GetScannedDevices](#getscanneddevices)
    - [StopBluetoothListening](#stopbluetoothlistening)
    - [SendElaBluetoothCommand](#sendelabluetoothcommand)
    - [Authenticate](#authenticate)
- [Objects](#objects)
    - [ElaBluetoothScanningRequest](#elabluetoothscanningrequest)
    - [ElaBluetoothConnectRequest](#elabluetoothconnectrequest)

## Functions
The different function provided for the current interface are the one describe in the **proto** summary just below.
```proto
service ElaBluetoothPublicService {

  // authentication functions
  rpc Connect(ElaAuthentication.ElaAuthenticationRequest) returns (ElaAuthentication.ElaAuthenticationResponse) {}
  rpc Disconnect(ElaCommon.ElaInputBaseRequest) returns (ElaCommon.ElaError) {}

  // bluetooth scanning
  rpc StartBluetoothListening(ElaBluetoothScanningRequest) returns (ElaCommon.ElaError) {}
  rpc GetScannedDevices(ElaCommon.ElaInputBaseRequest) returns (ElaBluetoothScanResults) {}
  rpc StopBluetoothListening(ElaCommon.ElaInputBaseRequest) returns (ElaCommon.ElaError) {}

  // bluetooth connections
  rpc SendElaBluetoothCommand(ElaBluetoothConnectRequest) returns (ElaBluetoothConnectResult) {}
}
```

You will find the associted proto file [here](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Protos/Bluetooth/ElaBluetoothPublicAPI.proto)

## StartBluetoothListening
### function
```proto
  rpc StartBluetoothListening(ElaBluetoothScanningRequest) returns (ElaCommon.ElaError) {}
```

**Brief** : This function start the bluetooth scanner for the **Bluetooth Base Microservice**. The scan start and the microservice state switch in ***Scanning*** mode. All the information relative to the **Bluetooth Base** are available [here][here_bluetooth_information]. Then you can get the result by calling the function **GetScannedDevices** to get all the data by the scanner 

### parameters
- **Input** ElaBluetoothScanningRequest :
    - ***Description*** : Bluetooth Scanning request
    - ***Information*** : [ElaBluetoothScanningRequest](#elabluetoothscanningrequest)
- **Output** ElaCommon.ElaError : 
    - ***Description*** : Generic error for the ELA Microservices
    - ***Information*** : [ElaError](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elaerror)

## GetScannedDevices
```proto
  rpc GetScannedDevices(ElaCommon.ElaInputBaseRequest) returns (ElaBluetoothScanResults) {}
```

**Brief** : This function allow you to get the scanned device using the associated object. To get the object, you need to call previously the **StartBluetoothListening** function. If the service is not in Scanning state, you won't have results.

### parameters
- **Input** ElaInputBaseRequest :
    - ***Description*** : Ela Input Base Request
    - ***Information*** : [ElaInputBaseRequest](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elainputbaserequest)
- **Output** ElaBluetoothScanResults : 
    - ***Description*** : Object containing all the results
    - ***Information*** : [ElaBluetoothScanResults](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Bluetooth%20Common/README.md#elabluetoothscanresults)

## StopBluetoothListening
```proto
  rpc StopBluetoothListening(ElaCommon.ElaInputBaseRequest) returns (ElaCommon.ElaError) {}
```

**Brief** : This function stop the bluetooth scanner for the **Bluetooth Base Microservice**. The scan stop and the microservice state switch in ***Pending*** mode. All the information relative to the **Bluetooth Base** are available [here][here_bluetooth_information].

### parameters
- **Input** ElaInputBaseRequest :
    - ***Description*** : Ela Input Base Request
    - ***Information*** : [ElaInputBaseRequest](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elainputbaserequest)
- **Output** ElaBluetoothScanResults : 
    - ***Description*** : Generic error for the ELA Microservices
    - ***Information*** : [ElaError](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elaerror)

## SendElaBluetoothCommand
```proto
  rpc SendElaBluetoothCommand(ElaBluetoothConnectRequest) returns (ElaBluetoothConnectResult) {}
```

**Brief** : This function send a command to the ELA Bluetooth device using **Bluetooth Base Microservice** and the associated Bluetooth service to ensure a connection. Calling this function change the state to service and switch in ***Connecting*** mode. When a connection is really established the state switch in **Connected** mode till the tag provide a response to the service. All the information relative to the **Bluetooth Base** are available [here][here_bluetooth_information].

### parameters
- **Input** ElaBluetoothConnectRequest :
    - ***Description*** : Ela Bluetooth Connection Request
    - ***Information*** : [ElaBluetoothConnectRequest](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Base/README.md#elabluetoothconnectrequest)
- **Output** ElaBluetoothConnectResult : 
    - ***Description*** : Ela Bluetooth Connection Result
    - ***Information*** : [ElaBluetoothConnectResult](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Base/README.md#elabluetoothconnectresult)

## Authenticate
All the information relative to the authentication, managing object and **session id** are available [here](https://github.com/elaInnovation/ELA-Microservices/blob/master/Documentation/Authentication/README.md})

## Objects
You will find here all the object description relative to the **Bluetooth Base Microservice**.

### ElaBluetoothScanningRequest
**Brief** : Bluetooth Scanning request object

**Desciption**
```proto
message ElaBluetoothScanningRequest {

	ElaCommon.ElaInputBaseRequest request = 1;
	ElaBluetoothFilter filter = 2;
	bool define_scan_time = 3;
	uint32 scan_time_seconds = 4;
}
````

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| request | ElaInputBaseRequest | Main input request for all ELA Microservice request | Mandatory |
| filter | ElaBluetoothFilter | Bluetooth filter object to define a specific filter for your Bluetooth Scanner | Optionnal |
| define_scan_time | bool | Define or not a specific time to scan, associated to **scan_time_seconds** | Optionnal |
| scan_time_seconds | uint32 | Target scan time, associated to the **define_scan_time** variable to define a time scan in seconds | Optionnal |

### ElaBluetoothConnectRequest
**Brief** : Bluetooth Connection Request definition

**Desciption**
```proto
message ElaBluetoothConnectRequest {
	
	ElaCommon.ElaInputBaseRequest request = 1;
	string target_mac_address = 2;
	string ela_command = 3;
	string ela_command_password = 4;
	string ela_command_arguments = 5;
	bool isLongWaitCommand = 6;
	//
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| request | ElaInputBaseRequest | Main input request for all ELA Microservice request | Mandatory |
| target_mac_address | string | Target mac address of the device to connect | Mandatory |
| ela_command_password | string | Bluetooth password associated to the tag | Optionnal |
| ela_command_arguments | string | Associated arguments to the command | Optionnal |
| isLongWaitCommand | bool | Is this command a long command where the service has to wait multiple answer (like data logger) | Optionnal |

### ElaBluetoothConnectResult
**Brief** : Bluetooth Connection Result definition, this object is the result provided by function **SendElaBluetoothCommand**.

**Desciption**
```proto
message ElaBluetoothConnectResult {

	ElaCommon.ElaError error = 1;
	ElaBluetoothConnectRequest input_request = 2;
	string result = 3;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| error | ElaError | Common error returned by a ELA Microservice | Always Present |
| input_request | ElaBluetoothConnectRequest | Copy of the input request associated to this result | Always Present |
| result | string | Result from the tag as a string | Optionnal |

[here_grpc]: https://grpc.io

[here_bluetooth_information]: https://github.com/elaInnovation/ELA-Microservices/blob/master/Documentation/Bluetooth%20Base/README.md
