using System;

/**
 * \namespace elaMicroservicesGrpc.Constant
 * \brief define all the common values for the gRPC definition
 */
namespace elaMicroservicesGrpc.Constant
{
    /**
     * \class ElaGrpcConstants
     * \brief ELA gRPC constant definition
     */
    public class ElaGrpcConstants
    {
        /// ///////////////////////////////////////////////////////
        // constant definition
        public static readonly String DEFAULT_SERVER_HOSTNAME = "0.0.0.0";
        public static readonly String DEFAULT_LOCALHOST = "127.0.0.1";

        /// ///////////////////////////////////////////////////////
        // Dataflow base definition
        public static readonly int PORT_DATAFLOW_BASE_REMOTE_API_DEFAULT = 50057;
        public static readonly int PORT_DATAFLOW_BASE_REMOTE_API_BLE = 50058;
        public static readonly int PORT_DATAFLOW_BASE_REMOTE_API_WIREPAS = 50059;
        public static readonly String DEFAULT_DATAFLOW_BASE_NAME = "Ela Dataflow Base Service";
        /// ///////////////////////////////////////////////////////
        // Dataflow master definition
        public static readonly int PORT_DATAFLOW_MASTER_REMOTE_API_DEFAULT = 50060;
        public static readonly String DEFAULT_DATAFLOW_MASTER_NAME = "Ela Dataflow Master Service";
        /// ///////////////////////////////////////////////////////
        // Authentication definition
        public static readonly int PORT_AUTHENTICATION_REMOTE_API = 50050;
        public static readonly String DEFAULT_AUTHENTICATION_NAME = "Authentication Service";
        /// ///////////////////////////////////////////////////////
        // Bluetooth definition
        public static readonly int PORT_BLUETOOTH_REMOTE_API = 50051;
        public static readonly String DEFAULT_BLUETOOTH_BASE_NAME = "Bluetooth Base Service";
        /// ///////////////////////////////////////////////////////
        // Wirepas definition
        public static readonly int PORT_WIREPAS_REMOTE_API = 50052;
        public static readonly String DEFAULT_WIREPAS_BASE_NAME = "Wirepas Base Service";
        // Uwb definition
        public static readonly int PORT_POSITIONING_ANCHOR_REMOTE_API = 50060;
        public static readonly String DEFAULT_POSITIONING_ANCHOR_BASE_NAME = "Positioning Anchor Base Service";
        /// ///////////////////////////////////////////////////////
        // MQTT Broker
        public static readonly int PORT_MQTT_BROKER_REMOTE_API_UNSECURE = 1883;
        /// ///////////////////////////////////////////////////////
        // Bluetooth Configuration definition
        public static readonly int PORT_BLUETOOTH_CONFIG_REMOTE_API = 50053;
        public static readonly String DEFAULT_BLUETOOTH_CONFIG_BASE_NAME = "Bluetooth Otap and Configuration Service";
        /// ///////////////////////////////////////////////////////
        // Bluetooth Master definition
        public static readonly int PORT_BLUETOOTH_MASTER_REMOTE_API = 50054;
        public static readonly String DEFAULT_BLUETOOTH_MASTER_BASE_NAME = "Bluetooth Master Service";        
        /// ///////////////////////////////////////////////////////
        // EPE Master definition
        public static readonly int PORT_EPE_REMOTE_API = 50055;
        public static readonly String DEFAULT_EPE_CORE_BASE_NAME = "Ela Positioning Engine Core Service";
        /// ///////////////////////////////////////////////////////
        // Nfc Master definition
        public static readonly int PORT_NFC_MASTER_REMOTE_API = 50056;
        public static readonly String DEFAULT_NFC_MASTER_BASE_NAME = "NFC Base Service";

        /// ///////////////////////////////////////////////////////
        // Proto version constant definition
        public static readonly uint VERSION_PROTO_MAJOR = 1;
        public static readonly uint VERSION_PROTO_MINOR = 5;
        public static readonly uint VERSION_PROTO_RELEASE = 0;
        //

        /**
         * \fn getVersion
         * \brief getter on the proto version
         */
        public static string GetVersion()
        {
            return $"{VERSION_PROTO_MAJOR}.{VERSION_PROTO_MINOR}.{VERSION_PROTO_RELEASE}";
        }
    }
}
