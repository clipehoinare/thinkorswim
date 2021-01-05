//https://docs.microsoft.com/en-us/office/vba/api/excel.irtdserver
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Library.ThinkOrSwim.Adapter
{
    /// <summary>
    /// Represents an interface for a real-time data server.
    /// </summary>
    /// <remarks>
    /// The IRTDServer object can be instantiated or created only by implementing the IRTDServer interface by using the Implements keyword.
    /// </remarks>
    [ComImport, TypeLibType((short)0x1040), Guid("EC0E6191-DB51-11D3-8F3E-00C04F3651B8")]
    interface IRTDServer
    {
        /// <summary>
        /// The ServerStart method is called immediately after a real-time data (RTD) server is instantiated. Returns a Long. A negative value or zero indicates failure to start the server; a positive value indicates success.
        /// </summary>
        /// <param name="callback" description="The callback object(type IRTDUpdateEvent)."></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(10)]
        int ServerStart([In, MarshalAs(UnmanagedType.Interface)] IRTDUpdateEvent callback);

        /// <summary>
        /// Adds new topics from a real-time data (RTD) server. The ConnectData method is called when a file is opened that contains real-time data functions or when a user types in a new formula that contains the RTD function.
        /// </summary>
        /// <param name="topicId" description="A unique value, assigned by Microsoft Excel, that identifies the topic."></param>
        /// <param name="parameters" description="A single-dimensional array of strings identifying the topic."></param>
        /// <param name="newValue" description="True to determine if new values are to be acquired."></param>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Struct)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(11)]
        object ConnectData([In] int topicId, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref object[] parameters, [In, Out] ref bool newValue);

        /// <summary>
        /// This method is called by Microsoft Excel to get new data. Returns a Variant.
        /// </summary>
        /// <remarks>
        /// The data returned to Excel is a Variant containing a two-dimensional array. The first dimension represents the list of topic IDs. The second dimension represents the values associated with the topic IDs.
        /// </remarks>
        /// <param name="topicCount" description="The real-time data (RTD) server must change the value of the TopicCount to the number of elements in the array returned."></param>
        /// <returns description="A Variant array that contains the new data."></returns>
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(12)]
        object[,] RefreshData([In, Out] ref int topicCount);

        /// <summary>
        /// Notifies a real-time data (RTD) server application that a topic is no longer in use.
        /// </summary>
        /// <param name="topicId" description="A unique value assigned to the topic assigned by Microsoft Excel."></param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(13)]
        void DisconnectData([In] int topicId);

        /// <summary>
        /// Determines if the real-time data (RTD) server is still active. Returns a Long value. 
        ///     Zero or a negative number indicates failure; a positive number indicates that the server is active.
        /// </summary>
        /// <remarks>
        /// The Heartbeat method is called by Microsoft Excel if the HeartbeatInterval property has elapsed 
        ///     since the last time Excel was called with the UpdateNotify method.
        /// </remarks>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(14)]
        int Heartbeat();

        /// <summary>
        /// Terminates the connection to the real-time data (RTD) server.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(15)]
        void ServerTerminate();
    }
}
