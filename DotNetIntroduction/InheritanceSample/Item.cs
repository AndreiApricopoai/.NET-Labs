namespace InheritanceSample
{
    public class Item : BaseEntity
    {
        public Item(string name, string description) : base(name, description)
        {
        }

        public override string GetInfo()
        {
            return $"Item: {Name} - Description: {Description}";
        }

        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
