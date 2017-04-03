using System;
using System.IO;

namespace Org.BouncyCastle.Cms
{
	/**
	* a holding class for a byte array of data to be processed.
	*/
	[Obsolete("For internal use only. If you want to use iText, please use a dependency on iText 7. ")]
    public class CmsProcessableByteArray
		: CmsProcessable, CmsReadable
	{
		private readonly byte[] bytes;

		public CmsProcessableByteArray(
			byte[] bytes)
		{
			this.bytes = bytes;
		}

		public Stream GetInputStream()
		{
			return new MemoryStream(bytes, false);
		}

		public virtual void Write(Stream zOut)
		{
			zOut.Write(bytes, 0, bytes.Length);
		}

		/// <returns>A clone of the byte array</returns>
		public virtual object GetContent()
		{
			return bytes.Clone();
		}
	}
}
