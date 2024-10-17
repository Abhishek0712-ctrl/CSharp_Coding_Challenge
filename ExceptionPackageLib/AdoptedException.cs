namespace ExceptionPackageLib
{

	[Serializable]
	public class AdoptedException : Exception
	{
		public AdoptedException() { }
		public AdoptedException(string message) : base(message) { }
		public AdoptedException(string message, Exception inner) : base(message, inner) { }
		protected AdoptedException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
