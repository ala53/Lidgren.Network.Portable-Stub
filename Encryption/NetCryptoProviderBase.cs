using System;
using System.Security.Cryptography;
using System.IO;


namespace Lidgren.Network
{
	public abstract class NetCryptoProviderBase : NetEncryption
	{
		protected SymmetricAlgorithm m_algorithm;

		public NetCryptoProviderBase(NetPeer peer, SymmetricAlgorithm algo)
			: base(peer)
		{
		}

		public override void SetKey(byte[] data, int offset, int count)
		{
		}

		public override bool Encrypt(NetOutgoingMessage msg)
		{
			return true;
		}

		public override bool Decrypt(NetIncomingMessage msg)
		{
			return true;
		}
	}
}
