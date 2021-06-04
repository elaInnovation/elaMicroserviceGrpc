# ELA Wirepas Common Objects
This part describe the **ELA Wirepas Common Objects** developped by ELA Innovation. We use gRPC and we love it! gRPC is a modern open source high performance Remote Procedure Call (RPC) framework that can run in any environment. All the desciprion here is based on proto files and describe the different function declared in the interface, and the associated object used as parameters.

To find all the information about gRPC, you can go directly to the official website [here][here_grpc]. The are lots of documentation, but we will provide here some description for the different public API, and at least how to generate the client side to plug directly to our application. But if you are familiar with the technologie, this is the place to be to have a good overview for the different fonctions and object.

## Objects
You will find the description here for the following objects
- [SendPacketReq](#sendpacketreq)
- [SendPacketResp](#sendpacketresp)
- [ResponseHeader](#responseheader)

### SendPacketReq
**Brief** : This class describe the request to send a command to the tag using Wirepas Network.

**Declaration** 
```proto
message SendPacketReq {
    RequestHeader header = 1;

    uint32 destination_address = 2;
    uint32 source_endpoint = 3;
    uint32 destination_endpoint = 4;
    uint32 qos = 5;
    bytes payload = 6;

    uint32 initial_delay_ms = 7;
    bool is_unack_csma_ca = 8;
    uint32 hop_limit = 9;

    ElaCommon.ElaInputBaseRequest request = 10;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| header | RequestHeader | This header is the common header here to describe informaiton like unique **request id** and **sink id** | Mandatory |
| destination_address | uint32 | Destination address of the tag in the wirepas network | Mandatory |
| source_endpoint | uint32 | Source enpoint relative to the tag and functionnality in the wirepas network | Mandatory |
| destination_endpoint | uint32 | Destination enpoint relative to the tag and functionnality in the wirepas network | Mandatory |
| qos | uint32 | Quality of service relative to the request | Mandatory |
| payload | bytes | Payload reltive to the command | Mandatory |
| initial_delay_ms | uint32 | reserved object for configuration and monitoring | Mandatory |
| is_unack_csma_ca | bool | reserved object for configuration and monitoring | Mandatory |
| hop_limit | uint32 | reserved object for configuration and monitoring | Mandatory |
| request | [ElaInputBaseRequest](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elainputbaserequest) | Main input request for all ELA Microservice request | Mandatory |

### SendPacketResp 
**Brief** : This class describe the response to send a command to the tag.

**Declaration** 
```proto
message SendPacketResp {
    ResponseHeader header = 1;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| header | ResponseHeader | Response with all information provided by the network | Always present |

### ResponseHeader 
**Brief** : This header describe all the content

**Declaration** 
```proto
message ResponseHeader {
    // Same as in Request
    uint64 req_id = 1;
    // Gw id that handled the request
    string gw_id = 2;
    // Sink id if relevant for request
    string sink_id = 3;
    // Global result of request
    ErrorCode res = 4;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| req_id | uint64 | **Request ID** as request unique identifiant provided to identifiy the request | Always present |
| gw_id | string | **Gateway ID** this is the unique identifiant from the gateway. This value often match with the **hostname** from the gateway | Always present |
| sink_id | string | **Sink ID** identifiant of your sink plug in your Wirepas Gateway | Always present |
| res | [ElaError](https://github.com/elaInnovation/elaMicroserviceGrpc/blob/master/Documentation/Ela%20Common/README.md#elaerror) | Ela error code associated to the service and the Wirepas Network management | Always present |