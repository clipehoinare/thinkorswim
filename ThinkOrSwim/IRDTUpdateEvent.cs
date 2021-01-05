//https://docs.microsoft.com/en-us/office/vba/api/excel.irtdupdateevent
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Library.ThinkOrSwim.Adapter
{
    /// <summary>
    /// Represents real-time data update events.
    /// </summary>
    /// <remarks>
    /// To instantiate or return an IRTDUpdateEvent object, declare a variable as an IRTDUpdateEvent object, and then use that variable as a callback object.
    /// </remarks>
    [ComImport, TypeLibType((short)0x1040), Guid("A43788C1-D91B-11D3-8F39-00C04F3651B8")]
    interface IRTDUpdateEvent
    {
        /// <summary>
        /// The real-time data (RTD) server uses this method to notify Microsoft Excel that new data has been received.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(10), PreserveSig]
        void UpdateNotify();

        /// <summary>
        /// Returns or sets a Long for the interval between updates for real-time data. Read/write.
        /// </summary>
        /// <remarks>
        /// Setting the HeartbeatInterval property to -1 will result in the Heartbeat method not being called.
        /// </remarks>
        /// <note>
        /// The heartbeat interval cannot be set below 15,000 milliseconds, due to the standard 15-second time out.
        /// </note>
        [DispId(11)]
        int HeartbeatInterval
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(11)]
            get;
            [param: In]
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(11)]
            set;
        }

        /// <summary>
        /// Instructs the real-time data (RTD) server to disconnect from the specified IRTDUpdateEvent object.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(12)]
        void Disconnect();
    }
}
