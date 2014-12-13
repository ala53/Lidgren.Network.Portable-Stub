using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lidgren.Network
{
	/// <summary>
	/// Status of the UPnP capabilities
	/// </summary>
	public enum UPnPStatus
	{
		/// <summary>
		/// Still discovering UPnP capabilities
		/// </summary>
		Discovering,

		/// <summary>
		/// UPnP is not available
		/// </summary>
		NotAvailable,

		/// <summary>
		/// UPnP is available and ready to use
		/// </summary>
		Available
	}

	/// <summary>
	/// UPnP support class
	/// </summary>
	public class NetUPnP
	{
		private const int c_discoveryTimeOutMillis = 1000;

		private NetPeer m_peer;
		private ManualResetEvent m_discoveryComplete = new ManualResetEvent(false);

		internal float m_discoveryResponseDeadline;

		private UPnPStatus m_status;

		/// <summary>
		/// Status of the UPnP capabilities of this NetPeer
		/// </summary>
		public UPnPStatus Status { get { return m_status; } }

		/// <summary>
		/// NetUPnP constructor
		/// </summary>
		public NetUPnP(NetPeer peer)
		{
			m_peer = peer;
			m_discoveryResponseDeadline = float.MinValue;
		}

		internal void Discover(NetPeer peer)
		{
			string str =
"M-SEARCH * HTTP/1.1\r\n" +
"HOST: 239.255.255.250:1900\r\n" +
"ST:upnp:rootdevice\r\n" +
"MAN:\"ssdp:discover\"\r\n" +
"MX:3\r\n\r\n";

			m_status = UPnPStatus.Discovering;

			byte[] arr = System.Text.Encoding.UTF8.GetBytes(str);

			m_peer.LogDebug("Attempting UPnP discovery");

			// allow some extra time for router to respond
			// System.Threading.Thread.Sleep(50);

			m_discoveryResponseDeadline = (float)NetTime.Now + 6.0f; // arbitrarily chosen number, router gets 6 seconds to respond
			m_status = UPnPStatus.Discovering;
		}

		internal void ExtractServiceUrl(string resp)
		{
		}

		private static string CombineUrls(string gatewayURL, string subURL)
		{
			// Is Control URL an absolute URL?
			if ((subURL.Contains("http:")) || (subURL.Contains(".")))
				return subURL;

			gatewayURL = gatewayURL.Replace("http://", "");  // strip any protocol
			int n = gatewayURL.IndexOf("/");
			if (n != -1)
				gatewayURL = gatewayURL.Substring(0, n);  // Use first portion of URL
			return "http://" + gatewayURL + subURL;
		}

		private bool CheckAvailability()
		{
			switch (m_status)
			{
				case UPnPStatus.NotAvailable:
					return false;
				case UPnPStatus.Available:
					return true;
				case UPnPStatus.Discovering:
					if (m_discoveryComplete.WaitOne(c_discoveryTimeOutMillis))
						return true;
					if (NetTime.Now > m_discoveryResponseDeadline)
						m_status = UPnPStatus.NotAvailable;
					return false;
			}
			return false;
		}

		/// <summary>
		/// Add a forwarding rule to the router using UPnP
		/// </summary>
		public bool ForwardPort(int port, string description)
		{
			if (!CheckAvailability())
				return false;

			IPAddress mask;
			var client = NetUtility.GetMyAddress(out mask);
			if (client == null)
				return false;

			return true;
		}

		/// <summary>
		/// Delete a forwarding rule from the router using UPnP
		/// </summary>
		public bool DeleteForwardingRule(int port)
		{
            return false;
		}

		/// <summary>
		/// Retrieve the extern ip using UPnP
		/// </summary>
		public IPAddress GetExternalIP()
		{
            return new IPAddress();
		}

		private object SOAPRequest(string url, string soap, string function)
		{
            return null;
		}
	}
}