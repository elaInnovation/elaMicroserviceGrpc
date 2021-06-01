# ELA Bluetooth Common Objects
This part describe the **ELA Bluetooth Common Objects** developped by ELA Innovation. We use gRPC and we love it! gRPC is a modern open source high performance Remote Procedure Call (RPC) framework that can run in any environment. All the desciprion here is based on proto files and describe the different function declared in the interface, and the associated object used as parameters.

To find all the information about gRPC, you can go directly to the official website [here][here_grpc]. The are lots of documentation, but we will provide here some description for the different public API, and at least how to generate the client side to plug directly to our application. But if you are familiar with the technologie, this is the place to be to have a good overview for the different fonctions and object.

## Objects
You will find the description here for the following objects
- [ElaBluetoothScanResults](#elabluetoothscanresults)
- [ElaBluetoothFilter](#elabluetoothfilter)
- [ElaBluetoothScanResultList](#elabluetoothscanresultlist)
- [ElaBluetoothScanResultItem](#elabluetoothscanresultitem)

### ElaBluetoothScanResults
**Brief** : This class describe the results from bluetooth scanning and provide to you all the scanned objects.

**Declaration** 
```proto
message ElaBluetoothScanResults {

	ElaCommon.ElaError error = 1;
	ElaBluetoothFilter current_filter_info = 2;
	uint32 total_scanned_items_counter = 3;
	uint32 last_scanned_items_counter = 4;
	// scan duration

	// max 64 items, all data will be bufferized in process
	ElaBluetoothScanResultList scanned = 5;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| error | ElaError | Common error returned by a ELA Microservice | Always Present |
| current_filter_info | ElaBluetoothFilter | Bluetooth Filter description associated for the current scan | Always Present |
| total_scanned_items_counter | uint32 | Total number of scanned devices till the start bluetooth scan | Always Present |
| last_scanned_items_counter | uint32 | Current number of devices scanned | Always Present |
| scanned | ElaBluetoothScanResultList | Reseved | Always Present |

### ElaBluetoothFilter
**Brief** : This class describe the content and function allowed to filter devices during a bluetooth scan.

**Declaration** 
```proto
message ElaBluetoothFilter {

	string filter_match_string = 1;
	repeated string filter_white_list = 2;
	int32 filter_maximum_rssi = 3;
	bool filter_only_manufacturer_id = 4;
	bool filter_only_connectable = 5;
	enum FilterType {
		No_Option = 0;
		Match_String = 1;
		White_List = 2;
		Maximum_Rssi = 3;
		Manufacturer_ID = 4;
	}
	FilterType filter_type = 6;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| filter_match_string | string | String filter to scan on the Bluetooth localname, string operation is a Contain | Optionnal |
| filter_white_list | string array | Reserved | Optionnal |
| filter_maximum_rssi | int32 | Define the maximum of rssi | Optionnal |
| filter_only_manufacturer_id | bool | Only device with the ELA Manufacturer Id (0x0757) | Optionnal |
| filter_only_connectable | Reserced | Reseved | Optionnal |
| filter_type | FilterType | Enumeration associated to the type of filter defined | Optionnal |

### ElaBluetoothScanResultList
**Brief** : This class describe the list of devices scanned for the call of the function **GetScannedDevices**.

**Declaration**
```proto
message ElaBluetoothScanResultList {

	string clientId = 1;
	repeated ElaBluetoothScanResultItem results = 2;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| clientId | string | identifiant of the client id from where the devices are comming | Optionnal |
| results | ElaBluetoothScanResultItem array | List of ElaBluetoothScanResultItem containing each devices | Optionnal |

### ElaBluetoothScanResultItem
**Brief** : This class describe all the parameters available for a scanned device.

**Declaration**
```proto
message ElaBluetoothScanResultItem {

	string time_stamp = 1;
	string mac_address = 2;
	string local_name = 3;
	int32 rssi = 4;
	uint32 flags = 5;
	bool connectable = 6;
	uint32 num_service_data = 7;
	repeated string service_data_array = 8;
	uint32 service_uuid = 9;
	uint32 manufacturer_id = 10;
	repeated string manufacturer_data = 11;
	string payload = 12;
	//
	// RFU
	string gps_coordinate = 13;
	string microservice_id = 14;
}
```

**Information**
| Name | Type | Description | Presence |
| --- | --- | --- | --- |
| time_stamp | string | timestamp of the scanned device | Always Present |
| mac_address | string | mac address of the scanned device | Always Present |
| local_name | string | local name of the scanned device | Optionnal |
| rssi | int32 | Received Signal Strength Indicator of the remote device (inquiry or advertising). | Optionnal |
| flags | uint32 | Bluetooth flags | Optionnal |
| connectable | bool | Is the device connectable or not | Optionnal |
| service_data_array | string array | list of scanned service from the device | Optionnal |
| service_uuid | uint32 | service uuid associated to the current device | Optionnal |
| manufacturer_id | uint32 | manufacturer id associated to the current device | Optionnal |
| manufacturer_data | string array | list of manufacturer data from the device | Optionnal |
| payload | string | raw bluetooth payload from the device | Optionnal |
| gps_coordinate | string | Reserved for futur use | Optionnal |
| microservice_id | string | Reserved | Optionnal |
