# elaMicroserviceGrpc
Main gRPC project to get all the proto files available for ELA Microservices. We use gRPC and we love it! gRPC is a modern open source high performance Remote Procedure Call (RPC) framework that can run in any environment. Here we use it with two different developpement environnement. The 1st one is **Microsoft Visual Studio**, **.NetCore** and **C#** to develop the server and client side for our application. The 2nd one is **Python** tp develop the server and client side too. The 3rd one is with **Android Studio** and **Java** especially for the client side.

To find all the information about gRPC, you can go directly to the official website [here][here_grpc]. The are lots of documentation, but we will provide here some description for the different public API, and at least how to generate the client side to plug directly to our application.

So, you will find more detail about what you can find in this repository by clicking on the following link and navigate through the different documentation. 
- [Description](#description)
- [API](#api)
    - [Bluetooth](#bluetooth)
    - [Wirepas](#wirepas)

## Description
So this repository contains the declaration of different API to code our applications. You will find here the declaration for the followig services. Some are public and we will provide more details there and some are not (unfortunately you will find no more documentation):
- Authentication (Private) 
- Bluetooth (Public)
- Common (Public)
- Tagset (Private)
- Wirepas (Public)
- eRTLS (Private)

If you are familiar with Microsoft technologies, you can clone the repository and run the solution for Visual Studio. But there, we will talk about the different services you can reach using gRPC, a couple hostname / port, and the public API we provide with the **proto file** declaration. The table just below summarize the port expose for each service.

| Service Name | Port |
| --- | --- |
| Authentication Module | 50050 |
| Bluetooth Base | 50051 |
| Wirepas Base | 50052 |
| Bluetooth Configuration and OTAP | 50053 |
| Bluetooth Master | 50054 |
| EPE | 50055 |

## API
So for each service, we can talk about their public API and where you can find them. As we said, we used the **proto** file which describe the main interface and the common object used to exchange informations between server and clients. For more information about our service and what ELA provide, you can find more information [here](https://github.com/elaInnovation/ELA-Microservices/blob/master/README.md) in the main service presentation.

You can install it using [docker][here_docker], all information are provided in the previous link.

### Bluetooth
For the **Bluetooth Base** the main description is declared in the **ElaBluetoothPublicAPI.proto** file that you can reach [here](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Protos/Bluetooth/ElaBluetoothPublicAPI.proto). You can find a description for this service [here](https://github.com/elaInnovation/ELA-Microservices/blob/master/Documentation/Bluetooth%20Base/README.md) where we try to summarize all the functionnalities available for the **Bluetooth Base** Microservice.

The summary of this API is just below. To find more information about the different object, you can follow ***this link***.
```proto
// The BackendConfig service definition.
service ElaBluetoothPublicService {

  // authentication functions
  rpc Connect(ElaAuthentication.ElaAuthenticationRequest) returns (ElaAuthentication.ElaAuthenticationResponse) {}
  rpc Disconnect(ElaCommon.ElaInputBaseRequest) returns (ElaCommon.ElaError) {}

  // bluetooth scanning
  rpc StartBluetoothListening(ElaBluetoothScanningRequest) returns (ElaCommon.ElaError) {}
  rpc GetScannedDevices(ElaCommon.ElaInputBaseRequest) returns (ElaBluetoothScanResults) {}
  rpc StopBluetoothListening(ElaCommon.ElaInputBaseRequest) returns (ElaCommon.ElaError) {}

  // bluetooth scanning streaming
  rpc StartBluetoothDataFlow(ElaBluetoothScanningRequest) returns (stream ElaBluetoothScanResults) {}
  rpc StopBluetoothDataFlow(ElaCommon.ElaInputBaseRequest) returns (ElaCommon.ElaError) {}

  // bluetooth connections
  rpc SendElaBluetoothCommand(ElaBluetoothConnectRequest) returns (ElaBluetoothConnectResult) {}

  // monitoring
  rpc GetServiceStatus(ElaCommon.ElaInputBaseRequest) returns (ElaBluetoothMicroserviceStatus) {}
  rpc GetLogInformations(ElaCommon.ElaLogRequest) returns (ElaCommon.ElaLogResponse) {}
  rpc SetUserInformations(ElaCommon.ElaUserInformationsRequest) returns (ElaCommon.ElaError) {}
  rpc SetConfiguration(ElaCommon.ElaConfigurationRequest) returns (ElaCommon.ElaError) {}
}
```

The complete description of the **Bluetooth Base API** is available [here][here_bluetooth_api]. 

### Wirepas 
For the **Wirepas Base** the main description is declared in the **ElaWirepasPublicAPI.proto** file that you can reach [here](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Protos/Bluetooth/ElaBluetoothPublicAPI.proto). You can find a description for this service [here](https://github.com/elaInnovation/ELA-Microservices/blob/master/Documentation/Wirepas%20Base/README.md) where we try to summarize all the functionnalities available for the **Wirepas Base** Microservice.

The summary of this API is just below. To find more information about the different object, you can follow ***this link***.
```proto
// The service definition.
service ElaWirepasPublicService {

  // authentication functions
  rpc Connect(ElaAuthentication.ElaAuthenticationRequest) returns (ElaAuthentication.ElaAuthenticationResponse) {}
  rpc Disconnect(ElaCommon.ElaInputBaseRequest) returns (ElaCommon.ElaError) {}

  // Wirepas flow management
  rpc StartWirepasDataFlow(ElaWirepasDataRequest) returns (stream ElaWirepasDataPacket) {}
  rpc StopWirepasDataFlow(ElaWirepasDataRequest) returns (ElaCommon.ElaError) {}

  // Wirepas Commands
  rpc SendElaWirepasCommand(SendPacketReq) returns (SendPacketResp) {}

  // Wirepas Monitoring
  rpc GetServiceStatus(ElaCommon.ElaInputBaseRequest) returns (ElaWirepasMicroserviceStatus) {}
}
```

[here_grpc]: https://grpc.io

[here_docker]: https://www.docker.com

[here_bluetooth_api]: https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Bluetooth%20Base/README.md
