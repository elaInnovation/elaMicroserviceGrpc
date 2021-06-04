# Wirepas Base API
This part describe the API associated to the **Wirepas Base Module** developped by ELA Innovation. We use gRPC and we love it! gRPC is a modern open source high performance Remote Procedure Call (RPC) framework that can run in any environment. All the desciprion here is based on proto files and describe the different function declared in the interface, and the associated object used as parameters.

To find all the information about gRPC, you can go directly to the official website [here][here_grpc]. The are lots of documentation, but we will provide here some description for the different public API, and at least how to generate the client side to plug directly to our application. But if you are familiar with the technologie, this is the place to be to have a good overview for the different fonctions and object.

- [Functions](#functions)
    - [StartWirepasDataFlow](#startwirepasdataflow)
    - [StopWirepasDataFlow](#stopwirepasdataflow)
    - [SendElaWirepasCommand](#sendelawirepascommand)
    - [Authenticate](#authenticate)
- [Objects](#objects)
    - [ElaWirepasDataRequest](#elawirepasdatarequest)
    - [ElaWirepasDataPacket](#elawirepasdatapacket)

## Functions
The different function provided for the current interface are the one describe in the **proto** summary just below.
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

You will find the associted proto file [here](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Protos/Wirepas/ElaWirepasPublicAPI.proto)

## StartWirepasDataFlow
### function
```proto
  rpc StartWirepasDataFlow(ElaWirepasDataRequest) returns (stream ElaWirepasDataPacket) {}
```

**Brief** : This function start the wirepas flow using streaming and provide the data catched by **Wirepas Base Microservice**. Wirepas Module connect to a MQTT broker, get the data and transform it to interpret data like sensor data.

### parameters
- **Input** ElaWirepasDataRequest :
    - ***Description*** : Starting request to open the streaming flow 
    - ***Information*** : [ElaWirepasDataRequest](#elawirepasdatarequest)
- **Output** ElaWirepasDataPacket : 
    - ***Description*** : Data packet object streamed from the wirepas service 
    - ***Information*** : [ElaWirepasDataPacket](#elawirepasdatapacket)

## StopWirepasDataFlow
### function
```proto
  rpc StopWirepasDataFlow(ElaWirepasDataRequest) returns (ElaCommon.ElaError) {}
```

**Brief** : This function stop the wirepas flow and close the streaming channel. The serivce stop to list the MQTT traffic and release the connection.

### parameters
- **Input** ElaWirepasDataRequest :
    - ***Description*** : Starting request to open the streaming flow 
    - ***Information*** : [ElaWirepasDataRequest](#elawirepasdatarequest)
- **Output** ElaError : 
    - ***Description*** : Generic error for the ELA Microservices
    - ***Information*** : [ElaError](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elaerror)  

## SendElaWirepasCommand
### function
```proto
  rpc SendElaWirepasCommand(SendPacketReq) returns (SendPacketResp) {}
```

**Brief** : This function allow to send a command through the network to the tag, using MQTT Broker and publish functionnalities. 

### parameters
- **Input** SendPacketReq :
    - ***Description*** : Object to create a packet to send a request to the tag
    - ***Information*** : [SendPacketReq](https://github.com/elaInnovation/elaMicroserviceGrpc/tree/master/Documentation/Wirepas%20Common#sendpacketreq)
- **Output** SendPacketResp : 
    - ***Description*** : Response from the tag or from the network
    - ***Information*** : [SendPacketResp](#sendpacketresp)      

## Authenticate
All the information relative to the authentication, managing object and **session id** are available [here](https://github.com/elaInnovation/ELA-Microservices/blob/master/Documentation/Authentication/README.md)

## Objects
You will find here all the object description relative to the **Wirepas Base Microservice**. The one provided by the public API are describe here, and some other common objet present for the different API are referenced in other documentation. However, you will find all the usefull links here.

### ElaWirepasDataRequest
**Brief** : Request object which handle all information to start a streaming request

**Desciption**
```proto
message ElaWirepasDataRequest {

	ElaCommon.ElaInputBaseRequest request = 1;
	string DataType = 2; // 
	string BrokerAdress = 3;
	int32 BrokerPort = 4;
}
````

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| request | [ElaInputBaseRequest](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elainputbaserequest) | Main input request for all ELA Microservice request | Mandatory |
| DataType | string | Defines what type of data is requested e.g. **Location** or **Sensor** data | Optionnal |
| BrokerAdress | string | Define the MQTT Broker hostname or IP address | Mandatory |
| BrokerPort | int32 | Define the connection port for your MQTT Broker | Mandatory |

### ElaWirepasDataPacket 
**Brief** : Packet containing data

**Desciption**
```proto
message ElaWirepasDataPacket {

	string last_updated_data_type = 1; // 

	ElaWirepasSensorDataItem wirepasSensorData = 2;
	ElaWirepasLocDataItem wirepasLocData = 3;

	double VBat = 4;
	string TimeStamp = 5;
	ElaWirepasNodeItem wpNode_item = 6;
	//
	ElaCommon.ElaCloseStreamingRequest closeStreamingRequest = 7;
}
````

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| last_updated_data_type | string | keyword associated to the last update type of data | Always Present |
| wirepasSensorData | ElaWirepasSensorDataItem | interpreted sensor data, this object is present if data has been catch by the program | Optionnal |
| wirepasLocData | ElaWirepasLocDataItem | interpreted location data, this object is present if data has been catch by the program | Optionnal |
| VBat | double | battery information | Optionnal |
| wpNode_item | ElaWirepasNodeItem | Note item information provided by the network | Optionnal |
| closeStreamingRequest | ElaCloseStreamingRequest | Close streaming request to notify you when a close request has been received in server side| Optionnal |
