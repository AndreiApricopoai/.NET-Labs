namespace InheritanceSample
{
    public abstract class BaseEntity
    {
        public string Name { get; }
        public string Description { get; }

        public BaseEntity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual string GetInfo()
        {
            return $"{Description} - {Name}";
        }

        public abstract void Use();
    }
}