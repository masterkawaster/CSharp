namespace NCrunch.Framework
{
	public class ExclusivelyUsesAttribute: ResourceUsageAttribute
	{
		public ExclusivelyUsesAttribute(params string[] resourceName) : base(resourceName) {}
        public ExclusivelyUsesAttribute(string resourceName) : base(resourceName) { }
    }
}
