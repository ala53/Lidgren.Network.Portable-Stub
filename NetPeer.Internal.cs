#if !__ANDROID__ && !IOS && !UNITY_WEBPLAYER && !UNITY_ANDROID && !UNITY_IPHONE
#define IS_MAC_AVAILABLE
#endif

using System;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Lidgren.Network
{
    public partial class NetPeer
    {
        private NetPeerStatus m_status;
        private object m_initializeLock = new object();

        internal readonly NetPeerConfiguration m_configuration;
        private readonly NetQueue<NetIncomingMessage> m_releasedIncomingMessages;
        internal readonly NetQueue<NetTuple<IPEndPoint, NetOutgoingMessage>> m_unsentUnconnectedMessages;

        internal Dictionary<IPEndPoint, NetConnection> m_handshakes;

        internal readonly NetPeerStatistics m_statistics;
        internal bool m_executeFlushSendQueue;

        private AutoResetEvent m_messageReceivedEvent;

        /// <summary>
        /// Gets the socket, if Start() has been called
        /// </summary>
        public Socket Socket { get { return null; } }

        /// <summary>
        /// Call this to register a callback for when a new message arrives
        /// </summary>
        public void RegisterReceivedCallback(SendOrPostCallback callback, SynchronizationContext syncContext = null)
        {
        }

        /// <summary>
        /// Call this to unregister a callback, but remember to do it in the same synchronization context!
        /// </summary>
        public void UnregisterReceivedCallback(SendOrPostCallback callback)
        {
        }

        internal void ReleaseMessage(NetIncomingMessage msg)
        {
        }

        private void BindSocket(bool reBind)
        {
        }

        private void InitializeNetwork()
        {
        }

        private void NetworkLoop()
        {
        }

        private void ExecutePeerShutdown()
        {
        }

        private void Heartbeat()
        {
        }

        /// <summary>
        /// If NetPeerConfiguration.AutoFlushSendQueue() is false; you need to call this to send all messages queued using SendMessage()
        /// </summary>
        public void FlushSendQueue()
        {
            m_executeFlushSendQueue = true;
        }

        internal void HandleIncomingDiscoveryRequest(double now, IPEndPoint senderEndPoint, int ptr, int payloadByteLength)
        {
        }

        internal void HandleIncomingDiscoveryResponse(double now, IPEndPoint senderEndPoint, int ptr, int payloadByteLength)
        {
        }

        private void ReceivedUnconnectedLibraryMessage(double now, IPEndPoint senderEndPoint, NetMessageType tp, int ptr, int payloadByteLength)
        {
        }

        internal void AcceptConnection(NetConnection conn)
        {
        }

        [Conditional("DEBUG")]
        internal void VerifyNetworkThread()
        {
        }

        internal NetIncomingMessage SetupReadHelperMessage(int ptr, int payloadLength)
        {
            return null;
        }

    }
}