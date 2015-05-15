namespace NCrunch.Framework
{
	public class InclusivelyUsesAttribute : ResourceUsageAttribute
	{
		public InclusivelyUsesAttribute(params string[] resourceNames): base(resourceNames) { }
        public InclusivelyUsesAttribute(string resourceName) : base(resourceName) { }
    }
}
