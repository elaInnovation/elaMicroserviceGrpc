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
    - ***Information*** : 
- **Output** ElaBluetoothScanResults : 
    - ***Description*** : Object containing all the results
    - ***Information*** : 

## StopBluetoothListening
```proto
  rpc StartBluetoothListening(ElaBluetoothScanningRequest) returns (ElaCommon.ElaError) {}
```

## SendElaBluetoothCommand
```proto
  rpc StartBluetoothListening(ElaBluetoothScanningRequest) returns (ElaCommon.ElaError) {}
```

## Authenticate
All the information relative to the authentication, managing object and **session id** are available [here](https://github.com/elaInnovation/ELA-Microservices/blob/master/Documentation/Authentication/README.md})

## Objects
You will find here all the object description relative to the **Bluetooth Base Microservice**.

### ElaBluetoothScanningRequest
```proto
message ElaBluetoothScanningRequest {

	ElaCommon.ElaInputBaseRequest request = 1;
	ElaBluetoothFilter filter = 2;
	bool define_scan_time = 3;
	uint32 scan_time_seconds = 4;
}
````

| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| request | ElaInputBaseRequest | Main input request for all ELA Microservice request | Mandatory |
| filter | ElaBluetoothFilter | Bluetooth filter object to define a specific filter for your Bluetooth Scanner | Optionnal |
| define_scan_time | bool | Define or not a specific time to scan, associated to **scan_time_seconds** | Optionnal |
| scan_time_seconds | uint32 | Target scan time, associated to the **define_scan_time** variable to define a time scan in seconds | Optionnal |

### ElaBluetoothScanningRequest
```proto
message ElaBluetoothScanningRequest {

	ElaCommon.ElaInputBaseRequest request = 1;
	ElaBluetoothFilter filter = 2;
	bool define_scan_time = 3;
	uint32 scan_time_seconds = 4;
}
```

[here_grpc]: https://grpc.io

[here_bluetooth_information]: https://github.com/elaInnovation/ELA-Microservices/blob/master/Documentation/Bluetooth%20Base/README.md
