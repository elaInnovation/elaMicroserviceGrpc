using System;
using System.Collections.Generic;
using System.Text;

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
        /// ///////////////////////////////////////////////////////
        // Bluetooth Configuration definition
        public static readonly int PORT_BLUETOOTH_CONFIG_REMOTE_API = 50053;
        public static readonly String DEFAULT_BLUETOOTH_CONFIG_BASE_NAME = "Bluetooth Otap and Configuration Service";

        /// ///////////////////////////////////////////////////////
        // Proto version constant definition
        public static readonly uint VERSION_PROTO_MAJOR = 1;
        public static readonly uint VERSION_PROTO_MINOR = 1;
        public static readonly uint VERSION_PROTO_RELEASE = 0;
        //

        /**
         * \fn getVersion
         * \brief getter on the proto version
         */
        public static String getVersion()
        {
            return $"{VERSION_PROTO_MAJOR.ToString()}.{VERSION_PROTO_MINOR.ToString()}.{VERSION_PROTO_RELEASE.ToString()}";
        }
    }
}
